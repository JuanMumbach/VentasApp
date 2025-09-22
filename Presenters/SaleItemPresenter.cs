using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Views.Sale;

namespace VentasApp.Presenters
{
    
    public class SaleItemPresenter
    {
        private ISaleItemView view;
        private ISaleItemRepository itemRepository;
        private IproductRepository productRepository;
        private BindingSource productsBindingSource;
        private IEnumerable<ProductModel> productsList;

        public SaleItemPresenter(ISaleItemView saleItemView,ISaleItemRepository saleItemRepository,IproductRepository _productRepository)
        {
            this.view = saleItemView;
            this.itemRepository = saleItemRepository;
            this.productRepository = _productRepository;
            productsBindingSource = new BindingSource();

            this.view.SetProductosListBindingSource(productsBindingSource);
            this.view.AddItemEvent += OnAddItem;
            this.view.CancelEvent += OnCancel;

            LoadAllProductsList();
            LoadProduct();
        }

        private void OnCancel(object? sender, EventArgs e)
        {
            view.CloseView();
        }

        private void OnAddItem(object? sender, EventArgs e)
        {
            if (view.SaleItemId == null)
            {

                if (view.GetSelectedProductId() == null)
                {
                    MessageBox.Show("Debes seleccionar un producto para agregar un nuevo artículo.",
                                    "Error de Selección",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                ProductModel selectedProduct = productRepository.GetProductById((int)view.GetSelectedProductId());
                
                if (selectedProduct == null)
                {
                    MessageBox.Show("El producto seleccionado no es válido.",
                                    "Error de producto",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (view.Amount <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número positivo.",
                                    "Error de cantidad",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                SaleItemModel saleItem = new SaleItemModel()
                {
                    ProductId = (int)view.GetSelectedProductId(),
                    Amount = view.Amount,
                    SaleId = view.SaleId,
                    Price = selectedProduct.Price * view.Amount
                };

                itemRepository.AddSaleItem(saleItem);

                view.Amount = 1;
                view.SetSelectedProduct(0);
                MessageBox.Show("Artículo agregado correctamente.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            }
            else
            {
                if (view.GetSelectedProductId() == null)
                {
                    // Muestra el mensaje de error
                    MessageBox.Show("Debes seleccionar un producto para agregar un nuevo artículo.",
                                    "Error de Selección",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                ProductModel selectedProduct = productRepository.GetProductById((int)view.GetSelectedProductId());

                if (selectedProduct == null)
                {
                    // Muestra el mensaje de error
                    MessageBox.Show("El producto seleccionado no es válido.",
                                    "Error de producto",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (view.Amount <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número positivo.",
                                    "Error de cantidad",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                SaleItemModel saleItem = itemRepository.GetSaleItemById((int)view.SaleItemId);
                saleItem.ProductId = (int)view.GetSelectedProductId();
                saleItem.SaleId = view.SaleId;
                saleItem.Amount = view.Amount;
                saleItem.Price = selectedProduct.Price * view.Amount;
                itemRepository.UpdateSaleItem(saleItem);
            }
        }

        private void LoadProduct()
        {
            if (view.SaleItemId != null)
            {
                SaleItemModel saleItem = itemRepository.GetSaleItemById((int)view.SaleItemId);
                view.SetSelectedProduct(saleItem.ProductId);
                view.Amount = saleItem.Amount;
            }
            else
            {
                view.Amount = 1;
                view.SetSelectedProduct(0);
            }
        }

        private void LoadAllProductsList()
        {
            productsList = productRepository.GetActiveProducts(true);

            productsBindingSource.DataSource = productsList;
        }
    }
}
