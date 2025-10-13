using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.Customer;
using VentasApp.Views.Sale;
using VentasApp.Views.User;

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
            this.view.UsersButtonEvent += LoadUsersView;
            this.view.CustomersButtonEvent += LoadCustomersView;
        }

        private void LoadCustomersView(object? sender, EventArgs e)
        {
            CustomerListView customersView = new CustomerListView();
            new CustomersPresenter(customersView, new CustomerRepository());
            view.LoadMainPanelView(customersView);
        }
        private void LoadUsersView(object? sender, EventArgs e)
        {
            ListUsersView usersView = new ListUsersView();
            new ListUsersPresenter(usersView, new UserRepository());
            view.LoadMainPanelView(usersView);
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
