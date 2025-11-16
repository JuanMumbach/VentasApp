using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views;
using VentasApp.Views.Customer;
using VentasApp.Views.Product;
using VentasApp.Views.Sale;
using static VentasApp.Services.PermissionManager;

namespace VentasApp.Presenters
{
    public class SalePresenter
    {
        private SaleModel sale;
        private ISaleView view;
        private ISaleRepository saleRepository;
        private ISaleItemRepository itemRepository;
        private ICustomerRepository customerRepository;
        private BindingSource saleItemsBindingSource;
        private IEnumerable<SaleItemModel> saleItemList;

        public SalePresenter(ISaleView saleView, ISaleRepository _saleRepository,ISaleItemRepository _itemRepository, ICustomerRepository _customerRepository, SaleModel? _sale = null)
        {
            this.view = saleView;
            this.saleRepository = _saleRepository;
            this.itemRepository = _itemRepository;
            this.customerRepository = _customerRepository;
            this.saleItemsBindingSource = new BindingSource();


            if (_sale == null)
            {              
                this.view.AddSaleItemViewEvent += OnAddSaleItemView;
                this.view.EditSaleItemViewEvent += OnEditSaleItemView;
                this.view.RemoveSaleItemEvent += OnRemoveSaleItem;
                this.view.FinishSaleEvent += OnFinishSale;
                this.view.CancelSaleEvent += OnCancelSale;
                this.view.CustomerSelectionChangedEvent += UpdateSaleCustomer;
                this.view.SearchCustomerEvent += (s, e) => OnSearchCustomer();


                this.sale = new SaleModel
                {
                    Customer = null,
                    SaleItems = new List<SaleItemModel>()
                };
            }
            else
            {
                this.sale = _sale;
                this.view.SetReadOnlyMode();
                this.view.SetCustomerName(_sale.Customer != null ? _sale.Customer.FullName : "No Registrado");
                this.view.CustomerId = _sale.CustomerId;
                this.view.CancelSaleEvent += CloseView;
                this.view.PrintReceiptEvent += (s, e) => PrintSaleReceipt(this.sale);
            }

            this.view.FormLoadEvent += CheckForPermissions;
            this.view.OnRecoverFocusEvent += OnRecoverFocus;
            this.view.CustomerSelectionChangedEvent += UpdateSaleCustomer;
            this.view.SetSaleItemsListBindingSource(saleItemsBindingSource);
            LoadAllSaleItems();
            LoadCustomers();
        }

