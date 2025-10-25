using System;
using System.Windows.Forms;
using VentasApp.Views.Supplier;

namespace VentasApp.Views
{
    public partial class ListSuppliersView : BaseForm, IListSuppliersView
    {
        public event EventHandler SearchSupplierEvent;
        public event EventHandler AddSupplierViewEvent;
        public event EventHandler EditSupplierViewEvent;
        public event EventHandler DeleteSupplierEvent;
        public event EventHandler RestoreSupplierEvent;
        public event EventHandler ShowDeletedCheckboxChange;

        public ListSuppliersView()
        {
            InitializeComponent();
            SetupEventsHandler();
            // Ejecutar la búsqueda inicial al cargar la vista
            SearchSupplierEvent?.Invoke(this, EventArgs.Empty);
        }

        public string searchValue
        {
            get { return SearchTextbox.Text; }
            set { SearchTextbox.Text = value; }
        }

        public bool showDeletedSuppliers
        {
            get { return ShowDeletedCheckbox.Checked; }
            set { ShowDeletedCheckbox.Checked = value; }
        }

        public void SetSuppliersListBindingSource(BindingSource source)
        {
            dataGridView1.DataSource = source;
        }

        private void SetupEventsHandler()
        {
            SearchTextbox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchSupplierEvent?.Invoke(this, EventArgs.Empty);
            };

            dataGridView1.SelectionChanged += (s, e) =>
            {
                UpdateDeleteButtonState();
                UpdateRestoreButtonState();
                UpdateEditButtonState();
            };

            OpenAddSupplierViewButton.Click += delegate { AddSupplierViewEvent?.Invoke(this, EventArgs.Empty); };
            EditSupplierButton.Click += delegate { EditSupplierViewEvent?.Invoke(this, EventArgs.Empty); };
            DeleteButton.Click += delegate { DeleteSupplierEvent?.Invoke(this, EventArgs.Empty); };
            RestoreButton.Click += delegate { RestoreSupplierEvent?.Invoke(this, EventArgs.Empty); };

            ShowDeletedCheckbox.CheckedChanged += delegate { SearchSupplierEvent?.Invoke(this, EventArgs.Empty); };

            // Re-ejecutar búsqueda en caso de click general para refrescar
            dataGridView1.Click += delegate { UpdateDeleteButtonState(); UpdateRestoreButtonState(); };
        }

        public (int? Id, bool? Active)? GetSelectedSupplierInfo()
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Asumiendo que las columnas son 'SupplierId' y 'Active'
                var supplierId = (int)dataGridView1.CurrentRow.Cells["SupplierId"].Value;
                // Si la columna 'Active' existe en el DataSource:
                var isActive = (bool)dataGridView1.CurrentRow.Cells["Active"].Value;
                return (supplierId, isActive);
            }
            return null;
        }

        private void UpdateDeleteButtonState()
        {
            var selectedSupplier = GetSelectedSupplierInfo();
            DeleteButton.Enabled = selectedSupplier.HasValue && selectedSupplier.Value.Active == true;
        }

        private void UpdateRestoreButtonState()
        {
            var selectedSupplier = GetSelectedSupplierInfo();
            RestoreButton.Enabled = selectedSupplier.HasValue && selectedSupplier.Value.Active == false;
        }

        private void UpdateEditButtonState()
        {
            EditSupplierButton.Enabled = GetSelectedSupplierInfo().HasValue;
        }
    }
}