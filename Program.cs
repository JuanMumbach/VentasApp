using Microsoft.Extensions.Configuration;
using VentasApp.Presenters;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.User;
using VentasApp.Utilities;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

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
        }
    }
}