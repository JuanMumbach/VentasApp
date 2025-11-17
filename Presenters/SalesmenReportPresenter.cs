using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Views.Dashboard;

namespace VentasApp.Presenters
{
    public class SalesmenReportPresenter
    {
        ISalesmenReportView view;
        DateOnly StartPeriod;
        DateOnly EndPeriod;
        BindingSource dataSource = new BindingSource();

        public SalesmenReportPresenter(ISalesmenReportView view, DateOnly startPeriod, DateOnly endPeriod)
        {
            this.view = view;
            this.StartPeriod = startPeriod;
            this.EndPeriod = endPeriod;
            this.view.ChangePeriodLabel(startPeriod, endPeriod);
            this.view.DataGridBindSource(dataSource);
            GenerateReportData();
        }

        void GenerateReportData()
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    int salesmanRoleId = context.Roles.FirstOrDefault(r => r.RoleName == "Salesperson")?.RoleId ?? 0;
                    var salesmen = context.Users.Where(u => u.RoleId == salesmanRoleId).ToList();

                    var reportData = salesmen.Select(s => new
                    {
                        Vendedor = s.FullName,
                        VentasTotales = context.Sales
                            .Where(sale => sale.UserId == s.Id
                                            && sale.CreatedAt >= StartPeriod.ToDateTime(new TimeOnly(0, 0))
                                            && sale.CreatedAt <= EndPeriod.ToDateTime(new TimeOnly(23,59))
                            )
                            .Count(),
                        IngresosTotales = "$" + (context.Sales
                            .Where(sale => sale.UserId == s.Id
                                            && sale.CreatedAt >= StartPeriod.ToDateTime(new TimeOnly(0, 0))
                                            && sale.CreatedAt <= EndPeriod.ToDateTime(new TimeOnly(23, 59))
                            )
                            .Sum(sale => (decimal?)sale.TotalPrice) ?? 0).ToString("N2"),
                        VentasCanceladas = context.Sales
                            .Where(sale => sale.UserId == s.Id
                                            && sale.CreatedAt >= StartPeriod.ToDateTime(new TimeOnly(0, 0))
                                            && sale.CreatedAt <= EndPeriod.ToDateTime(new TimeOnly(23, 59))
                                            && sale.CanceledAt != null
                            )
                            .Count(),
                    }).ToList();

                    dataSource.DataSource = reportData;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al generar el reporte: {ex.Message}");
            }
        }
    }
}
