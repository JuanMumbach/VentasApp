using Microsoft.Extensions.Configuration;
using VentasApp.Presenters;
using VentasApp.Repositories;
using VentasApp.Views;
using VentasApp.Views.Auth;
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

            // Mostrar pantalla de Login
            ILoginView loginView = new LoginView();
            UserRepository userRepository = new UserRepository();
            LoginPresenter loginPresenter = new LoginPresenter(loginView, userRepository);
            
            loginView.ShowView();

            // Si el login fue exitoso, mostrar la ventana principal
            if (loginPresenter.LoginSuccessful && SessionManager.Instance.IsAuthenticated)
            {
                Console.WriteLine($"Usuario autenticado: {SessionManager.Instance.CurrentUser?.Username}");
                
                // Crear el formulario principal
                MainView mainView = new MainView();
                new MainViewPresenter(mainView);

                // Ejecutar la aplicación con el formulario principal
                Application.Run(mainView);
            }
            else
            {
                Console.WriteLine("Login cancelado o fallido. Cerrando aplicación.");
            }
        }
    }
}