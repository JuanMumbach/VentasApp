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
<<<<<<< Updated upstream
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "MainView";
=======
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
            ListSalesButton = new Button();
            ProductsButton = new Button();
            CustomersButton = new Button();
            SuppliersButton = new Button();
            UsersViewButton = new Button();
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
            MainPanel.BackColor = Color.White;
            MainPanel.Controls.Add(MainPanelLogoPicturebox);
            MainPanel.Controls.Add(WelcomeLabel);
            MainPanel.Location = new Point(220, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(780, 600);
            MainPanel.TabIndex = 99;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // MainPanelLogoPicturebox
            // 
            MainPanelLogoPicturebox.Anchor = AnchorStyles.None;
            MainPanelLogoPicturebox.Image = Properties.Resources.VentasAppLogoClaro;
            MainPanelLogoPicturebox.Location = new Point(300, 150);
            MainPanelLogoPicturebox.Name = "MainPanelLogoPicturebox";
            MainPanelLogoPicturebox.Size = new Size(180, 180);
            MainPanelLogoPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            MainPanelLogoPicturebox.TabIndex = 1;
            MainPanelLogoPicturebox.TabStop = false;
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.Anchor = AnchorStyles.None;
            WelcomeLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            WelcomeLabel.ForeColor = Color.FromArgb(0, 123, 255);
            WelcomeLabel.Location = new Point(100, 350);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new Size(580, 60);
            WelcomeLabel.TabIndex = 0;
            WelcomeLabel.Text = "Bienvenido, Usuario";
            WelcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SidePanel
            // 
            SidePanel.BackColor = Color.FromArgb(248, 249, 250);
            SidePanel.Controls.Add(panel2);
            SidePanel.Controls.Add(SideLayoutPanel);
            SidePanel.Dock = DockStyle.Left;
            SidePanel.Location = new Point(0, 0);
            SidePanel.Name = "SidePanel";
            SidePanel.Size = new Size(220, 600);
            SidePanel.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(LogoutButton);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 545);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(220, 55);
            panel2.TabIndex = 99;
            // 
            // LogoutButton
            // 
            LogoutButton.BackColor = Color.FromArgb(220, 53, 69);
            LogoutButton.Dock = DockStyle.Fill;
            LogoutButton.FlatAppearance.BorderSize = 0;
            LogoutButton.FlatStyle = FlatStyle.Flat;
            LogoutButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LogoutButton.ForeColor = Color.White;
            LogoutButton.Location = new Point(10, 10);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(200, 35);
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "🚪  Cerrar Sesión";
            LogoutButton.UseVisualStyleBackColor = false;
            // 
            // SideLayoutPanel
            // 
            SideLayoutPanel.AutoScroll = true;
            SideLayoutPanel.BackColor = Color.Transparent;
            SideLayoutPanel.Controls.Add(PanelLogo);
            SideLayoutPanel.Controls.Add(SellButton);
            SideLayoutPanel.Controls.Add(ListSalesButton);
            SideLayoutPanel.Controls.Add(ProductsButton);
            SideLayoutPanel.Controls.Add(CustomersButton);
            SideLayoutPanel.Controls.Add(SuppliersButton);
            SideLayoutPanel.Controls.Add(UsersViewButton);
            SideLayoutPanel.Dock = DockStyle.Top;
            SideLayoutPanel.FlowDirection = FlowDirection.TopDown;
            SideLayoutPanel.Location = new Point(0, 0);
            SideLayoutPanel.Name = "SideLayoutPanel";
            SideLayoutPanel.Padding = new Padding(10);
            SideLayoutPanel.Size = new Size(220, 545);
            SideLayoutPanel.TabIndex = 99;
            // 
            // PanelLogo
            // 
            PanelLogo.Controls.Add(SidePanelLogoPicturebox);
            PanelLogo.Location = new Point(10, 10);
            PanelLogo.Margin = new Padding(0, 0, 0, 20);
            PanelLogo.Name = "PanelLogo";
            PanelLogo.Size = new Size(200, 100);
            PanelLogo.TabIndex = 0;
            // 
            // SidePanelLogoPicturebox
            // 
            SidePanelLogoPicturebox.Image = Properties.Resources.VentasAppLogoClaro;
            SidePanelLogoPicturebox.Location = new Point(50, 5);
            SidePanelLogoPicturebox.Name = "SidePanelLogoPicturebox";
            SidePanelLogoPicturebox.Size = new Size(100, 100);
            SidePanelLogoPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            SidePanelLogoPicturebox.TabIndex = 0;
            SidePanelLogoPicturebox.TabStop = false;
            // 
            // SellButton
            // 
            SellButton.BackColor = Color.White;
            SellButton.FlatAppearance.BorderSize = 0;
            SellButton.FlatStyle = FlatStyle.Flat;
            SellButton.Font = new Font("Segoe UI", 11F);
            SellButton.Location = new Point(10, 130);
            SellButton.Margin = new Padding(0, 0, 0, 5);
            SellButton.Name = "SellButton";
            SellButton.Size = new Size(200, 40);
            SellButton.TabIndex = 1;
            SellButton.Text = "VENDER";
            SellButton.TextAlign = ContentAlignment.MiddleLeft;
            SellButton.UseVisualStyleBackColor = false;
            // 
            // ListSalesButton
            // 
            ListSalesButton.BackColor = Color.White;
            ListSalesButton.FlatAppearance.BorderSize = 0;
            ListSalesButton.FlatStyle = FlatStyle.Flat;
            ListSalesButton.Font = new Font("Segoe UI", 11F);
            ListSalesButton.Location = new Point(10, 175);
            ListSalesButton.Margin = new Padding(0, 0, 0, 5);
            ListSalesButton.Name = "ListSalesButton";
            ListSalesButton.Size = new Size(200, 40);
            ListSalesButton.TabIndex = 2;
            ListSalesButton.Text = "Historial Ventas";
            ListSalesButton.TextAlign = ContentAlignment.MiddleLeft;
            ListSalesButton.UseVisualStyleBackColor = false;
            // 
            // ProductsButton
            // 
            ProductsButton.BackColor = Color.White;
            ProductsButton.FlatAppearance.BorderSize = 0;
            ProductsButton.FlatStyle = FlatStyle.Flat;
            ProductsButton.Font = new Font("Segoe UI", 11F);
            ProductsButton.Location = new Point(10, 220);
            ProductsButton.Margin = new Padding(0, 0, 0, 5);
            ProductsButton.Name = "ProductsButton";
            ProductsButton.Size = new Size(200, 40);
            ProductsButton.TabIndex = 3;
            ProductsButton.Text = "Productos";
            ProductsButton.TextAlign = ContentAlignment.MiddleLeft;
            ProductsButton.UseVisualStyleBackColor = false;
            // 
            // CustomersButton
            // 
            CustomersButton.BackColor = Color.White;
            CustomersButton.FlatAppearance.BorderSize = 0;
            CustomersButton.FlatStyle = FlatStyle.Flat;
            CustomersButton.Font = new Font("Segoe UI", 11F);
            CustomersButton.Location = new Point(10, 265);
            CustomersButton.Margin = new Padding(0, 0, 0, 5);
            CustomersButton.Name = "CustomersButton";
            CustomersButton.Size = new Size(200, 40);
            CustomersButton.TabIndex = 4;
            CustomersButton.Text = "Clientes";
            CustomersButton.TextAlign = ContentAlignment.MiddleLeft;
            CustomersButton.UseVisualStyleBackColor = false;
            // 
            // SuppliersButton
            // 
            SuppliersButton.BackColor = Color.White;
            SuppliersButton.FlatAppearance.BorderSize = 0;
            SuppliersButton.FlatStyle = FlatStyle.Flat;
            SuppliersButton.Font = new Font("Segoe UI", 11F);
            SuppliersButton.Location = new Point(10, 310);
            SuppliersButton.Margin = new Padding(0, 0, 0, 5);
            SuppliersButton.Name = "SuppliersButton";
            SuppliersButton.Size = new Size(200, 40);
            SuppliersButton.TabIndex = 5;
            SuppliersButton.Text = "Proveedores";
            SuppliersButton.TextAlign = ContentAlignment.MiddleLeft;
            SuppliersButton.UseVisualStyleBackColor = false;
            // 
            // UsersViewButton
            // 
            UsersViewButton.BackColor = Color.White;
            UsersViewButton.FlatAppearance.BorderSize = 0;
            UsersViewButton.FlatStyle = FlatStyle.Flat;
            UsersViewButton.Font = new Font("Segoe UI", 11F);
            UsersViewButton.Location = new Point(10, 355);
            UsersViewButton.Margin = new Padding(0, 0, 0, 5);
            UsersViewButton.Name = "UsersViewButton";
            UsersViewButton.Size = new Size(200, 40);
            UsersViewButton.TabIndex = 6;
            UsersViewButton.Text = "Usuarios";
            UsersViewButton.TextAlign = ContentAlignment.MiddleLeft;
            UsersViewButton.UseVisualStyleBackColor = false;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 600);
            Controls.Add(MainPanel);
            Controls.Add(SidePanel);
            MinimumSize = new Size(1024, 600);
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VentasApp - Sistema de Ventas";
            WindowState = FormWindowState.Maximized;
            FormClosed += MainView_FormClosed;
            MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainPanelLogoPicturebox).EndInit();
            SidePanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            SideLayoutPanel.ResumeLayout(false);
            PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SidePanelLogoPicturebox).EndInit();
            ResumeLayout(false);
>>>>>>> Stashed changes
        }

        #endregion
    }
}