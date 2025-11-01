namespace VentasApp.Views.Sale
{
    partial class SaleView
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
            SaleItemsDatagridview = new DataGridView();
            RemoveItemButton = new Button();
            ConfirmSaleButton = new Button();
            EditSaleItemButton = new Button();
            AddSaleItemButton = new Button();
            ViewItemsPanel = new Panel();
            CustomerLabel = new Label();
            label1 = new Label();
            CustomerCombobox = new ComboBox();
            CancelButton = new Button();
            PrintReceiptButton = new Button();
            ((System.ComponentModel.ISupportInitialize)SaleItemsDatagridview).BeginInit();
            ViewItemsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SaleItemsDatagridview
            // 
            SaleItemsDatagridview.AllowUserToAddRows = false;
            SaleItemsDatagridview.AllowUserToDeleteRows = false;
            SaleItemsDatagridview.AllowUserToOrderColumns = true;
            SaleItemsDatagridview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SaleItemsDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SaleItemsDatagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SaleItemsDatagridview.Location = new Point(10, 49);
            SaleItemsDatagridview.Margin = new Padding(3, 2, 3, 2);
            SaleItemsDatagridview.Name = "SaleItemsDatagridview";
            SaleItemsDatagridview.ReadOnly = true;
            SaleItemsDatagridview.RowHeadersWidth = 51;
            SaleItemsDatagridview.Size = new Size(734, 263);
            SaleItemsDatagridview.TabIndex = 0;
            // 
            // RemoveItemButton
            // 
            RemoveItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RemoveItemButton.FlatAppearance.BorderSize = 0;
            RemoveItemButton.FlatStyle = FlatStyle.Flat;
            RemoveItemButton.Font = new Font("Microsoft JhengHei", 9F);
            RemoveItemButton.Location = new Point(639, 316);
            RemoveItemButton.Margin = new Padding(3, 2, 3, 2);
            RemoveItemButton.Name = "RemoveItemButton";
            RemoveItemButton.Size = new Size(105, 22);
            RemoveItemButton.TabIndex = 1;
            RemoveItemButton.Text = "Eliminar Item";
            RemoveItemButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmSaleButton
            // 
            ConfirmSaleButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ConfirmSaleButton.FlatAppearance.BorderSize = 0;
            ConfirmSaleButton.FlatStyle = FlatStyle.Flat;
            ConfirmSaleButton.Font = new Font("Microsoft JhengHei", 9F);
            ConfirmSaleButton.Location = new Point(10, 356);
            ConfirmSaleButton.Margin = new Padding(3, 2, 3, 2);
            ConfirmSaleButton.Name = "ConfirmSaleButton";
            ConfirmSaleButton.Size = new Size(158, 22);
            ConfirmSaleButton.TabIndex = 2;
            ConfirmSaleButton.Text = "Finalizar Venta";
            ConfirmSaleButton.UseVisualStyleBackColor = true;
            // 
            // EditSaleItemButton
            // 
            EditSaleItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            EditSaleItemButton.FlatAppearance.BorderSize = 0;
            EditSaleItemButton.FlatStyle = FlatStyle.Flat;
            EditSaleItemButton.Font = new Font("Microsoft JhengHei", 9F);
            EditSaleItemButton.Location = new Point(529, 316);
            EditSaleItemButton.Margin = new Padding(3, 2, 3, 2);
            EditSaleItemButton.Name = "EditSaleItemButton";
            EditSaleItemButton.Size = new Size(105, 22);
            EditSaleItemButton.TabIndex = 3;
            EditSaleItemButton.Text = "Editar Item";
            EditSaleItemButton.UseVisualStyleBackColor = true;
            // 
            // AddSaleItemButton
            // 
            AddSaleItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddSaleItemButton.FlatAppearance.BorderSize = 0;
            AddSaleItemButton.FlatStyle = FlatStyle.Flat;
            AddSaleItemButton.Font = new Font("Microsoft JhengHei", 9F);
            AddSaleItemButton.Location = new Point(419, 316);
            AddSaleItemButton.Margin = new Padding(3, 2, 3, 2);
            AddSaleItemButton.Name = "AddSaleItemButton";
            AddSaleItemButton.Size = new Size(105, 22);
            AddSaleItemButton.TabIndex = 4;
            AddSaleItemButton.Text = "Agregar";
            AddSaleItemButton.UseVisualStyleBackColor = true;
            // 
            // ViewItemsPanel
            // 
            ViewItemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ViewItemsPanel.BackColor = SystemColors.ControlLightLight;
            ViewItemsPanel.Controls.Add(PrintReceiptButton);
            ViewItemsPanel.Controls.Add(CustomerLabel);
            ViewItemsPanel.Controls.Add(label1);
            ViewItemsPanel.Controls.Add(CustomerCombobox);
            ViewItemsPanel.Controls.Add(CancelButton);
            ViewItemsPanel.Controls.Add(AddSaleItemButton);
            ViewItemsPanel.Controls.Add(EditSaleItemButton);
            ViewItemsPanel.Controls.Add(ConfirmSaleButton);
            ViewItemsPanel.Controls.Add(RemoveItemButton);
            ViewItemsPanel.Controls.Add(SaleItemsDatagridview);
            ViewItemsPanel.Location = new Point(1, 1);
            ViewItemsPanel.Margin = new Padding(3, 2, 3, 2);
            ViewItemsPanel.Name = "ViewItemsPanel";
            ViewItemsPanel.Size = new Size(756, 388);
            ViewItemsPanel.TabIndex = 1;
            // 
            // CustomerLabel
            // 
            CustomerLabel.AutoSize = true;
            CustomerLabel.Location = new Point(561, 25);
            CustomerLabel.Name = "CustomerLabel";
            CustomerLabel.Size = new Size(91, 15);
            CustomerLabel.TabIndex = 8;
            CustomerLabel.Text = "Nombre Cliente";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(508, 24);
            label1.Name = "label1";
            label1.Size = new Size(50, 17);
            label1.TabIndex = 7;
            label1.Text = "Cliente:";
            // 
            // CustomerCombobox
            // 
            CustomerCombobox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CustomerCombobox.FormattingEnabled = true;
            CustomerCombobox.Location = new Point(561, 21);
            CustomerCombobox.Name = "CustomerCombobox";
            CustomerCombobox.Size = new Size(163, 23);
            CustomerCombobox.TabIndex = 6;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.FlatAppearance.BorderSize = 0;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Font = new Font("Microsoft JhengHei", 9F);
            CancelButton.Location = new Point(661, 356);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(63, 22);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // PrintReceiptButton
            // 
            PrintReceiptButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PrintReceiptButton.FlatAppearance.BorderSize = 0;
            PrintReceiptButton.FlatStyle = FlatStyle.Flat;
            PrintReceiptButton.Font = new Font("Microsoft JhengHei", 9F);
            PrintReceiptButton.Location = new Point(11, 356);
            PrintReceiptButton.Margin = new Padding(3, 2, 3, 2);
            PrintReceiptButton.Name = "PrintReceiptButton";
            PrintReceiptButton.Size = new Size(158, 22);
            PrintReceiptButton.TabIndex = 9;
            PrintReceiptButton.Text = "Imprimir Factura";
            PrintReceiptButton.UseVisualStyleBackColor = true;
            // 
            // SaleView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 387);
            Controls.Add(ViewItemsPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SaleView";
            Text = "SaleView";
            ((System.ComponentModel.ISupportInitialize)SaleItemsDatagridview).EndInit();
            ViewItemsPanel.ResumeLayout(false);
            ViewItemsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView SaleItemsDatagridview;
        private Button RemoveItemButton;
        private Button ConfirmSaleButton;
        private Button EditSaleItemButton;
        private Button AddSaleItemButton;
        private Panel ViewItemsPanel;
        private Button CancelButton;
        private Label label1;
        private ComboBox CustomerCombobox;
        private Label CustomerLabel;
        private Button PrintReceiptButton;
    }
}