using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasApp.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace VentasApp.Views.Sale
{
    // Se asume que BaseForm existe
    public partial class ListSalesView : BaseForm, IListSalesView
    {
        public event EventHandler LoadAllSalesEvent;
        public event EventHandler RestoreSaleEvent;
        public event EventHandler CancelSaleEvent;

        public ListSalesView()
        {
            InitializeComponent();
            SetupEventHandlers();

            // Llama a cargar las ventas al iniciar la vista
            this.Load += delegate { LoadAllSalesEvent?.Invoke(this, EventArgs.Empty); };
        }

        private void SetupEventHandlers()
        {
            RestoreButton.Click += delegate { RestoreSaleEvent?.Invoke(this, EventArgs.Empty); };
            CancelSaleButton.Click += delegate { CancelSaleEvent?.Invoke(this, EventArgs.Empty); };
        }

        public BindingSource SaleListBindingSource
        {
            set
            {
                SalesDataGridView.DataSource = value;
                // Configuración opcional de columnas aquí
            }
        }

        public int? GetSelectedSaleId()
        {
            if (SalesDataGridView.CurrentRow != null)
            {
                // Asumiendo que la columna de ID se llama "Id"
                return (int)SalesDataGridView.CurrentRow.Cells["Id"].Value;
            }
            return null;
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        protected override void CustomTheme()
        {
            // Puedes aplicar tu tema aquí si es necesario
        }
    }
}