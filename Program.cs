using Microsoft.Extensions.Configuration;
using VentasApp.Presenters;
using VentasApp.Repositories;
using VentasApp.Views;
<<<<<<< Updated upstream
using VentasApp.Views.User;
using VentasApp.Utilities;
=======
>>>>>>> Stashed changes

namespace VentasApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure application
            ApplicationConfiguration.Initialize();

<<<<<<< Updated upstream
            // Probar conexión a base de datos antes de continuar
            Console.WriteLine("=== PRUEBA DE CONEXIÓN A BASE DE DATOS ===");
            DatabaseTestHelper.TestDatabaseConnection();
            Console.WriteLine("==========================================");

            // Crear el formulario principal mejorado
            MainView mainView = new MainView();
            
            // Inicializar vista de productos
            ListProductsView productView = new ListProductsView();
            ProductRepository productRepository = new ProductRepository();
            new ListProductsPresenter(productView, productRepository);

            // Inicializar vista de usuarios
            ListUsersView usersView = new ListUsersView();
            UserRepository userRepository = new UserRepository();
            new ListUsersPresenter(usersView, userRepository);

            // Por ahora ejecutar la vista de usuarios
            Application.Run((Form)usersView);
=======
            // Ensure required directories exist
            AppConfiguration.EnsureDirectoriesExist();

            // Initialize logger
            ILogger logger = new FileLogger();

            try
            {
                logger.LogInformation("=== Application Starting ===");
                logger.LogInformation($"Application: {AppConfiguration.ApplicationName}");
                logger.LogInformation($"Version: {AppConfiguration.ApplicationVersion}");
                logger.LogInformation($"Environment: {Environment.OSVersion}");

                // Set application theme
                Themes.SetLightTheme();
                logger.LogInformation("Light theme applied");

                // Create and configure login view
                LoginView loginView = new LoginView();
                IUserRepository userRepository = new UserRepository();

                new LoginPresenter(loginView, userRepository, logger);

                logger.LogInformation("Application initialized successfully");

                // Run the application
                Application.Run((Form)loginView);

                logger.LogInformation("=== Application Closing ===");
            }
            catch (Exception ex)
            {
                logger.LogError("Fatal error during application startup", ex);
                MessageBox.Show(
                    "Ocurrió un error crítico al iniciar la aplicación. Revise los logs para más detalles.",
                    "Error Fatal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
>>>>>>> Stashed changes
        }
    }
}