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
    public interface IBaseForm 
    {
        event EventHandler FormLoadEvent;
        void CloseView();
    }
    public partial class BaseForm : Form, IBaseForm
    {
        public event EventHandler FormLoadEvent;
 
   public BaseForm()
        {
     InitializeComponent();

            this.Load += (s, e) =>
         {
  LoadColorTheme();
    };

       this.Shown += (s, e) =>
      {
        FormLoadEvent?.Invoke(s, e);
   };
     }

        protected void LoadColorTheme()
        {
     // Aplicar el tema al formulario principal
       this.BackColor = Themes.MainViewBackgroundColor;
         this.ForeColor = Themes.ColorNormalText;
     this.Font = Themes.NormalFont;

       // Aplica el tema a los controles de nivel superior del formulario
     ApplyThemeToControls(this.Controls);
       CustomTheme();
   }

     protected void SetAcceptButton(Button button)
        {
            this.AcceptButton = button;

     button.BackColor = Themes.MainActionButtonColor;
            button.ForeColor = Themes.MainActionButtonTextColor;
  button.FlatAppearance.BorderColor = Themes.MainActionButtonColor;
     button.FlatAppearance.MouseOverBackColor = Themes.MainActionButtonHoverColor;
    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(
     Math.Clamp(Themes.MainActionButtonColor.R + Themes.MouseDownBrightness, 0, 255),
     Math.Clamp(Themes.MainActionButtonColor.G + Themes.MouseDownBrightness, 0, 255),
Math.Clamp(Themes.MainActionButtonColor.B + Themes.MouseDownBrightness, 0, 255)
   );
        }

        /// <summary>
  /// Configura un botón como botón de advertencia (eliminar, cancelar, etc.)
   /// </summary>
      protected void SetWarningButton(Button button)
        {
     button.BackColor = Themes.WarningButtonBackground;
   button.ForeColor = Themes.WarningButtonTextColor;
            button.FlatAppearance.BorderColor = Themes.WarningButtonBackground;
    button.FlatAppearance.MouseOverBackColor = Themes.WarningButtonHoverColor;
      button.FlatAppearance.MouseDownBackColor = Color.FromArgb(
       Math.Clamp(Themes.WarningButtonBackground.R - 30, 0, 255),
  Math.Clamp(Themes.WarningButtonBackground.G - 30, 0, 255),
   Math.Clamp(Themes.WarningButtonBackground.B - 30, 0, 255)
 );
        }

   /// <summary>
  /// Configura un botón como botón de éxito (guardar, confirmar, etc.)
    /// </summary>
  protected void SetSuccessButton(Button button)
 {
      button.BackColor = Themes.SuccessButtonBackground;
      button.ForeColor = Themes.SuccessButtonTextColor;
   button.FlatAppearance.BorderColor = Themes.SuccessButtonBackground;
button.FlatAppearance.MouseOverBackColor = Themes.SuccessButtonHoverColor;
  button.FlatAppearance.MouseDownBackColor = Color.FromArgb(
    Math.Clamp(Themes.SuccessButtonBackground.R - 30, 0, 255),
   Math.Clamp(Themes.SuccessButtonBackground.G - 30, 0, 255),
           Math.Clamp(Themes.SuccessButtonBackground.B - 30, 0, 255)
    );
 }

        virtual protected void CustomTheme()
    {
   // Método virtual para que las clases derivadas puedan aplicar temas personalizados
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
  button.FlatStyle = FlatStyle.Flat;
        button.BackColor = Themes.MainViewButtonColor;
   button.ForeColor = Themes.MainViewButtonTextColor;
           button.Font = Themes.NormalFont;
           button.FlatAppearance.BorderColor = Themes.BorderColor;
       button.FlatAppearance.BorderSize = 1;
             button.FlatAppearance.MouseOverBackColor = ButtonMouseOverColor;
         button.FlatAppearance.MouseDownBackColor = ButtonMouseDownColor;
   button.Cursor = Cursors.Hand;
    }
              
if (control is Panel panel)
         {
             byte transparency = panel.BackColor.A;
        panel.BackColor = Themes.MainViewBackgroundColor;
        panel.BackColor = Color.FromArgb(transparency, panel.BackColor.R, panel.BackColor.G, panel.BackColor.B);
       panel.ForeColor = Themes.ColorNormalText;
      }
    
  if (control is Label label)
        {
      label.ForeColor = Themes.ColorNormalText;
   label.Font = Themes.NormalFont;
     }

          if (control is TextBox textBox)
         {
           Color textboxBackColor = Color.FromArgb(
  Math.Clamp(Themes.MainViewBackgroundColor.R - 10, 0, 255),
         Math.Clamp(Themes.MainViewBackgroundColor.G - 10, 0, 255),
  Math.Clamp(Themes.MainViewBackgroundColor.B - 10, 0, 255)
      );
       
     textBox.BackColor = textboxBackColor;
      textBox.ForeColor = Themes.ColorNormalText;
  textBox.Font = Themes.NormalFont;
    textBox.BorderStyle = BorderStyle.FixedSingle;
    }

    if (control is DataGridView dataGridView)
      {
     dataGridView.BackgroundColor = Themes.MainViewBackgroundColor;
       dataGridView.ForeColor = Themes.ColorNormalText;
   dataGridView.Font = Themes.NormalFont;
        dataGridView.GridColor = Themes.BorderColor;
  dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Themes.MainViewButtonColor;
         dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Themes.MainViewButtonTextColor;
       dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(Themes.NormalFont, FontStyle.Bold);
     dataGridView.EnableHeadersVisualStyles = false;
         dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(
         Math.Clamp(Themes.MainViewButtonColor.R - 20, 0, 255),
             Math.Clamp(Themes.MainViewButtonColor.G - 20, 0, 255),
     Math.Clamp(Themes.MainViewButtonColor.B - 20, 0, 255)
  );
    dataGridView.DefaultCellStyle.BackColor = Themes.MainViewBackgroundColor;
        dataGridView.DefaultCellStyle.ForeColor = Themes.ColorNormalText;
       dataGridView.DefaultCellStyle.SelectionBackColor = Themes.HighlightTextColor;
           dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(
   Math.Clamp(Themes.MainViewBackgroundColor.R - 5, 0, 255),
     Math.Clamp(Themes.MainViewBackgroundColor.G - 5, 0, 255),
             Math.Clamp(Themes.MainViewBackgroundColor.B - 5, 0, 255)
        );
      dataGridView.BorderStyle = BorderStyle.None;
   dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                }

        if (control is GroupBox groupBox)
      {
  groupBox.ForeColor = Themes.ColorNormalText;
          groupBox.Font = new Font(Themes.NormalFont, FontStyle.Bold);
 }

  if (control is CheckBox checkBox)
 {
       checkBox.ForeColor = Themes.ColorNormalText;
  checkBox.Font = Themes.NormalFont;
       }

       if (control is RadioButton radioButton)
  {
    radioButton.ForeColor = Themes.ColorNormalText;
    radioButton.Font = Themes.NormalFont;
           }

          if (control is ComboBox comboBox)
         {
comboBox.FlatStyle = FlatStyle.Flat;
     comboBox.BackColor = Themes.MainViewBackgroundColor;
   comboBox.ForeColor = Themes.ColorNormalText;
                    comboBox.Font = Themes.NormalFont;
     }

    // Llamada recursiva para controles dentro de contenedores
   if (control.Controls.Count > 0)
        {
          ApplyThemeToControls(control.Controls);
  }
            }
     }

   public virtual void CloseView()
        {
            this.Close();
        }
    }
}
