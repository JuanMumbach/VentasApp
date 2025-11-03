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

        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
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
            modelBuilder.Entity<RolePermission>()
                .ToTable("role_permission")
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);
        }

    }
}
