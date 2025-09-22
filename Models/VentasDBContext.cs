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
        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<SaleItemModel> SalesItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets<VentasDBContext>()
                .Build();

            string connectionString = configuration["MySqlConnection"];

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Configurar la clave primaria compuesta para SaleItem
            modelBuilder.Entity<SaleItemModel>()
                .HasKey(si => new { si.SaleId, si.ProductId });

            // 2. Configurar la relación con la tabla 'Sale'
            modelBuilder.Entity<SaleItemModel>()
                .HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId);

            // 3. Configurar la relación con la tabla 'Product'
            modelBuilder.Entity<SaleItemModel>()
                .HasOne(si => si.Product)
                .WithMany(p => p.SaleItems)
                .HasForeignKey(si => si.ProductId);
        }
    }
}
