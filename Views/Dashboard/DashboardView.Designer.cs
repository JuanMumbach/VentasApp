namespace VentasApp.Views.Dashboard
{
    partial class DashboardView
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
            AutoscrollPanel = new Panel();
            label9 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            TopProductsChartPanel = new Panel();
            panel1 = new Panel();
            TopCategoriasChartPanel = new Panel();
            label5 = new Label();
            TopSellersPanel = new Panel();
            Top3SellerPanel = new Panel();
            Top3SellerIncomesLabel = new Label();
            Top3SellerSalesLabel = new Label();
            label17 = new Label();
            label18 = new Label();
            Top3SellerNameLabel = new Label();
            label20 = new Label();
            Top2SellerPanel = new Panel();
            Top2SellerIncomesLabel = new Label();
            Top2SellerSalesLabel = new Label();
            label11 = new Label();
            label12 = new Label();
            Top2SellerNameLabel = new Label();
            label14 = new Label();
            Top1SellerPanel = new Panel();
            Top1SellerIncomesLabel = new Label();
            Top1SellerSalesLabel = new Label();
            label8 = new Label();
            label7 = new Label();
            Top1SellerNameLabel = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            YearlyPeriodButton = new Button();
            TrimesterPeriodButton = new Button();
            MonthlyPeriodButton = new Button();
            Label = new Label();
            WeeklyPeriodButton = new Button();
            EndDatePicker = new DateTimePicker();
            label2 = new Label();
            StartDatePicker = new DateTimePicker();
            label1 = new Label();
            SalesGraphPanel = new Panel();
            GenerateGeneralReport = new Button();
            DetailedSalesmenReportButton = new Button();
            DetailedProductsReportButton = new Button();
            AutoscrollPanel.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            TopSellersPanel.SuspendLayout();
            Top3SellerPanel.SuspendLayout();
            Top2SellerPanel.SuspendLayout();
            Top1SellerPanel.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // AutoscrollPanel
            // 
            AutoscrollPanel.AutoScroll = true;
            AutoscrollPanel.Controls.Add(DetailedProductsReportButton);
            AutoscrollPanel.Controls.Add(DetailedSalesmenReportButton);
            AutoscrollPanel.Controls.Add(GenerateGeneralReport);
            AutoscrollPanel.Controls.Add(label9);
            AutoscrollPanel.Controls.Add(panel3);
            AutoscrollPanel.Controls.Add(label5);
            AutoscrollPanel.Controls.Add(TopSellersPanel);
            AutoscrollPanel.Controls.Add(label4);
            AutoscrollPanel.Controls.Add(label3);
            AutoscrollPanel.Controls.Add(panel2);
            AutoscrollPanel.Controls.Add(SalesGraphPanel);
            AutoscrollPanel.Dock = DockStyle.Fill;
            AutoscrollPanel.Location = new Point(0, 0);
            AutoscrollPanel.MinimumSize = new Size(784, 0);
            AutoscrollPanel.Name = "AutoscrollPanel";
            AutoscrollPanel.Size = new Size(784, 749);
            AutoscrollPanel.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(37, 34);
            label9.Name = "label9";
            label9.Size = new Size(141, 40);
            label9.TabIndex = 15;
            label9.Text = "Informes";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel1);
            panel3.Location = new Point(14, 818);
            panel3.Name = "panel3";
            panel3.Size = new Size(737, 298);
            panel3.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.Controls.Add(TopProductsChartPanel);
            panel4.Location = new Point(373, 13);
            panel4.Name = "panel4";
            panel4.Size = new Size(339, 273);
            panel4.TabIndex = 1;
            // 
            // TopProductsChartPanel
            // 
            TopProductsChartPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TopProductsChartPanel.Location = new Point(18, 20);
            TopProductsChartPanel.Name = "TopProductsChartPanel";
            TopProductsChartPanel.Size = new Size(302, 234);
            TopProductsChartPanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(TopCategoriasChartPanel);
            panel1.Location = new Point(23, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 273);
            panel1.TabIndex = 0;
            // 
            // TopCategoriasChartPanel
            // 
            TopCategoriasChartPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TopCategoriasChartPanel.Location = new Point(18, 20);
            TopCategoriasChartPanel.Name = "TopCategoriasChartPanel";
            TopCategoriasChartPanel.Size = new Size(307, 234);
            TopCategoriasChartPanel.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 773);
            label5.Name = "label5";
            label5.Size = new Size(120, 32);
            label5.TabIndex = 14;
            label5.Text = "Productos";
            // 
            // TopSellersPanel
            // 
            TopSellersPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TopSellersPanel.Controls.Add(Top3SellerPanel);
            TopSellersPanel.Controls.Add(Top2SellerPanel);
            TopSellersPanel.Controls.Add(Top1SellerPanel);
            TopSellersPanel.Location = new Point(12, 512);
            TopSellersPanel.Name = "TopSellersPanel";
            TopSellersPanel.Size = new Size(739, 236);
            TopSellersPanel.TabIndex = 10;
            // 
            // Top3SellerPanel
            // 
            Top3SellerPanel.Anchor = AnchorStyles.Top;
            Top3SellerPanel.Controls.Add(Top3SellerIncomesLabel);
            Top3SellerPanel.Controls.Add(Top3SellerSalesLabel);
            Top3SellerPanel.Controls.Add(label17);
            Top3SellerPanel.Controls.Add(label18);
            Top3SellerPanel.Controls.Add(Top3SellerNameLabel);
            Top3SellerPanel.Controls.Add(label20);
            Top3SellerPanel.Location = new Point(473, 21);
            Top3SellerPanel.Name = "Top3SellerPanel";
            Top3SellerPanel.Size = new Size(160, 195);
            Top3SellerPanel.TabIndex = 7;
            // 
            // Top3SellerIncomesLabel
            // 
            Top3SellerIncomesLabel.Anchor = AnchorStyles.Top;
            Top3SellerIncomesLabel.AutoSize = true;
            Top3SellerIncomesLabel.Location = new Point(106, 133);
            Top3SellerIncomesLabel.Name = "Top3SellerIncomesLabel";
            Top3SellerIncomesLabel.Size = new Size(49, 15);
            Top3SellerIncomesLabel.TabIndex = 5;
            Top3SellerIncomesLabel.Text = "$459000";
            Top3SellerIncomesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Top3SellerSalesLabel
            // 
            Top3SellerSalesLabel.Anchor = AnchorStyles.Top;
            Top3SellerSalesLabel.AutoSize = true;
            Top3SellerSalesLabel.Location = new Point(106, 105);
            Top3SellerSalesLabel.Name = "Top3SellerSalesLabel";
            Top3SellerSalesLabel.Size = new Size(25, 15);
            Top3SellerSalesLabel.TabIndex = 4;
            Top3SellerSalesLabel.Text = "149";
            Top3SellerSalesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top;
            label17.AutoSize = true;
            label17.Location = new Point(5, 133);
            label17.Name = "label17";
            label17.Size = new Size(92, 15);
            label17.TabIndex = 3;
            label17.Text = "Ingresos totales:";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top;
            label18.AutoSize = true;
            label18.Location = new Point(5, 105);
            label18.Name = "label18";
            label18.Size = new Size(95, 15);
            label18.TabIndex = 2;
            label18.Text = "Cantidad ventas:";
            label18.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Top3SellerNameLabel
            // 
            Top3SellerNameLabel.Anchor = AnchorStyles.Top;
            Top3SellerNameLabel.AutoSize = true;
            Top3SellerNameLabel.Location = new Point(29, 42);
            Top3SellerNameLabel.Name = "Top3SellerNameLabel";
            Top3SellerNameLabel.Size = new Size(104, 15);
            Top3SellerNameLabel.TabIndex = 1;
            Top3SellerNameLabel.Text = "Nombre vendedor";
            Top3SellerNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Top;
            label20.AutoSize = true;
            label20.Location = new Point(63, 15);
            label20.Name = "label20";
            label20.Size = new Size(37, 15);
            label20.TabIndex = 0;
            label20.Text = "TOP 3";
            // 
            // Top2SellerPanel
            // 
            Top2SellerPanel.Anchor = AnchorStyles.Top;
            Top2SellerPanel.Controls.Add(Top2SellerIncomesLabel);
            Top2SellerPanel.Controls.Add(Top2SellerSalesLabel);
            Top2SellerPanel.Controls.Add(label11);
            Top2SellerPanel.Controls.Add(label12);
            Top2SellerPanel.Controls.Add(Top2SellerNameLabel);
            Top2SellerPanel.Controls.Add(label14);
            Top2SellerPanel.Location = new Point(294, 21);
            Top2SellerPanel.Name = "Top2SellerPanel";
            Top2SellerPanel.Size = new Size(156, 195);
            Top2SellerPanel.TabIndex = 6;
            // 
            // Top2SellerIncomesLabel
            // 
            Top2SellerIncomesLabel.Anchor = AnchorStyles.Top;
            Top2SellerIncomesLabel.AutoSize = true;
            Top2SellerIncomesLabel.Location = new Point(104, 133);
            Top2SellerIncomesLabel.Name = "Top2SellerIncomesLabel";
            Top2SellerIncomesLabel.Size = new Size(49, 15);
            Top2SellerIncomesLabel.TabIndex = 5;
            Top2SellerIncomesLabel.Text = "$459000";
            Top2SellerIncomesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Top2SellerSalesLabel
            // 
            Top2SellerSalesLabel.Anchor = AnchorStyles.Top;
            Top2SellerSalesLabel.AutoSize = true;
            Top2SellerSalesLabel.Location = new Point(104, 105);
            Top2SellerSalesLabel.Name = "Top2SellerSalesLabel";
            Top2SellerSalesLabel.Size = new Size(25, 15);
            Top2SellerSalesLabel.TabIndex = 4;
            Top2SellerSalesLabel.Text = "149";
            Top2SellerSalesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Location = new Point(3, 133);
            label11.Name = "label11";
            label11.Size = new Size(92, 15);
            label11.TabIndex = 3;
            label11.Text = "Ingresos totales:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Location = new Point(3, 105);
            label12.Name = "label12";
            label12.Size = new Size(95, 15);
            label12.TabIndex = 2;
            label12.Text = "Cantidad ventas:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Top2SellerNameLabel
            // 
            Top2SellerNameLabel.Anchor = AnchorStyles.Top;
            Top2SellerNameLabel.AutoSize = true;
            Top2SellerNameLabel.Location = new Point(27, 42);
            Top2SellerNameLabel.Name = "Top2SellerNameLabel";
            Top2SellerNameLabel.Size = new Size(104, 15);
            Top2SellerNameLabel.TabIndex = 1;
            Top2SellerNameLabel.Text = "Nombre vendedor";
            Top2SellerNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.Location = new Point(61, 15);
            label14.Name = "label14";
            label14.Size = new Size(37, 15);
            label14.TabIndex = 0;
            label14.Text = "TOP 2";
            // 
            // Top1SellerPanel
            // 
            Top1SellerPanel.Anchor = AnchorStyles.Top;
            Top1SellerPanel.Controls.Add(Top1SellerIncomesLabel);
            Top1SellerPanel.Controls.Add(Top1SellerSalesLabel);
            Top1SellerPanel.Controls.Add(label8);
            Top1SellerPanel.Controls.Add(label7);
            Top1SellerPanel.Controls.Add(Top1SellerNameLabel);
            Top1SellerPanel.Controls.Add(label6);
            Top1SellerPanel.Location = new Point(114, 21);
            Top1SellerPanel.Name = "Top1SellerPanel";
            Top1SellerPanel.Size = new Size(154, 195);
            Top1SellerPanel.TabIndex = 0;
            // 
            // Top1SellerIncomesLabel
            // 
            Top1SellerIncomesLabel.Anchor = AnchorStyles.Top;
            Top1SellerIncomesLabel.AutoSize = true;
            Top1SellerIncomesLabel.Location = new Point(103, 133);
            Top1SellerIncomesLabel.Name = "Top1SellerIncomesLabel";
            Top1SellerIncomesLabel.Size = new Size(49, 15);
            Top1SellerIncomesLabel.TabIndex = 5;
            Top1SellerIncomesLabel.Text = "$459000";
            Top1SellerIncomesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Top1SellerSalesLabel
            // 
            Top1SellerSalesLabel.Anchor = AnchorStyles.Top;
            Top1SellerSalesLabel.AutoSize = true;
            Top1SellerSalesLabel.Location = new Point(103, 105);
            Top1SellerSalesLabel.Name = "Top1SellerSalesLabel";
            Top1SellerSalesLabel.Size = new Size(25, 15);
            Top1SellerSalesLabel.TabIndex = 4;
            Top1SellerSalesLabel.Text = "149";
            Top1SellerSalesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(2, 133);
            label8.Name = "label8";
            label8.Size = new Size(92, 15);
            label8.TabIndex = 3;
            label8.Text = "Ingresos totales:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(2, 105);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 2;
            label7.Text = "Cantidad ventas:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Top1SellerNameLabel
            // 
            Top1SellerNameLabel.Anchor = AnchorStyles.Top;
            Top1SellerNameLabel.AutoSize = true;
            Top1SellerNameLabel.Location = new Point(26, 42);
            Top1SellerNameLabel.Name = "Top1SellerNameLabel";
            Top1SellerNameLabel.Size = new Size(104, 15);
            Top1SellerNameLabel.TabIndex = 1;
            Top1SellerNameLabel.Text = "Nombre vendedor";
            Top1SellerNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(60, 15);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 0;
            label6.Text = "TOP 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 467);
            label4.Name = "label4";
            label4.Size = new Size(232, 32);
            label4.TabIndex = 12;
            label4.Text = "Mejores vendedores";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 156);
            label3.Name = "label3";
            label3.Size = new Size(84, 32);
            label3.TabIndex = 11;
            label3.Text = "Ventas";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(YearlyPeriodButton);
            panel2.Controls.Add(TrimesterPeriodButton);
            panel2.Controls.Add(MonthlyPeriodButton);
            panel2.Controls.Add(Label);
            panel2.Controls.Add(WeeklyPeriodButton);
            panel2.Controls.Add(EndDatePicker);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(StartDatePicker);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(237, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(514, 102);
            panel2.TabIndex = 10;
            // 
            // YearlyPeriodButton
            // 
            YearlyPeriodButton.Anchor = AnchorStyles.Bottom;
            YearlyPeriodButton.FlatStyle = FlatStyle.Flat;
            YearlyPeriodButton.Location = new Point(383, 67);
            YearlyPeriodButton.Name = "YearlyPeriodButton";
            YearlyPeriodButton.Size = new Size(80, 27);
            YearlyPeriodButton.TabIndex = 15;
            YearlyPeriodButton.Text = "Anual";
            YearlyPeriodButton.UseVisualStyleBackColor = true;
            // 
            // TrimesterPeriodButton
            // 
            TrimesterPeriodButton.Anchor = AnchorStyles.Bottom;
            TrimesterPeriodButton.FlatStyle = FlatStyle.Flat;
            TrimesterPeriodButton.Location = new Point(291, 67);
            TrimesterPeriodButton.Name = "TrimesterPeriodButton";
            TrimesterPeriodButton.Size = new Size(80, 27);
            TrimesterPeriodButton.TabIndex = 14;
            TrimesterPeriodButton.Text = "Trimestral";
            TrimesterPeriodButton.UseVisualStyleBackColor = true;
            // 
            // MonthlyPeriodButton
            // 
            MonthlyPeriodButton.Anchor = AnchorStyles.Bottom;
            MonthlyPeriodButton.FlatStyle = FlatStyle.Flat;
            MonthlyPeriodButton.Location = new Point(197, 67);
            MonthlyPeriodButton.Name = "MonthlyPeriodButton";
            MonthlyPeriodButton.Size = new Size(80, 27);
            MonthlyPeriodButton.TabIndex = 13;
            MonthlyPeriodButton.Text = "Mensual";
            MonthlyPeriodButton.UseVisualStyleBackColor = true;
            // 
            // Label
            // 
            Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Label.AutoSize = true;
            Label.Location = new Point(243, 11);
            Label.Name = "Label";
            Label.Size = new Size(48, 15);
            Label.TabIndex = 12;
            Label.Text = "Periodo";
            // 
            // WeeklyPeriodButton
            // 
            WeeklyPeriodButton.Anchor = AnchorStyles.Bottom;
            WeeklyPeriodButton.FlatStyle = FlatStyle.Flat;
            WeeklyPeriodButton.Location = new Point(104, 67);
            WeeklyPeriodButton.Name = "WeeklyPeriodButton";
            WeeklyPeriodButton.Size = new Size(80, 27);
            WeeklyPeriodButton.TabIndex = 11;
            WeeklyPeriodButton.Text = "Semanal";
            WeeklyPeriodButton.UseVisualStyleBackColor = true;
            // 
            // EndDatePicker
            // 
            EndDatePicker.Anchor = AnchorStyles.Top;
            EndDatePicker.CustomFormat = "dd MMM, yyyy";
            EndDatePicker.Location = new Point(304, 38);
            EndDatePicker.Name = "EndDatePicker";
            EndDatePicker.Size = new Size(175, 23);
            EndDatePicker.TabIndex = 10;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(260, 42);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 9;
            label2.Text = "Fin";
            // 
            // StartDatePicker
            // 
            StartDatePicker.Anchor = AnchorStyles.Top;
            StartDatePicker.CustomFormat = "dd MMM, yyyy";
            StartDatePicker.Location = new Point(54, 38);
            StartDatePicker.Name = "StartDatePicker";
            StartDatePicker.Size = new Size(175, 23);
            StartDatePicker.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(10, 42);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 7;
            label1.Text = "Inicio";
            // 
            // SalesGraphPanel
            // 
            SalesGraphPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SalesGraphPanel.Location = new Point(12, 202);
            SalesGraphPanel.Name = "SalesGraphPanel";
            SalesGraphPanel.Size = new Size(739, 236);
            SalesGraphPanel.TabIndex = 9;
            // 
            // GenerateGeneralReport
            // 
            GenerateGeneralReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GenerateGeneralReport.Location = new Point(635, 121);
            GenerateGeneralReport.Name = "GenerateGeneralReport";
            GenerateGeneralReport.Size = new Size(116, 45);
            GenerateGeneralReport.TabIndex = 16;
            GenerateGeneralReport.Text = "Exportar resumen del periodo (PDF)";
            GenerateGeneralReport.UseVisualStyleBackColor = true;
            // 
            // DetailedSalesmenReportButton
            // 
            DetailedSalesmenReportButton.Location = new Point(605, 477);
            DetailedSalesmenReportButton.Name = "DetailedSalesmenReportButton";
            DetailedSalesmenReportButton.Size = new Size(146, 23);
            DetailedSalesmenReportButton.TabIndex = 17;
            DetailedSalesmenReportButton.Text = "Ver informe detallado";
            DetailedSalesmenReportButton.UseVisualStyleBackColor = true;
            // 
            // DetailedProductsReportButton
            // 
            DetailedProductsReportButton.Location = new Point(605, 783);
            DetailedProductsReportButton.Name = "DetailedProductsReportButton";
            DetailedProductsReportButton.Size = new Size(146, 23);
            DetailedProductsReportButton.TabIndex = 18;
            DetailedProductsReportButton.Text = "Ver informe detallado";
            DetailedProductsReportButton.UseVisualStyleBackColor = true;
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 749);
            Controls.Add(AutoscrollPanel);
            MinimumSize = new Size(800, 0);
            Name = "DashboardView";
            Text = "DashboardView";
            AutoscrollPanel.ResumeLayout(false);
            AutoscrollPanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            TopSellersPanel.ResumeLayout(false);
            Top3SellerPanel.ResumeLayout(false);
            Top3SellerPanel.PerformLayout();
            Top2SellerPanel.ResumeLayout(false);
            Top2SellerPanel.PerformLayout();
            Top1SellerPanel.ResumeLayout(false);
            Top1SellerPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel AutoscrollPanel;
        private Label label3;
        private Panel panel2;
        private Button YearlyPeriodButton;
        private Button TrimesterPeriodButton;
        private Button MonthlyPeriodButton;
        private Label Label;
        private Button WeeklyPeriodButton;
        private DateTimePicker EndDatePicker;
        private Label label2;
        private DateTimePicker StartDatePicker;
        private Label label1;
        private Panel SalesGraphPanel;
        private Panel panel3;
        private Label label5;
        private Panel TopSellersPanel;
        private Label label4;
        private Panel Top1SellerPanel;
        private Label Top1SellerNameLabel;
        private Label label6;
        private Label Top1SellerIncomesLabel;
        private Label Top1SellerSalesLabel;
        private Label label8;
        private Label label7;
        private Panel Top3SellerPanel;
        private Label Top3SellerIncomesLabel;
        private Label Top3SellerSalesLabel;
        private Label label17;
        private Label label18;
        private Label Top3SellerNameLabel;
        private Label label20;
        private Panel Top2SellerPanel;
        private Label Top2SellerIncomesLabel;
        private Label Top2SellerSalesLabel;
        private Label label11;
        private Label label12;
        private Label Top2SellerNameLabel;
        private Label label14;
        private Panel panel1;
        private Panel TopCategoriasChartPanel;
        private Panel panel4;
        private Panel TopProductsChartPanel;
        private Label label9;
        private Button GenerateGeneralReport;
        private Button DetailedProductsReportButton;
        private Button DetailedSalesmenReportButton;
    }
}