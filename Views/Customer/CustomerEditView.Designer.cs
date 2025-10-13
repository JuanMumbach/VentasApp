namespace VentasApp.Views.Customer
{
    partial class CustomerEditView
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            TB_Name = new TextBox();
            TB_Lastname = new TextBox();
            TB_Email = new TextBox();
            TB_Phone = new TextBox();
            TB_Address = new TextBox();
            UpdateCustomerButton = new Button();
            CancelButton = new Button();
            label6 = new Label();
            IdLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 62);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 111);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 159);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 204);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 243);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 4;
            label5.Text = "Domicilio";
            // 
            // TB_Name
            // 
            TB_Name.Location = new Point(105, 59);
            TB_Name.Name = "TB_Name";
            TB_Name.Size = new Size(197, 23);
            TB_Name.TabIndex = 6;
            // 
            // TB_Lastname
            // 
            TB_Lastname.Location = new Point(105, 108);
            TB_Lastname.Name = "TB_Lastname";
            TB_Lastname.Size = new Size(197, 23);
            TB_Lastname.TabIndex = 7;
            // 
            // TB_Email
            // 
            TB_Email.Location = new Point(105, 156);
            TB_Email.Name = "TB_Email";
            TB_Email.Size = new Size(197, 23);
            TB_Email.TabIndex = 8;
            // 
            // TB_Phone
            // 
            TB_Phone.Location = new Point(105, 201);
            TB_Phone.Name = "TB_Phone";
            TB_Phone.Size = new Size(197, 23);
            TB_Phone.TabIndex = 9;
            // 
            // TB_Address
            // 
            TB_Address.Location = new Point(105, 240);
            TB_Address.Name = "TB_Address";
            TB_Address.Size = new Size(348, 23);
            TB_Address.TabIndex = 10;
            // 
            // UpdateCustomerButton
            // 
            UpdateCustomerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UpdateCustomerButton.Location = new Point(48, 303);
            UpdateCustomerButton.Name = "UpdateCustomerButton";
            UpdateCustomerButton.Size = new Size(75, 23);
            UpdateCustomerButton.TabIndex = 12;
            UpdateCustomerButton.Text = "Actualizar";
            UpdateCustomerButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelButton.Location = new Point(140, 303);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 14;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(48, 27);
            label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 15;
            label6.Text = "ID";
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Location = new Point(105, 27);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(25, 15);
            IdLabel.TabIndex = 16;
            IdLabel.Text = "001";
            // 
            // CustomerEditView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 349);
            Controls.Add(IdLabel);
            Controls.Add(label6);
            Controls.Add(CancelButton);
            Controls.Add(UpdateCustomerButton);
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
            Name = "CustomerEditView";
            Text = "CustomerView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox TB_Name;
        private TextBox TB_Lastname;
        private TextBox TB_Email;
        private TextBox TB_Phone;
        private TextBox TB_Address;
        private Button UpdateCustomerButton;
        private Button CancelButton;
        private Label label6;
        private Label IdLabel;
    }
}