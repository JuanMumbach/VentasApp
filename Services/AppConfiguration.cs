using System;
using System.IO;

namespace VentasApp.Services
{
    /// <summary>
    /// Centralized configuration manager for application settings.
  /// Provides access to common configuration values.
    /// </summary>
    public static class AppConfiguration
    {
   // Application Info
        public static string ApplicationName => "VentasApp";
        public static string ApplicationVersion => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";

        // Paths
  public static string ApplicationBasePath => AppDomain.CurrentDomain.BaseDirectory;
        public static string ImagesPath => Path.Combine(ApplicationBasePath, "images");
  public static string LogsPath => Path.Combine(ApplicationBasePath, "logs");
        public static string ReportsPath => Path.Combine(ApplicationBasePath, "reports");

     // User Roles
        public const int AdminRoleId = 1;
      public const int EmployeeRoleId = 2;

        // Pagination
        public const int DefaultPageSize = 50;
        public const int MaxPageSize = 100;

 // Validation
        public const int MaxUsernameLength = 50;
        public const int MaxEmailLength = 100;
     public const int MinPasswordLength = 6;
   public const int MaxPasswordLength = 100;

        // UI Settings
        public const int DefaultFormWidth = 800;
        public const int DefaultFormHeight = 600;

   // Business Rules
        public const decimal MinProductPrice = 0.01m;
     public const decimal MaxProductPrice = 999999.99m;
   public const int MinProductStock = 0;
        public const int MaxProductStock = 999999;

        // Session
        public const int SessionTimeoutMinutes = 480; // 8 hours

   /// <summary>
        /// Ensures that all required directories exist.
    /// </summary>
        public static void EnsureDirectoriesExist()
     {
            EnsureDirectoryExists(ImagesPath);
       EnsureDirectoryExists(LogsPath);
   EnsureDirectoryExists(ReportsPath);
}

   private static void EnsureDirectoryExists(string path)
   {
            if (!Directory.Exists(path))
         {
            Directory.CreateDirectory(path);
  }
        }

     /// <summary>
   /// Gets a full file path for storing images.
/// </summary>
   public static string GetImagePath(string fileName)
 {
            return Path.Combine(ImagesPath, fileName);
        }

  /// <summary>
    /// Gets a full file path for storing logs.
/// </summary>
  public static string GetLogPath(string fileName)
   {
        return Path.Combine(LogsPath, fileName);
   }

 /// <summary>
   /// Gets a full file path for storing reports.
   /// </summary>
        public static string GetReportPath(string fileName)
        {
      return Path.Combine(ReportsPath, fileName);
  }
    }
}
