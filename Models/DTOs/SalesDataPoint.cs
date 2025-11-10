using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models.DTOs
{
    public class SalesDataPoint
    {
        public DateTime Date { get; set; }
        public decimal TotalSales { get; set; }
        public int SaleCount { get; set; }
    }
}
