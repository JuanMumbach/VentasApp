using System;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.Supplier;

namespace VentasApp.Presenters
{
    public class ListSuppliersPresenter
    {
        private IListSuppliersView view;
        private ISupplierRepository repository;
        private BindingSource suppliersBindingSource;

        public ListSuppliersPresenter(IListSuppliersView view, ISupplierRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.suppliersBindingSource = new BindingSource();

            this.view.SetSuppliersListBindingSource(suppliersBindingSource);

            // Suscribir eventos
            this.view.SearchSupplierEvent += SearchSupplier;
            this.view.AddSupplierViewEvent += OpenAddSupplierView;
            this.view.EditSupplierViewEvent += OpenEditSupplierView;
            this.view.DeleteSupplierEvent += DeleteSupplier;
            this.view.RestoreSupplierEvent += RestoreSupplier;
            this.view.ShowDeletedCheckboxChange += SearchSupplier;

            // Cargar datos iniciales
            LoadSuppliersList();
        }

        private void LoadSuppliersList()
        {
            var suppliers = repository.GetSuppliers(view.searchValue, view.showDeletedSuppliers);
            
            var displayList = suppliers.Select(s => new
            {
                Id = s.SupplierId,
                SupplierName = s.SupplierName,
                Cuil = s.Cuil,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                LastUpdate = s.UpdatedAt,
                Active = s.Active ? "Activo" : "Eliminado"
            }).ToList();
            suppliersBindingSource.DataSource = displayList;
        }

        private void SearchSupplier(object? sender, EventArgs e)
        {
            LoadSuppliersList();
        }

        private void OpenAddSupplierView(object? sender, EventArgs e)
        {
            ISupplierView supplierView = new SupplierView();
            new SupplierPresenter(supplierView, repository);
            supplierView.ShowDialogView();
            LoadSuppliersList(); // Recargar después de cerrar el diálogo
        }

        private void OpenEditSupplierView(object? sender, EventArgs e)
        {
            var selectedInfo = view.GetSelectedSupplierInfo();
            if (selectedInfo.HasValue)
            {
                ISupplierView supplierView = new SupplierView(selectedInfo.Value.Id!.Value);
                new SupplierPresenter(supplierView, repository);
                supplierView.ShowDialogView();
                LoadSuppliersList(); // Recargar después de cerrar el diálogo
            }
        }

        private void DeleteSupplier(object? sender, EventArgs e)
        {
            var selectedInfo = view.GetSelectedSupplierInfo();
            if (selectedInfo.HasValue && selectedInfo.Value.Active == true)
            {
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que quieres eliminar este proveedor? (Soft Delete)",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    repository.SetSupplierActiveState(selectedInfo.Value.Id!.Value, false);
                    LoadSuppliersList();
                }
            }
        }

        private void RestoreSupplier(object? sender, EventArgs e)
        {
            var selectedInfo = view.GetSelectedSupplierInfo();
            if (selectedInfo.HasValue && selectedInfo.Value.Active == false)
            {
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que quieres restaurar este proveedor?",
                    "Confirmar Restauración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    repository.SetSupplierActiveState(selectedInfo.Value.Id!.Value, true);
                    LoadSuppliersList();
                }
            }
        }
    }
}