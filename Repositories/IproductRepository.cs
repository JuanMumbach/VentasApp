using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;

namespace VentasApp.Repositories
{
    public interface IproductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        IEnumerable<ProductModel> GetProductsByCategory(string category);
        IEnumerable<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int id);
        void AddProduct(ProductModel user);
        void UpdateProduct(ProductModel user);
        void DeleteProduct(int id);
    }
}
