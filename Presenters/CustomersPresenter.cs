using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.Customer;
using VentasApp.Views.Product;

namespace VentasApp.Presenters
{
    public class CustomersPresenter
    {
        private ICustomerListView view;
        private ICustomerRepository repository;
        private BindingSource productsBindingSource;
        private IEnumerable<Models.CustomerModel> customersList;

        public CustomersPresenter(ICustomerListView view, ICustomerRepository repository)
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
            int? id = view.GetSelectedCustomerId();
            if (id == null) return;
            
            CustomerModel? customer = repository.GetCustomerById((int)id);
            if (customer == null) return;

            ICustomerEditView editCustomerView = new CustomerEditView((int)id);
            editCustomerView.ShowDialogView();

            editCustomerView.CancelEvent += (sender, e) => { CloseView(editCustomerView); };
            editCustomerView.SaveCustomerEvent += (sender, e) => { SaveCustomer(editCustomerView); };


            editCustomerView.CustomerName = customer.Firstname;
            editCustomerView.CustomerLastName = customer.Lastname;
            editCustomerView.CustomerEmail = customer.Email;
            editCustomerView.CustomerPhone = customer.PhoneNumber;
            editCustomerView.CustomerAddress = customer.Address;

        }

        private void SaveCustomer(ICustomerEditView editCustomerView)
        {
            int? customerId = editCustomerView.CustomerId;
            if (customerId == null) return;
            CustomerModel customer = repository.GetCustomerById((int)customerId);

            customer.Firstname = editCustomerView.CustomerName;
            customer.Lastname = editCustomerView.CustomerLastName;
            customer.Email = editCustomerView.CustomerEmail;
            customer.PhoneNumber = editCustomerView.CustomerPhone;
            customer.Address = editCustomerView.CustomerAddress;
            
            repository.UpdateCustomer(customer);
        }

        private void LoadAddCustomerView(object? sender, EventArgs e)
        {
            ICustomerAddView addCustomerView = new CustomerAddView();
            addCustomerView.ShowDialogView();

            addCustomerView.CancelEvent += (sender, e) => { CloseView(addCustomerView); };
            addCustomerView.AddCustomerEvent += (sender, e) => { AddCustomer(addCustomerView); };
        }

        private void AddCustomer(ICustomerAddView addCustomerView)
        {
            CustomerModel customer = new CustomerModel
            {
                Firstname = addCustomerView.CustomerName,
                Lastname = addCustomerView.CustomerLastName,
                Email = addCustomerView.CustomerEmail,
                PhoneNumber = addCustomerView.CustomerPhone,
                Address = addCustomerView.CustomerAddress
            };

            repository.AddCustomer(customer);
            LoadAllCustomersList();
        }

        private void CloseView(ICustomerEditView editCustomerView)
        {
            editCustomerView.CloseView();
        }

        private void CloseView(ICustomerAddView addCustomerView)
        {
            addCustomerView.CloseView();
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
