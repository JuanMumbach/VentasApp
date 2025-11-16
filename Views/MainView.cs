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
        public event EventHandler listSalesButtonEvent;
        public event EventHandler DashboardButtonEvent;
        public event EventHandler SystemSettingsButtonEvent;
        static bool HideDisabledMenuButtons = false;

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


                    /* Cambia el color si el boton esta desactivado */
                    if (!button.Enabled)
                    {
                        Color newBackColor = button.BackColor;
                        Color newForeColor = button.ForeColor;

                        newBackColor = Color.FromArgb(
                            Math.Clamp(newBackColor.R - 60, 0, 255),
                            Math.Clamp(newBackColor.G - 60, 0, 255),
                            Math.Clamp(newBackColor.B - 60, 0, 255)
                        );

                        newForeColor = Color.FromArgb(
                            Math.Clamp(newForeColor.R - 60, 0, 255),
                            Math.Clamp(newForeColor.G - 60, 0, 255),
                            Math.Clamp(newForeColor.B - 60, 0, 255)
                        );

                        button.BackColor = newBackColor;
                        button.ForeColor = newForeColor;
                    }
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
            ListSalesButton.Click += delegate { listSalesButtonEvent?.Invoke(this, EventArgs.Empty); };
            DashboardButton.Click += delegate { DashboardButtonEvent?.Invoke(this, EventArgs.Empty); };
            SystemSettingsViewButton.Click += delegate { SystemSettingsButtonEvent?.Invoke(this, EventArgs.Empty); };
        }

        public void SetMenuButtonVisibility(string buttonName, bool isVisible)
        {
            switch (buttonName)
            {
                case "Dashboard":
                    if (HideDisabledMenuButtons) DashboardButton.Visible = isVisible;
                    DashboardButton.Enabled = isVisible;
                    break;
                case "Products":
                    if (HideDisabledMenuButtons) ProductsButton.Visible = isVisible;
                    ProductsButton.Enabled = isVisible;
                    break;
                case "Sell":
                    if (HideDisabledMenuButtons) SellButton.Visible = isVisible;
                    SellButton.Enabled = isVisible;
                    break;
                case "Users":
                    if (HideDisabledMenuButtons) UsersViewButton.Visible = isVisible;
                    UsersViewButton.Enabled = isVisible;
                    break;
                case "Customers":
                    if (HideDisabledMenuButtons) CustomersButton.Visible = isVisible;
                    CustomersButton.Enabled = isVisible;
                    break;
                case "Suppliers":
                    if (HideDisabledMenuButtons) SuppliersButton.Visible = isVisible;
                    SuppliersButton.Enabled = isVisible;
                    break;
                case "Sales":
                    if (HideDisabledMenuButtons) ListSalesButton.Visible = isVisible;
                    ListSalesButton.Enabled = isVisible;
                    break;
                case "SystemSettings":
                    if (HideDisabledMenuButtons) SystemSettingsViewButton.Visible = isVisible;
                    SystemSettingsViewButton.Enabled = isVisible;
                    break;
                default:
                    throw new ArgumentException($"Button with name {buttonName} does not exist.");
            }
        }

        public void LoadMainPanelView(Form view)
        {
            if (view == null) return; 

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
