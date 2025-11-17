namespace VentasApp.Views.Dashboard
{
    partial class SalesmenReportView
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
            PeriodLabel = new Label();
            CloseButton = new Button();
            ExportReportButton = new Button();
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
            dataGridView1.Location = new Point(35, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(673, 265);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 25);
            label1.Name = "label1";
            label1.Size = new Size(222, 25);
            label1.TabIndex = 1;
            label1.Text = "Estadisticas Vendedores";
            // 
            // PeriodLabel
            // 
            PeriodLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PeriodLabel.AutoSize = true;
            PeriodLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PeriodLabel.Location = new Point(427, 30);
            PeriodLabel.Name = "PeriodLabel";
            PeriodLabel.Size = new Size(175, 20);
            PeriodLabel.TabIndex = 2;
            PeriodLabel.Text = "Periodo: [Inicio] hast [fin]";
            PeriodLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.Location = new Point(633, 370);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 3;
            CloseButton.Text = "Cerrar";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // ExportReportButton
            // 
            ExportReportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ExportReportButton.Location = new Point(519, 370);
            ExportReportButton.Name = "ExportReportButton";
            ExportReportButton.Size = new Size(95, 23);
            ExportReportButton.TabIndex = 4;
            ExportReportButton.Text = "Exportar PDF";
            ExportReportButton.UseVisualStyleBackColor = true;
            // 
            // SalesmenReportView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 415);
            Controls.Add(ExportReportButton);
            Controls.Add(CloseButton);
            Controls.Add(PeriodLabel);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            MinimumSize = new Size(748, 454);
            Name = "SalesmenReportView";
            Text = "SalesmenReportView";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label PeriodLabel;
        private Button CloseButton;
        private Button ExportReportButton;
    }
}