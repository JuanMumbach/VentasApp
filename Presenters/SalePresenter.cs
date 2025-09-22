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
        private BindingSource saleItemsBindingSource;
        private IEnumerable<SaleItemModel> saleItemList;

        public SalePresenter(ISaleView saleView, ISaleRepository _saleRepository,ISaleItemRepository _itemRepository)
        {
            this.view = saleView;
            this.saleRepository = _saleRepository;
            this.itemRepository = _itemRepository;
            this.saleItemsBindingSource = new BindingSource();

            this.view.AddSaleItemViewEvent += OnAddSaleItemView;
            this.view.EditSaleItemViewEvent += OnEditSaleItemView;
            this.view.RemoveSaleItemEvent += OnRemoveSaleItem;
            this.view.FinishSaleEvent += OnFinishSale;
            this.view.CancelSaleEvent += OnCancelSale;
            this.view.OnRecoverFocusEvent += OnRecoverFocus;
            this.view.SetSaleItemsListBindingSource(saleItemsBindingSource);
            LoadAllSaleItems();
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
        }

        private void OnFinishSale(object? sender, EventArgs e)
        {
            view.SaleId = null;
            LoadAllSaleItems();
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
            }
        }

        private void OnAddSaleItemView(object? sender, EventArgs e)
        {
            if (view.SaleId != null)
            {
                ISaleItemView saleItemView = new SaleItemView((int)view.SaleId);
                new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository());
                saleItemView.ShowDialogView();
            }
            else
            {
                SaleModel newSale = new SaleModel()
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                int newId = saleRepository.AddSale(newSale);
                view.SaleId = newId;

                ISaleItemView saleItemView = new SaleItemView((int)view.SaleId);
                new SaleItemPresenter(saleItemView, itemRepository, new ProductRepository());
                saleItemView.ShowDialogView();
            }
            /*
            IProductView addProductView = new ProductView();
            new ProductPresenter(addProductView, repository);

            addProductView.ShowDialogView();
            */
        }
    }
}
