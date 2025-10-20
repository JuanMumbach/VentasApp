using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Views
{
    public interface IMainView
    {
        public void LoadMainPanelView(Form view);
        public void UpdateUserInfo(string username, string role);

        event EventHandler ProductsButtonEvent;
        event EventHandler SalesButtonEvent;
        event EventHandler UsersButtonEvent;
        event EventHandler LogoutButtonEvent;
    }
}
