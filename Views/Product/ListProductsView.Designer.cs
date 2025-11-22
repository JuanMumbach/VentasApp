namespace VentasApp.Views
{
    partial class ListProductsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListProductsView));
            dataGridView1 = new DataGridView();
            SearchTextbox = new TextBox();
            OpenAddProductViewButton = new Button();
            DeleteButton = new Button();
            RestoreButton = new Button();
            ShowDeletedCheckbox = new CheckBox();
            EditProductButton = new Button();
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
            SearchTextbox.Size = new Size(457, 23);
            SearchTextbox.TabIndex = 1;
            // 
            // OpenAddProductViewButton
            // 
            OpenAddProductViewButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OpenAddProductViewButton.Location = new Point(33, 371);
            OpenAddProductViewButton.Margin = new Padding(3, 2, 3, 2);
            OpenAddProductViewButton.Name = "OpenAddProductViewButton";
            OpenAddProductViewButton.Size = new Size(82, 22);
            OpenAddProductViewButton.TabIndex = 2;
            OpenAddProductViewButton.Text = "Agregar";
            OpenAddProductViewButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DeleteButton.Location = new Point(667, 371);
            DeleteButton.Margin = new Padding(3, 2, 3, 2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(82, 22);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Eliminar";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // RestoreButton
            // 
            RestoreButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RestoreButton.Location = new Point(579, 371);
            RestoreButton.Margin = new Padding(3, 2, 3, 2);
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Size = new Size(82, 22);
            RestoreButton.TabIndex = 4;
            RestoreButton.Text = "Restaurar";
            RestoreButton.UseVisualStyleBackColor = true;
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
            // EditProductButton
            // 
            EditProductButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EditProductButton.Location = new Point(134, 371);
            EditProductButton.Margin = new Padding(3, 2, 3, 2);
            EditProductButton.Name = "EditProductButton";
            EditProductButton.Size = new Size(82, 22);
            EditProductButton.TabIndex = 6;
            EditProductButton.Text = "Editar";
            EditProductButton.UseVisualStyleBackColor = true;
            // 
            // ListProductsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(784, 428);
            Controls.Add(EditProductButton);
            Controls.Add(ShowDeletedCheckbox);
            Controls.Add(RestoreButton);
            Controls.Add(DeleteButton);
            Controls.Add(OpenAddProductViewButton);
            Controls.Add(SearchTextbox);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ListProductsView";
            Text = "Lista de productos - VentasApp";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox SearchTextbox;
        private Button OpenAddProductViewButton;
        private Button DeleteButton;
        private Button RestoreButton;
        private CheckBox ShowDeletedCheckbox;
        private Button EditProductButton;
    }
}