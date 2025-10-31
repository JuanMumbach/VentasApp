using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.Product;
using VentasApp.Views.Sale;

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
                this.view.CancelSaleEvent += CloseView;
            }

            this.view.OnRecoverFocusEvent += OnRecoverFocus;
            this.view.CustomerSelectionChangedEvent += UpdateSaleCustomer;
            this.view.SetSaleItemsListBindingSource(saleItemsBindingSource);
            LoadAllSaleItems();
            LoadCustomers();
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
            saleRepository.AddSale(sale);
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
            int? id = view.GetSelectedItemId();
            SaleItemModel item = sale.SaleItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                sale.SaleItems.Remove(item);
                LoadAllSaleItems();
            }
        }

        private void OnEditSaleItemView(object? sender, EventArgs e)
        {
            /*
            int? id = view.GetSelectedItemId();
            if (id != null)
            {
                ISaleItemView saleItemView = new SaleItemView((int)view.SaleId,(int)id);
                SaleItemPresenter presenter = new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository());
                saleItemView.ShowDialogView();
                LoadAllSaleItems();
            }
            */
            int? id = view.GetSelectedItemId();
            SaleItemModel item = sale.SaleItems.FirstOrDefault(i => i.ProductId == id);

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
    }
}
