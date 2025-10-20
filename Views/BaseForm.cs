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

namespace VentasApp.Views
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();

            this.Load += (s, e) => LoadColorTheme();

        }

        protected void LoadColorTheme()
        {
            // Aplicar el tema al formulario principal también
            this.BackColor = Themes.MainViewBackgroundColor;
            this.ForeColor = Themes.ColorNormalText;

            // Aplica el tema a los controles de nivel superior del formulario
            ApplyThemeToControls(this.Controls);
        }

        private void ApplyThemeToControls(Control.ControlCollection controls)
        {
            Color ButtonMouseOverColor = Color.FromArgb(
                        Math.Clamp(Themes.MainViewButtonColor.R + Themes.MouseOverBrightness, 0, 255),
                        Math.Clamp(Themes.MainViewButtonColor.G + Themes.MouseOverBrightness, 0, 255),
                        Math.Clamp(Themes.MainViewButtonColor.B + Themes.MouseOverBrightness, 0, 255)
                    );

            Color ButtonMouseDownColor = Color.FromArgb(
                        Math.Clamp(Themes.MainViewButtonColor.R + Themes.MouseDownBrightness, 0, 255),
                        Math.Clamp(Themes.MainViewButtonColor.G + Themes.MouseDownBrightness, 0, 255),
                        Math.Clamp(Themes.MainViewButtonColor.B + Themes.MouseDownBrightness, 0, 255)
                    );

            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Themes.MainViewButtonColor;
                    button.ForeColor = Themes.MainViewButtonTextColor;
                    button.FlatAppearance.BorderColor = Themes.MainViewButtonColor;
                    button.FlatAppearance.MouseOverBackColor = ButtonMouseOverColor;
                    button.FlatAppearance.MouseDownBackColor = ButtonMouseDownColor;
                }
                
                if (control is Panel panel)
                {
                    panel.BackColor = Themes.MainViewBackgroundColor;
                    panel.ForeColor = Themes.ColorNormalText;
                }
                
                if (control is Label label)
                {
                    label.ForeColor = Themes.ColorNormalText;
                }

                if (control is TextBox textBox)
                {
                    Color textboxBackColor = Color.FromArgb(
                        Math.Clamp(Themes.MainViewBackgroundColor.R - Themes.MouseOverBrightness, 0, 255),
                        Math.Clamp(Themes.MainViewBackgroundColor.G - Themes.MouseOverBrightness, 0, 255),
                        Math.Clamp(Themes.MainViewBackgroundColor.B - Themes.MouseOverBrightness, 0, 255)
                    );
                    
                    textBox.BackColor = textboxBackColor;
                    textBox.ForeColor = Themes.ColorNormalText;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }

                if (control is DataGridView dataGridView)
                {
                    dataGridView.BackgroundColor = Themes.MainViewBackgroundColor;
                    dataGridView.ForeColor = Themes.ColorNormalText;
                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Themes.MainViewButtonColor;
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Themes.MainViewButtonTextColor;
                    dataGridView.EnableHeadersVisualStyles = false;
                }

                // Llamada recursiva para controles dentro de contenedores
                if (control.Controls.Count > 0)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }
    }
}
