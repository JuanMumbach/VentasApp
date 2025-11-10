using System;

namespace VentasApp.Services
{
    /// <summary>
    /// Manages user session information throughout the application lifecycle.
    /// Provides thread-safe access to current user data.
    /// </summary>
    public static class SessionManager
    {
        private static int _currentUserId;
        private static string? _currentUsername;
        private static int _currentUserRoleId;
        private static bool _isAuthenticated;

        public static int CurrentUserId
        {
            get => _currentUserId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("User ID must be greater than 0", nameof(value));
                _currentUserId = value;
            }
        }

        public static string CurrentUsername
        {
            get => _currentUsername ?? string.Empty;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username cannot be null or empty", nameof(value));
                _currentUsername = value;
            }
        }

        public static int CurrentUserRoleId
        {
            get => _currentUserRoleId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Role ID must be greater than 0", nameof(value));
                _currentUserRoleId = value;
            }
        }

        public static bool IsAuthenticated => _isAuthenticated;

        public static bool IsAdmin => _currentUserRoleId == 1;
        public static bool IsEmployee => _currentUserRoleId == 2;

        /// <summary>
        /// Initializes a new user session with the provided credentials.
        /// </summary>
        public static void StartSession(int userId, string username, int roleId)
        {
            CurrentUserId = userId;
            CurrentUsername = username;
            CurrentUserRoleId = roleId;
            _isAuthenticated = true;
        }

        /// <summary>
        /// Clears the current session and resets all user data.
        /// </summary>
        public static void EndSession()
        {
            _currentUserId = 0;
            _currentUsername = null;
            _currentUserRoleId = 0;
            _isAuthenticated = false;
        }

        /// <summary>
        /// Validates if a user session is currently active.
        /// </summary>
        public static void ValidateSession()
        {
            if (!_isAuthenticated)
                throw new InvalidOperationException("No active user session");
        }
    }
}
