namespace CatCoffee
{
    partial class TablesForm
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
            dataGridViewTables = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTables).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTables
            // 
            dataGridViewTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTables.Location = new Point(131, 50);
            dataGridViewTables.Name = "dataGridViewTables";
            dataGridViewTables.RowHeadersWidth = 51;
            dataGridViewTables.Size = new Size(565, 300);
            dataGridViewTables.TabIndex = 0;
            // 
            // TablesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewTables);
            Name = "TablesForm";
            Text = "TablesForm";
            Load += TablesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTables).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewTables;
    }
}