using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasApp.Presenters;
using VentasApp.Repositories;
using VentasApp.Views.Product;
using VentasApp.Utilities;

namespace VentasApp.Views
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler ProductsButtonEvent;
        public event EventHandler SalesButtonEvent;
        public event EventHandler UsersButtonEvent;
        public event EventHandler LogoutButtonEvent;

        public MainView()
        {
            InitializeComponent();
            SetupEventsHandler();
            LoadUserInfo();
        }

        /// <summary>
        /// Carga y muestra la información del usuario actual.
        /// </summary>
        private void LoadUserInfo()
        {
            if (SessionManager.Instance.IsAuthenticated)
            {
                var user = SessionManager.Instance.CurrentUser;
                UpdateUserInfo(user.Username, user.RoleName);
            }
        }

        /// <summary>
        /// Actualiza la información del usuario en la interfaz.
        /// </summary>
        public void UpdateUserInfo(string username, string role)
        {
            lblUserInfo.Text = $"Usuario: {username}\nRol: {role}";
        }

        private void LoadDefaultPanel()
        {
            ListProductsView productsView = new ListProductsView();
            new ListProductsPresenter(productsView, new ProductRepository());

            LoadMainPanelView(productsView);
        }

        private void SetupEventsHandler()
        {
            ProductsButton.Click += delegate { ProductsButtonEvent?.Invoke(this, EventArgs.Empty); };
            SellButton.Click += delegate { SalesButtonEvent?.Invoke(this, EventArgs.Empty); };
            UsersViewButton.Click += delegate { UsersButtonEvent?.Invoke(this, EventArgs.Empty); };
            LogoutButton.Click += delegate { LogoutButtonEvent?.Invoke(this, EventArgs.Empty); };
        }

        public void LoadMainPanelView(Form view)
        {
            MainPanel.Controls.Clear();
            view.TopLevel = false;
            view.FormBorderStyle = FormBorderStyle.None;
            view.Dock = DockStyle.Fill;

            MainPanel.Controls.Add(view);
            view.Show();
        }
    }
}
