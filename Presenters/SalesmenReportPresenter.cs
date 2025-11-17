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
                    PdfService pdfService = new PdfService();

                    string titulo = "Rendimiento de Vendedores";
                    string periodo = $"Periodo: {StartPeriod} - {EndPeriod}";

                    pdfService.ExportarDatosTabla(titulo, periodo, currentDataList, saveFileDialog.FileName);

                    MessageBox.Show("Reporte exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new Process { StartInfo = new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true } }.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}