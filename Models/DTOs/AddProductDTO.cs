using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models.DTOs
{
    public class AddProductDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public uint Stock { get; set; }

        public int CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}
