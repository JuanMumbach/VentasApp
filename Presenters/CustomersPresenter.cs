using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Models.DTOs;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views;
using VentasApp.Views.Customer;
using VentasApp.Views.Product;
using static VentasApp.Services.PermissionManager;


namespace VentasApp.Presenters
{
    public class CustomersPresenter
    {
        private ICustomerListView view;
        private ICustomerRepository repository;
        private BindingSource productsBindingSource;
        private IEnumerable<Models.CustomerModel> customersList;
        private bool accessGranted = false;

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
            this.view.FormLoadEvent += CheckForPermission;

            LoadAllCustomersList();
        }

        private void CheckForPermission(object? sender, EventArgs e)
        {
            if (HasPermission((Roles)SessionManager.CurrentUserRoleId,Permissions.CustomersManage))
            {
                accessGranted = true;
                LoadAllCustomersList();
                return;
            }

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.CustomersView))
            {
                accessGranted = true;
                view.SetViewOnlyMode();
                LoadAllCustomersList();
                return;
            }

            MessageBox.Show("No tiene permisos para acceder a esta sección.", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            view.CloseView();
        }

        private void LoadAllCustomersList()
        {
            if (!accessGranted) return;

            if (view.showDeletedCustomers)
            { customersList = repository.GetAllCustomers(); }
            else
            { customersList = repository.GetActiveCustomers(true); }

            var displayList = customersList.Select(c => new
            {
                c.Id,
                Nombre = c.FullName,
                Email = c.Email,
                Telefono = c.PhoneNumber,
                Direccion = c.Address,
                Estado = c.DeletedAt == null ? "Activo" : $"Eliminado {((DateTime)c.DeletedAt).ToString("g")}"
            });
            productsBindingSource.DataSource = displayList;
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
                    

            editCustomerView.CancelEvent += (sender, e) => { CloseView(editCustomerView); };
            editCustomerView.SaveCustomerEvent += (sender, e) => { UpdateCustomer(editCustomerView); };


            editCustomerView.CustomerName = customer.Firstname;
            editCustomerView.CustomerLastName = customer.Lastname;
            editCustomerView.CustomerEmail = customer.Email;
            editCustomerView.CustomerPhone = customer.PhoneNumber;
            editCustomerView.CustomerAddress = customer.Address;

            editCustomerView.ShowDialogView();

        }

        private void UpdateCustomer(ICustomerEditView editCustomerView)
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
            LoadAllCustomersList();
            editCustomerView.CloseView();
        }

        private void LoadAddCustomerView(object? sender, EventArgs e)
        {
            ICustomerAddView addCustomerView = new CustomerAddView();
            

            addCustomerView.CancelEvent += (sender, e) => { CloseView(addCustomerView); };
            addCustomerView.AddCustomerEvent += (sender, e) => { AddCustomer(addCustomerView); };

            addCustomerView.ShowDialogView();
        }

        private void AddCustomer(ICustomerAddView addCustomerView)
        {
            AddCustomerDTO customer = new AddCustomerDTO
            {
                Firstname = addCustomerView.CustomerName,
                Lastname = addCustomerView.CustomerLastName,
                Email = addCustomerView.CustomerEmail,
                PhoneNumber = addCustomerView.CustomerPhone,
                Address = addCustomerView.CustomerAddress
            };

            repository.AddCustomer(customer);
            LoadAllCustomersList();
            CloseView(addCustomerView);
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
            if (!accessGranted) return;

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

            var displayList = customersList.Select(c => new
            {
                c.Id,
                Nombre = c.FullName,
                Email = c.Email,
                Telefono = c.PhoneNumber,
                Direccion = c.Address,
                Estado = c.DeletedAt == null ? "Activo" : $"Eliminado {((DateTime)c.DeletedAt).ToString("g")}"
            });
            productsBindingSource.DataSource = displayList;
        }
    }
}
