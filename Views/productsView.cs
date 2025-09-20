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
    public partial class productsView : Form, IproductsView
    {
        public event EventHandler SearchProductEvent;

        public productsView()
        {
            InitializeComponent();

            SetupEventsHandler();
        }

        public string searchValue
        {
            get { return SearchTextbox.Text; }
            set { SearchTextbox.Text = value; }
        }

        public void SetProductosListBindingSource(BindingSource source)
        {
            dataGridView1.DataSource = source;
        }

        private void SetupEventsHandler()
        {
            //SearchButton.Click += delegate { SearchProductEvent?.Invoke(this, EventArgs.Empty); };
            SearchTextbox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchProductEvent?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
