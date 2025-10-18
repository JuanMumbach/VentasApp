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
            MainPanel = new Panel();
            WelcomeLabel = new Label();
            SidePanel = new Panel();
            panel2 = new Panel();
            LogoutButton = new Button();
            SideLayoutPanel = new FlowLayoutPanel();
            UsersViewButton = new Button();
            CustomersButton = new Button();
            ProductsButton = new Button();
            SellButton = new Button();
            PanelLogo = new Panel();
            MainPanel.SuspendLayout();
            SidePanel.SuspendLayout();
            panel2.SuspendLayout();
            SideLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.BackColor = SystemColors.ActiveCaption;
            MainPanel.Controls.Add(WelcomeLabel);
            MainPanel.Location = new Point(198, 0);
            MainPanel.Margin = new Padding(3, 2, 3, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(695, 444);
            MainPanel.TabIndex = 1;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.Anchor = AnchorStyles.Top;
            WelcomeLabel.Font = new Font("Microsoft JhengHei", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WelcomeLabel.ForeColor = SystemColors.HotTrack;
            WelcomeLabel.Location = new Point(139, 54);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new Size(478, 50);
            WelcomeLabel.TabIndex = 0;
            WelcomeLabel.Text = "Bienvenido 001 - Username";
            WelcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SidePanel
            // 
            SidePanel.BackColor = SystemColors.AppWorkspace;
            SidePanel.Controls.Add(panel2);
            SidePanel.Controls.Add(SideLayoutPanel);
            SidePanel.Dock = DockStyle.Left;
            SidePanel.Location = new Point(0, 0);
            SidePanel.Name = "SidePanel";
            SidePanel.Size = new Size(200, 444);
            SidePanel.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(LogoutButton);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 399);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(200, 45);
            panel2.TabIndex = 1;
            // 
            // LogoutButton
            // 
            LogoutButton.AutoSize = true;
            LogoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LogoutButton.BackColor = SystemColors.InactiveBorder;
            LogoutButton.Dock = DockStyle.Bottom;
            LogoutButton.FlatAppearance.BorderSize = 0;
            LogoutButton.FlatStyle = FlatStyle.Flat;
            LogoutButton.Font = new Font("Microsoft JhengHei", 12F);
            LogoutButton.ForeColor = SystemColors.GrayText;
            LogoutButton.Location = new Point(5, 10);
            LogoutButton.Margin = new Padding(0, 10, 0, 0);
            LogoutButton.MaximumSize = new Size(0, 50);
            LogoutButton.MinimumSize = new Size(140, 25);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(190, 30);
            LogoutButton.TabIndex = 11;
            LogoutButton.Text = "Cerrar Sesión";
            LogoutButton.TextAlign = ContentAlignment.MiddleLeft;
            LogoutButton.UseVisualStyleBackColor = false;
            // 
            // SideLayoutPanel
            // 
            SideLayoutPanel.AutoScroll = true;
            SideLayoutPanel.BackColor = Color.Transparent;
            SideLayoutPanel.Controls.Add(PanelLogo);
            SideLayoutPanel.Controls.Add(SellButton);
            SideLayoutPanel.Controls.Add(ProductsButton);
            SideLayoutPanel.Controls.Add(CustomersButton);
            SideLayoutPanel.Controls.Add(UsersViewButton);
            SideLayoutPanel.Dock = DockStyle.Top;
            SideLayoutPanel.FlowDirection = FlowDirection.TopDown;
            SideLayoutPanel.Location = new Point(0, 0);
            SideLayoutPanel.Margin = new Padding(0);
            SideLayoutPanel.Name = "SideLayoutPanel";
            SideLayoutPanel.Padding = new Padding(5);
            SideLayoutPanel.Size = new Size(200, 399);
            SideLayoutPanel.TabIndex = 1;
            // 
            // UsersViewButton
            // 
            UsersViewButton.BackColor = SystemColors.InactiveBorder;
            UsersViewButton.Dock = DockStyle.Left;
            UsersViewButton.FlatAppearance.BorderSize = 0;
            UsersViewButton.FlatStyle = FlatStyle.Flat;
            UsersViewButton.Font = new Font("Microsoft JhengHei", 12F);
            UsersViewButton.ForeColor = SystemColors.GrayText;
            UsersViewButton.Location = new Point(5, 221);
            UsersViewButton.Margin = new Padding(0, 0, 0, 5);
            UsersViewButton.Name = "UsersViewButton";
            UsersViewButton.Size = new Size(190, 30);
            UsersViewButton.TabIndex = 8;
            UsersViewButton.Text = "Usuarios";
            UsersViewButton.TextAlign = ContentAlignment.MiddleLeft;
            UsersViewButton.UseVisualStyleBackColor = false;
            // 
            // CustomersButton
            // 
            CustomersButton.BackColor = SystemColors.InactiveBorder;
            CustomersButton.Dock = DockStyle.Left;
            CustomersButton.FlatAppearance.BorderSize = 0;
            CustomersButton.FlatStyle = FlatStyle.Flat;
            CustomersButton.Font = new Font("Microsoft JhengHei", 12F);
            CustomersButton.ForeColor = SystemColors.GrayText;
            CustomersButton.Location = new Point(5, 186);
            CustomersButton.Margin = new Padding(0, 0, 0, 5);
            CustomersButton.Name = "CustomersButton";
            CustomersButton.Size = new Size(190, 30);
            CustomersButton.TabIndex = 9;
            CustomersButton.Text = "Clientes";
            CustomersButton.TextAlign = ContentAlignment.MiddleLeft;
            CustomersButton.UseVisualStyleBackColor = false;
            // 
            // ProductsButton
            // 
            ProductsButton.BackColor = SystemColors.InactiveBorder;
            ProductsButton.Dock = DockStyle.Left;
            ProductsButton.FlatAppearance.BorderSize = 0;
            ProductsButton.FlatStyle = FlatStyle.Flat;
            ProductsButton.Font = new Font("Microsoft JhengHei", 12F);
            ProductsButton.ForeColor = SystemColors.GrayText;
            ProductsButton.Location = new Point(5, 151);
            ProductsButton.Margin = new Padding(0, 0, 0, 5);
            ProductsButton.Name = "ProductsButton";
            ProductsButton.Size = new Size(190, 30);
            ProductsButton.TabIndex = 5;
            ProductsButton.Text = "Productos";
            ProductsButton.TextAlign = ContentAlignment.MiddleLeft;
            ProductsButton.UseVisualStyleBackColor = false;
            // 
            // SellButton
            // 
            SellButton.BackColor = SystemColors.InactiveBorder;
            SellButton.Dock = DockStyle.Left;
            SellButton.FlatAppearance.BorderSize = 0;
            SellButton.FlatStyle = FlatStyle.Flat;
            SellButton.Font = new Font("Microsoft JhengHei", 12F);
            SellButton.ForeColor = SystemColors.GrayText;
            SellButton.Location = new Point(5, 116);
            SellButton.Margin = new Padding(0, 0, 0, 5);
            SellButton.Name = "SellButton";
            SellButton.Size = new Size(190, 30);
            SellButton.TabIndex = 7;
            SellButton.Text = "VENDER";
            SellButton.TextAlign = ContentAlignment.MiddleLeft;
            SellButton.UseVisualStyleBackColor = false;
            // 
            // PanelLogo
            // 
            PanelLogo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelLogo.Dock = DockStyle.Left;
            PanelLogo.Location = new Point(7, 10);
            PanelLogo.Margin = new Padding(2, 5, 0, 10);
            PanelLogo.Name = "PanelLogo";
            PanelLogo.Size = new Size(184, 96);
            PanelLogo.TabIndex = 6;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(893, 444);
            Controls.Add(SidePanel);
            Controls.Add(MainPanel);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(640, 480);
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainView";
            FormClosed += MainView_FormClosed;
            MainPanel.ResumeLayout(false);
            SidePanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            SideLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel MainPanel;
        private Label WelcomeLabel;
        private Panel SidePanel;
        private Panel panel2;
        private Button LogoutButton;
        private FlowLayoutPanel SideLayoutPanel;
        private Panel PanelLogo;
        private Button SellButton;
        private Button ProductsButton;
        private Button CustomersButton;
        private Button UsersViewButton;
    }
}