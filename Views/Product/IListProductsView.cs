namespace VentasApp.Views.Product
{
    public interface IListProductsView
    {
        event EventHandler SearchProductEvent;
        string searchValue { get; set; }
        event EventHandler AddProductViewEvent;

        void SetProductosListBindingSource(BindingSource productosList);
    }
}