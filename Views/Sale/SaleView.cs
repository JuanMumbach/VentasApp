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
using VentasApp.Services;

namespace VentasApp.Views.Sale
{
    public interface ISaleView
    {
        int? SaleId { get; set; }
        int? CustomerId { get; set; }
        IEnumerable<CustomerModel> Customers { set; }
        event EventHandler AddSaleItemViewEvent;
        event EventHandler EditSaleItemViewEvent;
        event EventHandler RemoveSaleItemEvent;
        event EventHandler FinishSaleEvent;
        event EventHandler CancelSaleEvent;
        event EventHandler OnRecoverFocusEvent;
        event EventHandler CustomerSelectionChangedEvent;

        void SetSaleItemsListBindingSource(BindingSource source);
        int? GetSelectedItemId();

    }
    public partial class SaleView : Form, ISaleView
    {
        public int? SaleId { get; set; }
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
            LoadColorTheme();
        }

        private void LoadColorTheme()
        {
            ViewItemsPanel.BackColor = Themes.ColorBack2;
            label1.ForeColor = Themes.ColorNormalText;


            Button[] buttons = { AddSaleItemButton, EditSaleItemButton, RemoveItemButton, ConfirmSaleButton, CancelButton };
            foreach (Button button in buttons)
            {
                button.BackColor = Themes.ColorBack;
                button.ForeColor = Themes.ColorNormalText;
                button.FlatAppearance.BorderColor = Themes.ColorBack2Highlighted;
                button.FlatAppearance.MouseOverBackColor = Themes.ColorBack2Highlighted;
            }

            RemoveItemButton.ForeColor = Themes.ColorWarning;
            AddSaleItemButton.ForeColor = Themes.ColorHighlight;
            ConfirmSaleButton.ForeColor = Themes.ColorHighlight;

            SaleItemsDatagridview.BackgroundColor = Themes.ColorBack;
            SaleItemsDatagridview.ForeColor = Themes.ColorPrimary;
            SaleItemsDatagridview.ColumnHeadersDefaultCellStyle.BackColor = Themes.ColorBack2;
            SaleItemsDatagridview.ColumnHeadersDefaultCellStyle.ForeColor = Themes.ColorPrimary;
            SaleItemsDatagridview.DefaultCellStyle.BackColor = Themes.ColorBack2;
            SaleItemsDatagridview.DefaultCellStyle.ForeColor = Themes.ColorNormalText;

        }

        private void SetupEventHandler()
        {
            AddSaleItemButton.Click += delegate { AddSaleItemViewEvent?.Invoke(this, EventArgs.Empty); };
            EditSaleItemButton.Click += delegate { EditSaleItemViewEvent?.Invoke(this, EventArgs.Empty); };
            RemoveItemButton.Click += delegate { RemoveSaleItemEvent?.Invoke(this, EventArgs.Empty); };
            ConfirmSaleButton.Click += delegate { FinishSaleEvent?.Invoke(this, EventArgs.Empty); };
            CancelButton.Click += delegate { CancelSaleEvent?.Invoke(this, EventArgs.Empty); };
            SaleItemsDatagridview.Click += delegate { OnRecoverFocusEvent?.Invoke(this, EventArgs.Empty); };
            //CustomerCombobox.SelectionChangeCommitted += delegate { CustomerSelectionChangedEvent?.Invoke(this, EventArgs.Empty); };
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
