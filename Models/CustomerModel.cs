using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models
{
    [Table("customer")]
    public class CustomerModel
    {
        [Column("customer_id")]
        [Key]
        public int Id { get; set; }

        [Column("email")]
        [EmailAddress(ErrorMessage = "Email invalido,revise que este bien escrito.")]
        public string? Email { get; set; }

        [Column("firstname")]
        [Required(ErrorMessage = "Nombre es necesario.")]
        [StringLength(50, ErrorMessage = "Nombre no puede exceder los 50 caracteres.")]
        public string Firstname { get; set; }

        [Column("lastname")]
        [StringLength(50, ErrorMessage = "Apellido no puede exceder los 50 caracteres.")]
        public string? Lastname { get; set; }

        public string FullName
        {
            get { return $"{Firstname} {Lastname}"; }
        }

        [Column("phone_number")]
        [StringLength(20, ErrorMessage = "El numero de telefono no puede exceder los 20 caracteres.")]
        [Phone(ErrorMessage = "El numero de telefono ingresado no es valido.")]
        public string? PhoneNumber { get; set; }

        [Column("address")]
        [StringLength(150, ErrorMessage = "El domicilio no puede exceder los 150 caracteres.")]
        public string? Address { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

    }
}
