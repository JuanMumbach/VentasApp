using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasApp.Views.Customer
{
    public interface ICustomerAddView
    {
        event EventHandler AddCustomerEvent;
        event EventHandler CancelEvent;
        string CustomerName { get; set; }
        string CustomerLastName { get; set; }
        string CustomerEmail { get; set; }
        string CustomerPhone { get; set; }
        string CustomerAddress { get; set; }

        void ShowDialogView();
        void CloseView();
    }
    public partial class CustomerAddView : BaseForm, ICustomerAddView
    {
        public event EventHandler AddCustomerEvent;
        public event EventHandler CancelEvent;

        public string CustomerName
        {
            get { return TB_Name.Text; }
            set { TB_Name.Text = value; }
        }
        public string CustomerLastName
        {
            get { return TB_Lastname.Text; }
            set { TB_Lastname.Text = value; }
        }
        public string CustomerEmail
        {
            get { return TB_Email.Text; }
            set { TB_Email.Text = value; }
        }
        public string CustomerPhone
        {
            get { return TB_Phone.Text; }
            set { TB_Phone.Text = value; }
        }
        public string CustomerAddress
        {
            get { return TB_Address.Text; }
            set { TB_Address.Text = value; }
        }
        public CustomerAddView()
        {
            InitializeComponent();
            SetupEventsHandler();
        }

        private void SetupEventsHandler()
        {
            AddCustomerButton.Click += delegate { AddCustomerEvent?.Invoke(this, EventArgs.Empty); };
            CancelButton.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
        }

        public void ShowDialogView()
        {
            this.ShowDialog();
        }

        public void CloseView()
        {
            this.Close();
        }
    }
}
