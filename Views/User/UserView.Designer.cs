namespace VentasApp.Views.User
{
    partial class UserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserView));
            UsernameTextBox = new TextBox();
            EmailTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            FullNameTextBox = new TextBox();
            RoleComboBox = new ComboBox();
            PhoneTextBox = new TextBox();
            SaveButton = new Button();
            CancelButton = new Button();
            label1 = new Label();
            label2 = new Label();
            PasswordLabel = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(131, 22);
            UsernameTextBox.Margin = new Padding(3, 2, 3, 2);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(219, 23);
            UsernameTextBox.TabIndex = 0;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(131, 56);
            EmailTextBox.Margin = new Padding(3, 2, 3, 2);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(219, 23);
            EmailTextBox.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(131, 90);
            PasswordTextBox.Margin = new Padding(3, 2, 3, 2);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(219, 23);
            PasswordTextBox.TabIndex = 2;
            // 
            // FullNameTextBox
            // 
            FullNameTextBox.Location = new Point(131, 124);
            FullNameTextBox.Margin = new Padding(3, 2, 3, 2);
            FullNameTextBox.Name = "FullNameTextBox";
            FullNameTextBox.Size = new Size(219, 23);
            FullNameTextBox.TabIndex = 3;
            // 
            // RoleComboBox
            // 
            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleComboBox.Location = new Point(131, 158);
            RoleComboBox.Margin = new Padding(3, 2, 3, 2);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(219, 23);
            RoleComboBox.TabIndex = 4;
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(131, 191);
            PhoneTextBox.Margin = new Padding(3, 2, 3, 2);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(219, 23);
            PhoneTextBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.FromArgb(46, 204, 113);
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(131, 232);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(88, 26);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Guardar";
            SaveButton.UseVisualStyleBackColor = false;
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.FromArgb(231, 76, 60);
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.ForeColor = Color.White;
            CancelButton.Location = new Point(262, 232);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(88, 26);
            CancelButton.TabIndex = 7;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(26, 25);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 8;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(26, 58);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 9;
            label2.Text = "Email:";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PasswordLabel.Location = new Point(26, 92);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(72, 15);
            PasswordLabel.TabIndex = 10;
            PasswordLabel.Text = "Contraseña:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(26, 126);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 11;
            label4.Text = "nombre completo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(26, 160);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 12;
            label5.Text = "Rol:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(26, 194);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 13;
            label6.Text = "Teléfono:";
            // 
            // UserView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(394, 285);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(PasswordLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(PhoneTextBox);
            Controls.Add(RoleComboBox);
            Controls.Add(FullNameTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(UsernameTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTextBox;
        private TextBox EmailTextBox;
        private TextBox PasswordTextBox;
        private TextBox FullNameTextBox;
        private ComboBox RoleComboBox;
        private TextBox PhoneTextBox;
        private Button SaveButton;
        private Button CancelButton;
        private Label label1;
        private Label label2;
        private Label PasswordLabel;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}