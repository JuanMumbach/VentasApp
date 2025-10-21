using Microsoft.Extensions.Configuration;
using VentasApp.Presenters;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views;


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


            Themes.SetLightTheme();
            LoginView loginView = new LoginView();
            new LoginPresenter(loginView, new UserRepository());
            
            Application.Run((Form)loginView);
        }
    }
}