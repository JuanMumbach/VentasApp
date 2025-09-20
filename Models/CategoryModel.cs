using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasApp.Models;
[Table("category")]
public class CategoryModel
{
    [Key]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(150)]
    [Column("category_name")]
    public string CategoryName { get; set; } = string.Empty;

    // Propiedad de navegación para la relación 1 a muchos
    public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
}