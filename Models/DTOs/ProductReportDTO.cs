using System.ComponentModel; // Para usar DisplayName si quieres encabezados bonitos

namespace VentasApp.Models.DTOs
{
    public class ProductReportDTO
    {
        
        public int ID { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public int Vendidos { get; set; }
        public string Ingresos { get; set; }
        public uint Stock { get; set; }
        public string Proveedor { get; set; }
    }
}