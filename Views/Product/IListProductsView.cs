namespace VentasApp.Views.Product
{
    public interface IListProductsView : IBaseForm
    {
        event EventHandler SearchProductEvent;
        string searchValue { get; set; }
        bool showDeletedProducts { get; set; }
        event EventHandler AddProductViewEvent;
        event EventHandler EditProductViewEvent;
        event EventHandler DeleteProductEvent;
        event EventHandler RestoreProductEvent;
        event EventHandler ShowDeletedCheckboxChange;
        public int? GetSelectedProductId();
        public (int? Id, bool? Active)? GetSelectedProductInfo();
        void SetProductosListBindingSource(BindingSource productosList);
        void CloseView();
    }
}