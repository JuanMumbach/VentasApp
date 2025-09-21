using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.Product;

namespace VentasApp.Presenters
{
    public class ListProductsPresenter
    {
        private IListProductsView view;
        private IproductRepository repository;
        private BindingSource productsBindingSource;
        private IEnumerable<Models.ProductModel> productList;

        public ListProductsPresenter(IListProductsView view, IproductRepository repository)
        {
            this.productsBindingSource = new BindingSource();

            this.view = view;
            this.repository = repository;

            this.view.SearchProductEvent += SearchProduct;
            this.view.AddProductViewEvent += LoadAddProductView;
            this.view.DeleteProductEvent += DeleteProduct;
            this.view.SetProductosListBindingSource(productsBindingSource);

            LoadAllProductsList();

            //this.view.BuscarProductoEvent += BuscarProducto;
        }

        private void LoadAddProductView(object? sender, EventArgs e)
        {
            IAddProductView addProductView = new AddProductView();
            new AddProductPresenter(addProductView, repository);
   
            addProductView.ShowDialogView();

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

        private void DeleteProduct(object? sender, EventArgs e)
        {
            var selectedProductInfo = view.GetSelectedProductInfo();
            if (selectedProductInfo.HasValue && selectedProductInfo.Value.Id.HasValue)
            {
                repository.DeleteProduct(selectedProductInfo.Value.Id.Value);
                LoadAllProductsList(); // Recarga la lista para reflejar el cambio
            }
        }
    }
}
