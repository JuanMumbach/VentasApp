using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models
{
    [Table("sale")]
    public class SaleModel
    {
        [Column("sale_id")]
        [Key]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("delivery_state",TypeName = "ENUM('pendiente', 'confirmado', 'en proceso', 'en camino', 'finalizado', 'cancelado')")]
        public string? DeliveryState { get; set; }

        [Column("total_price")]
        public decimal TotalPrice { get; set; }

        [Column("canceled_at")]
        public DateTime? CanceledAt { get; set; }

        [Column("customer_id")]
        public int? CustomerId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public ICollection<SaleItemModel> SaleItems { get; set; } = new List<SaleItemModel>();
    }
}
