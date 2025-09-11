using Microsoft.Extensions.Configuration;
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

            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets<MainView>()
                .Build();

            string connectionString = configuration["MySqlConnection"];

            Application.Run(new MainView());
        }
    }
}