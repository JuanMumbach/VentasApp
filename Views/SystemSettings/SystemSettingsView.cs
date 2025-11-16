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

namespace VentasApp.Views.SystemSettings
{
    public interface ISystemSettingsView : IBaseForm
    {
        event EventHandler PerformDbBackupEvent;
        event EventHandler RestoreDbEvent;

        void EnableBackupButtons();
    }
    public partial class SystemSettingsView : BaseForm, ISystemSettingsView
    {
        public event EventHandler PerformDbBackupEvent;
        public event EventHandler RestoreDbEvent;
        public SystemSettingsView()
        {
            InitializeComponent();
            SetupEventsHandler();

            PerformBackupButton.Enabled = false;
            RestoreBackupButton.Enabled = false;
        }

        protected override void CustomTheme()
        {
            DisclaimerLabel.ForeColor = Themes.WarningButtonBackground;
            RestoreBackupButton.BackColor = Themes.WarningButtonBackground;
            RestoreBackupButton.ForeColor = Themes.WarningButtonTextColor;

            var buttons = new List<Button>
            {
                PerformBackupButton,
                RestoreBackupButton
            };
            /* Cambia el color si el boton esta desactivado */
            foreach (var button in buttons)
            {
                if (!button.Enabled)
                {
                    Color newBackColor = Themes.MainViewButtonColor;
                    Color newForeColor = button.ForeColor;

                    newBackColor = Color.FromArgb(
                        Math.Clamp(newBackColor.R - 60, 0, 255),
                        Math.Clamp(newBackColor.G - 60, 0, 255),
                        Math.Clamp(newBackColor.B - 60, 0, 255)
                    );

                    newForeColor = Color.FromArgb(
                        Math.Clamp(newForeColor.R - 60, 0, 255),
                        Math.Clamp(newForeColor.G - 60, 0, 255),
                        Math.Clamp(newForeColor.B - 60, 0, 255)
                    );

                    button.BackColor = newBackColor;
                    button.ForeColor = newForeColor;
                }
            
            }
        }

        private void SetupEventsHandler()
        {
           PerformBackupButton.Click += (s, e) =>
           {
               PerformDbBackupEvent?.Invoke(s, e);
           };

            RestoreBackupButton.Click += (s, e) =>
            {
                RestoreDbEvent?.Invoke(s, e);
            };
        }

        public void EnableBackupButtons()
        {
            PerformBackupButton.Enabled = true;
            RestoreBackupButton.Enabled = true;

            CustomTheme();
        }

    }
}
