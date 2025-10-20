using System;
using System.Windows.Forms;
using VentasApp.Repositories;
using VentasApp.Utilities;
using VentasApp.Views.Auth;

namespace VentasApp.Presenters
{
    /// <summary>
    /// Presenter para la vista de Login.
    /// Maneja la lógica de autenticación del usuario.
    /// </summary>
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IUserRepository _userRepository;

        public bool LoginSuccessful { get; private set; }

        public LoginPresenter(ILoginView view, IUserRepository userRepository)
        {
            _view = view;
            _userRepository = userRepository;

            // Suscribirse a los eventos de la vista
            _view.LoginEvent += OnLogin;
            _view.RegisterLinkEvent += OnRegisterLink;
            _view.CancelEvent += OnCancel;

            LoginSuccessful = false;
        }

        /// <summary>
        /// Maneja el evento de inicio de sesión.
        /// Valida las credenciales y autentica al usuario.
        /// </summary>
        private void OnLogin(object? sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (string.IsNullOrWhiteSpace(_view.Username))
                {
                    _view.ShowMessage("Por favor ingrese su nombre de usuario.", "Campo requerido", true);
                    return;
                }

                if (string.IsNullOrWhiteSpace(_view.Password))
                {
                    _view.ShowMessage("Por favor ingrese su contraseña.", "Campo requerido", true);
                    return;
                }

                // Deshabilitar controles durante la validación
                _view.SetLoginEnabled(false);

                // Validar credenciales
                bool isValid = _userRepository.ValidateUser(_view.Username, _view.Password);

                if (isValid)
                {
                    // Obtener el usuario completo
                    var user = _userRepository.GetUserByUsername(_view.Username);

                    if (user == null)
                    {
                        _view.ShowMessage("Error al obtener información del usuario.", "Error", true);
                        _view.SetLoginEnabled(true);
                        return;
                    }

                    // Verificar que el usuario esté activo
                    if (!user.Active)
                    {
                        _view.ShowMessage("Esta cuenta está desactivada. Contacte al administrador.", "Cuenta desactivada", true);
                        _view.SetLoginEnabled(true);
                        return;
                    }

                    // Iniciar sesión
                    SessionManager.Instance.Login(user);
                    LoginSuccessful = true;

                    _view.ShowMessage($"¡Bienvenido {user.FullName}!", "Inicio de sesión exitoso");
                    _view.CloseView();
                }
                else
                {
                    _view.ShowMessage("Usuario o contraseña incorrectos.", "Error de autenticación", true);
                    _view.Password = string.Empty; // Limpiar contraseña
                    _view.SetLoginEnabled(true);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al intentar iniciar sesión: {ex.Message}", "Error", true);
                _view.SetLoginEnabled(true);
            }
        }

        /// <summary>
        /// Maneja el evento de click en el enlace de registro.
        /// Abre el formulario de registro.
        /// </summary>
        private void OnRegisterLink(object? sender, EventArgs e)
        {
            try
            {
                IRegisterView registerView = new RegisterView();
                RegisterPresenter registerPresenter = new RegisterPresenter(registerView, _userRepository);
                registerView.ShowView();

                // Si el registro fue exitoso, cerrar el login
                if (registerPresenter.RegistrationSuccessful)
                {
                    LoginSuccessful = true;
                    _view.CloseView();
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al abrir el formulario de registro: {ex.Message}", "Error", true);
            }
        }

        /// <summary>
        /// Maneja el evento de cancelación.
        /// Cierra la aplicación.
        /// </summary>
        private void OnCancel(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Está seguro que desea salir de la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
