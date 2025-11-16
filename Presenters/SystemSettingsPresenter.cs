using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Services;
using VentasApp.Views.SystemSettings;
using static VentasApp.Services.PermissionManager;

namespace VentasApp.Presenters
{
    public class SystemSettingsPresenter
    {
        ISystemSettingsView view;

        public SystemSettingsPresenter(ISystemSettingsView view) 
        {
            this.view = view;

            this.view.FormLoadEvent += CheckForPermissions;
            this.view.PerformDbBackupEvent += PerformBackup;
            this.view.RestoreDbEvent += RestoreBackup;
        }

        private void CheckForPermissions(object? sender, EventArgs e)
        {
            

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId,Permissions.SystemView)
                || HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SystemManage))
            {
                if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SystemBackup))
                    view.EnableBackupButtons();

                return;
            }

            

            

            MessageBox.Show("No tienes permiso para ver la configuración del sistema.",
                                "Acceso denegado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            this.view.CloseView();
            return;
        }


        private void RestoreBackup(object? sender, EventArgs e)
        {
            if (!HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SystemManage))
            {
                MessageBox.Show("No tiene permisos para restaurar la base de datos.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "¿Está seguro de que desea restaurar la base de datos desde un archivo de restauración?\n" +
                "Este proceso elimina la base de datos actual y carga la base de datos del archivo.",
                "WARNING: restaurar base de datos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                {
                    try
                    {
                        DbBackupService backupService = new DbBackupService();
                        backupService.PerformRestore();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Se produjo un error al inicializar el servicio de restauración: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PerformBackup(object? sender, EventArgs e)
        {
            if (!HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SystemBackup))
            {
                MessageBox.Show("No tiene permisos para realizar copias de seguridad.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "¿Está seguro de que desea iniciar una copia de seguridad de la base de datos?\n" +
                "El proceso puede tardar unos momentos y requiere que 'mysqldump.exe' esté accesible.",
                "Confirmar Backup",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DbBackupService backupService = new DbBackupService();
                    backupService.PerformBackup();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se produjo un error al inicializar el servicio de backup: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
