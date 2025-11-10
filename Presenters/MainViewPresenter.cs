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
using VentasApp.Views.Dashboard;
using VentasApp.Views.Product;
using VentasApp.Views.Sale;
using VentasApp.Views.User;
using VentasApp.Views.Backup; // ✨ AGREGAR
using static VentasApp.Services.PermissionManager;

namespace VentasApp.Presenters
{
    public class MainViewPresenter
    {
        private IMainView view;
        private ILoginView loginView;
        private UserModel currentUser;
        private ILogger logger; // ✨ AGREGAR
        bool logingOut;
        #if DEBUG
            bool NotHideMenuButtons = false;
        #endif

        public MainViewPresenter(IMainView mainView, ILoginView loginView)
        {
            view = mainView;
            this.loginView = loginView;
            this.logger = new FileLogger(); // ✨ AGREGAR

            logingOut = false;

            SetMenuButtonsVisibility();

            this.view.ProductsButtonEvent += LoadProductsView;
            this.view.SalesButtonEvent += LoadSaleView;
            this.view.UsersButtonEvent += LoadUsersView;
            this.view.CustomersButtonEvent += LoadCustomersView;
            this.view.LogoutButtonEvent += Logout;
            this.view.MainViewClosedEvent += Logout;
            this.view.listSalesButtonEvent += LoadListSalesView;
            this.view.BackupButtonEvent += LoadBackupView; // ✨ AGREGAR

            view.Show();
        }

        private void LoadProductsView(object? sender, EventArgs e)
        {
            ListProductsView productsView = new ListProductsView();
            new ListProductsPresenter(productsView, new ProductRepository());

            view.LoadMainPanelView(productsView);
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

        private void LoadSaleView(object? sender, EventArgs e)
        {
            SaleView saleView = new SaleView();
            new SalePresenter(saleView, new SaleRepository(), new SaleItemRepository(), new CustomerRepository());
            view.LoadMainPanelView(saleView);
        }

        private void LoadUsersView(object? sender, EventArgs e)
        {
            ListUsersView usersView = new ListUsersView();
            new ListUsersPresenter(usersView, new UserRepository());
            view.LoadMainPanelView(usersView);
        }

        private void LoadCustomersView(object? sender, EventArgs e)
        {
            CustomerListView customersView = new CustomerListView();
            new CustomersPresenter(customersView, new CustomerRepository());
            view.LoadMainPanelView(customersView);
        }

        private void LoadListSalesView(object? sender, EventArgs e)
        {
            ListSalesView saleView = new ListSalesView();
            new ListSalesPresenter(saleView, new SaleRepository());
            view.LoadMainPanelView(saleView);
        }

        // ✨ AGREGAR - Método para cargar vista de Backup
        private void LoadBackupView(object? sender, EventArgs e)
        {
            try
            {
                BackupView backupView = new BackupView();
                IBackupService backupService = new MySqlBackupService(logger);

                new BackupPresenter(backupView, backupService, logger);

                view.LoadMainPanelView(backupView);

                logger.LogInformation("Vista de Backup cargada exitosamente");
            }
            catch (Exception ex)
            {
                logger.LogError("Error al cargar vista de Backup", ex);
                MessageBox.Show(
                    $"Error al cargar el módulo de Backups:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SetMenuButtonsVisibility()
        {
#if DEBUG
            if (NotHideMenuButtons)return;
#endif
            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesManage) ||
                HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesViewAll))
            { view.SetMenuButtonVisibility("Dashboard", true); }
            else { view.SetMenuButtonVisibility("Dashboard", false); }

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

        private void Logout(object? sender, EventArgs e)
        {
            logingOut = true;
            SessionManager.ClearSession();
            view.Close();
            loginView.Show();
        }
    }
}
