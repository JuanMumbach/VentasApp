using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasApp.Views
{
<<<<<<< Updated upstream
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
=======
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

      // Crear efecto de borde derecho en sidebar
            SidePanel.Paint += (s, e) =>
            {
   using (Pen pen = new Pen(Themes.DividerColor, 1))
         {
       e.Graphics.DrawLine(pen, SidePanel.Width - 1, 0, SidePanel.Width - 1, SidePanel.Height);
        }
            };

      // Aplicar temas a botones del sidebar
            ApplySidebarButtonTheme(SellButton, "💳");
  ApplySidebarButtonTheme(ListSalesButton, "📊");
  ApplySidebarButtonTheme(ProductsButton, "📦");
      ApplySidebarButtonTheme(CustomersButton, "👥");
            ApplySidebarButtonTheme(SuppliersButton, "🏪");
            ApplySidebarButtonTheme(UsersViewButton, "👤");
   
    // Botón de logout con estilo especial
 LogoutButton.BackColor = Themes.WarningButtonBackground;
  LogoutButton.ForeColor = Themes.WarningButtonTextColor;
            LogoutButton.FlatAppearance.MouseOverBackColor = Themes.WarningButtonHoverColor;
            LogoutButton.Text = "🚪  Cerrar Sesión";
       LogoutButton.Font = new Font(Themes.NormalFont.FontFamily, 10F, FontStyle.Bold);

// Main panel
 MainPanel.BackColor = Themes.MainViewBackgroundColor;
 
            // Welcome label
            WelcomeLabel.Font = Themes.HeaderFont;
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
            button.FlatAppearance.MouseOverBackColor = Themes.SidebarButtonHoverColor;
            button.Font = new Font(Themes.NormalFont.FontFamily, 11F, FontStyle.Regular);
        button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(15, 0, 0, 0);
       button.Cursor = Cursors.Hand;
            
         // Agregar icono al texto
       string originalText = button.Text;
        button.Text = $"{icon}  {originalText}";
        
     // Efecto hover mejorado
            button.MouseEnter += (s, e) =>
   {
button.BackColor = Themes.SidebarButtonHoverColor;
           button.Font = new Font(button.Font.FontFamily, button.Font.Size, FontStyle.Bold);
            };
            
    button.MouseLeave += (s, e) =>
            {
  button.BackColor = Themes.SidebarButtonColor;
                button.Font = new Font(button.Font.FontFamily, button.Font.Size, FontStyle.Regular);
            };
        }

        private void ConfigureModernDesign()
        {
          // Configurar formulario
 this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1024, 600);
      
 // Agregar borde al panel principal
            MainPanel.Paint += (s, e) =>
        {
          using (Pen pen = new Pen(Themes.BorderColor, 1))
     {
        e.Graphics.DrawRectangle(pen, 0, 0, MainPanel.Width - 1, MainPanel.Height - 1);
  }
      };
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
>>>>>>> Stashed changes
        }
    }
}
