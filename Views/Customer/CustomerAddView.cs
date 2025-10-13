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
        
    }
    public partial class CustomerAddView : Form, ICustomerAddView
    {
        public CustomerAddView()
        {
            InitializeComponent();
        }
    }
}
