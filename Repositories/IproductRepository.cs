using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Models.DTOs;

namespace VentasApp.Repositories
{
    public interface IproductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        IEnumerable<ProductModel> GetActiveProducts(bool activeState);
        IEnumerable<ProductModel> GetProductsByCategory(string category);
        IEnumerable<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int id);
        void AddProduct(AddProductDTO productDTO);
        void UpdateProduct(ProductModel product);
        void DeleteProduct(int id);
        void RestoreProduct(int id);
        void AddProduct();
    }
}
