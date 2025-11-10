using VentasApp.Models;

namespace VentasApp.Services
{
    /// <summary>
    /// Factory interface for creating database context instances.
    /// Allows for better testability and centralized DbContext management.
  /// </summary>
    public interface IDbContextFactory
    {
        VentasDBContext CreateDbContext();
}
}
