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

namespace VentasApp.Views.Sale
{
    public interface ISaleItemView
    {
        event EventHandler AddItemEvent;
        event EventHandler CancelEvent;
        int? SaleItemId { get; set; }
        int SaleId { get; set; }
        int Amount { get; set; }
        void ShowDialogView();
        void CloseView();
        int? GetSelectedProductId();
        void SetSelectedProduct(int productId);
        void SetProductosListBindingSource(BindingSource source);
    }
    public partial class SaleItemView : Form, ISaleItemView
    {
        public event EventHandler AddItemEvent;
        public event EventHandler CancelEvent;
        public int? SaleItemId { get; set; }

        public int SaleId { get; set; }
        
        public SaleItemView(int saleId)
        {
            this.SaleId = saleId;
            InitializeComponent();

            AddButton.Click += delegate { AddItemEvent?.Invoke(this, EventArgs.Empty); };
            CancelButton.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
        }
        public int Amount
        {
            get { return int.Parse(AmountTextbox.Text); }
            set { AmountTextbox.Text = value.ToString(); }
        }
        public SaleItemView(int saleId, int saleItemId)
        {
            this.SaleId = saleId;
            this.SaleItemId = saleItemId;
            InitializeComponent();
        }

        public void ShowDialogView()
        {
            this.ShowDialog();
        }

        public void CloseView()
        {
            this.Close();
        }

        public void SetProductosListBindingSource(BindingSource source)
        {
            dataGridView1.DataSource = source;
        }

        public int? GetSelectedProductId()
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Assuming the first column is the Product's ID
                return (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            }
            return null;
        }

        public void SetSelectedProduct(int productId)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["Id"].Value) == productId)
                {
                    dataGridView1.CurrentCell = row.Cells["Id"];
                    break;
                }
            }
        }
    }
}
