namespace VentasApp.Views
{
    public interface IproductsView
    {
        event EventHandler BuscarProductoEvent;

        void SetProductosListBindingSource(BindingSource productosList);
    }
}