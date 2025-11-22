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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListSuppliersView));
            dataGridView1 = new DataGridView();
            SearchTextbox = new TextBox();
            OpenAddSupplierViewButton = new Button();
            DeleteButton = new Button();
            RestoreButton = new Button();
            ShowDeletedCheckbox = new CheckBox();
            EditSupplierButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 70);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(716, 286);
            dataGridView1.TabIndex = 0;
            // 
            // SearchTextbox
            // 
            SearchTextbox.Location = new Point(45, 42);
            SearchTextbox.Margin = new Padding(3, 2, 3, 2);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.Size = new Size(457, 23);
            SearchTextbox.TabIndex = 1;
            // 
            // OpenAddSupplierViewButton
            // 
            OpenAddSupplierViewButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OpenAddSupplierViewButton.Location = new Point(33, 371);
            OpenAddSupplierViewButton.Margin = new Padding(3, 2, 3, 2);
            OpenAddSupplierViewButton.Name = "OpenAddSupplierViewButton";
            OpenAddSupplierViewButton.Size = new Size(82, 22);
            OpenAddSupplierViewButton.TabIndex = 2;
            OpenAddSupplierViewButton.Text = "Agregar";
            OpenAddSupplierViewButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DeleteButton.Location = new Point(667, 371);
            DeleteButton.Margin = new Padding(3, 2, 3, 2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(82, 22);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Eliminar";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // RestoreButton
            // 
            RestoreButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RestoreButton.Location = new Point(579, 371);
            RestoreButton.Margin = new Padding(3, 2, 3, 2);
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Size = new Size(82, 22);
            RestoreButton.TabIndex = 4;
            RestoreButton.Text = "Restaurar";
            RestoreButton.UseVisualStyleBackColor = true;
            // 
            // ShowDeletedCheckbox
            // 
            ShowDeletedCheckbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ShowDeletedCheckbox.AutoSize = true;
            ShowDeletedCheckbox.Location = new Point(446, 373);
            ShowDeletedCheckbox.Margin = new Padding(3, 2, 3, 2);
            ShowDeletedCheckbox.Name = "ShowDeletedCheckbox";
            ShowDeletedCheckbox.Size = new Size(128, 19);
            ShowDeletedCheckbox.TabIndex = 5;
            ShowDeletedCheckbox.Text = "Mostrar eliminados";
            ShowDeletedCheckbox.UseVisualStyleBackColor = true;
            // 
            // EditSupplierButton
            // 
            EditSupplierButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EditSupplierButton.Location = new Point(134, 371);
            EditSupplierButton.Margin = new Padding(3, 2, 3, 2);
            EditSupplierButton.Name = "EditSupplierButton";
            EditSupplierButton.Size = new Size(82, 22);
            EditSupplierButton.TabIndex = 6;
            EditSupplierButton.Text = "Editar";
            EditSupplierButton.UseVisualStyleBackColor = true;
            // 
            // ListSuppliersView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(784, 428);
            Controls.Add(EditSupplierButton);
            Controls.Add(ShowDeletedCheckbox);
            Controls.Add(RestoreButton);
            Controls.Add(DeleteButton);
            Controls.Add(OpenAddSupplierViewButton);
            Controls.Add(SearchTextbox);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ListSuppliersView";
            Text = "Lista de Proveedores - VentasApp";
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