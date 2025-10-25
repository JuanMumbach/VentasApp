using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace VentasApp.Views
{
    partial class ListSuppliersView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridView1 = new System.Windows.Forms.DataGridView();
            SearchTextbox = new System.Windows.Forms.TextBox();
            OpenAddSupplierViewButton = new System.Windows.Forms.Button();
            DeleteButton = new System.Windows.Forms.Button();
            RestoreButton = new System.Windows.Forms.Button();
            ShowDeletedCheckbox = new System.Windows.Forms.CheckBox();
            EditSupplierButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(38, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new System.Drawing.Size(818, 381);
            dataGridView1.TabIndex = 0;
            // 
            // SearchTextbox
            // 
            SearchTextbox.Location = new System.Drawing.Point(51, 56);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.Size = new System.Drawing.Size(522, 27);
            SearchTextbox.TabIndex = 1;
            // 
            // OpenAddSupplierViewButton
            // 
            OpenAddSupplierViewButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            OpenAddSupplierViewButton.Location = new System.Drawing.Point(38, 495);
            OpenAddSupplierViewButton.Name = "OpenAddSupplierViewButton";
            OpenAddSupplierViewButton.Size = new System.Drawing.Size(94, 29);
            OpenAddSupplierViewButton.TabIndex = 2;
            OpenAddSupplierViewButton.Text = "Agregar";
            OpenAddSupplierViewButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DeleteButton.Location = new System.Drawing.Point(762, 495);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new System.Drawing.Size(94, 29);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Eliminar";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // RestoreButton
            // 
            RestoreButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            RestoreButton.Location = new System.Drawing.Point(662, 495);
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Size = new System.Drawing.Size(94, 29);
            RestoreButton.TabIndex = 4;
            RestoreButton.Text = "Restaurar";
            RestoreButton.UseVisualStyleBackColor = true;
            // 
            // ShowDeletedCheckbox
            // 
            ShowDeletedCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ShowDeletedCheckbox.AutoSize = true;
            ShowDeletedCheckbox.Location = new System.Drawing.Point(497, 498);
            ShowDeletedCheckbox.Name = "ShowDeletedCheckbox";
            ShowDeletedCheckbox.Size = new System.Drawing.Size(159, 24);
            ShowDeletedCheckbox.TabIndex = 5;
            ShowDeletedCheckbox.Text = "Mostrar eliminados";
            ShowDeletedCheckbox.UseVisualStyleBackColor = true;
            // 
            // EditSupplierButton
            // 
            EditSupplierButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            EditSupplierButton.Location = new System.Drawing.Point(153, 495);
            EditSupplierButton.Name = "EditSupplierButton";
            EditSupplierButton.Size = new System.Drawing.Size(94, 29);
            EditSupplierButton.TabIndex = 6;
            EditSupplierButton.Text = "Editar";
            EditSupplierButton.UseVisualStyleBackColor = true;
            // 
            // ListSuppliersView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLight;
            ClientSize = new System.Drawing.Size(896, 570);
            Controls.Add(EditSupplierButton);
            Controls.Add(ShowDeletedCheckbox);
            Controls.Add(RestoreButton);
            Controls.Add(DeleteButton);
            Controls.Add(OpenAddSupplierViewButton);
            Controls.Add(SearchTextbox);
            Controls.Add(dataGridView1);
            Name = "ListSuppliersView";
            Text = "Lista de Proveedores";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox SearchTextbox;
        private System.Windows.Forms.Button OpenAddSupplierViewButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.CheckBox ShowDeletedCheckbox;
        private System.Windows.Forms.Button EditSupplierButton;
    }
}