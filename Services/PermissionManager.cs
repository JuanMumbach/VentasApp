using Microsoft.EntityFrameworkCore;
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
            Admin = 1,
            SalesManager = 2,
            Salesperson = 3,
            Inventory = 4
        }

        public enum Permissions
        {
            SalesViewAll = 1,
            SalesCreate = 2,
            SalesManage = 3,
            ProductsView = 4,
            ProductsManage = 5,
            SuppliersView = 6,
            SuppliersManage = 7,
            CustomersView = 8,
            CustomersManage = 9,
            UsersView = 10,
            UsersManage = 11,
            DashboardView = 12,
            SystemView = 13,
            SystemManage = 14,
            SystemBackup = 15
        }

        public static bool HasPermission(Roles _role, Permissions permission)
        {
            using (var context = new VentasDBContext())
            {
                var role = context.Roles
                    .Where(r => r.RoleId == (int)_role)
                    .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                    .FirstOrDefault();

                if (role != null)
                {
                    return role.RolePermissions
                               .Any(rp => rp.Permission.PermissionId == (int)permission);
                }
                return false;
            }
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
