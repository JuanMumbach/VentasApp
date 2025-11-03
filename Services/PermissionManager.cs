using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;

namespace VentasApp.Services
{
    public static class PermissionManager
    {
        public enum Roles
        {
            SysAdmin = 1,
            SalesManager = 2,
            Salesperson = 3,
            InventoryManager = 4,
            Accountant = 5,
            ExecutiveViewer = 6
        }

        public enum Permissions
        {
            SalesViewAll = 1,
            SalesCreate = 2,
            SalesManage = 3,
            ProductsView = 4,
            ProductsManage = 5,
            ProvidersView = 6,
            ProvidersManage = 7,
            CustomersView = 8,
            CustomersManage = 9,
            UsersView = 10,
            UsersManage = 11,
            DashboardView = 12,
            AccountableView = 13,
            SystemView = 14,
            SystemManage = 15
        }

        public static bool HasPermission(Roles _role, Permissions permission)
        {
            using (var context = new VentasDBContext())
            {               
                var role = context.Roles
                .Where(r => r.RoleId == (int)_role)
                .FirstOrDefault();
                if (role != null)
                {
                    var hasPermission = role.Permissions
                        .Any(p => p.PermissionId == (int)permission);
                    return hasPermission;
                }
            }
            return false;
        }

        internal static int GetRoleIdByName(string v)
        {
            using (var context = new VentasDBContext())
            {
                var role = context.Roles
                    .Where(r => r.RoleName == v)
                    .FirstOrDefault();
                if (role != null)
                {
                    return role.RoleId;
                }
            }
            return -1;
        }

        internal static string getRoleNameById(int value)
        {
            using (var context = new VentasDBContext())
            {
                var role = context.Roles
                    .Where(r => r.RoleId == value)
                    .FirstOrDefault();
                if (role != null)
                {
                    return role.RoleName;
                }
            }

            return string.Empty;
        }

        internal static object[] getRoleNames()
        {
            using (var context = new VentasDBContext())
            {
                var roleNames = context.Roles
                    .Select(r => r.RoleName)
                    .ToArray();
                return roleNames;
            }
        }
    }
}
