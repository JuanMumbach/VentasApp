using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Services;

namespace VentasApp.Views.Sale
{
    public interface ISaleView
    {
        IEnumerable<CustomerModel> Customers { set; }
        int? CustomerId { get; set; }
        event EventHandler AddSaleItemViewEvent;
        event EventHandler EditSaleItemViewEvent;
        event EventHandler RemoveSaleItemEvent;
        event EventHandler FinishSaleEvent;
        event EventHandler CancelSaleEvent;
        event EventHandler OnRecoverFocusEvent;
        event EventHandler CustomerSelectionChangedEvent;
        
        void SetReadOnlyMode();
        void SetSaleItemsListBindingSource(BindingSource source);
        int? GetSelectedItemId();

    }
    public partial class SaleView : BaseForm, ISaleView
    {
        public IEnumerable<CustomerModel> Customers
        {
            set
            {
                List<CustomerModel> _customers = value.ToList();
                _customers.Insert(0, new CustomerModel { Id = -1, Firstname = "-- Sin definir --" });

                CustomerCombobox.DataSource = _customers;
                CustomerCombobox.DisplayMember = "FullName";
                CustomerCombobox.ValueMember = "Id";

            }
        }


        public int? CustomerId
        {
            get
            {
                int? value = (int?)CustomerCombobox.SelectedValue;
                if (value == -1) return null;
                return value;
            }
            set
            {
                if (value.HasValue)
                {
                    CustomerCombobox.SelectedValue = value.Value;
                }
                else
                {
                    CustomerCombobox.SelectedIndex = -1;
                }
            }
        }

        public event EventHandler AddSaleItemViewEvent;
        public event EventHandler EditSaleItemViewEvent;
        public event EventHandler RemoveSaleItemEvent;
        public event EventHandler FinishSaleEvent;
        public event EventHandler CancelSaleEvent;
        public event EventHandler OnRecoverFocusEvent;
        public event EventHandler CustomerSelectionChangedEvent;

        public SaleView()
        {
            InitializeComponent();
            SetupEventHandler();
        }
        public void SetReadOnlyMode()
        {
            AddSaleItemButton.Visible = false;
            EditSaleItemButton.Visible = false;
            RemoveItemButton.Visible = false;

            ConfirmSaleButton.Visible = false;

            // Cambiar el botón Cancelar a "Cerrar" y reposicionarlo (opcionalmente)
            CancelButton.Text = "Cerrar";
        }

        protected override void CustomTheme()
        {
            AddSaleItemButton.BackColor = Themes.MainActionButtonColor;
            AddSaleItemButton.ForeColor = Themes.MainActionButtonTextColor;
        }

        private void SetupEventHandler()
        {
            AddSaleItemButton.Click += delegate { AddSaleItemViewEvent?.Invoke(this, EventArgs.Empty); };
            EditSaleItemButton.Click += delegate { EditSaleItemViewEvent?.Invoke(this, EventArgs.Empty); };
            RemoveItemButton.Click += delegate { RemoveSaleItemEvent?.Invoke(this, EventArgs.Empty); };
            ConfirmSaleButton.Click += delegate { FinishSaleEvent?.Invoke(this, EventArgs.Empty); };
            CancelButton.Click += delegate { CancelSaleEvent?.Invoke(this, EventArgs.Empty); };
            SaleItemsDatagridview.Click += delegate { OnRecoverFocusEvent?.Invoke(this, EventArgs.Empty); };
            SaleItemsDatagridview.DataBindingComplete += SaleItemsDatagridview_DataBindingComplete;
            //CustomerCombobox.SelectionChangeCommitted += delegate { CustomerSelectionChangedEvent?.Invoke(this, EventArgs.Empty); };
        }

        private void SaleItemsDatagridview_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (SaleItemsDatagridview.Columns.Contains("Id"))
            {
                SaleItemsDatagridview.Columns["Id"].Visible = false;
            }

            /*
            if (SaleItemsDatagridview.Columns.Contains("PrecioUnitario"))
            {
                SaleItemsDatagridview.Columns["PrecioUnitario"].HeaderText = "P. Unitario";
            }
            */
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
