namespace VentasApp.Views.Customer
{
    partial class CustomerAddView
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
            CancelButton = new Button();
            AddCustomerButton = new Button();
            TB_Address = new TextBox();
            TB_Phone = new TextBox();
            TB_Email = new TextBox();
            TB_Lastname = new TextBox();
            TB_Name = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelButton.Location = new Point(140, 277);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 26;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // AddCustomerButton
            // 
            AddCustomerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddCustomerButton.Location = new Point(49, 277);
            AddCustomerButton.Name = "AddCustomerButton";
            AddCustomerButton.Size = new Size(75, 23);
            AddCustomerButton.TabIndex = 25;
            AddCustomerButton.Text = "Agregar";
            AddCustomerButton.UseVisualStyleBackColor = true;
            // 
            // TB_Address
            // 
            TB_Address.Location = new Point(106, 219);
            TB_Address.Name = "TB_Address";
            TB_Address.Size = new Size(348, 23);
            TB_Address.TabIndex = 24;
            // 
            // TB_Phone
            // 
            TB_Phone.Location = new Point(106, 180);
            TB_Phone.Name = "TB_Phone";
            TB_Phone.Size = new Size(197, 23);
            TB_Phone.TabIndex = 23;
            // 
            // TB_Email
            // 
            TB_Email.Location = new Point(106, 135);
            TB_Email.Name = "TB_Email";
            TB_Email.Size = new Size(197, 23);
            TB_Email.TabIndex = 22;
            // 
            // TB_Lastname
            // 
            TB_Lastname.Location = new Point(106, 87);
            TB_Lastname.Name = "TB_Lastname";
            TB_Lastname.Size = new Size(197, 23);
            TB_Lastname.TabIndex = 21;
            // 
            // TB_Name
            // 
            TB_Name.Location = new Point(106, 38);
            TB_Name.Name = "TB_Name";
            TB_Name.Size = new Size(197, 23);
            TB_Name.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 222);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 19;
            label5.Text = "Domicilio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 183);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 18;
            label4.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 138);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 17;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 90);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 16;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 41);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 15;
            label1.Text = "Nombre";
            // 
            // CustomerAddView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 342);
            Controls.Add(CancelButton);
            Controls.Add(AddCustomerButton);
            Controls.Add(TB_Address);
            Controls.Add(TB_Phone);
            Controls.Add(TB_Email);
            Controls.Add(TB_Lastname);
            Controls.Add(TB_Name);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CustomerAddView";
            Text = "CustomerAddView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelButton;
        private Button AddCustomerButton;
        private TextBox TB_Address;
        private TextBox TB_Phone;
        private TextBox TB_Email;
        private TextBox TB_Lastname;
        private TextBox TB_Name;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}