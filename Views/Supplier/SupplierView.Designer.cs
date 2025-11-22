using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace VentasApp.Views
{
    partial class SupplierView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierView));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            NameTextbox = new TextBox();
            CuilTextbox = new TextBox();
            EmailTextbox = new TextBox();
            PhoneTextbox = new TextBox();
            AddSupplierButton = new Button();
            CancelButton = new Button();
            UpdateSupplierButton = new Button();
            CloseAtUpdateCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 24);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 56);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 1;
            label2.Text = "CUIL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 88);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 121);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Teléfono";
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new Point(137, 22);
            NameTextbox.Margin = new Padding(3, 2, 3, 2);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(224, 23);
            NameTextbox.TabIndex = 6;
            // 
            // CuilTextbox
            // 
            CuilTextbox.Location = new Point(137, 54);
            CuilTextbox.Margin = new Padding(3, 2, 3, 2);
            CuilTextbox.Name = "CuilTextbox";
            CuilTextbox.Size = new Size(224, 23);
            CuilTextbox.TabIndex = 7;
            // 
            // EmailTextbox
            // 
            EmailTextbox.Location = new Point(137, 86);
            EmailTextbox.Margin = new Padding(3, 2, 3, 2);
            EmailTextbox.Name = "EmailTextbox";
            EmailTextbox.Size = new Size(224, 23);
            EmailTextbox.TabIndex = 8;
            // 
            // PhoneTextbox
            // 
            PhoneTextbox.Location = new Point(137, 118);
            PhoneTextbox.Margin = new Padding(3, 2, 3, 2);
            PhoneTextbox.Name = "PhoneTextbox";
            PhoneTextbox.Size = new Size(224, 23);
            PhoneTextbox.TabIndex = 9;
            // 
            // AddSupplierButton
            // 
            AddSupplierButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddSupplierButton.Location = new Point(28, 165);
            AddSupplierButton.Margin = new Padding(3, 2, 3, 2);
            AddSupplierButton.Name = "AddSupplierButton";
            AddSupplierButton.Size = new Size(123, 26);
            AddSupplierButton.TabIndex = 12;
            AddSupplierButton.Text = "Agregar Proveedor";
            AddSupplierButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelButton.Location = new Point(277, 165);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(83, 26);
            CancelButton.TabIndex = 13;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // UpdateSupplierButton
            // 
            UpdateSupplierButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UpdateSupplierButton.Location = new Point(169, 165);
            UpdateSupplierButton.Margin = new Padding(3, 2, 3, 2);
            UpdateSupplierButton.Name = "UpdateSupplierButton";
            UpdateSupplierButton.Size = new Size(88, 26);
            UpdateSupplierButton.TabIndex = 16;
            UpdateSupplierButton.Text = "Actualizar";
            UpdateSupplierButton.UseVisualStyleBackColor = true;
            // 
            // CloseAtUpdateCheckbox
            // 
            CloseAtUpdateCheckbox.AutoSize = true;
            CloseAtUpdateCheckbox.Location = new Point(28, 196);
            CloseAtUpdateCheckbox.Margin = new Padding(3, 2, 3, 2);
            CloseAtUpdateCheckbox.Name = "CloseAtUpdateCheckbox";
            CloseAtUpdateCheckbox.Size = new Size(234, 19);
            CloseAtUpdateCheckbox.TabIndex = 18;
            CloseAtUpdateCheckbox.Text = "No cerrar ventana al Agregar/Actualizar";
            CloseAtUpdateCheckbox.UseVisualStyleBackColor = true;
            // 
            // SupplierView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(394, 225);
            Controls.Add(CloseAtUpdateCheckbox);
            Controls.Add(UpdateSupplierButton);
            Controls.Add(CancelButton);
            Controls.Add(AddSupplierButton);
            Controls.Add(PhoneTextbox);
            Controls.Add(EmailTextbox);
            Controls.Add(CuilTextbox);
            Controls.Add(NameTextbox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "SupplierView";
            Text = "Gestión de Proveedor - VentasApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.TextBox CuilTextbox;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.TextBox PhoneTextbox;
        private System.Windows.Forms.Button AddSupplierButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button UpdateSupplierButton;
        private System.Windows.Forms.CheckBox CloseAtUpdateCheckbox;
    }
}