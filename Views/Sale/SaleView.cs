using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasApp.Views.Sale
{
    public interface ISaleView
    {
        int? SaleId { get; set; }
        event EventHandler AddSaleItemViewEvent;
        event EventHandler EditSaleItemViewEvent;
        event EventHandler RemoveSaleItemEvent;
        event EventHandler FinishSaleEvent;
        event EventHandler CancelSaleEvent;
        event EventHandler OnRecoverFocusEvent;

        void SetSaleItemsListBindingSource(BindingSource source);
        int? GetSelectedItemId();

    }
    public partial class SaleView : Form, ISaleView
    {
        public int? SaleId { get; set; }

        public event EventHandler AddSaleItemViewEvent;
        public event EventHandler EditSaleItemViewEvent;
        public event EventHandler RemoveSaleItemEvent;
        public event EventHandler FinishSaleEvent;
        public event EventHandler CancelSaleEvent;
        public event EventHandler OnRecoverFocusEvent;

        public SaleView()
        {
            InitializeComponent();
            SetupEventHandler();
        }

        private void SetupEventHandler()
        {
            AddSaleItemButton.Click += delegate { AddSaleItemViewEvent?.Invoke(this, EventArgs.Empty); };
            EditSaleItemButton.Click += delegate { EditSaleItemViewEvent?.Invoke(this, EventArgs.Empty); };
            RemoveItemButton.Click += delegate { RemoveSaleItemEvent?.Invoke(this, EventArgs.Empty); };
            ConfirmSaleButton.Click += delegate { FinishSaleEvent?.Invoke(this, EventArgs.Empty); };
            CancelButton.Click += delegate { CancelSaleEvent?.Invoke(this, EventArgs.Empty); };
            SaleItemsDatagridview.Click += delegate { OnRecoverFocusEvent?.Invoke(this, EventArgs.Empty); };
        }

        public void SetSaleItemsListBindingSource(BindingSource source)
        {
            SaleItemsDatagridview.DataSource = source;
        }

        public int? GetSelectedItemId()
        {
            if (SaleItemsDatagridview.CurrentRow != null)
            {
                // Assuming the first column is the Product's ID
                return (int)SaleItemsDatagridview.CurrentRow.Cells["Id"].Value;
            }
            return null;
        }
    }
}
