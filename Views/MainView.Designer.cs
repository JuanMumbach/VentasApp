namespace VentasApp.Views
{
    partial class MainView
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
            SidePanel = new Panel();
            ProductsButton = new Button();
            MainPanel = new Panel();
            SidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // SidePanel
            // 
            SidePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SidePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SidePanel.BackColor = SystemColors.Control;
            SidePanel.Controls.Add(ProductsButton);
            SidePanel.Location = new Point(-1, 0);
            SidePanel.Name = "SidePanel";
            SidePanel.RightToLeft = RightToLeft.No;
            SidePanel.Size = new Size(282, 591);
            SidePanel.TabIndex = 0;
            // 
            // ProductsButton
            // 
            ProductsButton.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductsButton.ForeColor = SystemColors.GrayText;
            ProductsButton.Location = new Point(3, 183);
            ProductsButton.Name = "ProductsButton";
            ProductsButton.Size = new Size(276, 46);
            ProductsButton.TabIndex = 0;
            ProductsButton.Text = "PRODUCTOS";
            ProductsButton.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.BackColor = SystemColors.ActiveCaption;
            MainPanel.Location = new Point(287, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(734, 591);
            MainPanel.TabIndex = 1;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1021, 592);
            Controls.Add(MainPanel);
            Controls.Add(SidePanel);
            Name = "MainView";
            Text = "MainView";
            SidePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel SidePanel;
        private Panel MainPanel;
        private Button ProductsButton;
    }
}