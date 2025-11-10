using System;
using System.Threading.Tasks;

namespace VentasApp.Services
{
    /// <summary>
    /// Interfaz para el servicio de backup de base de datos.
    /// </summary>
  public interface IBackupService
    {
        /// <summary>
  /// Crea un backup completo de la base de datos.
        /// </summary>
        /// <param name="backupPath">Ruta donde se guardará el backup. Si es null, usa la ruta por defecto.</param>
     /// <returns>Ruta del archivo de backup creado.</returns>
        string CreateBackup(string? backupPath = null);

     /// <summary>
        /// Crea un backup de forma asíncrona.
    /// </summary>
        Task<string> CreateBackupAsync(string? backupPath = null);

    /// <summary>
        /// Restaura la base de datos desde un archivo de backup.
        /// </summary>
        /// <param name="backupFilePath">Ruta del archivo de backup.</param>
        void RestoreBackup(string backupFilePath);

        /// <summary>
        /// Restaura la base de datos de forma asíncrona.
        /// </summary>
 Task RestoreBackupAsync(string backupFilePath);

     /// <summary>
        /// Lista todos los backups disponibles en el directorio de backups.
        /// </summary>
   IEnumerable<BackupInfo> GetAvailableBackups();

     /// <summary>
        /// Elimina backups antiguos según la política de retención.
        /// </summary>
        /// <param name="daysToKeep">Días de retención de backups.</param>
        void CleanOldBackups(int daysToKeep = 30);

     /// <summary>
      /// Programa un backup automático.
        /// </summary>
   /// <param name="intervalHours">Intervalo en horas entre backups.</param>
        void ScheduleAutoBackup(int intervalHours = 24);

        /// <summary>
     /// Detiene el backup automático programado.
        /// </summary>
        void StopAutoBackup();
    }

    /// <summary>
    /// Información de un archivo de backup.
    /// </summary>
    public class BackupInfo
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedDate { get; set; }
public long FileSizeBytes { get; set; }
     public string FileSizeFormatted => FormatFileSize(FileSizeBytes);

        private string FormatFileSize(long bytes)
        {
   string[] sizes = { "B", "KB", "MB", "GB" };
     double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
   order++;
        len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }
    }
}
