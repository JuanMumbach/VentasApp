using System.Windows.Forms;

namespace VentasApp.Views.Supplier
{
    public interface IListSuppliersView : IBaseForm
    {
        event EventHandler SearchSupplierEvent;
        string searchValue { get; set; }
        bool showDeletedSuppliers { get; set; }
        event EventHandler AddSupplierViewEvent;
        event EventHandler EditSupplierViewEvent;
        event EventHandler DeleteSupplierEvent;
        event EventHandler RestoreSupplierEvent;
        event EventHandler ShowDeletedCheckboxChange;

        public (int? Id, bool? Active)? GetSelectedSupplierInfo();
        void SetSuppliersListBindingSource(BindingSource suppliersList);
        void Show();
        void SetViewOnlyMode();
    }
}