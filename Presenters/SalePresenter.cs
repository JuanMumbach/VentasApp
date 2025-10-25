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
        private ISaleView view;
        private ISaleRepository saleRepository;
        private ISaleItemRepository itemRepository;
        private ICustomerRepository customerRepository;
        private BindingSource saleItemsBindingSource;
        private IEnumerable<SaleItemModel> saleItemList;

        public SalePresenter(ISaleView saleView, ISaleRepository _saleRepository,ISaleItemRepository _itemRepository, ICustomerRepository _customerRepository, bool isReadOnly = false)
        {
            this.view = saleView;
            this.saleRepository = _saleRepository;
            this.itemRepository = _itemRepository;
            this.customerRepository = _customerRepository;
            this.saleItemsBindingSource = new BindingSource();

            if (!isReadOnly)
            {
                this.view.AddSaleItemViewEvent += OnAddSaleItemView;
                this.view.EditSaleItemViewEvent += OnEditSaleItemView;
                this.view.RemoveSaleItemEvent += OnRemoveSaleItem;
                this.view.FinishSaleEvent += OnFinishSale;
                this.view.CancelSaleEvent += OnCancelSale;
                this.view.CustomerSelectionChangedEvent += UpdateSaleCustomer;
            }
            else
            {
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
            if (view.SaleId != null)
            {
                saleItemList = itemRepository.GetAllItemsOfSale((int)view.SaleId);
            }
            else
            {
                saleItemList = new List<SaleItemModel>();
            }
            
            saleItemsBindingSource.DataSource = saleItemList; 
        
        }

        private void OnCancelSale(object? sender, EventArgs e)
        {
            if (view.SaleId != null)
            {
                saleRepository.CancelSale((int)view.SaleId);
                view.SaleId = null;
            }
            LoadAllSaleItems();
            LoadCustomers();
        }

        private void OnFinishSale(object? sender, EventArgs e)
        {
            if (view.SaleId == null)
            {
                MessageBox.Show("No se han agregado articulos a la venta",
                                    "Venta vacía",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                return;
            }

            IEnumerable<SaleItemModel> items = itemRepository.GetAllItemsOfSale((int)view.SaleId);

            if (items.Count() == 0)
            {
                MessageBox.Show("No se han agregado articulos a la venta",
                                    "Venta vacía",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                return;
            }
            view.SaleId = null;
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
            throw new NotImplementedException();
        }

        private void OnEditSaleItemView(object? sender, EventArgs e)
        {
            int? id = view.GetSelectedItemId();
            if (id != null)
            {
                ISaleItemView saleItemView = new SaleItemView((int)view.SaleId,(int)id);
                new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository());
                saleItemView.ShowDialogView();
                LoadAllSaleItems();
            }
        }

        private void OnAddSaleItemView(object? sender, EventArgs e)
        {
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
        }
    }
}
