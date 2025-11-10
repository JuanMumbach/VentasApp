using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VentasApp.Models.DTOs;

namespace VentasApp.Views.Dashboard
{ 
    public interface IDashboardView : IBaseForm
    {
        DateOnly StartDate { get; set; }
        DateOnly EndDate { get; set; }
        void LoadGraph1(Chart chart);
        event EventHandler OnTimePeriodChanged;
        event EventHandler OnSetWeeklyTimePeriod;
        event EventHandler OnSetMonthlyTimePeriod;
        event EventHandler OnSetTrimesterTimePeriod;
        event EventHandler OnSetYearlyTimePeriod;

        void SetTopSellers(List<TopSellerDTO> topSellers);
    }

    public partial class DashboardView : BaseForm, IDashboardView
    {
        public event EventHandler OnTimePeriodChanged;
        public event EventHandler OnSetWeeklyTimePeriod;
        public event EventHandler OnSetMonthlyTimePeriod;
        public event EventHandler OnSetTrimesterTimePeriod;
        public event EventHandler OnSetYearlyTimePeriod;

        public DateOnly StartDate 
        {
            get { return DateOnly.FromDateTime(StartDatePicker.Value);}
            set { StartDatePicker.Value = value.ToDateTime(new TimeOnly(0,0)); }
        }

        public DateOnly EndDate 
        {
            get { return DateOnly.FromDateTime(EndDatePicker.Value);}
            set 
            { 
                if (value < StartDate)
                {
                    value = StartDate;
                }
                EndDatePicker.Value = value.ToDateTime(new TimeOnly(0, 0)); 
            }
        }

        public DashboardView()
        {
            InitializeComponent();

            StartDate = DateOnly.FromDateTime(DateTime.Now).AddMonths(-1);
            EndDate = DateOnly.FromDateTime(DateTime.Now);

            StartDatePicker.ValueChanged += (s, e) =>
            {
                StartDate = DateOnly.FromDateTime(StartDatePicker.Value);
                OnTimePeriodChanged?.Invoke(s, e);
            };

            EndDatePicker.ValueChanged += (s, e) =>
            {
                EndDate = DateOnly.FromDateTime(EndDatePicker.Value);
                OnTimePeriodChanged?.Invoke(s, e);
            };

            WeeklyPeriodButton.Click += (s, e) => {OnSetWeeklyTimePeriod?.Invoke(s, e);};
            MonthlyPeriodButton.Click += (s, e) => {OnSetMonthlyTimePeriod?.Invoke(s, e);};
            TrimesterPeriodButton.Click += (s, e) => {OnSetTrimesterTimePeriod?.Invoke(s, e);};
            YearlyPeriodButton.Click += (s, e) => {OnSetYearlyTimePeriod?.Invoke(s, e);};
        }

        public void LoadGraph1(Chart chart)
        {
            SalesGraphPanel.Controls.Clear();
            SalesGraphPanel.Controls.Add(chart);
            SalesGraphPanel.Refresh();
        }
        
        public void SetTopSellers(List<TopSellerDTO> topSellers)
        {
            if (topSellers.Count > 0)
            {
                Top1SellerPanel.Visible = true;
                Top1SellerNameLabel.Text = topSellers[0].SellerName;
                Top1SellerSalesLabel.Text = topSellers[0].TotalSales.ToString();
                Top1SellerIncomesLabel.Text = $"{topSellers[0].TotalValue:C2}";
            } else { Top1SellerPanel.Visible = false; }

            if (topSellers.Count > 1)
            {
                Top2SellerPanel.Visible = true;
                Top2SellerNameLabel.Text = topSellers[1].SellerName;
                Top2SellerSalesLabel.Text = topSellers[1].TotalSales.ToString();
                Top2SellerIncomesLabel.Text = $"{topSellers[1].TotalValue:C2}";
            }
            else { Top2SellerPanel.Visible = false; }

            if (topSellers.Count > 2)
            {
                Top3SellerPanel.Visible = true;
                Top3SellerNameLabel.Text = topSellers[2].SellerName;
                Top3SellerSalesLabel.Text = topSellers[2].TotalSales.ToString();
                Top3SellerIncomesLabel.Text = $"{topSellers[2].TotalValue:C2}";
            }
            else { Top3SellerPanel.Visible = false; }
        }
    }
}
