namespace VentasApp.Views
{
    partial class LoginView
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
            label1 = new Label();
            label2 = new Label();
            UsernameTextbox = new TextBox();
            PasswordTextbox = new TextBox();
            LoginButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Carlito", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 166);
            label1.Name = "label1";
            label1.Size = new Size(89, 29);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Carlito", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 223);
            label2.Name = "label2";
            label2.Size = new Size(126, 29);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameTextbox.Location = new Point(169, 169);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.Size = new Size(228, 29);
            UsernameTextbox.TabIndex = 2;
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordTextbox.Location = new Point(169, 226);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.PasswordChar = '*';
            PasswordTextbox.Size = new Size(228, 29);
            PasswordTextbox.TabIndex = 3;
            // 
            // LoginButton
            // 
            LoginButton.Anchor = AnchorStyles.None;
            LoginButton.Font = new Font("Carlito", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginButton.Location = new Point(153, 291);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(172, 36);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Iniciar Sesión";
            LoginButton.UseVisualStyleBackColor = true;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 355);
            Controls.Add(LoginButton);
            Controls.Add(PasswordTextbox);
            Controls.Add(UsernameTextbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox UsernameTextbox;
        private TextBox PasswordTextbox;
        private Button LoginButton;
    }
}