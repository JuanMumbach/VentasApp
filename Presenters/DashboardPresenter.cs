using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views.Dashboard;

namespace VentasApp.Presenters
{
    public class DashboardPresenter
    {
        private IDashboardView view;
        private ISaleRepository salesRepository;

        public DashboardPresenter(IDashboardView dashboardView, ISaleRepository _salesRepository)
        {
            this.view = dashboardView;
            this.salesRepository = _salesRepository;
            
            this.view.FormLoadEvent += LoadGraph;
        }

        private void LoadGraph(object? sender, EventArgs e)
        {
            
        }
    }
}
