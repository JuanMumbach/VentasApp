using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VentasApp.Views.Components
{
 /// <summary>
    /// TextBox moderno con bordes redondeados y efectos de foco.
    /// </summary>
    public class ModernTextBox : Panel
    {
     private TextBox innerTextBox;
   private int borderRadius = 8;
        private Color borderColor = Color.FromArgb(200, 200, 200);
  private Color focusBorderColor = Color.FromArgb(0, 123, 255);
        private bool isFocused = false;
        private string placeholderText = "";
        private Color placeholderColor = Color.Gray;

  public override string Text
 {
   get => innerTextBox.Text;
      set => innerTextBox.Text = value;
        }

   public string PlaceholderText
  {
         get => placeholderText;
  set
       {
         placeholderText = value;
      UpdatePlaceholder();
     }
   }

      public char PasswordChar
 {
   get => innerTextBox.PasswordChar;
      set => innerTextBox.PasswordChar = value;
        }

        public int BorderRadius
   {
       get => borderRadius;
      set
    {
     borderRadius = value;
        Invalidate();
         }
        }

  public Color BorderColor
        {
  get => borderColor;
    set
     {
      borderColor = value;
   Invalidate();
            }
        }

   public Color FocusBorderColor
 {
       get => focusBorderColor;
      set
       {
     focusBorderColor = value;
     Invalidate();
  }
 }

  public new Font Font
 {
       get => innerTextBox.Font;
          set => innerTextBox.Font = value;
        }

  public ModernTextBox()
        {
   innerTextBox = new TextBox
   {
     BorderStyle = BorderStyle.None,
   Location = new Point(10, 8),
     Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
     Font = new Font("Segoe UI", 11F)
    };

    Size = new Size(250, 35);
       Padding = new Padding(10, 8, 10, 8);

       Controls.Add(innerTextBox);

        innerTextBox.GotFocus += (s, e) =>
       {
isFocused = true;
            if (innerTextBox.Text == placeholderText)
     {
         innerTextBox.Text = "";
   innerTextBox.ForeColor = ForeColor;
       }
     Invalidate();
      };

        innerTextBox.LostFocus += (s, e) =>
            {
 isFocused = false;
          UpdatePlaceholder();
     Invalidate();
     };

       innerTextBox.TextChanged += (s, e) => OnTextChanged(e);

   UpdatePlaceholder();
        }

  private void UpdatePlaceholder()
     {
      if (string.IsNullOrEmpty(innerTextBox.Text) && !isFocused)
            {
                innerTextBox.Text = placeholderText;
          innerTextBox.ForeColor = placeholderColor;
      }
    else if (innerTextBox.Text == placeholderText)
         {
       innerTextBox.ForeColor = placeholderColor;
     }
  else
     {
 innerTextBox.ForeColor = ForeColor;
 }
        }

      protected override void OnPaint(PaintEventArgs e)
 {
     base.OnPaint(e);
   
   e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

 // Dibujar fondo
      using (GraphicsPath path = GetRoundedRectangle(ClientRectangle, borderRadius))
   {
    using (SolidBrush brush = new SolidBrush(BackColor))
       {
  e.Graphics.FillPath(brush, path);
      }

           // Dibujar borde
    Color currentBorderColor = isFocused ? focusBorderColor : borderColor;
     using (Pen pen = new Pen(currentBorderColor, isFocused ? 2 : 1))
   {
e.Graphics.DrawPath(pen, path);
     }
         }
        }

private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
  {
 GraphicsPath path = new GraphicsPath();
     int diameter = radius * 2;

  // Ajustar rectángulo para el borde
  rect.Inflate(-1, -1);

path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
      path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
     path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
      path.CloseFigure();

    return path;
 }

        protected override void OnResize(EventArgs e)
  {
  base.OnResize(e);
      
       // Ajustar tamaño del textbox interno
            if (innerTextBox != null)
 {
       innerTextBox.Width = Width - 20;
     innerTextBox.Height = Height - 16;
       }
    }
    }
}
