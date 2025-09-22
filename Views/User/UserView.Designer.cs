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
            UsernameTextBox.Location = new Point(150, 30);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(250, 27);
            UsernameTextBox.TabIndex = 0;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(150, 75);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(250, 27);
            EmailTextBox.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(150, 120);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(250, 27);
            PasswordTextBox.TabIndex = 2;
            // 
            // FullNameTextBox
            // 
            FullNameTextBox.Location = new Point(150, 165);
            FullNameTextBox.Name = "FullNameTextBox";
            FullNameTextBox.Size = new Size(250, 27);
            FullNameTextBox.TabIndex = 3;
            // 
            // RoleComboBox
            // 
            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleComboBox.Location = new Point(150, 210);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(250, 28);
            RoleComboBox.TabIndex = 4;
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(150, 255);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(250, 27);
            PhoneTextBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.FromArgb(46, 204, 113);
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(150, 310);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(100, 35);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Guardar";
            SaveButton.UseVisualStyleBackColor = false;
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.FromArgb(231, 76, 60);
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.ForeColor = Color.White;
            CancelButton.Location = new Point(300, 310);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(100, 35);
            CancelButton.TabIndex = 7;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(30, 33);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 8;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(30, 78);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 9;
            label2.Text = "Email:";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PasswordLabel.Location = new Point(30, 123);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(91, 20);
            PasswordLabel.TabIndex = 10;
            PasswordLabel.Text = "Contraseña:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(30, 168);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 11;
            label4.Text = "nombre completo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(30, 213);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 12;
            label5.Text = "Rol:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(30, 258);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 13;
            label6.Text = "Teléfono:";
            // 
            // UserView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(450, 380);
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