using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views;
using VentasApp.Views.Customer;
using VentasApp.Views.Sale;
using VentasApp.Views.User;

namespace VentasApp.Presenters
{
    public class MainViewPresenter
    {
        private readonly IMainView view;
        private readonly ILoginView loginView;
        private readonly ILogger logger;
        private bool logingOut;

        public MainViewPresenter(IMainView mainView, ILoginView loginView, ILogger? logger = null)
        {
            view = mainView ?? throw new ArgumentNullException(nameof(mainView));
            this.loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            this.logger = logger ?? new FileLogger();
            
            logingOut = false;

            this.view.ProductsButtonEvent += LoadListProductsView;
            this.view.SalesButtonEvent += LoadSaleView;
            this.view.UsersButtonEvent += LoadUsersView;
            this.view.CustomersButtonEvent += LoadCustomersView;
            this.view.LogoutButtonEvent += Logout;
            this.view.MainViewClosedEvent += MainViewClosed;
            this.view.listSalesButtonEvent += LoadListSalesView;

            logger.LogInformation($"MainView initialized for user: {SessionManager.CurrentUsername}");
        }

        private void MainViewClosed(object? sender, EventArgs e)
        {
            if (!logingOut)
            {
                logger.LogInformation("Application closed by user");
                SessionManager.EndSession();
                loginView.Close();
            }
        }

        private void Logout(object? sender, EventArgs e)
        {
            try
            {
                logger.LogInformation($"User logging out: {SessionManager.CurrentUsername}");
                logingOut = true;
                SessionManager.EndSession();
                loginView.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                logger.LogError("Error during logout", ex);
                MessageBox.Show("Ocurrió un error al cerrar sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadListSalesView(object? sender, EventArgs e)
        {
            try
            {
                logger.LogDebug("Loading sales list view");
                ListSalesView saleHistoryView = new ListSalesView();
                new ListSalesPresenter(saleHistoryView, new SaleRepository());
                view.LoadMainPanelView(saleHistoryView);
            }
            catch (Exception ex)
            {
                logger.LogError("Error loading sales list view", ex);
                MessageBox.Show("Error al cargar la vista de ventas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomersView(object? sender, EventArgs e)
        {
            try
            {
                logger.LogDebug("Loading customers view");
                CustomerListView customersView = new CustomerListView();
                new CustomersPresenter(customersView, new CustomerRepository());
                view.LoadMainPanelView(customersView);
            }
            catch (Exception ex)
            {
                logger.LogError("Error loading customers view", ex);
                MessageBox.Show("Error al cargar la vista de clientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsersView(object? sender, EventArgs e)
        {
            try
            {
                // Check if user has permission to view users (only admin)
                if (!SessionManager.IsAdmin)
                {
                    logger.LogWarning($"Unauthorized access attempt to users view by: {SessionManager.CurrentUsername}");
                    MessageBox.Show("No tiene permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                logger.LogDebug("Loading users view");
                ListUsersView usersView = new ListUsersView();
                new ListUsersPresenter(usersView, new UserRepository());
                view.LoadMainPanelView(usersView);
            }
            catch (Exception ex)
            {
                logger.LogError("Error loading users view", ex);
                MessageBox.Show("Error al cargar la vista de usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadListProductsView(object? sender, EventArgs e)
        {
            try
            {
                logger.LogDebug("Loading products list view");
                ListProductsView listProductsView = new ListProductsView();
                new ListProductsPresenter(listProductsView, new ProductRepository());
                view.LoadMainPanelView(listProductsView);
            }
            catch (Exception ex)
            {
                logger.LogError("Error loading products list view", ex);
                MessageBox.Show("Error al cargar la vista de productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSaleView(object? sender, EventArgs e)
        {
            try
            {
                logger.LogDebug("Loading sale view");
                SaleView saleView = new SaleView();
                new SalePresenter(saleView, new SaleRepository(), new SaleItemRepository(), new CustomerRepository());
                view.LoadMainPanelView(saleView);
            }
            catch (Exception ex)
            {
                logger.LogError("Error loading sale view", ex);
                MessageBox.Show("Error al cargar la vista de ventas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
