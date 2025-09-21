using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Views.Product;

namespace VentasApp.Views
{
    public partial class ListProductsView : Form, IListProductsView
    {
        public event EventHandler SearchProductEvent;
        public event EventHandler AddProductViewEvent;
        public event EventHandler DeleteProductEvent;
        public event EventHandler RestoreProductEvent;
        public event EventHandler ShowDeletedCheckboxChange;
        public event EventHandler EditProductViewEvent;

        public ListProductsView()
        {
            InitializeComponent();

            SetupEventsHandler();
        }


        public string searchValue
        {
            get { return SearchTextbox.Text; }
            set { SearchTextbox.Text = value; }
        }

        public bool showDeletedProducts 
        { 
            get { return ShowDeletedCheckbox.Checked; }
            set { ShowDeletedCheckbox.Checked = value; }
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

            dataGridView1.SelectionChanged += (s, e) =>
            {
                UpdateDeleteButtonState();
                UpdateRestoreButtonState();
                UpdateEditButtonState();
            };

            OpenAddProductViewButton.Click += delegate { AddProductViewEvent?.Invoke(this, EventArgs.Empty); };
            EditProductButton.Click += delegate { EditProductViewEvent?.Invoke(this, EventArgs.Empty); };
            DeleteButton.Click += delegate { DeleteProductEvent?.Invoke(this, EventArgs.Empty); };
            RestoreButton.Click += delegate { RestoreProductEvent?.Invoke(this, EventArgs.Empty); };

            ShowDeletedCheckbox.CheckedChanged += delegate { ShowDeletedCheckboxChange?.Invoke(this, EventArgs.Empty); };
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

        public (int? Id, bool? Active)? GetSelectedProductInfo()
        {
            if (dataGridView1.CurrentRow != null)
            {
                var productId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
                var isActive = (bool)dataGridView1.CurrentRow.Cells["Active"].Value;
                return (productId, isActive);
            }
            return null;
        }

        private void UpdateDeleteButtonState()
        {
            var selectedProduct = GetSelectedProductInfo();
            DeleteButton.Enabled = selectedProduct.HasValue && selectedProduct.Value.Active == true;
        }

        private void UpdateRestoreButtonState()
        {
            var selectedProduct = GetSelectedProductInfo();
            RestoreButton.Enabled = selectedProduct.HasValue && selectedProduct.Value.Active == false;
        }

        private void UpdateEditButtonState()
        {
            EditProductButton.Enabled = GetSelectedProductId().HasValue;
        }
    }
}
