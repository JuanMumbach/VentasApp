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
         ConfigureModernDesign();
        }

        protected override void CustomTheme()
 {
       LoginImage.Image = Themes.LogoImage;
        
    // Aplicar colores al panel principal
   if (MainLoginPanel != null)
       {
     MainLoginPanel.BackColor = Themes.MainViewBackgroundColor;
       }

    // Aplicar estilo al título
   if (TitleLabel != null)
  {
        TitleLabel.Font = Themes.HeaderFont;
TitleLabel.ForeColor = Themes.ColorNormalText;
   }

      // Aplicar estilo a las etiquetas
   if (UsernameLabel != null)
   {
      UsernameLabel.Font = Themes.NormalFont;
     UsernameLabel.ForeColor = Themes.SubtleTextColor;
    }
    
        if (PasswordLabel != null)
  {
   PasswordLabel.Font = Themes.NormalFont;
  PasswordLabel.ForeColor = Themes.SubtleTextColor;
   }

// Estilizar el botón de login como botón principal
     SetAcceptButton(LoginButton);
      LoginButton.Font = new Font(Themes.NormalFont.FontFamily, 12F, FontStyle.Bold);
   }

  private void ConfigureModernDesign()
        {
    // Configurar formulario
  this.FormBorderStyle = FormBorderStyle.None;
this.StartPosition = FormStartPosition.CenterScreen;
     this.BackColor = Themes.MainViewBackgroundColor;
  this.Size = new Size(450, 550);

       // Agregar sombra (simulada con panel)
     if (!this.Controls.Contains(ShadowPanel))
  {
       this.Controls.Add(ShadowPanel);
            ShadowPanel.BringToFront();
   }
        }
  
     private void SetupEventsHandler()
 {
  LoginButton.Click += delegate
       {
     LoginEvent?.Invoke(this, EventArgs.Empty);
     };

// Enter en username va a password
  UsernameTextbox.KeyDown += (s, e) =>
    {
     if (e.KeyCode == Keys.Enter)
      {
       PasswordTextbox.Focus();
   e.Handled = true;
     e.SuppressKeyPress = true;
     }
      };

     // Enter en password hace login
       PasswordTextbox.KeyDown += (s, e) =>
    {
    if (e.KeyCode == Keys.Enter)
            {
        LoginEvent?.Invoke(this, EventArgs.Empty);
   e.Handled = true;
      e.SuppressKeyPress = true;
     }
 };
        }

        // Permitir arrastrar el formulario
   private bool dragging = false;
  private Point dragCursorPoint;
   private Point dragFormPoint;

  protected override void OnMouseDown(MouseEventArgs e)
        {
    dragging = true;
       dragCursorPoint = Cursor.Position;
  dragFormPoint = this.Location;
      base.OnMouseDown(e);
     }

 protected override void OnMouseMove(MouseEventArgs e)
     {
   if (dragging)
       {
     Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
     this.Location = Point.Add(dragFormPoint, new Size(dif));
          }
     base.OnMouseMove(e);
  }

  protected override void OnMouseUp(MouseEventArgs e)
        {
            dragging = false;
      base.OnMouseUp(e);
 }
    }
}
