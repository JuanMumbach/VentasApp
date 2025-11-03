using System;

namespace VentasApp.Views.Supplier
{
    public interface ISupplierView : IBaseForm
    {
        event EventHandler AddSupplierEvent;
        event EventHandler UpdateSupplierEvent;
        event EventHandler CancelSupplierEditEvent;

        string SupplierName { get; set; }
        string Cuil { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        int? SupplierId { get; set; } // Usar 'int?' para indicar modo Agregar/Editar

        bool NotCloseAtUpdate { get; set; }

        void Show();
        void CloseView();
        void ShowDialogView();
    }
}