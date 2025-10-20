using VentasApp.Models;

namespace VentasApp.Utilities
{
    /// <summary>
    /// Gestiona la sesión del usuario autenticado en la aplicación.
    /// Implementa el patrón Singleton para garantizar una única instancia.
    /// </summary>
    public sealed class SessionManager
    {
        private static SessionManager? _instance;
        private static readonly object _lock = new object();

        public UserModel? CurrentUser { get; private set; }
        public bool IsAuthenticated => CurrentUser != null;

        // Constructor privado para Singleton
        private SessionManager() { }

        /// <summary>
        /// Obtiene la instancia única de SessionManager.
        /// </summary>
        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SessionManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Inicia sesión con el usuario especificado.
        /// </summary>
        public void Login(UserModel user)
        {
            CurrentUser = user;
        }

        /// <summary>
        /// Cierra la sesión actual.
        /// </summary>
        public void Logout()
        {
            CurrentUser = null;
        }

        /// <summary>
        /// Verifica si el usuario actual tiene un rol específico.
        /// </summary>
        public bool HasRole(int roleId)
        {
            return CurrentUser?.RoleId == roleId;
        }

        /// <summary>
        /// Verifica si el usuario actual es administrador.
        /// </summary>
        public bool IsAdmin => HasRole(1);

        /// <summary>
        /// Verifica si el usuario actual es empleado.
        /// </summary>
        public bool IsEmployee => HasRole(2);
    }
}
