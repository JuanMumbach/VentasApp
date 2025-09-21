using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views;

namespace VentasApp.Presenters
{
    public class MainViewPresenter
    {
        IMainView view;

        public MainViewPresenter(IMainView mainView)
        {
            view = mainView;

            this.view.ProductsButtonEvent += LoadListProductsView;
        }

        private void LoadListProductsView(object? sender, EventArgs e)
        {
            ListProductsView listProductsView = new ListProductsView();
            new ListProductsPresenter(listProductsView, new ProductRepository());
            view.LoadMainPanelView(listProductsView);
        }
    }
}
