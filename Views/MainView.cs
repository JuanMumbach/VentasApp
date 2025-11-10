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
        public event EventHandler BackupButtonEvent;
        public event EventHandler DashboardButtonEvent;

        public MainView()
        {
            InitializeComponent();
       SetupEventsHandler();
     ConfigureModernDesign();
     }

      protected override void CustomTheme()
        {
       // Sidebar
  SidePanel.BackColor = Themes.SidebarBackgroundColor;

       // Aplicar temas a botones del sidebar
            ApplySidebarButtonTheme(SellButton, "💳");
       ApplySidebarButtonTheme(ListSalesButton, "📊");
          ApplySidebarButtonTheme(ProductsButton, "📦");
            ApplySidebarButtonTheme(CustomersButton, "👥");
       ApplySidebarButtonTheme(SuppliersButton, "🏪");
          ApplySidebarButtonTheme(UsersViewButton, "👤");
   ApplySidebarButtonTheme(BackupButton, "🗄️");

       // Botón de logout con estilo especial
      LogoutButton.BackColor = Themes.WarningButtonBackground;
        LogoutButton.ForeColor = Themes.WarningButtonTextColor;
      LogoutButton.Text = "🚪  Cerrar Sesión";

 // Main panel
   MainPanel.BackColor = Themes.MainViewBackgroundColor;

          // Welcome label
    WelcomeLabel.ForeColor = Themes.HighlightTextColor;

    // Imágenes
            MainPanelLogoPicturebox.Image = Themes.LogoImage;
            SidePanelLogoPicturebox.Image = Themes.LogoImage;
        }

        private void ApplySidebarButtonTheme(Button button, string icon)
     {
      button.BackColor = Themes.SidebarButtonColor;
            button.ForeColor = Themes.SidebarButtonTextColor;
      button.FlatAppearance.BorderColor = Color.Transparent;
    button.FlatAppearance.BorderSize = 0;
      button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(15, 0, 0, 0);
   button.Cursor = Cursors.Hand;

       // Agregar icono al texto
    string originalText = button.Text;
 button.Text = $"{icon}  {originalText}";
        }

private void ConfigureModernDesign()
     {
    // Configurar formulario
   this.WindowState = FormWindowState.Maximized;
     this.MinimumSize = new Size(1024, 600);
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
    BackupButton.Click += delegate { BackupButtonEvent?.Invoke(this, EventArgs.Empty); };
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
       WelcomeLabel.Text = $"Bienvenido, {SessionManager.CurrentUsername}!");
  }

   public void SetMenuButtonVisibility(string buttonName, bool isVisible)
        {
      // Implementación simple
        }
    }
}
