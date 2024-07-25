namespace CatCoffee
{
    partial class CatsForm
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
            dataGridViewCats = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCats).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCats
            // 
            dataGridViewCats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCats.Location = new Point(108, 65);
            dataGridViewCats.Name = "dataGridViewCats";
            dataGridViewCats.RowHeadersWidth = 51;
            dataGridViewCats.Size = new Size(603, 286);
            dataGridViewCats.TabIndex = 0;
            // 
            // CatsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewCats);
            Name = "CatsForm";
            Text = "CatsForm";
            Load += CatsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCats).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewCats;
    }
}