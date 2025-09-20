using Microsoft.Extensions.Configuration;
using VentasApp.Presenters;
using VentasApp.Repositories;
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

            productsView productView = new productsView();
            ProductRepository productRepository = new ProductRepository();

            new ProductPresenter(productView, productRepository);

            Application.Run((Form)productView);
        }
    }
}