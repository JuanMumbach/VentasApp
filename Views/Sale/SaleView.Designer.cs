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
            CancelButton = new Button();
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
            SaleItemsDatagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SaleItemsDatagridview.Location = new Point(10, 49);
            SaleItemsDatagridview.Margin = new Padding(3, 2, 3, 2);
            SaleItemsDatagridview.Name = "SaleItemsDatagridview";
            SaleItemsDatagridview.ReadOnly = true;
            SaleItemsDatagridview.RowHeadersWidth = 51;
            SaleItemsDatagridview.Size = new Size(823, 263);
            SaleItemsDatagridview.TabIndex = 0;
            // 
            // RemoveItemButton
            // 
            RemoveItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RemoveItemButton.Location = new Point(728, 316);
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
            EditSaleItemButton.Location = new Point(618, 316);
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
            AddSaleItemButton.Location = new Point(508, 316);
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
            ViewItemsPanel.Controls.Add(CancelButton);
            ViewItemsPanel.Controls.Add(AddSaleItemButton);
            ViewItemsPanel.Controls.Add(EditSaleItemButton);
            ViewItemsPanel.Controls.Add(ConfirmSaleButton);
            ViewItemsPanel.Controls.Add(RemoveItemButton);
            ViewItemsPanel.Controls.Add(SaleItemsDatagridview);
            ViewItemsPanel.Location = new Point(1, 1);
            ViewItemsPanel.Margin = new Padding(3, 2, 3, 2);
            ViewItemsPanel.Name = "ViewItemsPanel";
            ViewItemsPanel.Size = new Size(845, 388);
            ViewItemsPanel.TabIndex = 1;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelButton.Location = new Point(187, 356);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(63, 22);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaleView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 387);
            Controls.Add(ViewItemsPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SaleView";
            Text = "SaleView";
            ((System.ComponentModel.ISupportInitialize)SaleItemsDatagridview).EndInit();
            ViewItemsPanel.ResumeLayout(false);
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
    }
}