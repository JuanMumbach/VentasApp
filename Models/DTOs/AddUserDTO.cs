using System.ComponentModel.DataAnnotations;

namespace VentasApp.Models.DTOs
{
    public class AddUserDTO
    {
        [Required(ErrorMessage = "Username es requerido.")]
        [StringLength(50, ErrorMessage = "Username no puede exceder 50 caracteres.")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido, revise que esté ingresado correctamente.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password es requerido.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password debe tener entre 6 y 100 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Full name es requerido.")]
        [StringLength(100, ErrorMessage = "Full name no puede exceder 100 caracteres.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Role es requerido.")]
        [Range(1, 2, ErrorMessage = "Role debe ser 1 (Admin) o 2 (Employee).")]
        public int RoleId { get; set; }

        [StringLength(15, ErrorMessage = "Phone no puede exceder 15 caracteres.")]
        public string? Phone { get; set; }
    }
}