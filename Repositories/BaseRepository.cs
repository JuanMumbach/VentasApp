using System;
using System.Threading.Tasks;
using VentasApp.Services;

namespace VentasApp.Repositories
{
    /// <summary>
    /// Base repository class providing common database operations.
    /// Implements IDisposable for proper resource management.
    /// </summary>
    public abstract class BaseRepository : IDisposable
    {
        protected readonly ILogger Logger;
        private bool disposed = false;

        protected BaseRepository(ILogger? logger = null)
      {
      Logger = logger ?? new FileLogger();
        }

        /// <summary>
        /// Executes a database operation with error handling and logging.
     /// </summary>
   protected T ExecuteWithErrorHandling<T>(Func<T> operation, string operationName, T defaultValue = default!)
        {
            try
         {
          Logger.LogDebug($"Executing: {operationName}");
      var result = operation();
         Logger.LogDebug($"Completed: {operationName}");
   return result;
   }
 catch (Exception ex)
   {
      Logger.LogError($"Error in {operationName}", ex);
      throw;
     }
        }

   /// <summary>
 /// Executes a database operation asynchronously with error handling and logging.
   /// </summary>
        protected async Task<T> ExecuteWithErrorHandlingAsync<T>(Func<Task<T>> operation, string operationName, T defaultValue = default!)
   {
      try
       {
    Logger.LogDebug($"Executing async: {operationName}");
     var result = await operation();
          Logger.LogDebug($"Completed async: {operationName}");
       return result;
}
  catch (Exception ex)
  {
       Logger.LogError($"Error in async {operationName}", ex);
       throw;
    }
 }

        /// <summary>
        /// Validates that an entity exists, throwing an exception if not found.
   /// </summary>
   protected void ValidateEntityExists<T>(T? entity, int id, string entityName) where T : class
  {
         if (entity == null)
      {
         string message = $"{entityName} with ID {id} not found";
       Logger.LogWarning(message);
       throw new InvalidOperationException(message);
      }
   }

        public void Dispose()
     {
 Dispose(true);
       GC.SuppressFinalize(this);
        }

 protected virtual void Dispose(bool disposing)
        {
     if (!disposed)
    {
      if (disposing)
       {
       // Dispose managed resources if any
       }
      disposed = true;
}
 }
    }
}
