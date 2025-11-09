using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasApp.Views.Dashboard
{
    public interface IDashboardView : IBaseForm
    {

    }

    public partial class DashboardView : BaseForm, IDashboardView
    {
        public DashboardView()
        {
            InitializeComponent();
        }
    }
}
