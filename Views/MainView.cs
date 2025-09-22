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

namespace VentasApp.Views
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler ProductsButtonEvent;
        public event EventHandler SalesButtonEvent;

        public MainView()
        {
            InitializeComponent();
            //LoadDefaultPanel();
            SetupEventsHandler();
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
