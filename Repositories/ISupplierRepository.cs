using VentasApp.Models;
using VentasApp.Models.DTOs;
using System.Collections.Generic; // Agregado

namespace VentasApp.Repositories
{
    public interface ISupplierRepository
    {
        void AddSupplier(AddSupplierDTO supplier);
        void UpdateSupplier(UpdateSupplierDTO supplier);
        SupplierModel GetSupplierById(int id);

        // Métodos de listado y gestión de estado
        IEnumerable<SupplierModel> GetSuppliers(string searchValue, bool includeInactive);
        void SetSupplierActiveState(int id, bool activeState);
    }
}