using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models.DTOs;
using VentasApp.Repositories;
using VentasApp.Views.Product;

namespace VentasApp.Presenters
{
    public class AddProductPresenter
    {
        private IAddProductView view;
        private IproductRepository repository;
        public AddProductPresenter(IAddProductView view, IproductRepository repository)
        {
            this.view = view;
            this.repository = repository;
            
            this.view.AddProductEvent += AddProduct;
            this.view.CancelProductAddEvent += CancelAddProduct;
        }

        private void CancelAddProduct(object? sender, EventArgs e)
        {
            this.view.CloseView();
        }

        private void AddProduct(object? sender, EventArgs e)
        {
            AddProductDTO newProduct = new AddProductDTO()
            {
                Name = view.ProductName,
                Description = view.ProductDescription,
                Price = view.Price,
                Stock = (uint)view.Stock,
                CategoryId = view.CategoryId,
                SupplierId = view.SupplierId
            };
            repository.AddProduct(newProduct);
        }
    }
}
