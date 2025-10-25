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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            NameTextbox = new System.Windows.Forms.TextBox();
            CuilTextbox = new System.Windows.Forms.TextBox();
            EmailTextbox = new System.Windows.Forms.TextBox();
            PhoneTextbox = new System.Windows.Forms.TextBox();
            AddSupplierButton = new System.Windows.Forms.Button();
            CancelButton = new System.Windows.Forms.Button();
            UpdateSupplierButton = new System.Windows.Forms.Button();
            CloseAtUpdateCheckbox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(32, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(32, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 20);
            label2.TabIndex = 1;
            label2.Text = "CUIL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(32, 118);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(32, 161);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(67, 20);
            label4.TabIndex = 3;
            label4.Text = "Teléfono";
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new System.Drawing.Point(157, 29);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new System.Drawing.Size(255, 27);
            NameTextbox.TabIndex = 6;
            // 
            // CuilTextbox
            // 
            CuilTextbox.Location = new System.Drawing.Point(157, 72);
            CuilTextbox.Name = "CuilTextbox";
            CuilTextbox.Size = new System.Drawing.Size(255, 27);
            CuilTextbox.TabIndex = 7;
            // 
            // EmailTextbox
            // 
            EmailTextbox.Location = new System.Drawing.Point(157, 115);
            EmailTextbox.Name = "EmailTextbox";
            EmailTextbox.Size = new System.Drawing.Size(255, 27);
            EmailTextbox.TabIndex = 8;
            // 
            // PhoneTextbox
            // 
            PhoneTextbox.Location = new System.Drawing.Point(157, 158);
            PhoneTextbox.Name = "PhoneTextbox";
            PhoneTextbox.Size = new System.Drawing.Size(255, 27);
            PhoneTextbox.TabIndex = 9;
            // 
            // AddSupplierButton
            // 
            AddSupplierButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            AddSupplierButton.Location = new System.Drawing.Point(32, 220);
            AddSupplierButton.Name = "AddSupplierButton";
            AddSupplierButton.Size = new System.Drawing.Size(141, 35);
            AddSupplierButton.TabIndex = 12;
            AddSupplierButton.Text = "Agregar Proveedor";
            AddSupplierButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            CancelButton.Location = new System.Drawing.Point(317, 220);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new System.Drawing.Size(95, 35);
            CancelButton.TabIndex = 13;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // UpdateSupplierButton
            // 
            UpdateSupplierButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            UpdateSupplierButton.Location = new System.Drawing.Point(193, 220);
            UpdateSupplierButton.Name = "UpdateSupplierButton";
            UpdateSupplierButton.Size = new System.Drawing.Size(100, 35);
            UpdateSupplierButton.TabIndex = 16;
            UpdateSupplierButton.Text = "Actualizar";
            UpdateSupplierButton.UseVisualStyleBackColor = true;
            // 
            // CloseAtUpdateCheckbox
            // 
            CloseAtUpdateCheckbox.AutoSize = true;
            CloseAtUpdateCheckbox.Location = new System.Drawing.Point(32, 261);
            CloseAtUpdateCheckbox.Name = "CloseAtUpdateCheckbox";
            CloseAtUpdateCheckbox.Size = new System.Drawing.Size(295, 24);
            CloseAtUpdateCheckbox.TabIndex = 18;
            CloseAtUpdateCheckbox.Text = "No cerrar ventana al Agregar/Actualizar";
            CloseAtUpdateCheckbox.UseVisualStyleBackColor = true;
            // 
            // SupplierView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLight;
            ClientSize = new System.Drawing.Size(450, 300);
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
            Name = "SupplierView";
            Text = "Gestión de Proveedor";
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