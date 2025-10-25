using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace VentasApp.Views.Sale
{
    partial class ListSalesView
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
            SalesDataGridView = new DataGridView();
            RestoreButton = new Button();
            CancelSaleButton = new Button();
            ViewDetailButton = new Button();
            TitleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)SalesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // SalesDataGridView
            // 
            SalesDataGridView.AllowUserToAddRows = false;
            SalesDataGridView.AllowUserToDeleteRows = false;
            SalesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SalesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SalesDataGridView.Location = new Point(12, 50);
            SalesDataGridView.Name = "SalesDataGridView";
            SalesDataGridView.ReadOnly = true;
            SalesDataGridView.RowHeadersWidth = 51;
            SalesDataGridView.RowTemplate.Height = 25;
            SalesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SalesDataGridView.Size = new Size(776, 350);
            SalesDataGridView.TabIndex = 0;
            // 
            // RestoreButton
            // 
            RestoreButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RestoreButton.Location = new Point(12, 415);
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Size = new Size(150, 23);
            RestoreButton.TabIndex = 1;
            RestoreButton.Text = "Restaurar Venta";
            RestoreButton.UseVisualStyleBackColor = true;
            // 
            // CancelSaleButton
            // 
            CancelSaleButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelSaleButton.Location = new Point(170, 415);
            CancelSaleButton.Name = "CancelSaleButton";
            CancelSaleButton.Size = new Size(150, 23);
            CancelSaleButton.TabIndex = 2;
            CancelSaleButton.Text = "Cancelar Venta";
            CancelSaleButton.UseVisualStyleBackColor = true;
            // 
            // ViewDetailButton
            // 
            ViewDetailButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ViewDetailButton.Location = new Point(328, 415); // Posicionarlo después de CancelSaleButton
            ViewDetailButton.Name = "ViewDetailButton";
            ViewDetailButton.Size = new Size(150, 23);
            ViewDetailButton.TabIndex = 3; // Ajustar TabIndex
            ViewDetailButton.Text = "Ver Detalle";
            ViewDetailButton.UseVisualStyleBackColor = true;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(220, 32);
            TitleLabel.TabIndex = 3;
            TitleLabel.Text = "Historial de Ventas";
            // 
            // SaleHistoryView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ViewDetailButton);
            Controls.Add(TitleLabel);
            Controls.Add(CancelSaleButton);
            Controls.Add(RestoreButton);
            Controls.Add(SalesDataGridView);
            Name = "SaleHistoryView";
            Text = "Historial de Ventas";
            ((System.ComponentModel.ISupportInitialize)SalesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView SalesDataGridView;
        private Button RestoreButton;
        private Button CancelSaleButton;
        private Label TitleLabel;
        private Button ViewDetailButton;
    }
}