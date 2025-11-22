namespace VentasApp.Views.User
{
    partial class ListUsersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListUsersView));
            dataGridView1 = new DataGridView();
            SearchTextbox = new TextBox();
            OpenAddUserViewButton = new Button();
            DeleteButton = new Button();
            RestoreButton = new Button();
            ShowDeletedCheckbox = new CheckBox();
            EditUserButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 70);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(716, 286);
            dataGridView1.TabIndex = 0;
            // 
            // SearchTextbox
            // 
            SearchTextbox.Location = new Point(45, 42);
            SearchTextbox.Margin = new Padding(3, 2, 3, 2);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.PlaceholderText = "Buscar por nombre, usuario, email o rol...";
            SearchTextbox.Size = new Size(457, 23);
            SearchTextbox.TabIndex = 1;
            // 
            // OpenAddUserViewButton
            // 
            OpenAddUserViewButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OpenAddUserViewButton.BackColor = Color.FromArgb(52, 152, 219);
            OpenAddUserViewButton.FlatStyle = FlatStyle.Flat;
            OpenAddUserViewButton.ForeColor = Color.White;
            OpenAddUserViewButton.Location = new Point(33, 371);
            OpenAddUserViewButton.Margin = new Padding(3, 2, 3, 2);
            OpenAddUserViewButton.Name = "OpenAddUserViewButton";
            OpenAddUserViewButton.Size = new Size(82, 22);
            OpenAddUserViewButton.TabIndex = 2;
            OpenAddUserViewButton.Text = "Agregar";
            OpenAddUserViewButton.UseVisualStyleBackColor = false;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DeleteButton.BackColor = Color.FromArgb(231, 76, 60);
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.ForeColor = Color.White;
            DeleteButton.Location = new Point(667, 371);
            DeleteButton.Margin = new Padding(3, 2, 3, 2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(82, 22);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Eliminar";
            DeleteButton.UseVisualStyleBackColor = false;
            // 
            // RestoreButton
            // 
            RestoreButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RestoreButton.BackColor = Color.FromArgb(46, 204, 113);
            RestoreButton.FlatStyle = FlatStyle.Flat;
            RestoreButton.ForeColor = Color.White;
            RestoreButton.Location = new Point(579, 371);
            RestoreButton.Margin = new Padding(3, 2, 3, 2);
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Size = new Size(82, 22);
            RestoreButton.TabIndex = 4;
            RestoreButton.Text = "Restaurar";
            RestoreButton.UseVisualStyleBackColor = false;
            // 
            // ShowDeletedCheckbox
            // 
            ShowDeletedCheckbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ShowDeletedCheckbox.AutoSize = true;
            ShowDeletedCheckbox.Location = new Point(446, 373);
            ShowDeletedCheckbox.Margin = new Padding(3, 2, 3, 2);
            ShowDeletedCheckbox.Name = "ShowDeletedCheckbox";
            ShowDeletedCheckbox.Size = new Size(128, 19);
            ShowDeletedCheckbox.TabIndex = 5;
            ShowDeletedCheckbox.Text = "Mostrar eliminados";
            ShowDeletedCheckbox.UseVisualStyleBackColor = true;
            // 
            // EditUserButton
            // 
            EditUserButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EditUserButton.BackColor = Color.FromArgb(241, 196, 15);
            EditUserButton.FlatStyle = FlatStyle.Flat;
            EditUserButton.ForeColor = Color.White;
            EditUserButton.Location = new Point(134, 371);
            EditUserButton.Margin = new Padding(3, 2, 3, 2);
            EditUserButton.Name = "EditUserButton";
            EditUserButton.Size = new Size(82, 22);
            EditUserButton.TabIndex = 6;
            EditUserButton.Text = "Editar";
            EditUserButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(33, 7);
            label1.Name = "label1";
            label1.Size = new Size(187, 30);
            label1.TabIndex = 7;
            label1.Text = "Gestión Usuarios";
            // 
            // ListUsersView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(784, 428);
            Controls.Add(label1);
            Controls.Add(EditUserButton);
            Controls.Add(ShowDeletedCheckbox);
            Controls.Add(RestoreButton);
            Controls.Add(DeleteButton);
            Controls.Add(OpenAddUserViewButton);
            Controls.Add(SearchTextbox);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ListUsersView";
            Text = "Gestión de Usuarios - VentasApp";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox SearchTextbox;
        private Button OpenAddUserViewButton;
        private Button DeleteButton;
        private Button RestoreButton;
        private CheckBox ShowDeletedCheckbox;
        private Button EditUserButton;
        private Label label1;
    }
}