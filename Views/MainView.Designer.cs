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
            UsersViewButton = new Button();
            SellButton = new Button();
            ProductsButton = new Button();
            MainPanel = new Panel();
            CustomersButton = new Button();
            SidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // SidePanel
            // 
            SidePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SidePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SidePanel.BackColor = SystemColors.Control;
            SidePanel.Controls.Add(CustomersButton);
            SidePanel.Controls.Add(UsersViewButton);
            SidePanel.Controls.Add(SellButton);
            SidePanel.Controls.Add(ProductsButton);
            SidePanel.Location = new Point(-1, 0);
            SidePanel.Margin = new Padding(3, 2, 3, 2);
            SidePanel.Name = "SidePanel";
            SidePanel.RightToLeft = RightToLeft.No;
            SidePanel.Size = new Size(247, 443);
            SidePanel.TabIndex = 0;
            // 
            // UsersViewButton
            // 
            UsersViewButton.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsersViewButton.ForeColor = SystemColors.GrayText;
            UsersViewButton.Location = new Point(3, 219);
            UsersViewButton.Margin = new Padding(3, 2, 3, 2);
            UsersViewButton.Name = "UsersViewButton";
            UsersViewButton.Size = new Size(242, 34);
            UsersViewButton.TabIndex = 2;
            UsersViewButton.Text = "USUARIOS";
            UsersViewButton.UseVisualStyleBackColor = true;
            // 
            // SellButton
            // 
            SellButton.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SellButton.ForeColor = SystemColors.GrayText;
            SellButton.Location = new Point(2, 143);
            SellButton.Margin = new Padding(3, 2, 3, 2);
            SellButton.Name = "SellButton";
            SellButton.Size = new Size(242, 34);
            SellButton.TabIndex = 1;
            SellButton.Text = "VENDER";
            SellButton.UseVisualStyleBackColor = true;
            // 
            // ProductsButton
            // 
            ProductsButton.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductsButton.ForeColor = SystemColors.GrayText;
            ProductsButton.Location = new Point(2, 181);
            ProductsButton.Margin = new Padding(3, 2, 3, 2);
            ProductsButton.Name = "ProductsButton";
            ProductsButton.Size = new Size(242, 34);
            ProductsButton.TabIndex = 0;
            ProductsButton.Text = "PRODUCTOS";
            ProductsButton.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.BackColor = SystemColors.ActiveCaption;
            MainPanel.Location = new Point(251, 0);
            MainPanel.Margin = new Padding(3, 2, 3, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(642, 443);
            MainPanel.TabIndex = 1;
            // 
            // CustomersButton
            // 
            CustomersButton.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CustomersButton.ForeColor = SystemColors.GrayText;
            CustomersButton.Location = new Point(3, 257);
            CustomersButton.Margin = new Padding(3, 2, 3, 2);
            CustomersButton.Name = "CustomersButton";
            CustomersButton.Size = new Size(242, 34);
            CustomersButton.TabIndex = 3;
            CustomersButton.Text = "CLIENTES";
            CustomersButton.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(893, 444);
            Controls.Add(MainPanel);
            Controls.Add(SidePanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainView";
            Text = "MainView";
            SidePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel SidePanel;
        private Panel MainPanel;
        private Button ProductsButton;
        private Button SellButton;
        private Button UsersViewButton;
        private Button CustomersButton;
    }
}