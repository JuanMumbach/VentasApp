using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Models
{
    [Table("role_permission")]
    public class RolePermission
    {
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("permission_id")]
        public int PermissionId { get; set; }

        public RoleModel Role { get; set; }
        public PermissionModel Permission { get; set; }
    }
}
