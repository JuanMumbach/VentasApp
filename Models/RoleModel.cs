using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace VentasApp.Models
{
    [Table("role")]
    public class RoleModel
    {
        [Key]
        [Column("role_id")]
        public int RoleId {get; set; }

        [Column("role_name")]
        [Required(ErrorMessage = "RoleName es necesario.")]
        public string RoleName { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}