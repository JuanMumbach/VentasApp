namespace VentasApp.Views.Product
{
    public interface IListProductsView
    {
        event EventHandler SearchProductEvent;
        string searchValue { get; set; }
        event EventHandler AddProductViewEvent;
        event EventHandler DeleteProductEvent;
        event EventHandler RestoreProductEvent;
        public int? GetSelectedProductId();
        public (int? Id, bool? Active)? GetSelectedProductInfo();
        void SetProductosListBindingSource(BindingSource productosList);
    }
}