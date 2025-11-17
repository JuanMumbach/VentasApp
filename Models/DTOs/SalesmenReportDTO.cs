using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models.DTOs
{
    public class SalesmenReportDTO
    {
        
        public string Vendedor { get; set; }
        public int Ventas { get; set; } 
        public string Ingresos { get; set; }
        public int Canceladas { get; set; }
    }
}