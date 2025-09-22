using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Models.DTOs;
using VentasApp.Repositories;
using VentasApp.Views.Product;

namespace VentasApp.Presenters
{
    public class ProductPresenter
    {
        private IProductView view;
        private IproductRepository repository;
        public ProductPresenter(IProductView view, IproductRepository repository)
        {
            this.view = view;
            this.repository = repository;
            
            this.view.AddProductEvent += AddProduct;
            this.view.UpdateProductEvent += UpdateProduct;
            this.view.CancelProductAddEvent += CancelAddProduct;
            this.view.ChangeProductImageEvent += ChangeProductImage;
            if (this.view.ProductId != null) LoadProductData();
        }

        private void LoadProductData()
        {
            ProductModel product = repository.GetProductById((int)this.view.ProductId);
            if (product != null)
            {
                this.view.ProductName = product.Name;
                this.view.ProductDescription = product.Description;
                this.view.Price = product.Price;
                this.view.Stock = (int)product.Stock;
                this.view.CategoryId = product.CategoryId;
                this.view.SupplierId = product.SupplierId;
                this.view.ImagePath = product.ImagePath;
                if (this.view.ImagePath != null) this.view.SecureImagePath = true;
                UpdateViewProductImage();
            }
        }

        private void ChangeProductImage(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // El usuario ha seleccionado un archivo.
                // Ahora puedes guardar la ruta en una propiedad de la vista.
                // Por ejemplo, un campo de texto oculto o una propiedad en la clase.
                string imagePath = openFileDialog.FileName;

                // Muestra el nombre del archivo en un label para el usuario
                //ImageNameLabel.Text = Path.GetFileName(imagePath);

                // Asigna la ruta a una propiedad pública de la vista para que el Presenter pueda acceder a ella
                // Por ejemplo:
                this.view.ImagePath = imagePath;
                this.view.SecureImagePath = false;
            }
            UpdateViewProductImage();
        }

        private void UpdateViewProductImage()
        {
            this.view.UpdateViewProductImage();
        }
        private void CancelAddProduct(object? sender, EventArgs e)
        {
            this.view.CloseView();
        }

        private void AddProduct(object? sender, EventArgs e)
        {
            if (!this.view.SecureImagePath && this.view.ImagePath != null)
            {
                string? newImagePath = SaveImageInAppDomain();
                if (newImagePath != null)
                {
                    this.view.SecureImagePath = true;
                    this.view.ImagePath = newImagePath;
                }
            }

            if (string.IsNullOrEmpty(view.ProductName))
            {
                MessageBox.Show("El nombre del producto no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (view.Price <= 0)
            {
                MessageBox.Show("El precio debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (view.Stock < 0)
            {
                MessageBox.Show("El stock debe ser un número no negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (view.CategoryId < 0)
            {
                MessageBox.Show("La categoria seleccionada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (view.SupplierId < 0)
            {
                MessageBox.Show("El proveedor seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddProductDTO newProduct = new AddProductDTO()
            {
                Name = view.ProductName,
                Description = view.ProductDescription,
                Price = view.Price,
                Stock = (uint)view.Stock,
                CategoryId = view.CategoryId,
                SupplierId = view.SupplierId,
                ImagePath = view.ImagePath
            };
            repository.AddProduct(newProduct);

            if (!view.NotCloseAtUpdate)
            {
                view.CloseView();
            }

        }

        private void UpdateProduct(object? sender, EventArgs e)
        {
            if (!this.view.SecureImagePath && this.view.ImagePath != null)
            {
                string? newImagePath = SaveImageInAppDomain();
                if (newImagePath != null)
                {
                    this.view.SecureImagePath = true;
                    this.view.ImagePath = newImagePath;
                }
            }

            if (view.Price <= 0)
            {
                MessageBox.Show("El precio debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (view.Stock < 0)
            {
                MessageBox.Show("El stock debe ser un número no negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (view.CategoryId < 0)
            {
                MessageBox.Show("La categoria seleccionada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (view.SupplierId < 0)
            {
                MessageBox.Show("El proveedor seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateProductDTO newProduct = new UpdateProductDTO()
            {
                Id = (int)this.view.ProductId!,
                Name = view.ProductName,
                Description = view.ProductDescription,
                Price = view.Price,
                Stock = (uint)view.Stock,
                CategoryId = view.CategoryId,
                SupplierId = view.SupplierId,
                ImagePath = view.ImagePath
            };
            repository.UpdateProduct(newProduct);

            if (!view.NotCloseAtUpdate)
            {
                view.CloseView();
            }
        }

        private string? SaveImageInAppDomain()
        {
            string imagePath = view.ImagePath;
            string savedImagePath = null;

            if (!string.IsNullOrEmpty(imagePath))
            {
                // 1. Define la carpeta de destino para las imágenes
                string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // 2. Genera un nombre de archivo único para evitar duplicados
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagePath);
                savedImagePath = Path.Combine(destinationFolder, fileName);

                // 3. Mueve el archivo a la carpeta de destino
                File.Copy(imagePath, savedImagePath, true);
                return "images/" + fileName;
            }
            return null;
        }
    }
}
