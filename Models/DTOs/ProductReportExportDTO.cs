using System;
using System.Collections.Generic;

namespace VentasApp.Models.DTOs
{
    public class ProductReportExportDTO
    {
        public string Periodo { get; set; }
        public DateTime FechaGeneracion { get; set; } = DateTime.Now;

        public string FiltroCategoria { get; set; }
        public string FiltroProveedor { get; set; }


        public int TotalUnidades { get; set; }
        public decimal TotalIngresos { get; set; }
        public string ProductoEstrella { get; set; }

        public List<ProductReportDTO> DetalleProductos { get; set; }
    }
}