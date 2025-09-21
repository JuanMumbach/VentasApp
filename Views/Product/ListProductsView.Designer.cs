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
            dataGridView1 = new DataGridView();
            SearchTextbox = new TextBox();
            OpenAddProductViewButton = new Button();
            DeleteButton = new Button();
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
            dataGridView1.Location = new Point(38, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(818, 381);
            dataGridView1.TabIndex = 0;
            // 
            // SearchTextbox
            // 
            SearchTextbox.Location = new Point(51, 56);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.Size = new Size(522, 27);
            SearchTextbox.TabIndex = 1;
            // 
            // OpenAddProductViewButton
            // 
            OpenAddProductViewButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OpenAddProductViewButton.Location = new Point(38, 495);
            OpenAddProductViewButton.Name = "OpenAddProductViewButton";
            OpenAddProductViewButton.Size = new Size(94, 29);
            OpenAddProductViewButton.TabIndex = 2;
            OpenAddProductViewButton.Text = "Agregar";
            OpenAddProductViewButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteButton.Location = new Point(167, 495);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(94, 29);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Eliminar";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // ListProductsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(896, 570);
            Controls.Add(DeleteButton);
            Controls.Add(OpenAddProductViewButton);
            Controls.Add(SearchTextbox);
            Controls.Add(dataGridView1);
            Name = "ListProductsView";
            Text = "productosView";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox SearchTextbox;
        private Button OpenAddProductViewButton;
        private Button DeleteButton;
    }
}