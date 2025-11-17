namespace VentasApp.Views.Dashboard
{
    partial class ProductsReportView
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
            ExportReportButton = new Button();
            CloseButton = new Button();
            PeriodLabel = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ExportReportButton
            // 
            ExportReportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ExportReportButton.Location = new Point(524, 365);
            ExportReportButton.Name = "ExportReportButton";
            ExportReportButton.Size = new Size(95, 23);
            ExportReportButton.TabIndex = 9;
            ExportReportButton.Text = "Exportar PDF";
            ExportReportButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.Location = new Point(638, 365);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 8;
            CloseButton.Text = "Cerrar";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // PeriodLabel
            // 
            PeriodLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PeriodLabel.AutoSize = true;
            PeriodLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PeriodLabel.Location = new Point(438, 25);
            PeriodLabel.Name = "PeriodLabel";
            PeriodLabel.Size = new Size(175, 20);
            PeriodLabel.TabIndex = 7;
            PeriodLabel.Text = "Periodo: [Inicio] hast [fin]";
            PeriodLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 20);
            label1.Name = "label1";
            label1.Size = new Size(208, 25);
            label1.TabIndex = 6;
            label1.Text = "Estadisticas productos";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 70);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(673, 265);
            dataGridView1.TabIndex = 5;
            // 
            // ProductsReportView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 409);
            Controls.Add(ExportReportButton);
            Controls.Add(CloseButton);
            Controls.Add(PeriodLabel);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "ProductsReportView";
            Text = "ProductReportView";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ExportReportButton;
        private Button CloseButton;
        private Label PeriodLabel;
        private Label label1;
        private DataGridView dataGridView1;
    }
}