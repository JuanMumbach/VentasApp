using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WinFormsTimer = System.Windows.Forms.Timer;

namespace VentasApp.Services
{
    /// <summary>
  /// Servicio para gestión de backups de MySQL.
    /// Implementa backup completo, restauración y gestión automática.
 /// </summary>
    public class MySqlBackupService : IBackupService
    {
        private readonly ILogger logger;
     private readonly string connectionString;
  private readonly string backupDirectory;
        private readonly string databaseName;
        private WinFormsTimer? autoBackupTimer;

public MySqlBackupService(ILogger logger)
        {
      this.logger = logger;
            
            // Obtener configuración
       this.connectionString = AppConfiguration.GetConnectionString();
     this.databaseName = ExtractDatabaseName(connectionString);
     
      // Configurar directorio de backups
        this.backupDirectory = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, 
       "backups"
       );

            // Crear directorio si no existe
     if (!Directory.Exists(backupDirectory))
  {
      Directory.CreateDirectory(backupDirectory);
         logger.LogInformation($"Directorio de backups creado: {backupDirectory}");
      }
        }

      /// <summary>
    /// Crea un backup completo de la base de datos.
        /// </summary>
  public string CreateBackup(string? backupPath = null)
      {
         try
            {
  logger.LogInformation("Iniciando backup de base de datos...");

     // Generar nombre de archivo
      string fileName = GenerateBackupFileName();
     string fullPath = backupPath ?? Path.Combine(backupDirectory, fileName);

       // Ejecutar mysqldump
                ExecuteMySqlDump(fullPath);

        logger.LogInformation($"Backup completado exitosamente: {fullPath}");
     
       // Limpiar backups antiguos automáticamente
       CleanOldBackups();

         return fullPath;
            }
 catch (Exception ex)
     {
          logger.LogError("Error al crear backup", ex);
      throw new Exception("No se pudo crear el backup de la base de datos.", ex);
          }
      }

        /// <summary>
        /// Crea un backup de forma asíncrona.
    /// </summary>
        public async Task<string> CreateBackupAsync(string? backupPath = null)
        {
            return await Task.Run(() => CreateBackup(backupPath));
        }

        /// <summary>
     /// Restaura la base de datos desde un archivo de backup.
        /// </summary>
        public void RestoreBackup(string backupFilePath)
        {
      try
       {
                if (!File.Exists(backupFilePath))
              {
    throw new FileNotFoundException("El archivo de backup no existe.", backupFilePath);
      }

    logger.LogInformation($"Iniciando restauración desde: {backupFilePath}");

       // Ejecutar mysql para restaurar
ExecuteMySqlRestore(backupFilePath);

    logger.LogInformation("Restauración completada exitosamente.");
      }
      catch (Exception ex)
         {
 logger.LogError("Error al restaurar backup", ex);
        throw new Exception("No se pudo restaurar el backup.", ex);
      }
        }

    /// <summary>
      /// Restaura la base de datos de forma asíncrona.
        /// </summary>
        public async Task RestoreBackupAsync(string backupFilePath)
        {
  await Task.Run(() => RestoreBackup(backupFilePath));
        }

        /// <summary>
   /// Lista todos los backups disponibles.
        /// </summary>
 public IEnumerable<BackupInfo> GetAvailableBackups()
  {
   try
   {
     if (!Directory.Exists(backupDirectory))
     {
          return Enumerable.Empty<BackupInfo>();
     }

   var backupFiles = Directory.GetFiles(backupDirectory, "*.sql")
     .Select(filePath => new BackupInfo
       {
      FilePath = filePath,
        FileName = Path.GetFileName(filePath),
                 CreatedDate = File.GetCreationTime(filePath),
        FileSizeBytes = new FileInfo(filePath).Length
             })
         .OrderByDescending(b => b.CreatedDate)
        .ToList();

     return backupFiles;
      }
     catch (Exception ex)
      {
      logger.LogError("Error al listar backups", ex);
       return Enumerable.Empty<BackupInfo>();
       }
        }

        /// <summary>
  /// Elimina backups antiguos según política de retención.
        /// </summary>
        public void CleanOldBackups(int daysToKeep = 30)
        {
try
            {
       var cutoffDate = DateTime.Now.AddDays(-daysToKeep);
         var oldBackups = GetAvailableBackups()
          .Where(b => b.CreatedDate < cutoffDate)
     .ToList();

  foreach (var backup in oldBackups)
          {
 File.Delete(backup.FilePath);
logger.LogInformation($"Backup antiguo eliminado: {backup.FileName}");
            }

   if (oldBackups.Any())
      {
     logger.LogInformation($"Se eliminaron {oldBackups.Count} backups antiguos.");
        }
            }
        catch (Exception ex)
      {
    logger.LogError("Error al limpiar backups antiguos", ex);
   }
        }

  /// <summary>
        /// Programa un backup automático.
    /// </summary>
        public void ScheduleAutoBackup(int intervalHours = 24)
        {
            try
            {
            StopAutoBackup(); // Detener cualquier timer existente

          int intervalMs = intervalHours * 60 * 60 * 1000;
                autoBackupTimer = new WinFormsTimer
        {
         Interval = intervalMs
       };

     autoBackupTimer.Tick += async (s, e) =>
       {
        try
               {
  logger.LogInformation("Ejecutando backup automático programado...");
          await CreateBackupAsync();
  }
        catch (Exception ex)
     {
           logger.LogError("Error en backup automático", ex);
              }
            };

      autoBackupTimer.Start();
      logger.LogInformation($"Backup automático programado cada {intervalHours} horas.");
       }
   catch (Exception ex)
    {
     logger.LogError("Error al programar backup automático", ex);
   }
        }

