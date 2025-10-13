using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models
{
    public class VentasDBContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<SaleItemModel> SalesItems { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets<VentasDBContext>()
                .Build();

            string connectionString = configuration["MySqlConnection"];

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

    }
}
