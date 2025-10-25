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
    public partial class MainView : BaseForm, IMainView
    {
        public event EventHandler ProductsButtonEvent;
        public event EventHandler SalesButtonEvent;
        public event EventHandler UsersButtonEvent;
        public event EventHandler CustomersButtonEvent;
        public event EventHandler SuppliersButtonEvent;
        public event EventHandler LogoutButtonEvent;
        public event EventHandler MainViewClosedEvent;

        public MainView()
        {
            InitializeComponent();
            //LoadDefaultPanel();
            SetupEventsHandler();

            
        }

        protected override void CustomTheme()
        {
            SidePanel.BackColor = Themes.SidebarBackgroundColor;
            //SideLayoutPanel.BackColor = Color.Transparent;
            //panel2.BackColor = Color.Transparent;

            Color ButtonMouseOverColor = Color.FromArgb(
                        Math.Clamp(Themes.SidebarButtonColor.R + Themes.MouseOverBrightness, 0, 255),
                        Math.Clamp(Themes.SidebarButtonColor.G + Themes.MouseOverBrightness, 0, 255),
                        Math.Clamp(Themes.SidebarButtonColor.B + Themes.MouseOverBrightness, 0, 255)
                    );

            Color ButtonMouseDownColor = Color.FromArgb(
                        Math.Clamp(Themes.SidebarButtonColor.R + Themes.MouseDownBrightness, 0, 255),
                        Math.Clamp(Themes.SidebarButtonColor.G + Themes.MouseDownBrightness, 0, 255),
                        Math.Clamp(Themes.SidebarButtonColor.B + Themes.MouseDownBrightness, 0, 255)
                    );

            foreach (Control control in SidePanel.Controls)
            {
                if (control is Button button)
                {                
                    button.BackColor = Themes.SidebarButtonColor;
                    button.ForeColor = Themes.SidebarButtonTextColor;
                    button.FlatAppearance.BorderColor = Themes.SidebarButtonColor;
                    button.FlatAppearance.MouseOverBackColor = ButtonMouseOverColor;
                    button.FlatAppearance.MouseDownBackColor = ButtonMouseDownColor;
                }
            }

            MainPanelLogoPicturebox.Image = Themes.LogoImage;
            SidePanelLogoPicturebox.Image = Themes.LogoImage;
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
            SuppliersButton.Click += delegate { LoadSuppliersView(); };
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

        private void LoadSuppliersView()
        {
            ListSuppliersView suppliersView = new ListSuppliersView();
            new ListSuppliersPresenter(suppliersView, new SupplierRepository());

            LoadMainPanelView(suppliersView);
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
