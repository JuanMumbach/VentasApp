namespace VentasApp.Views
{
    public interface IproductsView
    {
        event EventHandler SearchProductEvent;
        string searchValue { get; set; }

        void SetProductosListBindingSource(BindingSource productosList);
    }
}