using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Views.User;

namespace VentasApp.Presenters
{
    public class ListUsersPresenter
    {
        private IListUsersView view;
        private IUserRepository repository;
        private BindingSource usersBindingSource;
        private IEnumerable<UserModel> userList;

        public ListUsersPresenter(IListUsersView view, IUserRepository repository)
        {
            this.usersBindingSource = new BindingSource();

            this.view = view;
            this.repository = repository;

            this.view.SearchUserEvent += SearchUser;
            this.view.AddUserViewEvent += LoadAddUserView;
            this.view.EditUserViewEvent += LoadEditUserView;
            this.view.DeleteUserEvent += DeleteUser;
            this.view.RestoreUserEvent += RestoreUser;
            this.view.ShowDeletedCheckboxChange += (s, e) => LoadAllUsersList();
            this.view.SetUsersListBindingSource(usersBindingSource);

            LoadAllUsersList();
        }

        private void LoadEditUserView(object? sender, EventArgs e)
        {
            int? id = view.GetSelectedUserId();
            if (id != null)
            {
                try
                {
                    IUserView userView = new UserView((int)id);
                    new UserPresenter(userView, repository);
                    userView.ShowDialogView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir la vista de edición: {ex.Message}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadAddUserView(object? sender, EventArgs e)
        {
            try
            {
                IUserView userView = new UserView();
                new UserPresenter(userView, repository);
                userView.ShowDialogView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la vista de agregar usuario: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllUsersList()
        {
            try
            {
                if (view.showDeletedUsers)
                {
                    userList = repository.GetAllUsers();
                }
                else
                {
                    userList = repository.GetActiveUsers(true);
                }



                var displayList = userList.Select(u => new
                {
                    u.Id,
                    u.Username,
                    Role = u.RoleName,
                    u.Email,
                    u.FullName,
                    u.Phone,
                    Active = u.Active ? "Activo" : "Eliminado"
                }).ToList();

                usersBindingSource.DataSource = displayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de usuarios: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchUser(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(view.searchValue))
                {
                    LoadAllUsersList();
                }
                else
                {
                    if (view.showDeletedUsers)
                    {
                        userList = repository.SearchUsers(view.searchValue);
                    }
                    else
                    {
                        userList = repository.SearchUsers(view.searchValue, activeState: true);
                    }
                }

                var displayList = userList.Select(u => new
                {
                    u.Id,
                    u.Username,
                    Role = u.RoleName,
                    u.Email,
                    u.FullName,
                    u.Phone,
                    Active = u.Active ? "Activo" : "Eliminado"
                }).ToList();

                usersBindingSource.DataSource = displayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuarios: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteUser(object? sender, EventArgs e)
        {
            var selectedUserInfo = view.GetSelectedUserInfo();
            if (selectedUserInfo.HasValue && selectedUserInfo.Value.Id.HasValue)
            {
                var result = MessageBox.Show(
                    "¿Está seguro que desea eliminar este usuario?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        repository.DeleteUser(selectedUserInfo.Value.Id.Value);
                        LoadAllUsersList(); // Recarga la lista para reflejar el cambio
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RestoreUser(object? sender, EventArgs e)
        {
            var selectedUserInfo = view.GetSelectedUserInfo();
            if (selectedUserInfo.HasValue && selectedUserInfo.Value.Id.HasValue)
            {
                var result = MessageBox.Show(
                    "¿Está seguro que desea restaurar este usuario?",
                    "Confirmar restauración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        repository.RestoreUser(selectedUserInfo.Value.Id.Value);
                        LoadAllUsersList(); // Recarga la lista para reflejar el cambio
                        MessageBox.Show("Usuario restaurado correctamente.", "Éxito", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al restaurar el usuario: {ex.Message}", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}