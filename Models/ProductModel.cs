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
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        
        [Column("product_description")]
        public string? Description { get; set; }
        
        [Column("image_path")]
        public string? ImagePath { get; set; }
        
        [Column("price")]
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        
        [Column("category_id")]
        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }
        
        [Column("supplier_id")]
        public int? SupplierId { get; set; }
        
        [Column("active_state")]
        [Required(ErrorMessage = "Active state is required.")]
        public bool Active { get; set; }
        
        [Column("stock")]
        [Required(ErrorMessage = "Stock  is required.")]
        public uint Stock { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }

        [ForeignKey("SupplierId")]
        public SupplierModel? Supplier { get; set; }

        public ICollection<SaleItemModel> SaleItems { get; set; } = new List<SaleItemModel>();
    }
}