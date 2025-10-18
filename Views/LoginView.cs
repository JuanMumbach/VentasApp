using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasApp.Views
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }

        event EventHandler LoginEvent;

        void Close();
        void Hide();
        void Show();
    }
    public partial class LoginView : Form, ILoginView
    {
        public string Username => UsernameTextbox.Text;
        public string Password => PasswordTextbox.Text;

        public event EventHandler LoginEvent;
        public LoginView()
        {
            InitializeComponent();
            SetupEventsHandler();
        }

        private void SetupEventsHandler()
        {
            LoginButton.Click += delegate
            {
                LoginEvent?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