        /// <summary>
  /// Detiene el backup automático.
    /// </summary>
        public void StopAutoBackup()
        {
       if (autoBackupTimer != null)
   {
    autoBackupTimer.Stop();
          autoBackupTimer.Dispose();
       autoBackupTimer = null;
     logger.LogInformation("Backup automático detenido.");
}
    }

        #region Métodos Privados

        /// <summary>
   /// Ejecuta mysqldump para crear el backup.
        /// </summary>
    private void ExecuteMySqlDump(string outputPath)
        {
            // Extraer información de conexión
            var builder = new MySqlConnectionStringBuilder(connectionString);
     string server = builder.Server;
            string user = builder.UserID;
    string password = builder.Password;
            string database = builder.Database;

         // Ruta de mysqldump (ajustar según instalación de MySQL)
            string mysqldumpPath = FindMySqlDumpPath();

       if (string.IsNullOrEmpty(mysqldumpPath))
            {
   throw new FileNotFoundException(
               "No se encontró mysqldump.exe. Asegúrese de tener MySQL instalado y configurado en PATH."
       );
    }

     // Argumentos para mysqldump
        string arguments = $"--host={server} --user={user} --password={password} " +
                $"--databases {database} --result-file=\"{outputPath}\" " +
          $"--single-transaction --routines --triggers --events";

            // Ejecutar proceso
   var processInfo = new ProcessStartInfo
      {
         FileName = mysqldumpPath,
        Arguments = arguments,
                RedirectStandardOutput = true,
  RedirectStandardError = true,
     UseShellExecute = false,
     CreateNoWindow = true
};

     using (var process = Process.Start(processInfo))
            {
   if (process == null)
 {
            throw new Exception("No se pudo iniciar el proceso mysqldump.");
 }

    process.WaitForExit();

     if (process.ExitCode != 0)
          {
      string error = process.StandardError.ReadToEnd();
          throw new Exception($"mysqldump falló con código {process.ExitCode}: {error}");
 }
            }
        }

        /// <summary>
        /// Ejecuta mysql para restaurar el backup.
        /// </summary>
        private void ExecuteMySqlRestore(string backupFilePath)
      {
     // Extraer información de conexión
var builder = new MySqlConnectionStringBuilder(connectionString);
  string server = builder.Server;
 string user = builder.UserID;
            string password = builder.Password;
   string database = builder.Database;

            // Ruta de mysql (ajustar según instalación)
            string mysqlPath = FindMySqlPath();

       if (string.IsNullOrEmpty(mysqlPath))
    {
    throw new FileNotFoundException(
        "No se encontró mysql.exe. Asegúrese de tener MySQL instalado."
                );
            }

            // Leer el archivo SQL
    string sqlContent = File.ReadAllText(backupFilePath);

    // Argumentos para mysql
   string arguments = $"--host={server} --user={user} --password={password} {database}";

        // Ejecutar proceso
   var processInfo = new ProcessStartInfo
            {
  FileName = mysqlPath,
    Arguments = arguments,
        RedirectStandardInput = true,
      RedirectStandardOutput = true,
      RedirectStandardError = true,
             UseShellExecute = false,
       CreateNoWindow = true
      };

   using (var process = Process.Start(processInfo))
            {
    if (process == null)
     {
    throw new Exception("No se pudo iniciar el proceso mysql.");
    }

     // Escribir SQL al proceso
      process.StandardInput.WriteLine(sqlContent);
    process.StandardInput.Close();

       process.WaitForExit();

 if (process.ExitCode != 0)
              {
          string error = process.StandardError.ReadToEnd();
 throw new Exception($"mysql falló con código {process.ExitCode}: {error}");
    }
       }
        }

        /// <summary>
        /// Busca la ruta de mysqldump en ubicaciones comunes.
     /// </summary>
        private string FindMySqlDumpPath()
        {
            // Intentar desde PATH
            string[] possiblePaths = new[]
  {
                "mysqldump",
         @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
            @"C:\Program Files\MySQL\MySQL Server 5.7\bin\mysqldump.exe",
     @"C:\Program Files (x86)\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
    @"C:\xampp\mysql\bin\mysqldump.exe"
  };

            foreach (var path in possiblePaths)
      {
       try
   {
     var processInfo = new ProcessStartInfo
       {
          FileName = path,
            Arguments = "--version",
          RedirectStandardOutput = true,
             UseShellExecute = false,
        CreateNoWindow = true
        };

     using (var process = Process.Start(processInfo))
           {
       if (process != null)
       {
    process.WaitForExit();
          if (process.ExitCode == 0)
      {
         return path;
         }
     }
     }
        }
    catch
                {
                    continue;
                }
 }

            return null;
      }

   /// <summary>
   /// Busca la ruta de mysql.exe.
        /// </summary>
     private string FindMySqlPath()
      {
       string mysqldumpPath = FindMySqlDumpPath();
            if (!string.IsNullOrEmpty(mysqldumpPath))
   {
        return mysqldumpPath.Replace("mysqldump", "mysql");
     }
       return null;
        }

        /// <summary>
      /// Genera un nombre de archivo para el backup.
        /// </summary>
        private string GenerateBackupFileName()
        {
      string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
return $"backup_{databaseName}_{timestamp}.sql";
}

 /// <summary>
        /// Extrae el nombre de la base de datos del connection string.
        /// </summary>
        private string ExtractDatabaseName(string connString)
        {
            try
{
      var builder = new MySqlConnectionStringBuilder(connString);
                return builder.Database;
 }
         catch
  {
    return "ventasdb";
       }
        }

        #endregion
    }
}
