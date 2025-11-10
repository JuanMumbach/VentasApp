using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views;

namespace VentasApp.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView loginView;
        private readonly IUserRepository userRepository;
        private readonly ILogger logger;

        public LoginPresenter(ILoginView loginView, IUserRepository userRepository, ILogger? logger = null)
        {
            this.loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.logger = logger ?? new FileLogger();

            this.loginView.LoginEvent += Login;
        }

        private void Login(object? sender, EventArgs e)
        {
            try
            {
                string username = loginView.Username;
                string password = loginView.Password;

                // Clear password field for security
                loginView.Password = string.Empty;

                // Validate input
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                logger.LogInformation($"Login attempt for user: {username}");

                int? isValidUser = userRepository.ValidateUser(username, password);
                if (isValidUser != null)
                {
                    var user = userRepository.GetUserByUsername(username);

                    if (user == null)
                    {
                        logger.LogWarning($"User validated but not found: {username}");
                        ShowAuthenticationError();
                        return;
                    }

                    // Check if user is active
                    if (!user.Active)
                    {
                        logger.LogWarning($"Inactive user attempted login: {username}");
                        MessageBox.Show("Su cuenta ha sido desactivada. Contacte al administrador.", "Cuenta desactivada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Start session using improved SessionManager
                    SessionManager.StartSession(isValidUser.Value, username, user.RoleId);
                    logger.LogInformation($"User logged in successfully: {username} (Role: {user.RoleId})");

                    MainView mainView = new MainView();
                    new MainViewPresenter(mainView, loginView, logger);

                    mainView.Show();
                    this.loginView.Hide();
                }
                else
                {
                    logger.LogWarning($"Failed login attempt for user: {username}");
                    ShowAuthenticationError();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error during login process", ex);
                MessageBox.Show("Ocurrió un error durante el inicio de sesión. Por favor, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAuthenticationError()
        {
            MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
