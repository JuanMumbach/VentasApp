using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasApp.Repositories;
using VentasApp.Utilities;
using VentasApp.Views;
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
            this.view.LogoutButtonEvent += HandleLogout;
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

        /// <summary>
        /// Maneja el evento de cierre de sesión.
        /// </summary>
        private void HandleLogout(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Confirmar cierre de sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cerrar sesión
                SessionManager.Instance.Logout();

                // Cerrar el formulario principal
                if (view is Form form)
                {
                    form.Close();
                }

                // Mostrar nuevamente el login
                var loginView = new Views.Auth.LoginView();
                var loginPresenter = new LoginPresenter(loginView, new UserRepository());
                loginView.ShowView();

                // Si el usuario inició sesión nuevamente, abrir MainView
                if (loginPresenter.LoginSuccessful && SessionManager.Instance.IsAuthenticated)
                {
                    var newMainView = new MainView();
                    new MainViewPresenter(newMainView);
                    Application.Run(newMainView);
                }
            }
        }
    }
}
