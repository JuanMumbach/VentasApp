using System;
using System.Windows.Forms;
using VentasApp.Views.Supplier;

namespace VentasApp.Views
{
    public partial class SupplierView : BaseForm, ISupplierView
    {
        // Eventos
        public event EventHandler AddSupplierEvent;
        public event EventHandler UpdateSupplierEvent;
        public event EventHandler CancelSupplierEditEvent;

        // Constructor para agregar
        public SupplierView()
        {
            InitializeComponent();
            SwitchEditModeButtons();
            SetupEventsHandler();
        }

        // Constructor para editar
        public SupplierView(int supplierId)
        {
            SupplierId = supplierId;
            InitializeComponent();
            SwitchEditModeButtons();
            SetupEventsHandler();
        }

        // Propiedades de la vista
        public string SupplierName
        {
            get { return NameTextbox.Text; }
            set { NameTextbox.Text = value; }
        }

        public string Cuil
        {
            get { return CuilTextbox.Text; }
            set { CuilTextbox.Text = value; }
        }

        public string Email
        {
            get { return EmailTextbox.Text; }
            set { EmailTextbox.Text = value; }
        }

        public string PhoneNumber
        {
            get { return PhoneTextbox.Text; }
            set { PhoneTextbox.Text = value; }
        }

        public int? SupplierId { get; set; }

        public bool NotCloseAtUpdate
        {
            get { return CloseAtUpdateCheckbox.Checked; }
            set { CloseAtUpdateCheckbox.Checked = value; }
        }

        // Métodos de la vista
        public void CloseView()
        {
            this.Close();
        }

        public void ShowDialogView()
        {
            this.ShowDialog();
        }

        public new void Show()
        {
            base.Show();
        }

        private void SetupEventsHandler()
        {
            AddSupplierButton.Click += delegate { AddSupplierEvent?.Invoke(this, EventArgs.Empty); };
            CancelButton.Click += delegate { CancelSupplierEditEvent?.Invoke(this, EventArgs.Empty); };
            UpdateSupplierButton.Click += delegate { UpdateSupplierEvent?.Invoke(this, EventArgs.Empty); };
        }

        private void SwitchEditModeButtons()
        {
            if (SupplierId == null)
            {
                // Modo Agregar
                AddSupplierButton.Enabled = true;
                UpdateSupplierButton.Enabled = false;
            }
            else
            {
                // Modo Editar
                AddSupplierButton.Enabled = false;
                UpdateSupplierButton.Enabled = true;
            }
        }
    }
}