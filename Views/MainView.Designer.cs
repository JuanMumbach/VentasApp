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
            MainPanelLogoPicturebox = new PictureBox();
            WelcomeLabel = new Label();
            SidePanel = new Panel();
            panel2 = new Panel();
            LogoutButton = new Button();
            SideLayoutPanel = new FlowLayoutPanel();
            PanelLogo = new Panel();
            SidePanelLogoPicturebox = new PictureBox();
            SellButton = new Button();
            DashboardButton = new Button();
            ListSalesButton = new Button();
            ProductsButton = new Button();
            CustomersButton = new Button();
            SuppliersButton = new Button();
            UsersViewButton = new Button();
            SystemSettingsViewButton = new Button();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainPanelLogoPicturebox).BeginInit();
            SidePanel.SuspendLayout();
            panel2.SuspendLayout();
            SideLayoutPanel.SuspendLayout();
            PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SidePanelLogoPicturebox).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.BackColor = SystemColors.ActiveCaption;
            MainPanel.Controls.Add(MainPanelLogoPicturebox);
            MainPanel.Controls.Add(WelcomeLabel);
            MainPanel.Location = new Point(198, 0);
            MainPanel.Margin = new Padding(3, 2, 3, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(695, 507);
            MainPanel.TabIndex = 99;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // MainPanelLogoPicturebox
            // 
            MainPanelLogoPicturebox.Anchor = AnchorStyles.None;
            MainPanelLogoPicturebox.Image = Properties.Resources.VentasAppLogoClaro;
            MainPanelLogoPicturebox.Location = new Point(282, 68);
            MainPanelLogoPicturebox.Name = "MainPanelLogoPicturebox";
            MainPanelLogoPicturebox.Size = new Size(180, 180);
            MainPanelLogoPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            MainPanelLogoPicturebox.TabIndex = 1;
            MainPanelLogoPicturebox.TabStop = false;
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.Anchor = AnchorStyles.None;
            WelcomeLabel.Font = new Font("Microsoft JhengHei", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WelcomeLabel.ForeColor = SystemColors.HotTrack;
            WelcomeLabel.Location = new Point(139, 262);
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
            SidePanel.Size = new Size(200, 507);
            SidePanel.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(LogoutButton);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 462);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(200, 45);
            panel2.TabIndex = 99;
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
            LogoutButton.TabIndex = 4;
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
            SideLayoutPanel.Controls.Add(DashboardButton);
            SideLayoutPanel.Controls.Add(ListSalesButton);
            SideLayoutPanel.Controls.Add(ProductsButton);
            SideLayoutPanel.Controls.Add(CustomersButton);
            SideLayoutPanel.Controls.Add(SuppliersButton);
            SideLayoutPanel.Controls.Add(UsersViewButton);
            SideLayoutPanel.Controls.Add(SystemSettingsViewButton);
            SideLayoutPanel.Dock = DockStyle.Top;
            SideLayoutPanel.FlowDirection = FlowDirection.TopDown;
            SideLayoutPanel.Location = new Point(0, 0);
            SideLayoutPanel.Margin = new Padding(0);
            SideLayoutPanel.Name = "SideLayoutPanel";
            SideLayoutPanel.Padding = new Padding(5);
            SideLayoutPanel.Size = new Size(200, 420);
            SideLayoutPanel.TabIndex = 99;
            // 
            // PanelLogo
            // 
            PanelLogo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelLogo.Controls.Add(SidePanelLogoPicturebox);
            PanelLogo.Dock = DockStyle.Left;
            PanelLogo.Location = new Point(7, 10);
            PanelLogo.Margin = new Padding(2, 5, 0, 10);
            PanelLogo.Name = "PanelLogo";
            PanelLogo.Size = new Size(184, 96);
            PanelLogo.TabIndex = 6;
            // 
            // SidePanelLogoPicturebox
            // 
            SidePanelLogoPicturebox.Anchor = AnchorStyles.None;
            SidePanelLogoPicturebox.Image = Properties.Resources.VentasAppLogoClaro;
            SidePanelLogoPicturebox.Location = new Point(45, 4);
            SidePanelLogoPicturebox.Name = "SidePanelLogoPicturebox";
            SidePanelLogoPicturebox.Size = new Size(90, 90);
            SidePanelLogoPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            SidePanelLogoPicturebox.TabIndex = 0;
            SidePanelLogoPicturebox.TabStop = false;
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
            SellButton.TabIndex = 0;
            SellButton.Text = "VENDER";
            SellButton.TextAlign = ContentAlignment.MiddleLeft;
            SellButton.UseVisualStyleBackColor = false;
            // 
            // DashboardButton
            // 
            DashboardButton.BackColor = SystemColors.InactiveBorder;
            DashboardButton.Dock = DockStyle.Left;
            DashboardButton.FlatAppearance.BorderSize = 0;
            DashboardButton.FlatStyle = FlatStyle.Flat;
            DashboardButton.Font = new Font("Microsoft JhengHei", 12F);
            DashboardButton.ForeColor = SystemColors.GrayText;
            DashboardButton.Location = new Point(5, 151);
            DashboardButton.Margin = new Padding(0, 0, 0, 5);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(190, 30);
            DashboardButton.TabIndex = 100;
            DashboardButton.Text = "Dashboard";
            DashboardButton.TextAlign = ContentAlignment.MiddleLeft;
            DashboardButton.UseVisualStyleBackColor = false;
            // 
            // ListSalesButton
            // 
            ListSalesButton.BackColor = SystemColors.InactiveBorder;
            ListSalesButton.Dock = DockStyle.Left;
            ListSalesButton.FlatAppearance.BorderSize = 0;
            ListSalesButton.FlatStyle = FlatStyle.Flat;
            ListSalesButton.Font = new Font("Microsoft JhengHei", 12F);
            ListSalesButton.ForeColor = SystemColors.GrayText;
            ListSalesButton.Location = new Point(5, 186);
            ListSalesButton.Margin = new Padding(0, 0, 0, 5);
            ListSalesButton.Name = "ListSalesButton";
            ListSalesButton.Size = new Size(190, 30);
            ListSalesButton.TabIndex = 104;
            ListSalesButton.Text = "Historial Ventas";
            ListSalesButton.TextAlign = ContentAlignment.MiddleLeft;
            ListSalesButton.UseVisualStyleBackColor = false;
            // 
            // ProductsButton
            // 
            ProductsButton.BackColor = SystemColors.InactiveBorder;
            ProductsButton.Dock = DockStyle.Left;
            ProductsButton.FlatAppearance.BorderSize = 0;
            ProductsButton.FlatStyle = FlatStyle.Flat;
            ProductsButton.Font = new Font("Microsoft JhengHei", 12F);
            ProductsButton.ForeColor = SystemColors.GrayText;
            ProductsButton.Location = new Point(5, 221);
            ProductsButton.Margin = new Padding(0, 0, 0, 5);
            ProductsButton.Name = "ProductsButton";
            ProductsButton.Size = new Size(190, 30);
            ProductsButton.TabIndex = 101;
            ProductsButton.Text = "Productos";
            ProductsButton.TextAlign = ContentAlignment.MiddleLeft;
            ProductsButton.UseVisualStyleBackColor = false;
            // 
            // CustomersButton
            // 
            CustomersButton.BackColor = SystemColors.InactiveBorder;
            CustomersButton.Dock = DockStyle.Left;
            CustomersButton.FlatAppearance.BorderSize = 0;
            CustomersButton.FlatStyle = FlatStyle.Flat;
            CustomersButton.Font = new Font("Microsoft JhengHei", 12F);
            CustomersButton.ForeColor = SystemColors.GrayText;
            CustomersButton.Location = new Point(5, 256);
            CustomersButton.Margin = new Padding(0, 0, 0, 5);
            CustomersButton.Name = "CustomersButton";
            CustomersButton.Size = new Size(190, 30);
            CustomersButton.TabIndex = 102;
            CustomersButton.Text = "Clientes";
            CustomersButton.TextAlign = ContentAlignment.MiddleLeft;
            CustomersButton.UseVisualStyleBackColor = false;
            // 
            // SuppliersButton
            // 
            SuppliersButton.BackColor = SystemColors.InactiveBorder;
            SuppliersButton.Dock = DockStyle.Left;
            SuppliersButton.FlatAppearance.BorderSize = 0;
            SuppliersButton.FlatStyle = FlatStyle.Flat;
            SuppliersButton.Font = new Font("Microsoft JhengHei", 12F);
            SuppliersButton.ForeColor = SystemColors.GrayText;
            SuppliersButton.Location = new Point(5, 291);
            SuppliersButton.Margin = new Padding(0, 0, 0, 5);
            SuppliersButton.Name = "SuppliersButton";
            SuppliersButton.Size = new Size(190, 30);
            SuppliersButton.TabIndex = 105;
            SuppliersButton.Text = "Proveedores";
            SuppliersButton.TextAlign = ContentAlignment.MiddleLeft;
            SuppliersButton.UseVisualStyleBackColor = false;
            // 
            // UsersViewButton
            // 
            UsersViewButton.BackColor = SystemColors.InactiveBorder;
            UsersViewButton.Dock = DockStyle.Left;
            UsersViewButton.FlatAppearance.BorderSize = 0;
            UsersViewButton.FlatStyle = FlatStyle.Flat;
            UsersViewButton.Font = new Font("Microsoft JhengHei", 12F);
            UsersViewButton.ForeColor = SystemColors.GrayText;
            UsersViewButton.Location = new Point(5, 326);
            UsersViewButton.Margin = new Padding(0, 0, 0, 5);
            UsersViewButton.Name = "UsersViewButton";
            UsersViewButton.Size = new Size(190, 30);
            UsersViewButton.TabIndex = 103;
            UsersViewButton.Text = "Usuarios";
            UsersViewButton.TextAlign = ContentAlignment.MiddleLeft;
            UsersViewButton.UseVisualStyleBackColor = false;
            // 
            // SystemSettingsViewButton
            // 
            SystemSettingsViewButton.BackColor = SystemColors.InactiveBorder;
            SystemSettingsViewButton.Dock = DockStyle.Left;
            SystemSettingsViewButton.FlatAppearance.BorderSize = 0;
            SystemSettingsViewButton.FlatStyle = FlatStyle.Flat;
            SystemSettingsViewButton.Font = new Font("Microsoft JhengHei", 12F);
            SystemSettingsViewButton.ForeColor = SystemColors.GrayText;
            SystemSettingsViewButton.Location = new Point(5, 361);
            SystemSettingsViewButton.Margin = new Padding(0, 0, 0, 5);
            SystemSettingsViewButton.Name = "SystemSettingsViewButton";
            SystemSettingsViewButton.Size = new Size(190, 30);
            SystemSettingsViewButton.TabIndex = 106;
            SystemSettingsViewButton.Text = "Sistema";
            SystemSettingsViewButton.TextAlign = ContentAlignment.MiddleLeft;
            SystemSettingsViewButton.UseVisualStyleBackColor = false;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(893, 507);
            Controls.Add(SidePanel);
            Controls.Add(MainPanel);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(640, 480);
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VentasApp";
            FormClosed += MainView_FormClosed;
            MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainPanelLogoPicturebox).EndInit();
            SidePanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            SideLayoutPanel.ResumeLayout(false);
            PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SidePanelLogoPicturebox).EndInit();
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
        private PictureBox SidePanelLogoPicturebox;
        private PictureBox MainPanelLogoPicturebox;
        private Button DashboardButton;
        private Button ListSalesButton;
        private Button ProductsButton;
        private Button CustomersButton;
        private Button SuppliersButton;
        private Button UsersViewButton;
        private Button SystemSettingsViewButton;
    }
}