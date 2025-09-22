using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasApp.Models
{
    [Table("user")]
    public class UserModel
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }

        [Column("username")]
        [Required(ErrorMessage = "Username es necesario.")]
        [StringLength(50, ErrorMessage = "Username no puede exceder 50 caracteres.")]
        public string Username { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Email es necesario.")]
        [EmailAddress(ErrorMessage = "Email invalido,revise que este bien escrito.")]
        public string Email { get; set; }

        [Column("passwordhash")]
        [Required(ErrorMessage = "Password es necesario.")]
        public string PasswordHash { get; set; }

        [Column("full_name")]
        [Required(ErrorMessage = "Full name es necesario.")]
        [StringLength(100, ErrorMessage = "Full name no puede exceder 100 caracteres.")]
        public string FullName { get; set; }

        [Column("role_id")]
        [Required(ErrorMessage = "Role es necesario.")]
        public int RoleId { get; set; } // 1 = Admin, 2 = Employee

        [Column("phone")]
        [StringLength(15, ErrorMessage = "Phone no puede exceder 15 caracteres.")]
        public string? Phone { get; set; }

        [Column("active_state")]
        [Required(ErrorMessage = "Active state es necesario.")]
        public bool Active { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        // Propiedad calculada para obtener el nombre del rol
        [NotMapped]
        public string RoleName
        {
            get
            {
                return RoleId switch
                {
                    1 => "Admin",
                    2 => "Employee",
                    _ => "Unknown"
                };
            }
        }
    }
}