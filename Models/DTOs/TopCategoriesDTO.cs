using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models.DTOs
{
    public class TopCategoriesDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal TotalValue { get; set; }
    }
}
