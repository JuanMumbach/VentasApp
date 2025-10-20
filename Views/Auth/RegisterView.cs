using System;
using System.Windows.Forms;

namespace VentasApp.Views.Auth
{
    /// <summary>
    /// Vista de Registro que implementa IRegisterView.
    /// Permite al usuario crear una nueva cuenta en la aplicación.
    /// </summary>
    public partial class RegisterView : Form, IRegisterView
    {
        public RegisterView()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        // Implementación de propiedades de IRegisterView
        public string Username
        {
            get => txtUsername.Text;
            set => txtUsername.Text = value;
        }

        public string Email
        {
            get => txtEmail.Text;
            set => txtEmail.Text = value;
        }

        public string Password
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value;
        }

        public string ConfirmPassword
        {
            get => txtConfirmPassword.Text;
            set => txtConfirmPassword.Text = value;
        }

        public string FullName
        {
            get => txtFullName.Text;
            set => txtFullName.Text = value;
        }

        public string Phone
        {
            get => txtPhone.Text;
            set => txtPhone.Text = value;
        }

        // Implementación de eventos de IRegisterView
        public event EventHandler? RegisterEvent;
        public event EventHandler? CancelEvent;

        /// <summary>
        /// Configura los manejadores de eventos para los controles del formulario.
        /// </summary>
        private void SetupEventHandlers()
        {
            btnRegister.Click += (s, e) => RegisterEvent?.Invoke(this, EventArgs.Empty);
            btnCancel.Click += (s, e) => CancelEvent?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Muestra el formulario de registro.
        /// </summary>
        public void ShowView()
        {
            this.ShowDialog();
        }

        /// <summary>
        /// Cierra el formulario de registro.
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
        /// Limpia todos los campos del formulario.
        /// </summary>
        public void ClearFields()
        {
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtUsername.Focus();
        }

        /// <summary>
        /// Habilita o deshabilita los controles del formulario.
        /// </summary>
        public void SetRegisterEnabled(bool enabled)
        {
            btnRegister.Enabled = enabled;
            txtUsername.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtPassword.Enabled = enabled;
            txtConfirmPassword.Enabled = enabled;
            txtFullName.Enabled = enabled;
            txtPhone.Enabled = enabled;
        }
    }
}
