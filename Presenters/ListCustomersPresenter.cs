using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.Customer;
using VentasApp.Views.Product;

namespace VentasApp.Presenters
{
    public class ListCustomersPresenter
    {
        private ICustomerListView view;
        private ICustomerRepository repository;
        private BindingSource productsBindingSource;
        private IEnumerable<Models.CustomerModel> customersList;

        public ListCustomersPresenter(ICustomerListView view, ICustomerRepository repository)
        {
            this.productsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchCustomerEvent += SearchCustomer;
            this.view.AddCustomerEvent += LoadAddCustomerView;
            this.view.EditCustomerEvent += LoadEditCustomerView;
            this.view.DeleteCustomerEvent += DeleteCustomer;
            this.view.RestoreDeletedCustomerEvent += RestoreCustomer;
            this.view.ShowDeletedChangeEvent += (s, e) => LoadAllCustomersList();
            this.view.SetCustomerListBindingSource(productsBindingSource);

            LoadAllCustomersList();
        }

        private void LoadAllCustomersList()
        {
            if (view.showDeletedCustomers)
            { customersList = repository.GetAllCustomers(); }
            else
            { customersList = repository.GetActiveCustomers(true); }

            productsBindingSource.DataSource = customersList;
        }

        private void RestoreCustomer(object? sender, EventArgs e)
        {
            int? selectedId = (int?)view.GetSelectedCustomerId();
            if (selectedId != null)
            {
                repository.RestoreCustomer((int)selectedId);
                LoadAllCustomersList();
            }
        }

        private void DeleteCustomer(object? sender, EventArgs e)
        {
            int? selectedId = (int?)view.GetSelectedCustomerId();
            if (selectedId != null)
            {
                repository.DeleteCustomer((int)selectedId);
                LoadAllCustomersList();
            }
        }

        private void LoadEditCustomerView(object? sender, EventArgs e)
        {
            ICustomerEditView editCustomerView = new CustomerEditView();
            //new CustomerAddPresenter(addProductView, repository);

            //addCustomerView.ShowDialogView();
        }

        private void LoadAddCustomerView(object? sender, EventArgs e)
        {
            ICustomerAddView addCustomerView = new CustomerAddView();
            //new CustomerAddPresenter(addProductView, repository);

            //addCustomerView.ShowDialogView();
        }

        private void SearchCustomer(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(view.searchValue))
            {
                LoadAllCustomersList();
            }
            else
            {

                if (view.showDeletedCustomers)
                { customersList = repository.SearchCustomers(view.searchValue); }
                else
                { customersList = repository.SearchCustomers(view.searchValue, activeState: true); }
            }

            productsBindingSource.DataSource = customersList;
        }
    }
}
