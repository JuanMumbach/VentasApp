using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasApp.Views.Dashboard
{
    public interface IProductReportView : IBaseForm
    {
        event EventHandler CloseButtonClickEvent;
        event EventHandler ExportReportEvent;
        void ChangePeriodLabel(DateOnly startPeriod, DateOnly endPeriod);
        void DataGridBindSource(object source);
    }
    public partial class ProductsReportView : BaseForm, IProductReportView
    {
        public event EventHandler CloseButtonClickEvent;
        public event EventHandler ExportReportEvent;
        public ProductsReportView()
        {
            InitializeComponent();

            CloseButton.Click += (s, e) =>
            {
                CloseButtonClickEvent?.Invoke(s, e);
            };

            ExportReportButton.Click += (s, e) =>
            {
                ExportReportEvent?.Invoke(s, e);
            };
        }

        public void ChangePeriodLabel(DateOnly startPeriod, DateOnly endPeriod)
        {
            PeriodLabel.Text = $"Periodo: {startPeriod:dd/MM/yyyy} - {endPeriod:dd/MM/yyyy}";
        }

        public void DataGridBindSource(object source)
        {
            dataGridView1.DataSource = source;
        }
    }
}
