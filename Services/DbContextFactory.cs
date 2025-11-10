using VentasApp.Models;

namespace VentasApp.Services
{
    /// <summary>
    /// Factory implementation for creating database context instances.
    /// Centralizes DbContext creation and configuration.
    /// </summary>
    public class DbContextFactory : IDbContextFactory
  {
        public VentasDBContext CreateDbContext()
        {
         return new VentasDBContext();
 }
    }
}
