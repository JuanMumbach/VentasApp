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
            ViewItemsPanel = new Panel();
            SaleItemsDatagridview = new DataGridView();
            RemoveItemButton = new Button();
            ConfirmSaleButton = new Button();
            EditSaleItemButton = new Button();
            AddSaleItemButton = new Button();
            ViewItemsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SaleItemsDatagridview).BeginInit();
            SuspendLayout();
            // 
            // ViewItemsPanel
            // 
            ViewItemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ViewItemsPanel.BackColor = SystemColors.ControlLightLight;
            ViewItemsPanel.Controls.Add(AddSaleItemButton);
            ViewItemsPanel.Controls.Add(EditSaleItemButton);
            ViewItemsPanel.Controls.Add(ConfirmSaleButton);
            ViewItemsPanel.Controls.Add(RemoveItemButton);
            ViewItemsPanel.Controls.Add(SaleItemsDatagridview);
            ViewItemsPanel.Location = new Point(1, 1);
            ViewItemsPanel.Name = "ViewItemsPanel";
            ViewItemsPanel.Size = new Size(966, 518);
            ViewItemsPanel.TabIndex = 1;
            // 
            // SaleItemsDatagridview
            // 
            SaleItemsDatagridview.AllowUserToAddRows = false;
            SaleItemsDatagridview.AllowUserToDeleteRows = false;
            SaleItemsDatagridview.AllowUserToOrderColumns = true;
            SaleItemsDatagridview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SaleItemsDatagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SaleItemsDatagridview.Location = new Point(11, 65);
            SaleItemsDatagridview.Name = "SaleItemsDatagridview";
            SaleItemsDatagridview.ReadOnly = true;
            SaleItemsDatagridview.RowHeadersWidth = 51;
            SaleItemsDatagridview.Size = new Size(941, 351);
            SaleItemsDatagridview.TabIndex = 0;
            // 
            // RemoveItemButton
            // 
            RemoveItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RemoveItemButton.Location = new Point(832, 422);
            RemoveItemButton.Name = "RemoveItemButton";
            RemoveItemButton.Size = new Size(120, 29);
            RemoveItemButton.TabIndex = 1;
            RemoveItemButton.Text = "Eliminar Item";
            RemoveItemButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmSaleButton
            // 
            ConfirmSaleButton.Location = new Point(11, 474);
            ConfirmSaleButton.Name = "ConfirmSaleButton";
            ConfirmSaleButton.Size = new Size(180, 29);
            ConfirmSaleButton.TabIndex = 2;
            ConfirmSaleButton.Text = "Finalizar Venta";
            ConfirmSaleButton.UseVisualStyleBackColor = true;
            // 
            // EditSaleItemButton
            // 
            EditSaleItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            EditSaleItemButton.Location = new Point(706, 422);
            EditSaleItemButton.Name = "EditSaleItemButton";
            EditSaleItemButton.Size = new Size(120, 29);
            EditSaleItemButton.TabIndex = 3;
            EditSaleItemButton.Text = "Editar Item";
            EditSaleItemButton.UseVisualStyleBackColor = true;
            // 
            // AddSaleItemButton
            // 
            AddSaleItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddSaleItemButton.Location = new Point(580, 422);
            AddSaleItemButton.Name = "AddSaleItemButton";
            AddSaleItemButton.Size = new Size(120, 29);
            AddSaleItemButton.TabIndex = 4;
            AddSaleItemButton.Text = "Agregar";
            AddSaleItemButton.UseVisualStyleBackColor = true;
            // 
            // SaleView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 516);
            Controls.Add(ViewItemsPanel);
            Name = "SaleView";
            Text = "SaleView";
            ViewItemsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SaleItemsDatagridview).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel ViewItemsPanel;
        private DataGridView SaleItemsDatagridview;
        private Button ConfirmSaleButton;
        private Button RemoveItemButton;
        private Button AddSaleItemButton;
        private Button EditSaleItemButton;
    }
}