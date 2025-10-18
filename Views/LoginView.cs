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
            LoginImage.Image = Themes.LogoImage;
            this.BackColor = Themes.ColorBack2;
            LoginButton.BackColor = Themes.ColorBack2;
            LoginButton.ForeColor = Themes.ColorPrimary;
            LoginButton.FlatAppearance.BorderColor = Themes.ColorBackHighlighted;
            LoginButton.FlatAppearance.MouseOverBackColor = Themes.ColorBackHighlighted;
            label1.ForeColor = Themes.ColorNormalText;
            label2.ForeColor = Themes.ColorNormalText;
            UsernameTextbox.BackColor = Themes.ColorBack2;
            UsernameTextbox.ForeColor = Themes.ColorNormalText;
            PasswordTextbox.BackColor = Themes.ColorBack2;
            PasswordTextbox.ForeColor = Themes.ColorNormalText;
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
