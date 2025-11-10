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
            SalesGraphPanel = new Panel();
            panel2 = new Panel();
            Label = new Label();
            EndDatePicker = new DateTimePicker();
            label2 = new Label();
            StartDatePicker = new DateTimePicker();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label3 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // SalesGraphPanel
            // 
            SalesGraphPanel.Location = new Point(35, 182);
            SalesGraphPanel.Name = "SalesGraphPanel";
            SalesGraphPanel.Size = new Size(715, 236);
            SalesGraphPanel.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(Label);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(EndDatePicker);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(StartDatePicker);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(258, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(514, 102);
            panel2.TabIndex = 7;
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
            // EndDatePicker
            // 
            EndDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EndDatePicker.CustomFormat = "dd MMM, yyyy";
            EndDatePicker.Location = new Point(304, 38);
            EndDatePicker.Name = "EndDatePicker";
            EndDatePicker.Size = new Size(200, 23);
            EndDatePicker.TabIndex = 10;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(260, 42);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 9;
            label2.Text = "label2";
            // 
            // StartDatePicker
            // 
            StartDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StartDatePicker.CustomFormat = "dd MMM, yyyy";
            StartDatePicker.Location = new Point(54, 38);
            StartDatePicker.Name = "StartDatePicker";
            StartDatePicker.Size = new Size(200, 23);
            StartDatePicker.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(10, 42);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(104, 67);
            button1.Name = "button1";
            button1.Size = new Size(75, 25);
            button1.TabIndex = 11;
            button1.Text = "Semanal";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(197, 67);
            button2.Name = "button2";
            button2.Size = new Size(75, 25);
            button2.TabIndex = 13;
            button2.Text = "Mensual";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(291, 67);
            button3.Name = "button3";
            button3.Size = new Size(75, 25);
            button3.TabIndex = 14;
            button3.Text = "Trimestral";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(383, 67);
            button4.Name = "button4";
            button4.Size = new Size(75, 25);
            button4.TabIndex = 15;
            button4.Text = "Anual";
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(35, 128);
            label3.Name = "label3";
            label3.Size = new Size(84, 32);
            label3.TabIndex = 8;
            label3.Text = "Ventas";
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 450);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(SalesGraphPanel);
            Name = "DashboardView";
            Text = "DashboardView";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel SalesGraphPanel;
        private Panel panel2;
        private Label Label;
        private DateTimePicker EndDatePicker;
        private Label label2;
        private DateTimePicker StartDatePicker;
        private Label label1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label3;
    }
}