namespace VentasApp.Views
{
    partial class AddProductView
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            NameTextbox = new TextBox();
            DescriptionTextbox = new TextBox();
            CategoryCombo = new ComboBox();
            SupplierCombo = new ComboBox();
            StockTextbox = new TextBox();
            PriceTextbox = new TextBox();
            AddProductButton = new Button();
            CancelAddButton = new Button();
            ProductImageBox = new PictureBox();
            ChangeImageButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ProductImageBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 32);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 75);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "Descripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 318);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "Precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 278);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 3;
            label4.Text = "Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 195);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 4;
            label5.Text = "Categoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 239);
            label6.Name = "label6";
            label6.Size = new Size(77, 20);
            label6.TabIndex = 5;
            label6.Text = "Proveedor";
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new Point(157, 29);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(255, 27);
            NameTextbox.TabIndex = 6;
            // 
            // DescriptionTextbox
            // 
            DescriptionTextbox.Location = new Point(157, 72);
            DescriptionTextbox.Multiline = true;
            DescriptionTextbox.Name = "DescriptionTextbox";
            DescriptionTextbox.Size = new Size(255, 98);
            DescriptionTextbox.TabIndex = 7;
            // 
            // CategoryCombo
            // 
            CategoryCombo.FormattingEnabled = true;
            CategoryCombo.Location = new Point(157, 192);
            CategoryCombo.Name = "CategoryCombo";
            CategoryCombo.Size = new Size(255, 28);
            CategoryCombo.TabIndex = 8;
            // 
            // SupplierCombo
            // 
            SupplierCombo.FormattingEnabled = true;
            SupplierCombo.Location = new Point(157, 236);
            SupplierCombo.Name = "SupplierCombo";
            SupplierCombo.Size = new Size(255, 28);
            SupplierCombo.TabIndex = 9;
            // 
            // StockTextbox
            // 
            StockTextbox.Location = new Point(157, 275);
            StockTextbox.Name = "StockTextbox";
            StockTextbox.Size = new Size(75, 27);
            StockTextbox.TabIndex = 10;
            // 
            // PriceTextbox
            // 
            PriceTextbox.Location = new Point(157, 315);
            PriceTextbox.Name = "PriceTextbox";
            PriceTextbox.Size = new Size(75, 27);
            PriceTextbox.TabIndex = 11;
            // 
            // AddProductButton
            // 
            AddProductButton.Location = new Point(49, 377);
            AddProductButton.Name = "AddProductButton";
            AddProductButton.Size = new Size(123, 46);
            AddProductButton.TabIndex = 12;
            AddProductButton.Text = "Agregar";
            AddProductButton.UseVisualStyleBackColor = true;
            // 
            // CancelAddButton
            // 
            CancelAddButton.Location = new Point(202, 377);
            CancelAddButton.Name = "CancelAddButton";
            CancelAddButton.Size = new Size(123, 46);
            CancelAddButton.TabIndex = 13;
            CancelAddButton.Text = "Cancelar";
            CancelAddButton.UseVisualStyleBackColor = true;
            // 
            // ProductImageBox
            // 
            ProductImageBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ProductImageBox.BackColor = SystemColors.Control;
            ProductImageBox.BackgroundImage = Properties.Resources.genericProductImage;
            ProductImageBox.BackgroundImageLayout = ImageLayout.Stretch;
            ProductImageBox.Location = new Point(520, 29);
            ProductImageBox.Name = "ProductImageBox";
            ProductImageBox.Size = new Size(178, 178);
            ProductImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ProductImageBox.TabIndex = 14;
            ProductImageBox.TabStop = false;
            // 
            // ChangeImageButton
            // 
            ChangeImageButton.Location = new Point(546, 213);
            ChangeImageButton.Name = "ChangeImageButton";
            ChangeImageButton.Size = new Size(131, 29);
            ChangeImageButton.TabIndex = 15;
            ChangeImageButton.Text = "Cambiar imagen";
            ChangeImageButton.UseVisualStyleBackColor = true;
            // 
            // AddProductView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(ChangeImageButton);
            Controls.Add(ProductImageBox);
            Controls.Add(CancelAddButton);
            Controls.Add(AddProductButton);
            Controls.Add(PriceTextbox);
            Controls.Add(StockTextbox);
            Controls.Add(SupplierCombo);
            Controls.Add(CategoryCombo);
            Controls.Add(DescriptionTextbox);
            Controls.Add(NameTextbox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddProductView";
            Text = "AddProductView";
            ((System.ComponentModel.ISupportInitialize)ProductImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox NameTextbox;
        private TextBox DescriptionTextbox;
        private ComboBox CategoryCombo;
        private ComboBox SupplierCombo;
        private TextBox StockTextbox;
        private TextBox PriceTextbox;
        private Button AddProductButton;
        private Button CancelAddButton;
        private PictureBox ProductImageBox;
        private Button ChangeImageButton;
    }
}