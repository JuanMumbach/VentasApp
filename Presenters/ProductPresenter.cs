using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views;

namespace VentasApp.Presenters
{
    public class ProductPresenter
    {
        private IproductsView view;
        private IproductRepository repository;
        private BindingSource productsBindingSource;
        private IEnumerable<Models.ProductModel> productList;

        public ProductPresenter(IproductsView view, IproductRepository repository)
        {
            this.productsBindingSource = new BindingSource();

            this.view = view;
            this.repository = repository;

            this.view.SearchProductEvent += SearchProduct;

            this.view.SetProductosListBindingSource(productsBindingSource);

            LoadAllProductsList();

            //this.view.BuscarProductoEvent += BuscarProducto;
        }

        private void LoadAllProductsList()
        {
            productList = repository.GetAllProducts();
            productsBindingSource.DataSource = productList;
        }

        private void SearchProduct(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(view.searchValue))
            {
                productList = repository.GetAllProducts();
            }
            else
            {
                productList = repository.SearchProducts(view.searchValue);
            }

            productsBindingSource.DataSource = productList;
        }
    }
}
