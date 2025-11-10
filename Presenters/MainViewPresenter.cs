using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views;
using VentasApp.Views.Customer;
using VentasApp.Views.Dashboard;
using VentasApp.Views.Sale;
using VentasApp.Views.User;
using static VentasApp.Services.PermissionManager;

namespace VentasApp.Presenters
{
    public class MainViewPresenter
    {
        IMainView view;
        ILoginView loginView;
        bool logingOut;
        #if DEBUG
            bool NotHideMenuButtons = false;
        #endif

        public MainViewPresenter(IMainView mainView, ILoginView loginView)
        {
            view = mainView;
            this.loginView = loginView;
            
            logingOut = false;

            SetMenuButtonsVisibility();

            this.view.ProductsButtonEvent += LoadListProductsView;
            this.view.SalesButtonEvent += LoadSaleView;
            this.view.UsersButtonEvent += LoadUsersView;
            this.view.CustomersButtonEvent += LoadCustomersView;
            this.view.LogoutButtonEvent += Logout;
            this.view.MainViewClosedEvent += MainViewClosed;
            this.view.listSalesButtonEvent += LoadListSalesView;
            this.view.DashboardButtonEvent += LoadDashboardView;
        }

        private void LoadDashboardView(object? sender, EventArgs e)
        {
            /*
            CustomerListView customersView = new CustomerListView();
            new CustomersPresenter(customersView, new CustomerRepository());
            view.LoadMainPanelView(customersView);
             */

            DashboardView dashboardView = new DashboardView();
            new DashboardPresenter(dashboardView, new SaleRepository(), new UserRepository());
            view.LoadMainPanelView(dashboardView);
        }

        private void SetMenuButtonsVisibility()
        {
#if DEBUG
            if (NotHideMenuButtons)return;
#endif
            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesCreate) ||
                HasPermission((Roles)SessionManager.CurrentUserRoleId,Permissions.SalesManage))
            { view.SetMenuButtonVisibility("Sell", true); }
            else { view.SetMenuButtonVisibility("Sell", false); }

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesCreate) ||
                HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesManage) ||
                HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesViewAll))
            { view.SetMenuButtonVisibility("Sales", true); }
            else { view.SetMenuButtonVisibility("Sales", false); }

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.ProductsView) ||
                HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.ProductsManage))
            { view.SetMenuButtonVisibility("Products", true); }
            else { view.SetMenuButtonVisibility("Products", false); }
            
            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.CustomersManage) ||
                HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.CustomersView))
            { view.SetMenuButtonVisibility("Customers", true); }
            else { view.SetMenuButtonVisibility("Customers", false); }

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SuppliersManage) ||
                HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SuppliersView))
            { view.SetMenuButtonVisibility("Suppliers", true); }
            else { view.SetMenuButtonVisibility("Suppliers", false); }

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.UsersManage) ||
                HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.UsersView))
            { view.SetMenuButtonVisibility("Users", true); }
            else { view.SetMenuButtonVisibility("Users", false); }
        }

        private void MainViewClosed(object? sender, EventArgs e)
        {
            if (!logingOut)
            {
                loginView.Close();
            }
        }

        private void Logout(object? sender, EventArgs e)
        {
            logingOut = true;
            loginView.Show();
            view.Close();
        }

        private void LoadListSalesView(object? sender, EventArgs e)
        {
            ListSalesView saleHistoryView = new ListSalesView(); // Se asume que crearás SaleHistoryView
            new ListSalesPresenter(saleHistoryView, new SaleRepository()); // Se asume que crearás SaleHistoryPresenter
            view.LoadMainPanelView(saleHistoryView);
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
            new SalePresenter(saleView, new SaleRepository(), new SaleItemRepository(), new CustomerRepository());
            view.LoadMainPanelView(saleView);
        }
    }
}
