using System;
using System.Drawing;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Services;

namespace VentasApp.Views.User
{
    public partial class UserView : BaseForm, IUserView
    {
        public event EventHandler SaveUserEvent;
        public event EventHandler CancelUserEvent;

        public UserView()
        {
            InitializeComponent();
            SetupEventHandlers();
            SetupRoles();
            IsEditMode = false;
        }

        public UserView(int userId) : this()
        {
            UserId = userId;
            IsEditMode = true;
        }

        public int UserId { get; set; }

        public string Username
        {
            get { return UsernameTextBox.Text; }
            set { UsernameTextBox.Text = value; }
        }

        public string Email
        {
            get { return EmailTextBox.Text; }
            set { EmailTextBox.Text = value; }
        }

        public string Password
        {
            get { return PasswordTextBox.Text; }
            set { PasswordTextBox.Text = value; }
        }

        public string FullName
        {
            get { return FullNameTextBox.Text; }
            set { FullNameTextBox.Text = value; }
        }

        public string Role
        {
            get { return RoleComboBox.SelectedItem?.ToString() ?? ""; }
            set { 
                if (RoleComboBox.Items.Contains(value))
                    RoleComboBox.SelectedItem = value; 
                else
                    RoleComboBox.SelectedIndex = 0; // Default to first item
            }
        }

        public int RoleId
        {
            get 
            { 
                var selectedRole = RoleComboBox.SelectedItem?.ToString();
                return PermissionManager.GetRoleIdByName(selectedRole ?? "");
            }
            set 
            {
                var roleName = PermissionManager.getRoleNameById(value);
                if (RoleComboBox.Items.Contains(roleName))
                    RoleComboBox.SelectedItem = roleName; 
                else
                    RoleComboBox.SelectedIndex = 0; // Default to first item
            }
        }

        public string Phone
        {
            get { return PhoneTextBox.Text; }
            set { PhoneTextBox.Text = value; }
        }

        public bool IsEditMode
        {
            get; set;
        }

        private void SetupEventHandlers()
        {
            SaveButton.Click += (s, e) => SaveUserEvent?.Invoke(this, EventArgs.Empty);
            CancelButton.Click += (s, e) => CancelUserEvent?.Invoke(this, EventArgs.Empty);
        }

        private void SetupRoles()
        {
            // Usar roles definidos en UserRoles
            RoleComboBox.Items.Clear();
            RoleComboBox.Items.AddRange(PermissionManager.getRoleNames());
            RoleComboBox.SelectedIndex = 1; // Employee por defecto (índice 1)
        }

        public void ShowDialogView()
        {
            this.Text = IsEditMode ? "Editar Usuario" : "Agregar Usuario";
            PasswordLabel.Text = IsEditMode ? "Nueva Contraseña (opcional):" : "Contraseña:";
            
            // En modo edición, la contraseña no es obligatoria
            if (IsEditMode)
            {
                PasswordTextBox.PlaceholderText = "Dejar vacío para mantener la actual";
            }
            
            this.ShowDialog();
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void CloseView()
        {
            this.Close();
        }

        public void SetRoleComboBoxDataSource(object dataSource)
        {
            RoleComboBox.DataSource = dataSource;
        }
    }
}