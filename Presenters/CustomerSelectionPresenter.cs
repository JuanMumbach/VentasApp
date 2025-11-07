using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views.Customer;

namespace VentasApp.Presenters
{
    public class CustomerSelectionPresenter : CustomersPresenter
    {
        public event EventHandler? ConfirmSelectionEvent;
        public CustomerSelectionPresenter(ICustomerListView view, ICustomerRepository repository) : base(view, repository)
        {
            view.AddCustomerEvent -= LoadAddCustomerView;
            view.AddCustomerEvent += OnConfirmSelection;
            view.SetSelectionMode();
        }

        private void OnConfirmSelection(object? sender, EventArgs e)
        {
            int customerId = view.GetSelectedCustomerId() ?? 0;
            ConfirmSelectionEvent?.Invoke(customerId, EventArgs.Empty);
            view.CloseView();
        }
    }
}
