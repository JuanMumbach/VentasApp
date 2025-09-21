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
            this.view.ChangeProductImageEvent += ChangeProductImage;
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
            UpdateProductImage();
        }

        private void UpdateProductImage()
        {
            this.view.UpdateProductImage();
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
