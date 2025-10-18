using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasApp.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace VentasApp.Views
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; set; }

        event EventHandler LoginEvent;

        void Close();
        void Hide();
        void Show();
    }
    public partial class LoginView : Form, ILoginView
    {
        public string Username => UsernameTextbox.Text;
        public string Password { get => PasswordTextbox.Text; set => PasswordTextbox.Text = value; }

        public event EventHandler LoginEvent;
        public LoginView()
        {
            InitializeComponent();
            SetupEventsHandler();
            LoadColorTheme();

        }

        private void LoadColorTheme()
        {
            LoginImage.Image = ColorThemes.LogoImage;
            this.BackColor = ColorThemes.Back2;
            LoginButton.BackColor = ColorThemes.Back2;
            LoginButton.ForeColor = ColorThemes.Primary;
            LoginButton.FlatAppearance.BorderColor = ColorThemes.BackHighlighted;
            LoginButton.FlatAppearance.MouseOverBackColor = ColorThemes.BackHighlighted;
            label1.ForeColor = ColorThemes.NormalText;
            label2.ForeColor = ColorThemes.NormalText;
            UsernameTextbox.BackColor = ColorThemes.Back2;
            UsernameTextbox.ForeColor = ColorThemes.NormalText;
            PasswordTextbox.BackColor = ColorThemes.Back2;
            PasswordTextbox.ForeColor = ColorThemes.NormalText;
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
