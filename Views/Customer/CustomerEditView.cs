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
    public interface ICustomerEditView
    {

    }
    public partial class CustomerEditView : Form, ICustomerEditView
    {
        public CustomerEditView()
        {
            InitializeComponent();
        }

        private void CustomerView_Load(object sender, EventArgs e)
        {

        }
    }
}
