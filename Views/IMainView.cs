using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Views.Customer;

namespace VentasApp.Views
{
    public interface IMainView : IBaseForm
    {
        public void LoadMainPanelView(Form view);
        void Close();
        void SetMenuButtonVisibility(string buttonName, bool isVisible);

        event EventHandler ProductsButtonEvent;
        event EventHandler SalesButtonEvent;
        event EventHandler UsersButtonEvent;
        event EventHandler CustomersButtonEvent;
        event EventHandler LogoutButtonEvent;
        event EventHandler MainViewClosedEvent;
        event EventHandler listSalesButtonEvent;
        event EventHandler DashboardButtonEvent;
        event EventHandler SystemSettingsButtonEvent;
    }
}
