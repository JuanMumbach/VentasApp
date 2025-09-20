using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasApp.Models
{
    [Table("product")]
    public class ProductModel
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }

        [Column("product_name")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        
        [Column("product_description")]
        public string? Description { get; set; }
        
        [Column("image")]
        public string? Image { get; set; }
        
        [Column("price")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Price { get; set; }
        
        [Column("category_id")]
        [Required(ErrorMessage = "La categoria es obligatoria")]
        public int CategoryId { get; set; }
        
        [Column("supplier_id")]
        public int? SupplierId { get; set; }
        
        [Column("active_state")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Active { get; set; }
        
        [Column("stock")]
        [Required(ErrorMessage = "El stock es obligatorio")]
        public uint Stock { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}