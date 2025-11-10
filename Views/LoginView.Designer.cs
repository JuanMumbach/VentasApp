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
            ShadowPanel = new Panel();
            MainLoginPanel = new Panel();
            CloseButton = new Button();
            LoginButton = new Button();
            PasswordTextbox = new TextBox();
            UsernameTextbox = new TextBox();
            PasswordLabel = new Label();
            UsernameLabel = new Label();
            TitleLabel = new Label();
            LoginImage = new PictureBox();
            ShadowPanel.SuspendLayout();
            MainLoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LoginImage).BeginInit();
            SuspendLayout();
            // 
            // ShadowPanel
            // 
            ShadowPanel.BackColor = Color.FromArgb(230, 230, 230);
            ShadowPanel.Controls.Add(MainLoginPanel);
            ShadowPanel.Dock = DockStyle.Fill;
            ShadowPanel.Location = new Point(0, 0);
            ShadowPanel.Name = "ShadowPanel";
            ShadowPanel.Padding = new Padding(3);
            ShadowPanel.Size = new Size(450, 550);
            ShadowPanel.TabIndex = 100;
            // 
            // MainLoginPanel
            // 
            MainLoginPanel.BackColor = Color.White;
            MainLoginPanel.Controls.Add(CloseButton);
            MainLoginPanel.Controls.Add(LoginButton);
            MainLoginPanel.Controls.Add(PasswordTextbox);
            MainLoginPanel.Controls.Add(UsernameTextbox);
            MainLoginPanel.Controls.Add(PasswordLabel);
            MainLoginPanel.Controls.Add(UsernameLabel);
            MainLoginPanel.Controls.Add(TitleLabel);
            MainLoginPanel.Controls.Add(LoginImage);
            MainLoginPanel.Dock = DockStyle.Fill;
            MainLoginPanel.Location = new Point(3, 3);
            MainLoginPanel.Name = "MainLoginPanel";
            MainLoginPanel.Size = new Size(444, 544);
            MainLoginPanel.TabIndex = 0;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CloseButton.BackColor = Color.Transparent;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            CloseButton.ForeColor = Color.Gray;
            CloseButton.Location = new Point(404, 10);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(30, 30);
            CloseButton.TabIndex = 100;
            CloseButton.Text = "✕";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += (s, e) => this.Close();
            CloseButton.MouseEnter += (s, e) => CloseButton.ForeColor = Color.Red;
            CloseButton.MouseLeave += (s, e) => CloseButton.ForeColor = Color.Gray;
            // 
            // LoginButton
            // 
            LoginButton.Anchor = AnchorStyles.None;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LoginButton.Location = new Point(90, 430);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(264, 45);
            LoginButton.TabIndex = 3;
            LoginButton.Text = "INICIAR SESIÓN";
            LoginButton.UseVisualStyleBackColor = true;
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Anchor = AnchorStyles.None;
            PasswordTextbox.BorderStyle = BorderStyle.FixedSingle;
            PasswordTextbox.Font = new Font("Segoe UI", 12F);
            PasswordTextbox.Location = new Point(90, 355);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.PasswordChar = '●';
            PasswordTextbox.PlaceholderText = "Ingrese su contraseña";
            PasswordTextbox.Size = new Size(264, 29);
            PasswordTextbox.TabIndex = 2;
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Anchor = AnchorStyles.None;
            UsernameTextbox.BorderStyle = BorderStyle.FixedSingle;
            UsernameTextbox.Font = new Font("Segoe UI", 12F);
            UsernameTextbox.Location = new Point(90, 275);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.PlaceholderText = "Ingrese su usuario";
            UsernameTextbox.Size = new Size(264, 29);
            UsernameTextbox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            PasswordLabel.Anchor = AnchorStyles.None;
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 10F);
            PasswordLabel.ForeColor = Color.Gray;
            PasswordLabel.Location = new Point(90, 330);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(83, 19);
            PasswordLabel.TabIndex = 102;
            PasswordLabel.Text = "Contraseña";
            // 
            // UsernameLabel
            // 
            UsernameLabel.Anchor = AnchorStyles.None;
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI", 10F);
            UsernameLabel.ForeColor = Color.Gray;
            UsernameLabel.Location = new Point(90, 250);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(56, 19);
            UsernameLabel.TabIndex = 101;
            UsernameLabel.Text = "Usuario";
            // 
            // TitleLabel
            // 
            TitleLabel.Anchor = AnchorStyles.None;
            TitleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            TitleLabel.Location = new Point(90, 170);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(264, 50);
            TitleLabel.TabIndex = 103;
            TitleLabel.Text = "Bienvenido";
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginImage
            // 
            LoginImage.Anchor = AnchorStyles.None;
            LoginImage.Image = Properties.Resources.VentasAppLogoClaro;
            LoginImage.Location = new Point(147, 40);
            LoginImage.Name = "LoginImage";
            LoginImage.Size = new Size(150, 150);
            LoginImage.SizeMode = PictureBoxSizeMode.StretchImage;
            LoginImage.TabIndex = 0;
            LoginImage.TabStop = false;
            // 
            // LoginView
            // 
            AcceptButton = LoginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 550);
            Controls.Add(ShadowPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VentasApp - Login";
            ShadowPanel.ResumeLayout(false);
            MainLoginPanel.ResumeLayout(false);
            MainLoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LoginImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ShadowPanel;
        private Panel MainLoginPanel;
        private Button CloseButton;
        private Label TitleLabel;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox UsernameTextbox;
        private TextBox PasswordTextbox;
        private Button LoginButton;
        private PictureBox LoginImage;
    }
}