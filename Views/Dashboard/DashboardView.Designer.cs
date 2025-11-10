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
            panel3 = new Panel();
            label5 = new Label();
            panel1 = new Panel();
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
            AutoscrollPanel.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // AutoscrollPanel
            // 
            AutoscrollPanel.AutoScroll = true;
            AutoscrollPanel.Controls.Add(panel3);
            AutoscrollPanel.Controls.Add(label5);
            AutoscrollPanel.Controls.Add(panel1);
            AutoscrollPanel.Controls.Add(label4);
            AutoscrollPanel.Controls.Add(label3);
            AutoscrollPanel.Controls.Add(panel2);
            AutoscrollPanel.Controls.Add(SalesGraphPanel);
            AutoscrollPanel.Dock = DockStyle.Fill;
            AutoscrollPanel.Location = new Point(0, 0);
            AutoscrollPanel.Name = "AutoscrollPanel";
            AutoscrollPanel.Size = new Size(784, 749);
            AutoscrollPanel.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Location = new Point(14, 806);
            panel3.Name = "panel3";
            panel3.Size = new Size(722, 236);
            panel3.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 761);
            label5.Name = "label5";
            label5.Size = new Size(120, 32);
            label5.TabIndex = 14;
            label5.Text = "Productos";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(12, 490);
            panel1.Name = "panel1";
            panel1.Size = new Size(722, 236);
            panel1.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 445);
            label4.Name = "label4";
            label4.Size = new Size(232, 32);
            label4.TabIndex = 12;
            label4.Text = "Mejores vendedores";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 134);
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
            panel2.Location = new Point(242, 10);
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
            SalesGraphPanel.Location = new Point(12, 180);
            SalesGraphPanel.Name = "SalesGraphPanel";
            SalesGraphPanel.Size = new Size(722, 236);
            SalesGraphPanel.TabIndex = 9;
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 749);
            Controls.Add(AutoscrollPanel);
            Name = "DashboardView";
            Text = "DashboardView";
            AutoscrollPanel.ResumeLayout(false);
            AutoscrollPanel.PerformLayout();
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
        private Panel panel1;
        private Label label4;
    }
}