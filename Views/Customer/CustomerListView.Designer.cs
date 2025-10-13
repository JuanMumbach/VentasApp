namespace VentasApp.Views.Customer
{
    partial class CustomerListView
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            SearchTextbox = new TextBox();
            ShowDeletedCheckbox = new CheckBox();
            AddCustomerButton = new Button();
            EditCustomerButton = new Button();
            DeleteButton = new Button();
            RestoreDeletedButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(41, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(630, 258);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 36);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 1;
            label1.Text = "Buscar por nombre o ID";
            // 
            // SearchTextbox
            // 
            SearchTextbox.Location = new Point(179, 33);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.Size = new Size(211, 23);
            SearchTextbox.TabIndex = 2;
            // 
            // ShowDeletedCheckbox
            // 
            ShowDeletedCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ShowDeletedCheckbox.AutoSize = true;
            ShowDeletedCheckbox.Location = new Point(500, 35);
            ShowDeletedCheckbox.Name = "ShowDeletedCheckbox";
            ShowDeletedCheckbox.Size = new Size(128, 19);
            ShowDeletedCheckbox.TabIndex = 3;
            ShowDeletedCheckbox.Text = "Mostrar eliminados";
            ShowDeletedCheckbox.UseVisualStyleBackColor = true;
            // 
            // AddCustomerButton
            // 
            AddCustomerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddCustomerButton.Location = new Point(41, 347);
            AddCustomerButton.Name = "AddCustomerButton";
            AddCustomerButton.Size = new Size(75, 23);
            AddCustomerButton.TabIndex = 4;
            AddCustomerButton.Text = "Agregar";
            AddCustomerButton.UseVisualStyleBackColor = true;
            // 
            // EditCustomerButton
            // 
            EditCustomerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EditCustomerButton.Location = new Point(122, 347);
            EditCustomerButton.Name = "EditCustomerButton";
            EditCustomerButton.Size = new Size(75, 23);
            EditCustomerButton.TabIndex = 5;
            EditCustomerButton.Text = "Editar";
            EditCustomerButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DeleteButton.Location = new Point(596, 347);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 6;
            DeleteButton.Text = "Eliminar";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // RestoreDeletedButton
            // 
            RestoreDeletedButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RestoreDeletedButton.Location = new Point(515, 347);
            RestoreDeletedButton.Name = "RestoreDeletedButton";
            RestoreDeletedButton.Size = new Size(75, 23);
            RestoreDeletedButton.TabIndex = 7;
            RestoreDeletedButton.Text = "Restaurar";
            RestoreDeletedButton.UseVisualStyleBackColor = true;
            // 
            // CustomerListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 392);
            Controls.Add(RestoreDeletedButton);
            Controls.Add(DeleteButton);
            Controls.Add(EditCustomerButton);
            Controls.Add(AddCustomerButton);
            Controls.Add(ShowDeletedCheckbox);
            Controls.Add(SearchTextbox);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "CustomerListView";
            Text = "CustomerListView";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox SearchTextbox;
        private CheckBox ShowDeletedCheckbox;
        private Button AddCustomerButton;
        private Button EditCustomerButton;
        private Button DeleteButton;
        private Button RestoreDeletedButton;
    }
}