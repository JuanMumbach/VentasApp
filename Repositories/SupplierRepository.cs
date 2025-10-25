using VentasApp.Models;
using VentasApp.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace VentasApp.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public void AddSupplier(AddSupplierDTO dto)
        {
            using (var context = new VentasDBContext())
            {
                var newSupplier = new SupplierModel
                {
                    SupplierName = dto.Name,
                    Cuil = dto.Cuil,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    // CreatedAt y UpdatedAt son manejados por la DB o EF Core
                };
                context.Suppliers.Add(newSupplier);
                context.SaveChanges();
            }
        }

        public void UpdateSupplier(UpdateSupplierDTO dto)
        {
            using (var context = new VentasDBContext())
            {
                // La propiedad de clave es SupplierId
                var existingSupplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == dto.Id);
                if (existingSupplier != null)
                {
                    existingSupplier.SupplierName = dto.Name;
                    existingSupplier.Cuil = dto.Cuil;
                    existingSupplier.Email = dto.Email;
                    existingSupplier.PhoneNumber = dto.PhoneNumber;
                    // UpdatedAt se actualiza por el trigger o EF Core
                    context.SaveChanges();
                }
            }
        }

        public SupplierModel GetSupplierById(int id)
        {
            using (var context = new VentasDBContext())
            {
                return context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            }
        }

        public IEnumerable<SupplierModel> GetSuppliers(string searchValue, bool includeInactive)
        {
            using (var context = new VentasDBContext())
            {
                var query = context.Suppliers.AsQueryable();

                if (!includeInactive)
                {
                    // Filtrar solo activos (asumiendo que SupplierModel tiene una propiedad Active)
                    query = query.Where(s => s.Active);
                }

                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    string search = searchValue.ToLower();
                    query = query.Where(s => s.SupplierName.ToLower().Contains(search) ||
                                             (s.Cuil != null && s.Cuil.Contains(search)) ||
                                             (s.Email != null && s.Email.ToLower().Contains(search)));
                }

                return query.ToList();
            }
        }

        public void SetSupplierActiveState(int id, bool activeState)
        {
            using (var context = new VentasDBContext())
            {
                var supplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
                if (supplier != null)
                {
                    // Asumiendo que SupplierModel tiene una propiedad Active
                    supplier.Active = activeState;
                    context.SaveChanges();
                }
            }
        }
    }
}