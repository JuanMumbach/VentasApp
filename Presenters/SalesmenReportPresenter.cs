using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Models.DTOs; 
using VentasApp.Repositories;
using VentasApp.Services;   
using VentasApp.Views.Dashboard;

namespace VentasApp.Presenters
{
    public class SalesmenReportPresenter
    {
        private ISalesmenReportView view;
        private DateOnly StartPeriod;
        private DateOnly EndPeriod;
        private BindingSource dataSource = new BindingSource();


        private List<SalesmenReportDTO> currentDataList;

        public SalesmenReportPresenter(ISalesmenReportView view, DateOnly startPeriod, DateOnly endPeriod)
        {
            this.view = view;
            this.StartPeriod = startPeriod;
            this.EndPeriod = endPeriod;

            this.view.ChangePeriodLabel(startPeriod, endPeriod);
            this.view.DataGridBindSource(dataSource);

            // Suscribir al evento de exportar
            this.view.ExportReportEvent += ExportarPdf;

            GenerateReportData();
        }

        private void GenerateReportData()
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    int salesmanRoleId = context.Roles.FirstOrDefault(r => r.RoleName == "Salesperson")?.RoleId ?? 0;
                    var salesmen = context.Users.Where(u => u.RoleId == salesmanRoleId).ToList();

                    DateTime startDt = StartPeriod.ToDateTime(new TimeOnly(0, 0));
                    DateTime endDt = EndPeriod.ToDateTime(new TimeOnly(23, 59));

                    var reportData = salesmen.Select(s => new SalesmenReportDTO
                    {
                        Vendedor = s.FullName,
                        Ventas = context.Sales
                            .Where(sale => sale.UserId == s.Id
                                            && sale.CreatedAt >= startDt
                                            && sale.CreatedAt <= endDt
                            )
                            .Count(),
                        Ingresos = "$" + (context.Sales
                            .Where(sale => sale.UserId == s.Id
                                            && sale.CreatedAt >= startDt
                                            && sale.CreatedAt <= endDt
                            )
                            .Sum(sale => (decimal?)sale.TotalPrice) ?? 0).ToString("N2"),
                        Canceladas = context.Sales
                            .Where(sale => sale.UserId == s.Id
                                            && sale.CreatedAt >= startDt
                                            && sale.CreatedAt <= endDt
                                            && sale.CanceledAt != null
                            )
                            .Count(),
                    }).ToList();

                    this.currentDataList = reportData;

                    dataSource.DataSource = reportData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarPdf(object? sender, EventArgs e)
        {
            if (currentDataList == null || currentDataList.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.FileName = $"Reporte_Vendedores_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var context = new VentasDBContext())
                    {
                        // 1. Configurar fechas
                        DateTime startDt = StartPeriod.ToDateTime(new TimeOnly(0, 0));
                        DateTime endDt = EndPeriod.ToDateTime(new TimeOnly(23, 59));

                        // 2. Obtener ID del Rol
                        int salesmanRoleId = context.Roles.FirstOrDefault(r => r.RoleName == "Salesperson")?.RoleId ?? 0;

                        // 3. QUERY UNIFICADA CON JOIN
                        // Como Sale no tiene 'User', los unimos manualmente por UserId
                        var queryBase = from s in context.Sales
                                        join u in context.Users on s.UserId equals u.Id
                                        where u.RoleId == salesmanRoleId
                                           && s.CreatedAt >= startDt
                                           && s.CreatedAt <= endDt
                                           && s.CanceledAt == null
                                        select new { Venta = s, Usuario = u };

                        // 4. Calcular Totales
                        int totalVentas = queryBase.Count();

                        // Validamos si hay datos para evitar error en Sum si está vacío
                        decimal totalIngresos = 0;
                        if (totalVentas > 0)
                        {
                            totalIngresos = queryBase.Sum(x => x.Venta.TotalPrice);
                        }

                        // 5. Encontrar al Mejor Vendedor
                        var mejorDatos = queryBase
                             .GroupBy(x => x.Usuario.FullName)
                             .Select(g => new {
                                 Nombre = g.Key,
                                 Total = g.Sum(x => x.Venta.TotalPrice)
                             })
                             .OrderByDescending(x => x.Total)
                             .FirstOrDefault();

                        string nombreMejor = mejorDatos != null ? mejorDatos.Nombre : "N/A";

                        // 6. Crear el DTO y Exportar
                        var exportDto = new SalesmenReportExportDTO
                        {
                            Periodo = $"Periodo: {StartPeriod} - {EndPeriod}",
                            TotalVentas = totalVentas,
                            TotalIngresos = totalIngresos,
                            MejorVendedor = nombreMejor,
                            DetalleVendedores = this.currentDataList
                        };

                        PdfService pdfService = new PdfService();
                        pdfService.ExportarReporteVendedores(exportDto, saveFileDialog.FileName);

                        MessageBox.Show("Reporte exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        new Process { StartInfo = new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true } }.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}