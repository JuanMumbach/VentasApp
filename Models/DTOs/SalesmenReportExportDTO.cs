using System;
using System.Collections.Generic;

namespace VentasApp.Models.DTOs
{
    public class SalesmenReportExportDTO
    {
        public string Periodo { get; set; }
        public DateTime FechaGeneracion { get; set; } = DateTime.Now;

        public int TotalVentas { get; set; }
        public decimal TotalIngresos { get; set; }
        public string MejorVendedor { get; set; } 

        public List<SalesmenReportDTO> DetalleVendedores { get; set; }
    }
}