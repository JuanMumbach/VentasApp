using System.Collections.Generic;
using System.Linq;

namespace VentasApp.Models
{
    public static class UserRoles
    {
        public const int Admin = 1;
        public const int Employee = 2;

        private static readonly Dictionary<int, string> RoleNames = new Dictionary<int, string>
        {
            { Admin, "Admin" },
            { Employee, "Employee" }
        };

        private static readonly Dictionary<string, int> RoleIds = new Dictionary<string, int>
        {
            { "Admin", Admin },
            { "Employee", Employee }
        };

        public static string GetRoleName(int roleId)
        {
            return RoleNames.TryGetValue(roleId, out var name) ? name : "Unknown";
        }

        public static int GetRoleId(string roleName)
        {
            return RoleIds.TryGetValue(roleName, out var id) ? id : 0;
        }

        public static Dictionary<string, int> GetAllRoles()
        {
            return new Dictionary<string, int>(RoleIds);
        }

        public static List<string> GetRoleNames()
        {
            return RoleNames.Values.ToList();
        }

        public static bool IsValidRoleId(int roleId)
        {
            return RoleNames.ContainsKey(roleId);
        }

        public static bool IsValidRoleName(string roleName)
        {
            return RoleIds.ContainsKey(roleName);
        }
    }
}