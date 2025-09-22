using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using VentasApp.Models.DTOs;
using VentasApp.Repositories;
using VentasApp.Views.User;
using VentasApp.Models;

namespace VentasApp.Presenters
{
    public class UserPresenter
    {
        private IUserView view;
        private IUserRepository repository;

        public UserPresenter(IUserView view, IUserRepository repository)
        {
            this.view = view;
            this.repository = repository;

            this.view.SaveUserEvent += SaveUser;
            this.view.CancelUserEvent += CancelUser;

            if (view.IsEditMode)
            {
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            try
            {
                var user = repository.GetUserById(view.UserId);
                if (user != null)
                {
                    view.Username = user.Username;
                    view.Email = user.Email;
                    view.FullName = user.FullName;
                    view.RoleId = user.RoleId; // Usar RoleId en lugar de Role
                    view.Phone = user.Phone ?? "";
                    // No cargar la contraseña por seguridad
                }
                else
                {
                    view.ShowMessage("Usuario no encontrado.", "Error", MessageBoxIcon.Error);
                    view.CloseView();
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Error al cargar los datos del usuario: {ex.Message}", 
                    "Error", MessageBoxIcon.Error);
                view.CloseView();
            }
        }

        private void SaveUser(object sender, EventArgs e)
        {
            try
            {
                if (ValidateUserData())
                {
                    if (view.IsEditMode)
                    {
                        UpdateUser();
                    }
                    else
                    {
                        AddUser();
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Error al guardar el usuario: {ex.Message}", 
                    "Error", MessageBoxIcon.Error);
            }
        }

        private void AddUser()
        {
            // Validar que el username y email no existan
            if (!repository.IsUsernameAvailable(view.Username))
            {
                view.ShowMessage("El nombre de usuario ya existe.", "Error", MessageBoxIcon.Warning);
                return;
            }

            if (!repository.IsEmailAvailable(view.Email))
            {
                view.ShowMessage("El email ya está registrado.", "Error", MessageBoxIcon.Warning);
                return;
            }

            var userDTO = new AddUserDTO
            {
                Username = view.Username,
                Email = view.Email,
                Password = view.Password,
                FullName = view.FullName,
                RoleId = view.RoleId, // Usar RoleId en lugar de Role
                Phone = string.IsNullOrWhiteSpace(view.Phone) ? null : view.Phone
            };

            repository.AddUser(userDTO);
            view.ShowMessage("Usuario agregado correctamente.", "Éxito", MessageBoxIcon.Information);
            view.CloseView();
        }

        private void UpdateUser()
        {
            // Validar que el username y email no existan para otros usuarios
            var existingUserByUsername = repository.GetUserByUsername(view.Username);
            if (existingUserByUsername != null && existingUserByUsername.Id != view.UserId)
            {
                view.ShowMessage("El nombre de usuario ya existe.", "Error", MessageBoxIcon.Warning);
                return;
            }

            var existingUserByEmail = repository.GetUserByEmail(view.Email);
            if (existingUserByEmail != null && existingUserByEmail.Id != view.UserId)
            {
                view.ShowMessage("El email ya está registrado.", "Error", MessageBoxIcon.Warning);
                return;
            }

            var userDTO = new UpdateUserDTO
            {
                Id = view.UserId,
                Username = view.Username,
                Email = view.Email,
                FullName = view.FullName,
                RoleId = view.RoleId, // Usar RoleId en lugar de Role
                Phone = string.IsNullOrWhiteSpace(view.Phone) ? null : view.Phone,
                Password = string.IsNullOrWhiteSpace(view.Password) ? null : view.Password
            };

            repository.UpdateUser(userDTO);
            view.ShowMessage("Usuario actualizado correctamente.", "Éxito", MessageBoxIcon.Information);
            view.CloseView();
        }

        private bool ValidateUserData()
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(view.Username))
            {
                view.ShowMessage("El nombre de usuario es requerido.", "Error", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(view.Email))
            {
                view.ShowMessage("El email es requerido.", "Error", MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidEmail(view.Email))
            {
                view.ShowMessage("El formato del email no es válido.", "Error", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(view.FullName))
            {
                view.ShowMessage("El nombre completo es requerido.", "Error", MessageBoxIcon.Warning);
                return false;
            }

            if (!UserRoles.IsValidRoleId(view.RoleId))
            {
                view.ShowMessage("El rol seleccionado no es válido.", "Error", MessageBoxIcon.Warning);
                return false;
            }

            // Validar contraseña solo si no está en modo edición o si se proporcionó una nueva
            if (!view.IsEditMode && string.IsNullOrWhiteSpace(view.Password))
            {
                view.ShowMessage("La contraseña es requerida.", "Error", MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(view.Password) && view.Password.Length < 6)
            {
                view.ShowMessage("La contraseña debe tener al menos 6 caracteres.", "Error", MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var emailAttribute = new EmailAddressAttribute();
                return emailAttribute.IsValid(email);
            }
            catch
            {
                return false;
            }
        }

        private void CancelUser(object sender, EventArgs e)
        {
            view.CloseView();
        }
    }
}