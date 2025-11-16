using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using VentasApp.Models;

namespace VentasApp.Services
{
    public class DbBackupService
    {
        private string server;
        private string user;
        private string password;
        private string database;

        public DbBackupService()
        {
            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .AddUserSecrets<VentasDBContext>()
                    .Build();

                string connectionString = configuration["MySqlConnection"];

                var parts = connectionString.Split(';')
                    .Where(s => !string.IsNullOrEmpty(s))
                    .Select(s => s.Split(new[] { '=' }, 2))
                    .ToDictionary(s => s[0].Trim().ToLower(), s => s[1].Trim());

                server = parts["server"];
                user = parts["uid"];
                password = parts["pwd"];
                database = parts["database"];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer la configuración de la base de datos: {ex.Message}", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new InvalidOperationException("No se pudo leer la configuración de la base de datos.", ex);
            }
        }

        public void PerformBackup()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = $"backup_{database}_{DateTime.Now:yyyyMMdd_HHmmss}.sql",
                    Filter = "SQL Backup File (*.sql)|*.sql|All Files (*.*)|*.*",
                    Title = "Guardar Backup de Base de Datos"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    string args = $"--user=\"{user}\" --password=\"{password}\" --host=\"{server}\" --protocol=tcp --port=3306 --default-character-set=utf8 --routines --events --triggers \"{database}\"";

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "mysqldump",
                        Arguments = args,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = Process.Start(psi))
                    {
                        if (process == null)
                        {
                            throw new Exception("No se pudo iniciar el proceso mysqldump. ¿Está en el PATH del sistema?");
                        }

                        using (StreamReader reader = process.StandardOutput)
                        {
                            using (StreamWriter writer = new StreamWriter(savePath))
                            {
                                writer.Write(reader.ReadToEnd());
                            }
                        }

                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        if (process.ExitCode == 0)
                        {
                            MessageBox.Show($"Backup completado exitosamente y guardado en:\n{savePath}", "Backup Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            throw new Exception($"mysqldump falló con código {process.ExitCode}:\n{error}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el backup: {ex.Message}", "Error de Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PerformRestore()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SQL Backup File (*.sql)|*.sql|All Files (*.*)|*.*",
                Title = "Seleccionar Archivo de Backup para Restaurar",
                CheckFileExists = true
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string backupFilePath = openFileDialog.FileName;


            var confirmResult = MessageBox.Show(
                $"¡ADVERTENCIA MUY IMPORTANTE!\n\n" +
                $"Usted está a punto de SOBREESCRIBIR la base de datos '{database}' con el contenido del archivo:\n\n" +
                $"{Path.GetFileName(backupFilePath)}\n\n" +
                "¡TODOS LOS DATOS ACTUALES SERÁN PERDIDOS!\nEsta acción es IRREVERSIBLE.\n\n" +
                "¿Está ABSOLUTAMENTE SEGURO de que desea continuar?",
                "Confirmar Restauración Destructiva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (confirmResult != DialogResult.Yes)
            {
                MessageBox.Show("Restauración cancelada por el usuario.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string args = $"--user=\"{user}\" --password=\"{password}\" --host=\"{server}\" --protocol=tcp --port=3306 \"{database}\"";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "mysql", 
                Arguments = args,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(psi))
                {
                    if (process == null)
                    {
                        throw new Exception("No se pudo iniciar el proceso mysql.exe. ¿Está en el PATH del sistema?");
                    }

                    using (StreamReader reader = new StreamReader(backupFilePath))
                    {
                        using (StreamWriter writer = process.StandardInput)
                        {
                            
                            writer.Write(reader.ReadToEnd());
                        }
                    }

                    
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("Restauración completada exitosamente.", "Restauración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception($"mysql.exe falló con código {process.ExitCode}:\n{error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la restauración: {ex.Message}", "Error de Restauración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}