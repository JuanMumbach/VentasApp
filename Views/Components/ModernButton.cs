using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VentasApp.Services;

namespace VentasApp.Views.Components
{
  /// <summary>
  /// Botón moderno con efectos visuales mejorados.
 /// Soporta iconos, bordes redondeados y animaciones suaves.
    /// </summary>
    public class ModernButton : Button
    {
        private int borderRadius = 8;
        private Color hoverBackColor;
      private Color normalBackColor;
    private bool isHovering = false;
        private Image? buttonIcon = null;
        private int iconSize = 20;
        private int iconPadding = 8;

        public int BorderRadius
 {
            get => borderRadius;
     set
            {
      borderRadius = value;
  Invalidate();
     }
        }

      public Image? ButtonIcon
        {
            get => buttonIcon;
    set
            {
       buttonIcon = value;
     Invalidate();
      }
        }

  public int IconSize
        {
            get => iconSize;
 set
            {
  iconSize = value;
         Invalidate();
 }
        }

        public ModernButton()
        {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
     Font = new Font("Segoe UI", 10F, FontStyle.Regular);
     Cursor = Cursors.Hand;
         Padding = new Padding(iconPadding);

   normalBackColor = BackColor;
      hoverBackColor = ControlPaint.Light(BackColor, 0.2f);

            MouseEnter += OnMouseEnterHandler;
    MouseLeave += OnMouseLeaveHandler;
     }

        private void OnMouseEnterHandler(object? sender, EventArgs e)
        {
            isHovering = true;
  BackColor = hoverBackColor;
        }

  private void OnMouseLeaveHandler(object? sender, EventArgs e)
        {
            isHovering = false;
            BackColor = normalBackColor;
        }

        protected override void OnPaint(PaintEventArgs e)
      {
     base.OnPaint(e);
     
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

  // Dibujar fondo con bordes redondeados
  using (GraphicsPath path = GetRoundedRectangle(ClientRectangle, borderRadius))
     {
       using (SolidBrush brush = new SolidBrush(BackColor))
  {
     e.Graphics.FillPath(brush, path);
       }

          // Borde sutil
      using (Pen pen = new Pen(ControlPaint.Dark(BackColor, 0.1f), 1))
     {
      e.Graphics.DrawPath(pen, path);
          }
          }

       // Dibujar icono si existe
            if (buttonIcon != null)
         {
             int iconX = iconPadding;
  int iconY = (Height - iconSize) / 2;
                
     Rectangle iconRect = new Rectangle(iconX, iconY, iconSize, iconSize);
     e.Graphics.DrawImage(buttonIcon, iconRect);
      }

// Dibujar texto
   TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;

            if (buttonIcon != null)
            {
  flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
     
      int textX = iconPadding * 2 + iconSize;
Rectangle textRect = new Rectangle(textX, 0, Width - textX - iconPadding, Height);
        TextRenderer.DrawText(e.Graphics, Text, Font, textRect, ForeColor, flags);
          }
         else
            {
         TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor, flags);
        }
        }

      private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

  path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
   path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

 return path;
        }

     public void SetColors(Color normal, Color hover, Color text)
        {
     normalBackColor = normal;
            hoverBackColor = hover;
            BackColor = normal;
      ForeColor = text;
        }
    }
}
