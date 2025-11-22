namespace VentasApp.Views.SystemSettings
{
    partial class SystemSettingsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSettingsView));
            panel1 = new Panel();
            DisclaimerLabel = new Label();
            RestoreLabel = new Label();
            PerformLabel = new Label();
            RestoreBackupButton = new Button();
            PerformBackupButton = new Button();
            label1 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(DisclaimerLabel);
            panel1.Controls.Add(RestoreLabel);
            panel1.Controls.Add(PerformLabel);
            panel1.Controls.Add(RestoreBackupButton);
            panel1.Controls.Add(PerformBackupButton);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(23, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(732, 171);
            panel1.TabIndex = 0;
            // 
            // DisclaimerLabel
            // 
            DisclaimerLabel.AllowDrop = true;
            DisclaimerLabel.Location = new Point(371, 122);
            DisclaimerLabel.Name = "DisclaimerLabel";
            DisclaimerLabel.Size = new Size(308, 40);
            DisclaimerLabel.TabIndex = 5;
            DisclaimerLabel.Text = "ATENCION: esta accion elimina toda la base de datos actual, utilizar con precaución.";
            DisclaimerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // RestoreLabel
            // 
            RestoreLabel.AllowDrop = true;
            RestoreLabel.Location = new Point(507, 68);
            RestoreLabel.Name = "RestoreLabel";
            RestoreLabel.Size = new Size(172, 51);
            RestoreLabel.TabIndex = 4;
            RestoreLabel.Text = "Restaurar la base de datos desde un archivo de restauracion.";
            RestoreLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PerformLabel
            // 
            PerformLabel.AllowDrop = true;
            PerformLabel.Location = new Point(160, 68);
            PerformLabel.Name = "PerformLabel";
            PerformLabel.Size = new Size(172, 51);
            PerformLabel.TabIndex = 3;
            PerformLabel.Text = "Realizar una copia de seguridad de la base de datos.";
            PerformLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RestoreBackupButton
            // 
            RestoreBackupButton.Location = new Point(371, 68);
            RestoreBackupButton.Name = "RestoreBackupButton";
            RestoreBackupButton.Size = new Size(130, 51);
            RestoreBackupButton.TabIndex = 2;
            RestoreBackupButton.Text = "Restaurar Base de Datos desde archivo";
            RestoreBackupButton.UseVisualStyleBackColor = true;
            // 
            // PerformBackupButton
            // 
            PerformBackupButton.Location = new Point(24, 68);
            PerformBackupButton.Name = "PerformBackupButton";
            PerformBackupButton.Size = new Size(130, 51);
            PerformBackupButton.TabIndex = 1;
            PerformBackupButton.Text = "Realizar Backup";
            PerformBackupButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 17);
            label1.Name = "label1";
            label1.Size = new Size(91, 32);
            label1.TabIndex = 0;
            label1.Text = "Backup";
            // 
            // SystemSettingsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SystemSettingsView";
            Text = "SystemSettingsView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button PerformBackupButton;
        private Label label1;
        private SaveFileDialog saveFileDialog1;
        private Button RestoreBackupButton;
        private Label DisclaimerLabel;
        private Label RestoreLabel;
        private Label PerformLabel;
    }
}