using System;
using System.IO;

namespace VentasApp.Services
{
    /// <summary>
    /// File-based logger implementation.
    /// Writes log messages to a file with timestamp and severity level.
    /// </summary>
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;
        private readonly object _lockObject = new object();

    public FileLogger()
  {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
    if (!Directory.Exists(logDirectory))
         {
                Directory.CreateDirectory(logDirectory);
       }
        
            string logFileName = $"app_{DateTime.Now:yyyyMMdd}.log";
            _logFilePath = Path.Combine(logDirectory, logFileName);
        }

     public void LogInformation(string message)
      {
            WriteLog("INFO", message);
        }

 public void LogWarning(string message)
      {
            WriteLog("WARN", message);
    }

 public void LogError(string message, Exception? exception = null)
   {
            string fullMessage = exception != null 
        ? $"{message}\nException: {exception.Message}\nStackTrace: {exception.StackTrace}"
   : message;
          WriteLog("ERROR", fullMessage);
        }

        public void LogDebug(string message)
    {
        #if DEBUG
      WriteLog("DEBUG", message);
  #endif
 }

        private void WriteLog(string level, string message)
        {
       try
      {
             lock (_lockObject)
     {
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
 File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
         }
        }
         catch
 {
     // Silently fail to avoid breaking the application
            }
        }
    }
}
