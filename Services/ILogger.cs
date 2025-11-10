using System;

namespace VentasApp.Services
{
    /// <summary>
    /// Simple logger interface for application-wide logging.
    /// </summary>
    public interface ILogger
    {
        void LogInformation(string message);
  void LogWarning(string message);
    void LogError(string message, Exception? exception = null);
        void LogDebug(string message);
    }
}
