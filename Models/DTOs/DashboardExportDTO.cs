using System;
using System.Collections.Generic;

namespace VentasApp.Models.DTOs
{
    public class DashboardExportDTO
    {
        public string Periodo { get; set; }
        public DateTime FechaGeneracion { get; set; } = DateTime.Now;

        public double TotalIngresos { get; set; }
        public int TotalVentas { get; set; }

        public List<TopSellerDTO> TopSellers { get; set; }
        public byte[] SalesChartImage { get; set; }
        public byte[] CategoriesChartImage { get; set; }
        public byte[] ProductsChartImage { get; set; }
    }
}