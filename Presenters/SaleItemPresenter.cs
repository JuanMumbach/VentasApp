using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private SaleModel sale;
        private SaleItemModel? saleItem;
        private ISaleItemView view;
        private ISaleItemRepository itemRepository;
        private IproductRepository productRepository;
        private BindingSource productsBindingSource;
        private IEnumerable<ProductModel> productsList;

        public SaleItemPresenter(ISaleItemView saleItemView,ISaleItemRepository saleItemRepository,IproductRepository _productRepository, SaleModel sale)
        {
            this.sale = sale;
            this.view = saleItemView;
            this.itemRepository = saleItemRepository;
            this.productRepository = _productRepository;
            productsBindingSource = new BindingSource();

            this.view.SetProductosListBindingSource(productsBindingSource);
            this.view.CancelEvent += OnCancel;
            this.view.SearchProductEvent += SearchProduct;
            this.view.OnAmountChangedEvent += CompareAmountWithStock;
            this.view.OnSelectedProductChangedEvent += CompareAmountWithStock;

            this.view.AddItemEvent += OnAddItem;
            LoadAllProductsList();
            LoadProduct();
        }

        public SaleItemPresenter(ISaleItemView saleItemView, ISaleItemRepository saleItemRepository, IproductRepository _productRepository, SaleItemModel saleItem)
        {
            this.saleItem = saleItem;

            this.view = saleItemView;
            this.view.SetEditMode(saleItem.Product.Name);
            this.view.searchValue = saleItem.Product.Name;

            this.itemRepository = saleItemRepository;
            this.productRepository = _productRepository;
            productsBindingSource = new BindingSource();

            this.view.SetProductosListBindingSource(productsBindingSource);
            this.view.CancelEvent += OnCancel;
            this.view.SearchProductEvent += SearchProduct;
            this.view.OnAmountChangedEvent += CompareAmountWithStock;
            this.view.OnSelectedProductChangedEvent += CompareAmountWithStock;

            this.view.EditItemEvent += OnEditItem;
            LoadAllProductsList();
            LoadProduct();

            /*this.saleItem = saleItem;
            this.view.AddItemEvent -= OnAddItem;
            this.view.EditItemEvent += OnEditItem;
            LoadProduct();*/
        }

        private void CompareAmountWithStock(object? sender, EventArgs e)
        {
            if (view.GetSelectedProductId() == null) return;
            
            ProductModel selectedProduct = productRepository.GetProductById((int)view.GetSelectedProductId());

            if (selectedProduct == null) return;
            
            if (selectedProduct.Stock <= 0)
            {
                //this.view.ClearSelectedProduct();
                this.view.SetSelectedProduct(-1);
                MessageBox.Show("El producto seleccionado no tiene stock disponible.",
                                "Sin stock",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (view.Amount <= 0)
            {
                view.Amount = 1;
                return;
            }

            if (view.Amount > selectedProduct.Stock)
            {
                view.Amount = (int)selectedProduct.Stock;
                return;
            }
        }

        private void SearchProduct(object? sender, EventArgs e)
        {
            LoadAllProductsList();
        }

        private void OnCancel(object? sender, EventArgs e)
        {
            view.CloseView();
        }

        private void OnAddItem(object? sender, EventArgs e)
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

            if (view.Amount > selectedProduct.Stock)
            {
                MessageBox.Show("La cantidad seleccionada es mayor al stock disponible",
                                "Error de cantidad",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            //itemRepository.AddSaleItem(saleItem); //
            SaleItemModel newSaleItem = new SaleItemModel()
            {
                Id = 0,
                ProductId = selectedProduct.Id,
                Product = selectedProduct,
                Amount = view.Amount,
                Price = selectedProduct.Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (sale.SaleItems.Any(item => item.ProductId == newSaleItem.ProductId))
            {
                var existingItem = sale.SaleItems.FirstOrDefault(item => item.ProductId == newSaleItem.ProductId);

                if (existingItem != null)
                {
                    existingItem.Amount += newSaleItem.Amount;
                }
            }
            else
            {
                sale.SaleItems.Add(newSaleItem);
            }

            view.Amount = 1;
            view.SetSelectedProduct(0);
            MessageBox.Show("Artículo agregado correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            LoadAllProductsList();
        }

        private void OnEditItem(object? sender, EventArgs e)
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

            //saleItem.ProductId = (int)view.GetSelectedProductId();
            saleItem.Product = selectedProduct;
            saleItem.Amount = view.Amount;
            saleItem.Price = selectedProduct.Price;
            view.SetSelectedProduct(0);
            MessageBox.Show("Artículo actualizado correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.view.CloseView();
        }
        private void LoadProduct()
        {
            if (saleItem != null)
            {
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
            string searchTerm = view.searchValue ?? string.Empty;

            if (saleItem != null)
            {
                productsList = new List<ProductModel> { saleItem.Product };
            }
            else
            {
                if (String.IsNullOrEmpty(searchTerm))
                {
                    productsList = productRepository.GetActiveProducts(true).ToList();
                }
                else
                {
                    productsList = productRepository.GetActiveProducts(true)
                    .Where(p =>
                        (p.Name != null && p.Name.ToLower().Contains(searchTerm)) ||
                        p.Id.ToString().Contains(searchTerm) ||
                        (p.Category != null && p.Category.CategoryName.ToLower().Contains(searchTerm)) ||
                        (p.Description != null && p.Description.ToLower().Contains(searchTerm)))
                    .ToList();

                }
            }

            

            var displayList = productsList.Select(p => new
            {
                p.Id,
                Name = p.Name,
                p.Price,
                Stock = (int)p.Stock,
                Category = p.Category.CategoryName
            }).ToList();
            
            if (sale != null)
            {
                displayList = productsList.Select(p => new
                {
                    p.Id,
                    Name = p.Name,
                    p.Price,
                    Stock = (int)p.Stock - (sale?.SaleItems.Where(si => si.ProductId == p.Id).Sum(si => si.Amount) ?? 0),
                    Category = p.Category.CategoryName
                }).ToList();
            }




                productsBindingSource.DataSource = displayList;
        }
    }
}
