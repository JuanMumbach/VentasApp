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
        public event EventHandler ViewSaleDetailEvent;
        public event EventHandler OnChangeSelectedSaleEvent;
        public event EventHandler OnChangeDeliveryStateEvent;

        public ListSalesView()
        {
            InitializeComponent();
            SetupEventHandlers();

            this.Load += delegate { LoadAllSalesEvent?.Invoke(this, EventArgs.Empty); };
        }

        public string DeliveryState { 
            get 
            {
                if (DeliveryStateCombobox.SelectedItem != null)
                {
                    return DeliveryStateCombobox.SelectedItem.ToString();
                }
                return null;
            }

            set             
            {
                DeliveryStateCombobox.SelectedItem = value;
            }
        }

        private void SetupEventHandlers()
        {
            RestoreButton.Click += delegate { RestoreSaleEvent?.Invoke(this, EventArgs.Empty); };
            CancelSaleButton.Click += delegate { CancelSaleEvent?.Invoke(this, EventArgs.Empty); };
            ViewDetailButton.Click += delegate { ViewSaleDetailEvent?.Invoke(this, EventArgs.Empty); };
            SalesDataGridView.SelectionChanged += delegate { OnChangeSelectedSaleEvent?.Invoke(this, EventArgs.Empty); };
            DeliveryStateCombobox.SelectedIndexChanged += delegate { OnChangeDeliveryStateEvent?.Invoke(this, EventArgs.Empty); };
        }

        public BindingSource SaleListBindingSource
        {
            set
            {
                SalesDataGridView.DataSource = value;
            }
        }

        public int? GetSelectedSaleId()
        {
            if (SalesDataGridView.CurrentRow != null)
            {
                return (int)SalesDataGridView.CurrentRow.Cells["Id"].Value;
            }
            return null;
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }


        public void CloseView()
        {
            this.Close();
        }

        public void SetViewOnlyMode()
        {
            CancelSaleButton.Enabled = false;
            CancelSaleButton.Visible = false;
            RestoreButton.Enabled = false;
            RestoreButton.Visible = false;
            DeliveryStateLabel.Enabled = false;
            DeliveryStateLabel.Visible = false;
            DeliveryStateCombobox.Enabled = false;
            DeliveryStateCombobox.Visible = false;

        }

        public void SetDeliveryStateOptions(List<string> states)
        {
            DeliveryStateCombobox.Items.Clear();
            foreach (var state in states)
            {
                DeliveryStateCombobox.Items.Add(state);
            }
        }
    }
}