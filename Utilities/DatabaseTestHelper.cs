using System;
using VentasApp.Models;

namespace VentasApp.Utilities
{
    /// <summary>
    /// Utilidad para probar la conexión a la base de datos.
    /// </summary>
    public static class DatabaseTestHelper
    {
        /// <summary>
        /// Prueba la conexión a la base de datos e imprime el resultado en consola.
        /// </summary>
        public static void TestDatabaseConnection()
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    // Intentar realizar una operación simple para verificar la conexión
                    var canConnect = context.Database.CanConnect();
                    
                    if (canConnect)
                    {
                        Console.WriteLine("? Conexión a la base de datos exitosa");
                        
                        // Obtener información adicional
                        var userCount = context.Users.Count();
                        var productCount = context.Products.Count();
                        
                        Console.WriteLine($"  - Usuarios en la base de datos: {userCount}");
                        Console.WriteLine($"  - Productos en la base de datos: {productCount}");
                    }
                    else
                    {
                        Console.WriteLine("? No se pudo conectar a la base de datos");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error al conectar con la base de datos: {ex.Message}");
                Console.WriteLine($"  Detalles: {ex.InnerException?.Message}");
            }
        }
    }
}
