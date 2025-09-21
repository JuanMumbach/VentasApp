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
        event EventHandler UpdateProductEvent;
        event EventHandler CancelProductAddEvent;
        event EventHandler ChangeProductImageEvent;
        string ProductName { get; set; }
        string ProductDescription { get; set; }
        decimal Price { get; set; }
        int Stock { get; set; }
        int CategoryId { get; set; }
        int? SupplierId { get; set; }
        int? ProductId { get; set; }

        string? ImagePath { get; set; }
        bool SecureImagePath { get; set; }
        bool NotCloseAtUpdate { get; set; }

        void Show();
        void CloseView();
        void ShowDialogView();
        public void UpdateViewProductImage();
    }
}
