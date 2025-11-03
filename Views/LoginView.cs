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
    public interface ILoginView : IBaseForm
    {
        string Username { get; }
        string Password { get; set; }

        event EventHandler LoginEvent;

        void Close();
        void Hide();
        void Show();
    }
    public partial class LoginView : BaseForm, ILoginView
    {
        public string Username => UsernameTextbox.Text;
        public string Password { get => PasswordTextbox.Text; set => PasswordTextbox.Text = value; }

        public event EventHandler LoginEvent;
        public LoginView()
        {
            InitializeComponent();
            SetupEventsHandler();


        }

        protected override void CustomTheme()
        {
            LoginImage.Image = Themes.LogoImage;
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
