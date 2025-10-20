using System;
using System.Text.RegularExpressions;
using VentasApp.Models.DTOs;
using VentasApp.Repositories;
using VentasApp.Utilities;
using VentasApp.Views.Auth;

namespace VentasApp.Presenters
{
    /// <summary>
    /// Presenter para la vista de Registro.
    /// Maneja la lógica de creación de nuevas cuentas de usuario.
    /// </summary>
    public class RegisterPresenter
    {
        private readonly IRegisterView _view;
        private readonly IUserRepository _userRepository;

        public bool RegistrationSuccessful { get; private set; }

        public RegisterPresenter(IRegisterView view, IUserRepository userRepository)
        {
            _view = view;
            _userRepository = userRepository;

            // Suscribirse a los eventos de la vista
            _view.RegisterEvent += OnRegister;
            _view.CancelEvent += OnCancel;

            RegistrationSuccessful = false;
        }

        /// <summary>
        /// Maneja el evento de registro.
        /// Valida los datos y crea el nuevo usuario.
        /// </summary>
        private void OnRegister(object? sender, EventArgs e)
        {
            try
            {
                // Validar todos los campos
                if (!ValidateFields())
                {
                    return;
                }

                // Deshabilitar controles durante el registro
                _view.SetRegisterEnabled(false);

                // Crear el DTO para agregar el usuario
                var addUserDTO = new AddUserDTO
                {
                    Username = _view.Username.Trim(),
                    Email = _view.Email.Trim(),
                    Password = _view.Password,
                    FullName = _view.FullName.Trim(),
                    Phone = string.IsNullOrWhiteSpace(_view.Phone) ? null : _view.Phone.Trim(),
                    RoleId = 2 // Por defecto, los usuarios registrados son empleados
                };

                // Agregar el usuario
                _userRepository.AddUser(addUserDTO);

                // Obtener el usuario recién creado para iniciar sesión automáticamente
                var newUser = _userRepository.GetUserByUsername(addUserDTO.Username);

                if (newUser != null)
                {
                    // Iniciar sesión automáticamente
                    SessionManager.Instance.Login(newUser);
                    RegistrationSuccessful = true;

                    _view.ShowMessage(
                        $"¡Cuenta creada exitosamente!\n\nBienvenido {newUser.FullName}",
                        "Registro exitoso");

                    _view.CloseView();
                }
                else
                {
                    _view.ShowMessage(
                        "Usuario creado pero hubo un problema al iniciar sesión. Por favor, inicie sesión manualmente.",
                        "Advertencia");
                    _view.SetRegisterEnabled(true);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al registrar usuario: {ex.Message}", "Error", true);
                _view.SetRegisterEnabled(true);
            }
        }

        /// <summary>
        /// Valida todos los campos del formulario de registro.
        /// </summary>
        private bool ValidateFields()
        {
            // Validar nombre de usuario
            if (string.IsNullOrWhiteSpace(_view.Username))
            {
                _view.ShowMessage("Por favor ingrese un nombre de usuario.", "Campo requerido", true);
                return false;
            }

            if (_view.Username.Length < 3)
            {
                _view.ShowMessage("El nombre de usuario debe tener al menos 3 caracteres.", "Validación", true);
                return false;
            }

            if (_view.Username.Length > 50)
            {
                _view.ShowMessage("El nombre de usuario no puede exceder 50 caracteres.", "Validación", true);
                return false;
            }

            // Verificar si el username ya existe
            if (!_userRepository.IsUsernameAvailable(_view.Username))
            {
                _view.ShowMessage("Este nombre de usuario ya está en uso. Por favor elija otro.", "Usuario existente", true);
                return false;
            }

            // Validar email
            if (string.IsNullOrWhiteSpace(_view.Email))
            {
                _view.ShowMessage("Por favor ingrese un correo electrónico.", "Campo requerido", true);
                return false;
            }

            if (!IsValidEmail(_view.Email))
            {
                _view.ShowMessage("Por favor ingrese un correo electrónico válido.", "Email inválido", true);
                return false;
            }

            // Verificar si el email ya existe
            if (!_userRepository.IsEmailAvailable(_view.Email))
            {
                _view.ShowMessage("Este correo electrónico ya está registrado.", "Email existente", true);
                return false;
            }

            // Validar nombre completo
            if (string.IsNullOrWhiteSpace(_view.FullName))
            {
                _view.ShowMessage("Por favor ingrese su nombre completo.", "Campo requerido", true);
                return false;
            }

            if (_view.FullName.Length > 100)
            {
                _view.ShowMessage("El nombre completo no puede exceder 100 caracteres.", "Validación", true);
                return false;
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.ShowMessage("Por favor ingrese una contraseña.", "Campo requerido", true);
                return false;
            }

            if (_view.Password.Length < 6)
            {
                _view.ShowMessage("La contraseña debe tener al menos 6 caracteres.", "Contraseña débil", true);
                return false;
            }

            // Validar confirmación de contraseña
            if (_view.Password != _view.ConfirmPassword)
            {
                _view.ShowMessage("Las contraseñas no coinciden.", "Error de confirmación", true);
                return false;
            }

            // Validar teléfono (opcional)
            if (!string.IsNullOrWhiteSpace(_view.Phone) && _view.Phone.Length > 15)
            {
                _view.ShowMessage("El número de teléfono no puede exceder 15 caracteres.", "Validación", true);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida el formato de un correo electrónico.
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Maneja el evento de cancelación.
        /// </summary>
        private void OnCancel(object? sender, EventArgs e)
        {
            _view.CloseView();
        }
    }
}
