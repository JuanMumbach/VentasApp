using System;
using System.Windows.Forms;

namespace VentasApp.Views.Auth
{
    /// <summary>
    /// Vista de Login que implementa ILoginView.
    /// Permite al usuario autenticarse en la aplicación.
    /// </summary>
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        // Implementación de propiedades de ILoginView
        public string Username
        {
            get => txtUsername.Text;
            set => txtUsername.Text = value;
        }

        public string Password
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value;
        }

        // Implementación de eventos de ILoginView
        public event EventHandler? LoginEvent;
        public event EventHandler? RegisterLinkEvent;
        public event EventHandler? CancelEvent;

        /// <summary>
        /// Configura los manejadores de eventos para los controles del formulario.
        /// </summary>
        private void SetupEventHandlers()
        {
            btnLogin.Click += (s, e) => LoginEvent?.Invoke(this, EventArgs.Empty);
            linkRegister.LinkClicked += (s, e) => RegisterLinkEvent?.Invoke(this, EventArgs.Empty);
            btnCancel.Click += (s, e) => CancelEvent?.Invoke(this, EventArgs.Empty);

            // Permitir login con Enter en el campo de contraseña
            txtPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    LoginEvent?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        /// <summary>
        /// Muestra el formulario de login.
        /// </summary>
        public void ShowView()
        {
            this.ShowDialog();
        }

        /// <summary>
        /// Cierra el formulario de login.
        /// </summary>
        public void CloseView()
        {
            this.Close();
        }

        /// <summary>
        /// Muestra un mensaje al usuario.
        /// </summary>
        public void ShowMessage(string message, string title, bool isError = false)
        {
            MessageBoxIcon icon = isError ? MessageBoxIcon.Error : MessageBoxIcon.Information;
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Limpia los campos del formulario.
        /// </summary>
        public void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        /// <summary>
        /// Habilita o deshabilita el botón de login.
        /// </summary>
        public void SetLoginEnabled(bool enabled)
        {
            btnLogin.Enabled = enabled;
            txtUsername.Enabled = enabled;
            txtPassword.Enabled = enabled;
        }
    }
}
