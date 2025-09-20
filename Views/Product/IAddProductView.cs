using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;

namespace VentasApp.Views.Product
{
    public interface IAddProductView
    {
        event EventHandler AddProductEvent;
        event EventHandler CancelProductAddEvent;
        string ProductName { get; set; }
        string ProductDescription { get; set; }
        decimal Price { get; set; }
        int Stock { get; set; }
        int CategoryId { get; set; }
        int? SupplierId { get; set; }

        void Show();

        void CloseView();
        void ShowDialogView();
    }
}
