using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views;
using VentasApp.Views.Product;
using static VentasApp.Services.PermissionManager;

namespace VentasApp.Presenters
{
    public class ListProductsPresenter
    {
        private IListProductsView view;
        private IproductRepository repository;
        private BindingSource productsBindingSource;
        private IEnumerable<Models.ProductModel> productList;
        private bool accessGranted = false;

        public ListProductsPresenter(IListProductsView view, IproductRepository repository)
        {
            this.productsBindingSource = new BindingSource();

            this.view = view;
            this.repository = repository;

            this.view.FormLoadEvent += CheckForPermission;
            this.view.SearchProductEvent += SearchProduct;
            this.view.AddProductViewEvent += LoadAddProductView;
            this.view.EditProductViewEvent += LoadEditProductView;
            this.view.DeleteProductEvent += DeleteProduct;
            this.view.RestoreProductEvent += RestoreProduct;
            this.view.ShowDeletedCheckboxChange += (s, e) => LoadAllProductsList();
            this.view.SetProductosListBindingSource(productsBindingSource);

            LoadAllProductsList();

            //this.view.BuscarProductoEvent += BuscarProducto;
        }

        private void CheckForPermission(object? sender, EventArgs e)
        {
            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.ProductsManage))
            {
                accessGranted = true;
                LoadAllProductsList();
                return;
            }

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.ProductsView))
            {
                accessGranted = true;
                view.SetViewOnlyMode();
                LoadAllProductsList();
                return;
            }

            

            MessageBox.Show("No tiene permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            view.CloseView();
        }

        private void LoadEditProductView(object? sender, EventArgs e)
        {
            int? id = view.GetSelectedProductId();
            if (id != null)
            {
                IProductView addProductView = new ProductView((int)id);
                new ProductPresenter(addProductView, repository);

                addProductView.ShowDialogView();
                LoadAllProductsList();
            }
        }
        private void LoadAddProductView(object? sender, EventArgs e)
        {
            IProductView addProductView = new ProductView();
            new ProductPresenter(addProductView, repository);
   
            addProductView.ShowDialogView();
            LoadAllProductsList();
        }

        private void LoadAllProductsList()
        {
            if (!accessGranted) return;
            
            if (view.showDeletedProducts)
            { productList = repository.GetAllProducts(); }
            else
            { productList = repository.GetActiveProducts(true); }


            var displayList = productList.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category.CategoryName,
                Supplier = p.Supplier != null ? p.Supplier.SupplierName : "No registrado",
                Active = p.Active
            }).ToList();
            productsBindingSource.DataSource = displayList;
        }

        private void SearchProduct(object? sender, EventArgs e)
        {
            if (!accessGranted) return;

            if (string.IsNullOrWhiteSpace(view.searchValue))
            {
                LoadAllProductsList();
            }
            else
            {
                
                if (view.showDeletedProducts)
                { productList = repository.SearchProducts(view.searchValue);}
                else
                { productList = repository.SearchProducts(view.searchValue, activeState: true); }
            }

            var displayList = productList.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category.CategoryName,
                Supplier = p.Supplier != null ? p.Supplier.SupplierName : "No registrado",
                Active = p.Active
            }).ToList();
            productsBindingSource.DataSource = displayList;

        }

        private void DeleteProduct(object? sender, EventArgs e)
        {
            var selectedProductInfo = view.GetSelectedProductInfo();
           

            if (selectedProductInfo.HasValue && selectedProductInfo.Value.Id.HasValue)
            {
                repository.DeleteProduct(selectedProductInfo.Value.Id.Value);
                LoadAllProductsList(); // Recarga la lista para reflejar el cambio
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RestoreProduct(object? sender, EventArgs e)
        {
            var selectedProductInfo = view.GetSelectedProductInfo();
            if (selectedProductInfo.HasValue && selectedProductInfo.Value.Id.HasValue)
            {
                repository.RestoreProduct(selectedProductInfo.Value.Id.Value);
                LoadAllProductsList(); // Recarga la lista para reflejar el cambio
            }
            else
            {
                MessageBox.Show("Seleccione un producto para restaurar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
