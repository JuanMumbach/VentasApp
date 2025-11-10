using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models.DTOs
{
    public class TopSellerDTO
    {
        public int SellerId { get; set; } 
        public string SellerName { get; set; }
        public decimal TotalValue { get; set; }
        public int TotalSales { get; set; }
    }
}
