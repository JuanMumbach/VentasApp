using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsTimer = System.Windows.Forms.Timer;

namespace VentasApp.Services
{
    /// <summary>
    /// Utilidades para animaciones y transiciones visuales suaves.
    /// </summary>
    public static class UIAnimations
    {
        /// <summary>
        /// Anima la transición de color de un control.
        /// </summary>
        public static void AnimateColorTransition(Control control, Color targetColor, int durationMs = 200)
        {
            if (control == null) return;

            Color startColor = control.BackColor;
            int steps = 10;
            int stepDuration = durationMs / steps;

            WinFormsTimer animationTimer = new WinFormsTimer { Interval = stepDuration };
            int currentStep = 0;

            animationTimer.Tick += (s, e) =>
            {
                currentStep++;
                if (currentStep >= steps)
                {
                    control.BackColor = targetColor;
                    animationTimer.Stop();
                    animationTimer.Dispose();
                    return;
                }

                float progress = (float)currentStep / steps;
                int r = (int)(startColor.R + (targetColor.R - startColor.R) * progress);
                int g = (int)(startColor.G + (targetColor.G - startColor.G) * progress);
                int b = (int)(startColor.B + (targetColor.B - startColor.B) * progress);

                control.BackColor = Color.FromArgb(r, g, b);
            };

            animationTimer.Start();
        }

        /// <summary>
        /// Anima un fade in del control.
        /// </summary>
        public static void FadeIn(Control control, int durationMs = 300)
        {
            if (control == null) return;

            control.Visible = true;
            double opacity = 0;
            int steps = 20;
            int stepDuration = durationMs / steps;
            double opacityIncrement = 1.0 / steps;

            WinFormsTimer fadeTimer = new WinFormsTimer { Interval = stepDuration };

            fadeTimer.Tick += (s, e) =>
            {
                opacity += opacityIncrement;
                if (opacity >= 1)
                {
                    opacity = 1;
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                }

                // Simular opacity cambiando el color del form (si es posible)
                // En WinForms, esto es limitado sin usar forms completos
            };

            fadeTimer.Start();
        }

        /// <summary>
        /// Anima el movimiento de un control de una posición a otra.
        /// </summary>
        public static void SlideTo(Control control, Point targetLocation, int durationMs = 300)
        {
            if (control == null) return;

            Point startLocation = control.Location;
            int steps = 20;
            int stepDuration = durationMs / steps;

            WinFormsTimer slideTimer = new WinFormsTimer { Interval = stepDuration };
            int currentStep = 0;

            slideTimer.Tick += (s, e) =>
            {
                currentStep++;
                if (currentStep >= steps)
                {
                    control.Location = targetLocation;
                    slideTimer.Stop();
                    slideTimer.Dispose();
                    return;
                }

                float progress = EaseInOutQuad((float)currentStep / steps);
                int x = (int)(startLocation.X + (targetLocation.X - startLocation.X) * progress);
                int y = (int)(startLocation.Y + (targetLocation.Y - startLocation.Y) * progress);

                control.Location = new Point(x, y);
            };

            slideTimer.Start();
        }

        /// <summary>
        /// Función de easing para transiciones suaves (ease-in-out quadratic).
        /// </summary>
        private static float EaseInOutQuad(float t)
        {
            return t < 0.5f ? 2 * t * t : 1 - (float)Math.Pow(-2 * t + 2, 2) / 2;
        }

        /// <summary>
        /// Crea un efecto de "pulse" en un botón.
        /// </summary>
        public static void PulseButton(Button button)
        {
            if (button == null) return;

            Size originalSize = button.Size;
            Point originalLocation = button.Location;
            Size enlargedSize = new Size(originalSize.Width + 4, originalSize.Height + 4);
            Point enlargedLocation = new Point(originalLocation.X - 2, originalLocation.Y - 2);

            // Agrandar
            WinFormsTimer growTimer = new WinFormsTimer { Interval = 50 };
            int growSteps = 0;

            growTimer.Tick += (s, e) =>
            {
                growSteps++;
                if (growSteps >= 3)
                {
                    button.Size = enlargedSize;
                    button.Location = enlargedLocation;
                    growTimer.Stop();

                    // Reducir de vuelta
                    WinFormsTimer shrinkTimer = new WinFormsTimer { Interval = 50 };
                    int shrinkSteps = 0;

                    shrinkTimer.Tick += (s2, e2) =>
                    {
                        shrinkSteps++;
                        if (shrinkSteps >= 3)
                        {
                            button.Size = originalSize;
                            button.Location = originalLocation;
                            shrinkTimer.Stop();
                            shrinkTimer.Dispose();
                        }
                    };

                    shrinkTimer.Start();
                    growTimer.Dispose();
                }
            };

            growTimer.Start();
        }

        /// <summary>
        /// Muestra un mensaje toast (notificación temporal) en el formulario.
        /// </summary>
        public static void ShowToast(Form parentForm, string message, int durationMs = 2000, Color? backgroundColor = null)
        {
            if (parentForm == null) return;

            Panel toastPanel = new Panel
            {
                Size = new Size(300, 60),
                Location = new Point(parentForm.Width - 320, parentForm.Height - 80),
                BackColor = backgroundColor ?? Color.FromArgb(40, 167, 69),
                BorderStyle = BorderStyle.None,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };

            Label toastLabel = new Label
            {
                Text = message,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            toastPanel.Controls.Add(toastLabel);
            parentForm.Controls.Add(toastPanel);
            toastPanel.BringToFront();

            // Auto-cerrar después de la duración
            WinFormsTimer closeTimer = new WinFormsTimer { Interval = durationMs };
            closeTimer.Tick += (s, e) =>
            {
                parentForm.Controls.Remove(toastPanel);
                toastPanel.Dispose();
                closeTimer.Stop();
                closeTimer.Dispose();
            };
            closeTimer.Start();
        }

        /// <summary>
        /// Aplica un efecto de sombra a un panel (simulado con bordes).
        /// </summary>
        public static void ApplyShadowEffect(Panel panel, int shadowSize = 3)
        {
            if (panel == null) return;

            panel.Paint += (s, e) =>
            {
                // Dibujar sombra
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    for (int i = 0; i < shadowSize; i++)
                    {
                        Rectangle shadowRect = new Rectangle(
                            i, i,
                            panel.Width - i, panel.Height - i
                        );
                        e.Graphics.FillRectangle(shadowBrush, shadowRect);
                    }
                }
            };
        }
    }
}
