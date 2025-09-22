using Microsoft.EntityFrameworkCore;
using VentasApp.Models;

namespace VentasApp.Utilities
{
    public static class DatabaseTestHelper
    {
        public static void TestDatabaseConnection()
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    // Verificar conexión
                    var canConnect = context.Database.CanConnect();
                    Console.WriteLine($"¿Puede conectar a la base de datos?: {canConnect}");

                    if (canConnect)
                    {
                        // Verificar si la tabla Users existe
                        var tableExists = context.Database.SqlQueryRaw<int>(
                            "SELECT COUNT(*) as Count FROM information_schema.tables WHERE table_name = 'user' AND table_schema = DATABASE()"
                        ).First();
                        
                        Console.WriteLine($"¿Existe la tabla 'user'?: {tableExists > 0}");

                        if (tableExists > 0)
                        {
                            // Mostrar estructura de la tabla
                            Console.WriteLine("Estructura de la tabla 'user':");
                            var columns = context.Database.SqlQueryRaw<dynamic>(
                                "DESCRIBE user"
                            ).ToList();
                            
                            // Intentar obtener algunos usuarios
                            var userCount = context.Users.Count();
                            Console.WriteLine($"Número de usuarios en la tabla: {userCount}");
                        }
                        else
                        {
                            Console.WriteLine("La tabla 'user' no existe. Necesitas crearla.");
                            Console.WriteLine("SQL para crear la tabla:");
                            Console.WriteLine(@"
CREATE TABLE user (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(255) NOT NULL UNIQUE,
    passwordhash TEXT NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    role_id VARCHAR(20) NOT NULL,
    phone VARCHAR(15),
    active_state BOOLEAN NOT NULL DEFAULT TRUE,
    created_at DATETIME NOT NULL,
    updated_at DATETIME NOT NULL
);");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al probar la conexión: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }
    }
}