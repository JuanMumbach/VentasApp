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
using VentasApp.Services;
using VentasApp.Views.Product;

namespace VentasApp.Views
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler ProductsButtonEvent;
        public event EventHandler SalesButtonEvent;
        public event EventHandler UsersButtonEvent;
        public event EventHandler CustomersButtonEvent;
        public event EventHandler LogoutButtonEvent;
        public event EventHandler MainViewClosedEvent;

        public MainView()
        {
            InitializeComponent();
            //LoadDefaultPanel();
            SetupEventsHandler();
            LoadColorTheme();
        }

        private void LoadColorTheme()
        {
            SidePanelLogoPicturebox.Image = Themes.LogoImage;
            MainPanelLogoPicturebox.Image = Themes.LogoImage;
            SidePanel.BackColor = Themes.ColorBack;
            MainPanel.BackColor = Themes.ColorBack2;
            WelcomeLabel.ForeColor = Themes.ColorPrimary;

            SellButton.BackColor = Themes.ColorBack2;
            SellButton.ForeColor = Themes.ColorHighlight;
            SellButton.FlatAppearance.BorderColor = Themes.ColorBack2Highlighted;
            SellButton.FlatAppearance.MouseOverBackColor = Themes.ColorBack2Highlighted;

            Button[] buttons = { ProductsButton, UsersViewButton, CustomersButton, LogoutButton };
            foreach (Button button in buttons)
            {
                button.BackColor = Themes.ColorBack2;
                button.ForeColor = Themes.ColorPrimary;
                button.FlatAppearance.BorderColor = Themes.ColorBack2Highlighted;
                button.FlatAppearance.MouseOverBackColor = Themes.ColorBack2Highlighted;

            }
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
            CustomersButton.Click += delegate { CustomersButtonEvent?.Invoke(this, EventArgs.Empty); };
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

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainViewClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            WelcomeLabel.Text = $"Bienvenido, {SessionManager.CurrentUsername}!";
        }
    }
}
