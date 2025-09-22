using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.Sale;

namespace VentasApp.Presenters
{
    public class MainViewPresenter
    {
        IMainView view;

        public MainViewPresenter(IMainView mainView)
        {
            view = mainView;

            this.view.ProductsButtonEvent += LoadListProductsView;
            this.view.SalesButtonEvent += LoadSaleView;
        }

        private void LoadListProductsView(object? sender, EventArgs e)
        {
            ListProductsView listProductsView = new ListProductsView();
            new ListProductsPresenter(listProductsView, new ProductRepository());
            view.LoadMainPanelView(listProductsView);
        }

        private void LoadSaleView(object? sender, EventArgs e)
        {
            SaleView saleView = new SaleView();
            new SalePresenter(saleView, new SaleRepository(), new SaleItemRepository());
            view.LoadMainPanelView(saleView);
        }
    }
}
