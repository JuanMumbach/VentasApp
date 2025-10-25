using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentasApp.Models;

namespace VentasApp.Views.Sale
{
    public interface IListSalesView
    {
        // Propiedad que el Presenter usará para inyectar la lista de ventas
        BindingSource SaleListBindingSource { set; }

        // Evento para cargar las ventas al abrir la vista
        event EventHandler LoadAllSalesEvent;

        // Evento para manejar la restauración de una venta cancelada
        event EventHandler RestoreSaleEvent;

        // Evento para manejar la cancelación de una venta
        event EventHandler CancelSaleEvent;

        // Método para obtener el ID de la venta seleccionada en el DataGridView
        int? GetSelectedSaleId();

        // Método para mostrar un mensaje al usuario (opcional, pero útil)
        void ShowMessage(string message, string title, MessageBoxIcon icon);
    }
}