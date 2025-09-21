namespace VentasApp.Views.Sale
{
    partial class SaleItemView
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
            SearchTextbox = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            AmountTextbox = new TextBox();
            AddButton = new Button();
            CancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 24);
            label1.Name = "label1";
            label1.Size = new Size(232, 20);
            label1.TabIndex = 0;
            label1.Text = "Buscar producto por nombre o ID";
            // 
            // SearchTextbox
            // 
            SearchTextbox.Location = new Point(259, 21);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.Size = new Size(453, 27);
            SearchTextbox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(767, 220);
            dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 306);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 3;
            label2.Text = "Cantidad";
            // 
            // AmountTextbox
            // 
            AmountTextbox.Location = new Point(96, 303);
            AmountTextbox.Name = "AmountTextbox";
            AmountTextbox.Size = new Size(100, 27);
            AmountTextbox.TabIndex = 4;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(21, 409);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(94, 29);
            AddButton.TabIndex = 5;
            AddButton.Text = "Add item";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(136, 409);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(94, 29);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaleItemView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(AmountTextbox);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(SearchTextbox);
            Controls.Add(label1);
            Name = "SaleItemView";
            Text = "SaleItemView";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox SearchTextbox;
        private DataGridView dataGridView1;
        private Label label2;
        private TextBox AmountTextbox;
        private Button AddButton;
        private Button CancelButton;
    }
}