        private void CheckForPermissions(object? sender, EventArgs e)
        {
            if (this.sale.Id < 1)
            {
                if (HasPermission(
                    (Roles)SessionManager.CurrentUserRoleId,
                    Permissions.SalesCreate)
                    )return;

                MessageBox.Show("No tienes permiso para realizar ventas.",
                                    "Acceso denegado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                CloseView(sender, e);
                return;
            }
            else
            {
                if (HasPermission(
                    (Roles)SessionManager.CurrentUserRoleId,
                    Permissions.SalesManage)
                    ) return;

                if (sale.UserId == SessionManager.CurrentUserId &&
                    HasPermission(
                    (Roles)SessionManager.CurrentUserRoleId,
                    Permissions.SalesCreate)
                    ) return;

                if (HasPermission(
                    (Roles)SessionManager.CurrentUserRoleId,
                    Permissions.SalesViewAll)
                    ) return;

                MessageBox.Show("No tienes permiso para acceder a esta venta",
                                    "Acceso denegado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                CloseView(sender, e);
                return;
            }
        }

       

        private void UpdateSaleCustomer(object? sender, EventArgs e)
        {
            /*
            if (view.SaleId != null)
            {
               SaleModel sale = saleRepository.GetSaleById((int)view.SaleId);
               if (sale != null)
               {
                   int? customerID = view.CustomerId;
                   if (customerID == -1) customerID = null;
                   sale.CustomerId = customerID;
                   sale.UpdatedAt = DateTime.Now;
                   saleRepository.UpdateSale(sale);
                }
            } 
            */
            int? customerID = view.CustomerId;
            if (customerID == -1) customerID = null;
            sale.CustomerId = customerID;
        }

        private void LoadCustomers()
        {
            view.Customers = customerRepository.GetAllCustomers();
        }

        private void OnRecoverFocus(object? sender, EventArgs e)
        {
            LoadAllSaleItems();
        }

        private void LoadAllSaleItems()
        {
            if (sale != null)
            {
                if (sale.SaleItems == null)
                {
                    sale.SaleItems = new List<SaleItemModel>();
                }
                saleItemList = sale.SaleItems;
            }
            else
            {
                saleItemList = new List<SaleItemModel>();
            }               
            

            var displayList = saleItemList.Select(item => new
            {
                Id = item.Id,
                IdProducto = item.ProductId,
                Producto = item.Product.Name,
                Cantidad = item.Amount,
                PrecioUnitario = item.Price,
                SubTotal = item.Amount * item.Price
            }).ToList();

            saleItemsBindingSource.DataSource = displayList;      
        }

        private void OnCancelSale(object? sender, EventArgs e)
        {
            
            sale = new SaleModel()
            {
                CustomerId = null,
                SaleItems = new List<SaleItemModel>(),
            };

            LoadAllSaleItems();
            LoadCustomers();
        }

        private void OnFinishSale(object? sender, EventArgs e)
        {
            if (sale == null || sale.SaleItems.Count == 0)
            {
                MessageBox.Show("No se han agregado articulos a la venta",
                                    "Venta vacía",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            sale.CreatedAt = DateTime.Now;
            sale.UpdatedAt = DateTime.Now;
            sale.DeliveryState = "pendiente";
            sale.UserId = SessionManager.CurrentUserId;
            int newSaleId = saleRepository.AddSale(sale);

            SaleModel newSale = saleRepository.GetSaleById(newSaleId);
            if (newSale == null)
            {
                MessageBox.Show("Error al guardar la venta.",
                                    "Error de venta",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Venta agregada con éxito.",
                                        "Venta exitosa",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                PrintSaleReceipt(newSale);
            }
            
            sale = new SaleModel()
            {
                CustomerId = null,
                SaleItems = new List<SaleItemModel>(),
            };
            
            
            LoadAllSaleItems();
            LoadCustomers();
        }

        private void CloseView(object? sender, EventArgs e)
        {
            if (view is Form form)
            {
                form.Close();
            }
        }
        private void OnRemoveSaleItem(object? sender, EventArgs e)
        {
            /*
            int? id = view.GetSelectedItemId();
            if (id != null)
            {
                ISaleItemView saleItemView = new SaleItemView((int)view.SaleId, (int)id);
                new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository());
                saleItemView.ShowDialogView();
                LoadAllSaleItems();
            }
            */
            int index = view.GetSelectedRowIndex();
            SaleItemModel item = sale.SaleItems.ElementAt(index);

            if (item != null)
            {
                sale.SaleItems.Remove(item);
                LoadAllSaleItems();
            }
        }

        private void OnEditSaleItemView(object? sender, EventArgs e)
        {
            int index = view.GetSelectedRowIndex();
            SaleItemModel item = sale.SaleItems.ElementAt(index);

            if (item != null)
            {
                ISaleItemView saleItemView = new SaleItemView();
                SaleItemPresenter presenter = new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository(), item);
                saleItemView.ShowDialogView();
                LoadAllSaleItems();
            }
        }

        private void OnAddSaleItemView(object? sender, EventArgs e)
        {
            /*
            if (view.SaleId != null)
            {
                ISaleItemView saleItemView = new SaleItemView((int)view.SaleId);
                new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository());
                saleItemView.ShowDialogView();
                LoadAllSaleItems();
            }
            else
            {
                int? customerID = view.CustomerId;
                if (customerID == -1) customerID = null;

                SaleModel newSale = new SaleModel()
                {
                    CustomerId = customerID,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                int newId = saleRepository.AddSale(newSale);
                view.SaleId = newId;

                ISaleItemView saleItemView = new SaleItemView((int)view.SaleId);
                new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository());
                saleItemView.ShowDialogView();
                LoadAllSaleItems();
            }
            */
            ISaleItemView saleItemView = new SaleItemView();
            new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository(),this.sale);
            saleItemView.ShowDialogView();
            LoadAllSaleItems();
        }

        private void OnSearchCustomer()
        {
            ICustomerListView view = new CustomerListView();
            CustomerSelectionPresenter presenter = new CustomerSelectionPresenter(view, new CustomerRepository());
            presenter.ConfirmSelectionEvent += (s, e) =>
            {
                int customerId = (int)s;
                if (customerId != null && customerId > 0)
                {
                    this.view.CustomerId = customerId;
                    UpdateSaleCustomer(this, EventArgs.Empty);
                }
                
            };

            view.ShowDialogView();
        }

        void PrintSaleReceipt(SaleModel saleToPrint)
        { 
            if (saleToPrint != null)
            {
                PrinterManager printerManager = new PrinterManager();
                printerManager.PrintSaleReceipt(saleToPrint);
                
            } 
        }
    }
}
