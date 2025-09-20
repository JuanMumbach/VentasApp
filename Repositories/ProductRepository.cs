using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;

namespace VentasApp.Repositories
{
    public class ProductRepository : IproductRepository
    {
        public void AddProduct(ProductModel user)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            using (var context = new VentasDBContext())
            {
                return context.Products.ToList();
            }
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> SearchProducts(string searchTerm)
        {
            using (var context = new VentasDBContext())
            {
                return context.Products.Where(p =>
                    p.Name.Contains(searchTerm) || 
                    p.Description.Contains(searchTerm) ||
                    p.Id.ToString().Contains(searchTerm)
                ).ToList();
            }
        }

        public void UpdateProduct(ProductModel user)
        {
            throw new NotImplementedException();
        }
    }
}
