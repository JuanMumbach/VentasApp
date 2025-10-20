using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace VentasApp.Views.Customer
{
    public interface ICustomerListView
    {
        event EventHandler AddCustomerEvent;
        event EventHandler EditCustomerEvent;
        event EventHandler DeleteCustomerEvent;
        event EventHandler RestoreDeletedCustomerEvent;
        event EventHandler ShowDeletedChangeEvent;
        event EventHandler SearchCustomerEvent;

        bool showDeletedCustomers { get; }
        string searchValue { get; set; }
        public int? GetSelectedCustomerId();
        void SetCustomerListBindingSource(BindingSource source);
    }

    public partial class CustomerListView : BaseForm, ICustomerListView
    {
        public event EventHandler AddCustomerEvent;
        public event EventHandler EditCustomerEvent;
        public event EventHandler DeleteCustomerEvent;
        public event EventHandler RestoreDeletedCustomerEvent;
        public event EventHandler ShowDeletedChangeEvent;
        public event EventHandler SearchCustomerEvent;
        public CustomerListView()
        {
            InitializeComponent();
            SetupEventsHandler();
        }

        public string searchValue
        {
            get { return SearchTextbox.Text; }
            set { SearchTextbox.Text = value; }
        }

        public bool showDeletedCustomers => ShowDeletedCheckbox.Checked;

        private void SetupEventsHandler()
        {
            SearchTextbox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchCustomerEvent?.Invoke(this, EventArgs.Empty);
            };

            dataGridView1.SelectionChanged += (s, e) =>
            {
                UpdateDeleteButtonState();
                UpdateRestoreButtonState();
                UpdateEditButtonState();
            };

            ShowDeletedCheckbox.CheckedChanged += delegate { ShowDeletedChangeEvent?.Invoke(this, EventArgs.Empty); };

            dataGridView1.Click += delegate { SearchCustomerEvent?.Invoke(this, EventArgs.Empty); };

            AddCustomerButton.Click += delegate { AddCustomerEvent?.Invoke(this, EventArgs.Empty); };
            EditCustomerButton.Click += delegate { EditCustomerEvent?.Invoke(this, EventArgs.Empty); };
            DeleteButton.Click += delegate { DeleteCustomerEvent?.Invoke(this, EventArgs.Empty); };
            RestoreDeletedButton.Click += delegate { RestoreDeletedCustomerEvent?.Invoke(this, EventArgs.Empty); };
        }

        private void UpdateDeleteButtonState()
        {
            var selectedCustomer = GetSelectedCustomerId();
            if (dataGridView1.CurrentRow == null)
            {
                DeleteButton.Enabled = false;
                return;
            }
            var isActive = (bool)(dataGridView1.CurrentRow.Cells["DeletedAt"].Value == null);
            DeleteButton.Enabled = selectedCustomer.HasValue && isActive;
        }

        private void UpdateRestoreButtonState()
        {
            var selectedCustomer = GetSelectedCustomerId();
            if (dataGridView1.CurrentRow == null)
            {
                RestoreDeletedButton.Enabled = false;
                return;
            }
            var isActive = (bool)(dataGridView1.CurrentRow.Cells["DeletedAt"].Value == null);
            RestoreDeletedButton.Enabled = selectedCustomer.HasValue && !isActive;
        }

        private void UpdateEditButtonState()
        {
            EditCustomerButton.Enabled = GetSelectedCustomerId().HasValue;
        }

        public int? GetSelectedCustomerId()
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.CurrentRow.Cells["Id"].Value == null)
                    return null;
                int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
                return id;
            }
            return null;
        }

        public void SetCustomerListBindingSource(BindingSource source)
        {
            dataGridView1.DataSource = source;
        }
    }
}
