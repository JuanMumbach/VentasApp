using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Models.DTOs;
using VentasApp.Services;
using VentasApp.Services;
using VentasApp.Views.Dashboard;

namespace VentasApp.Presenters
{
    public class ProductsReportPresenter
    {
        private IProductReportView view;
        private DateOnly StartPeriod;
        private DateOnly EndPeriod;
        private BindingSource dataSource = new BindingSource();
        private List<ProductReportDTO> currentDataList;

        public ProductsReportPresenter(IProductReportView view, DateOnly startPeriod, DateOnly endPeriod)
        {
            this.view = view;
            this.StartPeriod = startPeriod;
            this.EndPeriod = endPeriod;

            this.view.ChangePeriodLabel(startPeriod, endPeriod);
            this.view.DataGridBindSource(dataSource);

            LoadFilters();

            this.view.FilterChangedEvent += (s, e) => GenerateReportData();
            this.view.ExportReportEvent += ExportarPdf;

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

                        return new ProductReportDTO
                        {
                            ID = p.Id,
                            Producto = p.Name,
                            Categoria = p.Category != null ? p.Category.CategoryName : "N/A",
                            Vendidos = salesItemsInPeriod.Sum(si => si.Amount),
                            Ingresos = "$" + salesItemsInPeriod.Sum(si => si.Amount * si.Price).ToString("N2"),
                            Stock = p.Stock,
                            Proveedor = p.Supplier != null ? p.Supplier.SupplierName : "N/A"
                        };
                    })
                    .OrderByDescending(x => x.Vendidos) 
                    .ToList();

                    this.currentDataList = new List<ProductReportDTO>(reportData);

                    dataSource.DataSource = reportData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarPdf(object? sender, EventArgs e)
        {
            if (currentDataList == null || currentDataList.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.FileName = $"Reporte_Productos_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfService pdfService = new PdfService();

                    string titulo = "Reporte de Productos";
                    string periodo = $"Periodo: {StartPeriod} - {EndPeriod}";

                    pdfService.ExportarDatosTabla(titulo, periodo, currentDataList, saveFileDialog.FileName);

                    MessageBox.Show("Reporte exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    new Process { StartInfo = new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true } }.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar: {ex.Message}");
                }
            }
        }
    }
}