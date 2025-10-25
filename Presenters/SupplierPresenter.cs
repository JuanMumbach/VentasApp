using System;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Models.DTOs;
using VentasApp.Repositories;
using VentasApp.Views.Supplier;

namespace VentasApp.Presenters
{
    public class SupplierPresenter
    {
        private ISupplierView view;
        private ISupplierRepository repository;

        public SupplierPresenter(ISupplierView view, ISupplierRepository repository)
        {
            this.view = view;
            this.repository = repository;

            // Suscribir eventos
            this.view.AddSupplierEvent += AddSupplier;
            this.view.UpdateSupplierEvent += UpdateSupplier;
            this.view.CancelSupplierEditEvent += CancelEditSupplier;

            // Cargar datos si es modo edición
            if (this.view.SupplierId.HasValue)
            {
                LoadSupplierData((int)this.view.SupplierId);
            }
        }

        private void LoadSupplierData(int id)
        {
            SupplierModel supplier = repository.GetSupplierById(id);
            if (supplier != null)
            {
                this.view.SupplierName = supplier.SupplierName;
                this.view.Cuil = supplier.Cuil ?? string.Empty;
                this.view.Email = supplier.Email ?? string.Empty;
                this.view.PhoneNumber = supplier.PhoneNumber ?? string.Empty;
            }
        }

        private void CancelEditSupplier(object? sender, EventArgs e)
        {
            this.view.CloseView();
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(view.SupplierName))
            {
                MessageBox.Show("El nombre del proveedor no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Implementar más validaciones si es necesario (ej. formato de email, CUIL)
            return true;
        }

        private void AddSupplier(object? sender, EventArgs e)
        {
            if (!ValidateData()) return;

            AddSupplierDTO newSupplier = new AddSupplierDTO()
            {
                Name = view.SupplierName,
                Cuil = string.IsNullOrWhiteSpace(view.Cuil) ? null : view.Cuil,
                Email = string.IsNullOrWhiteSpace(view.Email) ? null : view.Email,
                PhoneNumber = string.IsNullOrWhiteSpace(view.PhoneNumber) ? null : view.PhoneNumber
            };

            try
            {
                repository.AddSupplier(newSupplier);
                MessageBox.Show("Proveedor agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!view.NotCloseAtUpdate)
                {
                    view.CloseView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al agregar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSupplier(object? sender, EventArgs e)
        {
            if (!ValidateData() || !view.SupplierId.HasValue) return;

            UpdateSupplierDTO updatedSupplier = new UpdateSupplierDTO()
            {
                Id = view.SupplierId.Value,
                Name = view.SupplierName,
                Cuil = string.IsNullOrWhiteSpace(view.Cuil) ? null : view.Cuil,
                Email = string.IsNullOrWhiteSpace(view.Email) ? null : view.Email,
                PhoneNumber = string.IsNullOrWhiteSpace(view.PhoneNumber) ? null : view.PhoneNumber
            };

            try
            {
                repository.UpdateSupplier(updatedSupplier);
                MessageBox.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!view.NotCloseAtUpdate)
                {
                    view.CloseView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al actualizar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}