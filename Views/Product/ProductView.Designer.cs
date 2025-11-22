namespace VentasApp.Views
{
    partial class ProductView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductView));
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
            UpdateProductButton = new Button();
            DeleteProductButton = new Button();
            CloseAtUpdateCheckbox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)ProductImageBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 24);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 56);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 1;
            label2.Text = "Descripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 238);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 2;
            label3.Text = "Precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 208);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 146);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 4;
            label5.Text = "Categoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 179);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 5;
            label6.Text = "Proveedor";
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new Point(137, 22);
            NameTextbox.Margin = new Padding(3, 2, 3, 2);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(224, 23);
            NameTextbox.TabIndex = 6;
            // 
            // DescriptionTextbox
            // 
            DescriptionTextbox.Location = new Point(137, 54);
            DescriptionTextbox.Margin = new Padding(3, 2, 3, 2);
            DescriptionTextbox.Multiline = true;
            DescriptionTextbox.Name = "DescriptionTextbox";
            DescriptionTextbox.Size = new Size(224, 74);
            DescriptionTextbox.TabIndex = 7;
            // 
            // CategoryCombo
            // 
            CategoryCombo.FormattingEnabled = true;
            CategoryCombo.Location = new Point(137, 144);
            CategoryCombo.Margin = new Padding(3, 2, 3, 2);
            CategoryCombo.Name = "CategoryCombo";
            CategoryCombo.Size = new Size(224, 23);
            CategoryCombo.TabIndex = 8;
            // 
            // SupplierCombo
            // 
            SupplierCombo.FormattingEnabled = true;
            SupplierCombo.Location = new Point(137, 177);
            SupplierCombo.Margin = new Padding(3, 2, 3, 2);
            SupplierCombo.Name = "SupplierCombo";
            SupplierCombo.Size = new Size(224, 23);
            SupplierCombo.TabIndex = 9;
            // 
            // StockTextbox
            // 
            StockTextbox.Location = new Point(137, 206);
            StockTextbox.Margin = new Padding(3, 2, 3, 2);
            StockTextbox.Name = "StockTextbox";
            StockTextbox.Size = new Size(66, 23);
            StockTextbox.TabIndex = 10;
            // 
            // PriceTextbox
            // 
            PriceTextbox.Location = new Point(137, 236);
            PriceTextbox.Margin = new Padding(3, 2, 3, 2);
            PriceTextbox.Name = "PriceTextbox";
            PriceTextbox.Size = new Size(66, 23);
            PriceTextbox.TabIndex = 11;
            // 
            // AddProductButton
            // 
            AddProductButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddProductButton.Location = new Point(28, 279);
            AddProductButton.Margin = new Padding(3, 2, 3, 2);
            AddProductButton.Name = "AddProductButton";
            AddProductButton.Size = new Size(123, 26);
            AddProductButton.TabIndex = 12;
            AddProductButton.Text = "Agregar producto";
            AddProductButton.UseVisualStyleBackColor = true;
            // 
            // CancelAddButton
            // 
            CancelAddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelAddButton.Location = new Point(264, 279);
            CancelAddButton.Margin = new Padding(3, 2, 3, 2);
            CancelAddButton.Name = "CancelAddButton";
            CancelAddButton.Size = new Size(83, 26);
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
            ProductImageBox.Location = new Point(455, 22);
            ProductImageBox.Margin = new Padding(3, 2, 3, 2);
            ProductImageBox.Name = "ProductImageBox";
            ProductImageBox.Size = new Size(156, 134);
            ProductImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ProductImageBox.TabIndex = 14;
            ProductImageBox.TabStop = false;
            // 
            // ChangeImageButton
            // 
            ChangeImageButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ChangeImageButton.Location = new Point(478, 160);
            ChangeImageButton.Margin = new Padding(3, 2, 3, 2);
            ChangeImageButton.Name = "ChangeImageButton";
            ChangeImageButton.Size = new Size(115, 22);
            ChangeImageButton.TabIndex = 15;
            ChangeImageButton.Text = "Cambiar imagen";
            ChangeImageButton.UseVisualStyleBackColor = true;
            // 
            // UpdateProductButton
            // 
            UpdateProductButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UpdateProductButton.Location = new Point(169, 279);
            UpdateProductButton.Margin = new Padding(3, 2, 3, 2);
            UpdateProductButton.Name = "UpdateProductButton";
            UpdateProductButton.Size = new Size(77, 26);
            UpdateProductButton.TabIndex = 16;
            UpdateProductButton.Text = "Actualizar";
            UpdateProductButton.UseVisualStyleBackColor = true;
            // 
            // DeleteProductButton
            // 
            DeleteProductButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DeleteProductButton.Location = new Point(547, 279);
            DeleteProductButton.Margin = new Padding(3, 2, 3, 2);
            DeleteProductButton.Name = "DeleteProductButton";
            DeleteProductButton.Size = new Size(120, 26);
            DeleteProductButton.TabIndex = 17;
            DeleteProductButton.Text = "Eliminar producto";
            DeleteProductButton.UseVisualStyleBackColor = true;
            // 
            // CloseAtUpdateCheckbox
            // 
            CloseAtUpdateCheckbox.AutoSize = true;
            CloseAtUpdateCheckbox.Location = new Point(28, 310);
            CloseAtUpdateCheckbox.Margin = new Padding(3, 2, 3, 2);
            CloseAtUpdateCheckbox.Name = "CloseAtUpdateCheckbox";
            CloseAtUpdateCheckbox.Size = new Size(234, 19);
            CloseAtUpdateCheckbox.TabIndex = 18;
            CloseAtUpdateCheckbox.Text = "No cerrar ventana al Agregar/Actualizar";
            CloseAtUpdateCheckbox.UseVisualStyleBackColor = true;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(700, 338);
            Controls.Add(CloseAtUpdateCheckbox);
            Controls.Add(DeleteProductButton);
            Controls.Add(UpdateProductButton);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProductView";
            Text = "Gestión de producto - VentasApp";
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
        private Button UpdateProductButton;
        private Button DeleteProductButton;
        private CheckBox CloseAtUpdateCheckbox;
    }
}