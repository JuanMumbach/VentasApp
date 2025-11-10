using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using VentasApp.Models.DTOs;
using VentasApp.Repositories;
using VentasApp.Views.Dashboard;

namespace VentasApp.Presenters
{
    public class DashboardPresenter
    {
        private IDashboardView view;
        private ISaleRepository salesRepository;
        private IUserRepository userRepository;

        public DashboardPresenter(IDashboardView dashboardView, ISaleRepository _salesRepository, IUserRepository userRepository)
        {
            this.view = dashboardView;
            this.salesRepository = _salesRepository;

            this.view.FormLoadEvent += LoadGraphs;
            this.view.OnTimePeriodChanged += LoadGraphs;

            this.view.OnSetWeeklyTimePeriod += (s, e) => { SetTimePeriod(DateTime.Today.Subtract(TimeSpan.FromDays(7)), DateTime.Today); };
            this.view.OnSetMonthlyTimePeriod += (s, e) => { SetTimePeriod(DateTime.Today.Subtract(TimeSpan.FromDays(30)), DateTime.Today); };
            this.view.OnSetTrimesterTimePeriod += (s, e) => { SetTimePeriod(DateTime.Today.Subtract(TimeSpan.FromDays(90)), DateTime.Today); };
            this.view.OnSetYearlyTimePeriod += (s, e) => { SetTimePeriod(DateTime.Today.Subtract(TimeSpan.FromDays(365)), DateTime.Today); };
            this.userRepository = userRepository;
        }

        private void SetTimePeriod(DateTime startTime, DateTime endTime)
        {
            this.view.EndDate = DateOnly.FromDateTime(endTime);
            
            if (startTime > endTime)
            {
                startTime = endTime;
            }
            this.view.StartDate = DateOnly.FromDateTime(startTime);
        }

        private void LoadGraphs(object? sender, EventArgs e)
        {
            LoadSalesGraph();
            LoadTopSellersGraph();
        }

        private void LoadTopSellersGraph()
        {
            DateTime start = view.StartDate.ToDateTime(TimeOnly.MinValue);
            DateTime end = view.EndDate.ToDateTime(TimeOnly.MinValue);

            IEnumerable<TopSellerDTO> topSellers = salesRepository.GetTopSellers(start, end);

            this.view.SetTopSellers(topSellers.ToList());
        }

        private void LoadSalesGraph()
        {
            DateTime start = view.StartDate.ToDateTime(TimeOnly.MinValue);
            DateTime end = view.EndDate.ToDateTime(TimeOnly.MinValue);

            Chart chart = new Chart();

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Tiempo";
            chartArea.AxisY.Title = "Ventas";
            chartArea.AxisX.MajorGrid.Interval = 1;
            chart.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                Name = "Sales",
                Color = Color.Blue,
                IsVisibleInLegend = true, //
                ChartType = SeriesChartType.Line,
                ChartArea = "MainArea"
            };


            chart.Titles.Add("Ventas");

            if ((end - start) < TimeSpan.FromDays(30))
            {
                var salesData = salesRepository.GetSalesGroupedByDate(start, end, 1);
                var finalData = FillMissingIntervals(salesData, start, end, 1);
                foreach (SalesDataPoint data in finalData)
                {
                    series.Points.AddXY(data.Date.ToString("dd/MM/yy"), data.TotalSales);
                }
            }
            else if ((end - start) < TimeSpan.FromDays(180))
            {
                var salesData = salesRepository.GetSalesGroupedByDate(start, end, 7);
                var finalData = FillMissingIntervals(salesData, start, end, 7);
                foreach (SalesDataPoint data in finalData)
                {
                    int day = data.Date.Day;
                    int week = ((day - 1) / 7) + 1;
                    series.Points.AddXY(data.Date.ToString("MMM w" + week), data.TotalSales);
                }
            }
            else
            {
                var salesData = salesRepository.GetSalesGroupedByDate(start, end, 30);
                var finalData = FillMissingIntervals(salesData, start, end, 30);
                foreach (SalesDataPoint data in finalData)
                {
                    
                    series.Points.AddXY(data.Date.ToString("MMMM"), data.TotalSales);
                }
            }


            chart.Series.Add(series);

            chart.Dock = DockStyle.Fill;//que el contenedor ocupe todo el espacio

            view.LoadGraph1(chart);

        }

    IEnumerable<SalesDataPoint> FillMissingIntervals(IEnumerable<SalesDataPoint> salesData,DateTime start,DateTime end,int intervalDays)
        {
            // 1. Calcular el número total de intervalos
            TimeSpan totalDuration = end.Date - start.Date;
            int totalIntervals = (int)Math.Ceiling(totalDuration.TotalDays / intervalDays);

            // 2. Generar todos los puntos de intervalo posibles (con TotalSales = 0)
            var allIntervals = Enumerable.Range(0, totalIntervals + 1)
                .Select(i =>
                {
                    // Calcula la fecha de inicio del intervalo (ej. Lunes, Lunes siguiente, etc.)
                    DateTime intervalDate = start.Date.AddDays(i * intervalDays);

                    // Asegurarse de no exceder el límite de la fecha 'end'
                    if (intervalDate > end.Date)
                    {
                        return null;
                    }

                    return new SalesDataPoint
                    {
                        Date = intervalDate,
                        TotalSales = 0, // Inicializado en 0
                        SaleCount = 0   // Inicializado en 0
                    };
                })
                .Where(p => p != null)
                .ToList();

            // 3. Unir los intervalos completos con los datos reales usando GroupJoin (equivalente a Left Join)
            // El 'Key' para la unión es la propiedad 'Date' (que ya es el inicio del intervalo)
            var finalData = allIntervals
                .GroupJoin(
                    salesData,
                    all => all.Date,
                    real => real.Date,
                    (all, realGroup) =>
                    {
                        // Si realGroup tiene elementos, significa que hubo ventas para ese intervalo.
                        var realPoint = realGroup.FirstOrDefault();

                        if (realPoint != null)
                        {
                            // Devolver el punto de datos real
                            return realPoint;
                        }
                        else
                        {
                            // Devolver el punto de datos generado con valores en cero
                            return all;
                        }
                    })
                .OrderBy(p => p.Date); // Garantizar que el orden cronológico sea correcto

            return finalData;
        }
    }
}
