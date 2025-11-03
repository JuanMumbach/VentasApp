using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models
{
    [Table("permission")]
    public class PermissionModel
    {
        [Key]
        [Column("permission_id")]
        public int PermissionId { get; set; }

        [Column("permission_name")]
        [Required(ErrorMessage = "Permission name is required.")]
        public string PermissionName { get; set; }

        public ICollection<RoleModel> Roles { get; set; } = new List<RoleModel>();
    }
}
