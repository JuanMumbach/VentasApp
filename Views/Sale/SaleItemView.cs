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
        event EventHandler SearchProductEvent;
        int? SaleItemId { get; set; }
        int SaleId { get; set; }
        int Amount { get; set; }
        string searchValue { get; set; }
        void ShowDialogView();
        void CloseView();
        int? GetSelectedProductId();
        void SetSelectedProduct(int productId);
        void SetProductosListBindingSource(BindingSource source);
    }
    public partial class SaleItemView : BaseForm, ISaleItemView
    {
        public event EventHandler AddItemEvent;
        public event EventHandler CancelEvent;
        public event EventHandler SearchProductEvent;
        public int? SaleItemId { get; set; }

        public int SaleId { get; set; }

        public string searchValue
        {
            get { return SearchTextbox.Text; }
            set { SearchTextbox.Text = value; }
        }
        public SaleItemView(int saleId)
        {
            this.SaleId = saleId;
            InitializeComponent();

            AddButton.Click += delegate { AddItemEvent?.Invoke(this, EventArgs.Empty); };
            CancelButton.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
            SearchTextbox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchProductEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        public int Amount
        {
            get 
            { 
                if (int.TryParse(AmountTextbox.Text, out int amount))
                {
                    return amount;
                }
                else
                {
                    return -1;
                }
            }
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
