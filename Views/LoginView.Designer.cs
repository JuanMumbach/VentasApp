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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            label1 = new Label();
            label2 = new Label();
            UsernameTextbox = new TextBox();
            PasswordTextbox = new TextBox();
            LoginButton = new Button();
            LoginImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)LoginImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei", 14.25F);
            label1.Location = new Point(36, 170);
            label1.Name = "label1";
            label1.Size = new Size(79, 24);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei", 14.25F);
            label2.Location = new Point(36, 227);
            label2.Name = "label2";
            label2.Size = new Size(113, 24);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameTextbox.Location = new Point(153, 169);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.Size = new Size(228, 29);
            UsernameTextbox.TabIndex = 2;
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordTextbox.Location = new Point(155, 226);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.PasswordChar = '*';
            PasswordTextbox.Size = new Size(228, 29);
            PasswordTextbox.TabIndex = 3;
            // 
            // LoginButton
            // 
            LoginButton.Anchor = AnchorStyles.None;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Microsoft JhengHei", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginButton.Location = new Point(153, 291);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(172, 36);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Iniciar Sesión";
            LoginButton.UseVisualStyleBackColor = true;
            // 
            // LoginImage
            // 
            LoginImage.Image = Properties.Resources.VentasAppLogoClaro;
            LoginImage.Location = new Point(178, 30);
            LoginImage.Name = "LoginImage";
            LoginImage.Size = new Size(115, 115);
            LoginImage.SizeMode = PictureBoxSizeMode.StretchImage;
            LoginImage.TabIndex = 5;
            LoginImage.TabStop = false;
            // 
            // LoginView
            // 
            AcceptButton = LoginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 355);
            Controls.Add(LoginImage);
            Controls.Add(LoginButton);
            Controls.Add(PasswordTextbox);
            Controls.Add(UsernameTextbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - VentasApp";
            ((System.ComponentModel.ISupportInitialize)LoginImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox UsernameTextbox;
        private TextBox PasswordTextbox;
        private Button LoginButton;
        private PictureBox LoginImage;
    }
}