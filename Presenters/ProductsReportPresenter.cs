using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Views.Dashboard;

namespace VentasApp.Presenters
{
    public class ProductsReportPresenter
    {
        private IProductReportView view;
        private DateOnly StartPeriod;
        private DateOnly EndPeriod;
        private BindingSource dataSource = new BindingSource();

        public ProductsReportPresenter(IProductReportView view, DateOnly startPeriod, DateOnly endPeriod)
        {
            this.view = view;
            this.StartPeriod = startPeriod;
            this.EndPeriod = endPeriod;

            this.view.ChangePeriodLabel(startPeriod, endPeriod);
            this.view.DataGridBindSource(dataSource);

            LoadFilters();

            this.view.FilterChangedEvent += (s, e) => GenerateReportData();

            GenerateReportData();
        }

        private void LoadFilters()
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    var categories = context.Categories.ToList();

                    categories.Insert(0, new CategoryModel { CategoryId = 0, CategoryName = "Todas las Categorías" });
                    view.SetCategoriesDataSource(categories);

                    var suppliers = context.Suppliers.ToList();
                    
                    suppliers.Insert(0, new SupplierModel { SupplierId = 0, SupplierName = "Todos los Proveedores" });
                    view.SetSuppliersDataSource(suppliers);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar filtros: {ex.Message}");
            }
        }

        private void GenerateReportData()
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    
                    var productsQuery = context.Products
                                          .Include(p => p.Category)
                                          .Include(p => p.Supplier)
                                          .Where(p => p.Active)
                                          .AsQueryable(); // sirve para ir agregando filtros

                    
                    if (view.SelectedCategoryId > 0)
                    {
                        productsQuery = productsQuery.Where(p => p.CategoryId == view.SelectedCategoryId);
                    }

                    
                    if (view.SelectedSupplierId > 0)
                    {
                        productsQuery = productsQuery.Where(p => p.SupplierId == view.SelectedSupplierId);
                    }

                    
                    var products = productsQuery.ToList();

                    DateTime startDt = StartPeriod.ToDateTime(new TimeOnly(0, 0));
                    DateTime endDt = EndPeriod.ToDateTime(new TimeOnly(23, 59));

                    
                    var reportData = products.Select(p => {

                        
                        var salesItemsInPeriod = context.SalesItems
                            .Include(si => si.Sale)
                            .Where(si => si.ProductId == p.Id
                                         && si.Sale.CreatedAt >= startDt
                                         && si.Sale.CreatedAt <= endDt
                                         && si.Sale.CanceledAt == null)
                            .ToList();

                        return new
                        {
                            ID = p.Id,
                            Producto = p.Name,
                            Categoria = p.Category != null ? p.Category.CategoryName : "N/A",
                            UnidadesVendidas = salesItemsInPeriod.Sum(si => si.Amount),
                            IngresosGenerados = "$" + salesItemsInPeriod.Sum(si => si.Amount * si.Price).ToString("N2"),
                            StockActual = p.Stock,
                            Proveedor = p.Supplier != null ? p.Supplier.SupplierName : "N/A"
                        };
                    })
                    .OrderByDescending(x => x.UnidadesVendidas) 
                    .ToList();

                    dataSource.DataSource = reportData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}