using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VentasApp.Models;
[Table("supplier")]

public class SupplierModel
{
    [Key]
    [Column("supplier_id")]

    public int? SupplierId { get; set; }

    [Required]
    [StringLength(150)]
    [Column("supplier_name")]
    public string SupplierName { get; set; } = string.Empty;

    [StringLength(50)]
    [Column("cuil")]
    public string? Cuil { get; set; }

    [StringLength(50)]
    [Column("email")]
    public string? Email { get; set; }

    [StringLength(50)]
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("active_state")]
    [Required(ErrorMessage = "Active state is required.")]
    public bool Active { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    // Propiedad de navegación para la relación 1 a muchos
    public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
}