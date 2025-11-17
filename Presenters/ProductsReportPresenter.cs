using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Views.Dashboard;

namespace VentasApp.Presenters
{
    public class ProductsReportPresenter
    {
        IProductReportView view;
        public ProductsReportPresenter(IProductReportView view)
        {
            this.view = view;
        }
    }
}
