using System;
using System.Linq;
using System.Windows.Forms;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views.Backup;

namespace VentasApp.Presenters
{
    /// <summary>
    /// Presenter para la gestión de backups.
    /// </summary>
    public class BackupPresenter
{
        private IBackupView view;
        private IBackupService backupService;
        private ILogger logger;
        private BindingSource backupsBindingSource;

        public BackupPresenter(IBackupView view, IBackupService backupService, ILogger logger)
        {
            this.view = view;
         this.backupService = backupService;
          this.logger = logger;
      this.backupsBindingSource = new BindingSource();

   // Suscribir eventos
          this.view.FormLoadEvent += OnViewLoad;
            this.view.CreateBackupEvent += OnCreateBackup;
         this.view.RestoreBackupEvent += OnRestoreBackup;
            this.view.RefreshBackupsEvent += OnRefreshBackups;
     this.view.DeleteBackupEvent += OnDeleteBackup;
       this.view.ScheduleAutoBackupEvent += OnScheduleAutoBackup;
    this.view.StopAutoBackupEvent += OnStopAutoBackup;

         // Configurar binding
   this.view.SetBackupsBindingSource(backupsBindingSource);
        }

        private void OnViewLoad(object? sender, EventArgs e)
        {
            LoadBackupsList();
         view.SetAutoBackupStatus(false, 24);
    }

  private async void OnCreateBackup(object? sender, EventArgs e)
        {
      try
 {
             view.ShowProgress("Creando backup...");

      var result = MessageBox.Show(
 "¿Está seguro que desea crear un backup de la base de datos?",
  "Confirmar Backup",
       MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
             );

    if (result == DialogResult.Yes)
 {
   string backupPath = await backupService.CreateBackupAsync();
        
            view.HideProgress();
      
      MessageBox.Show(
      $"Backup creado exitosamente:\n{backupPath}",
        "Backup Completado",
            MessageBoxButtons.OK,
       MessageBoxIcon.Information
        );

   LoadBackupsList();
       logger.LogInformation("Backup creado manualmente desde la interfaz.");
                }
      else
  {
            view.HideProgress();
  }
            }
      catch (Exception ex)
     {
      view.HideProgress();
                logger.LogError("Error al crear backup desde interfaz", ex);
        MessageBox.Show(
       $"Error al crear backup:\n{ex.Message}",
               "Error",
            MessageBoxButtons.OK,
         MessageBoxIcon.Error
     );
   }
        }

        private async void OnRestoreBackup(object? sender, EventArgs e)
     {
            try
 {
        var selectedBackup = view.GetSelectedBackup();
             if (selectedBackup == null)
    {
         MessageBox.Show(
        "Por favor, seleccione un backup para restaurar.",
      "Selección Requerida",
            MessageBoxButtons.OK,
       MessageBoxIcon.Warning
 );
           return;
                }

                var result = MessageBox.Show(
        $"ADVERTENCIA: Esta acción reemplazará TODA la base de datos actual.\n\n" +
       $"Backup seleccionado:\n{selectedBackup.FileName}\n" +
   $"Fecha: {selectedBackup.CreatedDate}\n\n" +
           $"¿Está ABSOLUTAMENTE SEGURO que desea continuar?",
         "?? CONFIRMACIÓN CRÍTICA",
     MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
                );

    if (result == DialogResult.Yes)
       {
            view.ShowProgress("Restaurando backup...");

     await backupService.RestoreBackupAsync(selectedBackup.FilePath);

         view.HideProgress();

     MessageBox.Show(
 "Backup restaurado exitosamente.\n\n" +
       "Se recomienda reiniciar la aplicación.",
      "Restauración Completada",
           MessageBoxButtons.OK,
            MessageBoxIcon.Information
             );

        logger.LogInformation($"Backup restaurado: {selectedBackup.FileName}");
         }
            }
     catch (Exception ex)
  {
   view.HideProgress();
              logger.LogError("Error al restaurar backup", ex);
       MessageBox.Show(
      $"Error al restaurar backup:\n{ex.Message}",
   "Error",
      MessageBoxButtons.OK,
    MessageBoxIcon.Error
     );
            }
        }

  private void OnRefreshBackups(object? sender, EventArgs e)
   {
            LoadBackupsList();
        }

 private void OnDeleteBackup(object? sender, EventArgs e)
  {
        try
{
                var selectedBackup = view.GetSelectedBackup();
      if (selectedBackup == null)
       {
                    MessageBox.Show(
  "Por favor, seleccione un backup para eliminar.",
            "Selección Requerida",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
         );
          return;
        }

    var result = MessageBox.Show(
      $"¿Está seguro que desea eliminar este backup?\n\n{selectedBackup.FileName}",
          "Confirmar Eliminación",
     MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
      );

             if (result == DialogResult.Yes)
                {
     System.IO.File.Delete(selectedBackup.FilePath);
logger.LogInformation($"Backup eliminado: {selectedBackup.FileName}");
  
          MessageBox.Show(
        "Backup eliminado exitosamente.",
             "Eliminación Completada",
      MessageBoxButtons.OK,
                MessageBoxIcon.Information
    );

         LoadBackupsList();
  }
        }
   catch (Exception ex)
            {
    logger.LogError("Error al eliminar backup", ex);
   MessageBox.Show(
           $"Error al eliminar backup:\n{ex.Message}",
        "Error",
          MessageBoxButtons.OK,
 MessageBoxIcon.Error
            );
     }
        }

    private void OnScheduleAutoBackup(object? sender, EventArgs e)
      {
            try
         {
         int intervalHours = view.AutoBackupIntervalHours;

       backupService.ScheduleAutoBackup(intervalHours);
         view.SetAutoBackupStatus(true, intervalHours);

                MessageBox.Show(
    $"Backup automático programado cada {intervalHours} horas.",
         "Programación Exitosa",
   MessageBoxButtons.OK,
        MessageBoxIcon.Information
     );

        logger.LogInformation($"Backup automático programado: cada {intervalHours}h");
      }
            catch (Exception ex)
{
      logger.LogError("Error al programar backup automático", ex);
       MessageBox.Show(
            $"Error al programar backup automático:\n{ex.Message}",
         "Error",
              MessageBoxButtons.OK,
          MessageBoxIcon.Error
      );
}
        }

        private void OnStopAutoBackup(object? sender, EventArgs e)
        {
            try
         {
  backupService.StopAutoBackup();
    view.SetAutoBackupStatus(false, 0);

              MessageBox.Show(
           "Backup automático detenido.",
          "Detención Exitosa",
        MessageBoxButtons.OK,
      MessageBoxIcon.Information
    );

    logger.LogInformation("Backup automático detenido.");
            }
            catch (Exception ex)
         {
    logger.LogError("Error al detener backup automático", ex);
         MessageBox.Show(
            $"Error al detener backup automático:\n{ex.Message}",
                "Error",
MessageBoxButtons.OK,
            MessageBoxIcon.Error
           );
            }
    }

        private void LoadBackupsList()
        {
  try
       {
      var backups = backupService.GetAvailableBackups().ToList();
        backupsBindingSource.DataSource = backups;

                logger.LogInformation($"Lista de backups cargada: {backups.Count} archivos.");
       }
    catch (Exception ex)
            {
        logger.LogError("Error al cargar lista de backups", ex);
      MessageBox.Show(
              $"Error al cargar lista de backups:\n{ex.Message}",
          "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error
      );
 }
      }
    }
}
