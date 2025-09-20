using Microsoft.EntityFrameworkCore;
using VentasApp.Models;
using VentasApp.Models.DTOs;

namespace VentasApp.Repositories
{
    public class ProductRepository : IproductRepository
    {
        public void AddProduct(AddProductDTO productDTO)
        {
            using (var context = new VentasDBContext())
            {
                var product = new ProductModel
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Price = productDTO.Price,
                    Stock = productDTO.Stock,
                    CategoryId = productDTO.CategoryId,
                    SupplierId = productDTO.SupplierId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Active = true
                };

                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void AddProduct()
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
                )
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToList();
            }
        }

        public void UpdateProduct(ProductModel user)
        {
            throw new NotImplementedException();
        }
    }
}
