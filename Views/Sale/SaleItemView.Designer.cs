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
            label1.Location = new Point(18, 18);
            label1.Name = "label1";
            label1.Size = new Size(184, 15);
            label1.TabIndex = 0;
            label1.Text = "Buscar producto por nombre o ID";
            // 
            // SearchTextbox
            // 
            SearchTextbox.Location = new Point(227, 16);
            SearchTextbox.Margin = new Padding(3, 2, 3, 2);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.Size = new Size(397, 23);
            SearchTextbox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 48);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(671, 165);
            dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(18, 230);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Cantidad";
            // 
            // AmountTextbox
            // 
            AmountTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AmountTextbox.Location = new Point(84, 227);
            AmountTextbox.Margin = new Padding(3, 2, 3, 2);
            AmountTextbox.Name = "AmountTextbox";
            AmountTextbox.Size = new Size(88, 23);
            AmountTextbox.TabIndex = 4;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddButton.Location = new Point(18, 307);
            AddButton.Margin = new Padding(3, 2, 3, 2);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(82, 22);
            AddButton.TabIndex = 5;
            AddButton.Text = "Agregar";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelButton.Location = new Point(106, 307);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(82, 22);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaleItemView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(AmountTextbox);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(SearchTextbox);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
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