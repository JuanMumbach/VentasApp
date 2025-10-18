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
        private ILoginView loginView;
        private IUserRepository userRepository;

        public LoginPresenter(ILoginView loginView, IUserRepository userRepository)
        {
            this.loginView = loginView;
            this.userRepository = userRepository;

            this.loginView.LoginEvent += Login;
        }

        private void Login(object? sender, EventArgs e)
        {
            string username = loginView.Username;
            string password = loginView.Password;

            loginView.Password = string.Empty;
            int? isValidUser = userRepository.ValidateUser(username, password);
            if (isValidUser != null)
            {
                SessionManager.CurrentUsername = username;
                SessionManager.CurrentUserId = isValidUser.Value;

                MainView mainView = new MainView();

                new MainViewPresenter(mainView, loginView);

                mainView.Show();

                this.loginView.Hide();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
