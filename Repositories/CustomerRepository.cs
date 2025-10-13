using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Models.DTOs;

namespace VentasApp.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetAllCustomers();
        IEnumerable<CustomerModel> GetActiveCustomers(bool activeState);
        IEnumerable<CustomerModel> SearchCustomers(string searchTerm);
        IEnumerable<CustomerModel> SearchCustomers(string searchTerm, bool activeState);
        CustomerModel? GetCustomerById(int id);
        int AddCustomer(CustomerModel newCustomer);
        void UpdateCustomer(CustomerModel customer);
        bool DeleteCustomer(int id);
        void RestoreCustomer(int id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        public int AddCustomer(CustomerModel newCustomer)
        {
            using (var context = new VentasDBContext())
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();          
                return newCustomer.Id;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var context = new VentasDBContext())
            {
                CustomerModel? customer = GetCustomerById(id);
                if (customer == null) return false;
                context.Customers.Remove(customer);
                return context.SaveChanges() > 0;
            }
        }

        public IEnumerable<CustomerModel> GetActiveCustomers(bool activeState)
        {
            using (var context = new VentasDBContext())
            {
                return context.Customers.Where(p => (p.DeletedAt == null) == activeState).ToList();
            }
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            using (var context = new VentasDBContext())
            { 
                return context.Customers.ToList();
            }
        }

        public CustomerModel? GetCustomerById(int id)
        {
            using (var context = new VentasDBContext())
            {
                return context.Customers.Find(id);
            }
        }

        public void RestoreCustomer(int id)
        {
            using (var context = new VentasDBContext())
            {
                CustomerModel? customer = GetCustomerById(id);
                if (customer == null) return;
                customer.DeletedAt = null;
                context.Customers.Update(customer);
                context.SaveChanges();
            }
        }

        public IEnumerable<CustomerModel> SearchCustomers(string searchTerm)
        {
            using (var context = new VentasDBContext())
            {
                return context.Customers.Where(u =>
                    u.Firstname.Contains(searchTerm) ||
                    u.Lastname.Contains(searchTerm) ||
                    u.Email.Contains(searchTerm) ||
                    u.Id.ToString().Contains(searchTerm)
                ).ToList();
            }
        }

        public IEnumerable<CustomerModel> SearchCustomers(string searchTerm, bool activeState)
        {
            using (var context = new VentasDBContext())
            {
                return context.Customers.Where(u =>
                    (u.Firstname.Contains(searchTerm) ||
                    u.Lastname.Contains(searchTerm) ||
                    u.Email.Contains(searchTerm) ||
                    u.Id.ToString().Contains(searchTerm)) &&
                    (u.DeletedAt == null) == activeState
                ).ToList();
            }
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            using (var context = new VentasDBContext())
            {
                context.Customers.Update(customer);
                context.SaveChanges();
            }
        }
    }
}
