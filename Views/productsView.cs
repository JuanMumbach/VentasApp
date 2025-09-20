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
        public productsView()
        {
            InitializeComponent();

            SetupEventsHandler();
        }

        public event EventHandler BuscarProductoEvent;

        public void SetProductosListBindingSource(BindingSource source)
        {
            dataGridView1.DataSource = source;
        }

        private void SetupEventsHandler()
        {
            
        }
    }
}
