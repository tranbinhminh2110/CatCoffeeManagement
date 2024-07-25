namespace CatCoffee
{
    partial class TableManagement
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
            txtTableName = new TextBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnActivate = new Button();
            btnDeactivate = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtCapacity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTables).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTables
            // 
            dataGridViewTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTables.Location = new Point(12, 12);
            dataGridViewTables.Name = "dataGridViewTables";
            dataGridViewTables.RowHeadersWidth = 51;
            dataGridViewTables.Size = new Size(760, 150);
            dataGridViewTables.TabIndex = 0;
            dataGridViewTables.CellClick += dataGridViewTables_CellClick;
            // 
            // txtTableName
            // 
            txtTableName.Location = new Point(126, 186);
            txtTableName.Name = "txtTableName";
            txtTableName.Size = new Size(260, 27);
            txtTableName.TabIndex = 1;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(69, 240);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 33);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(166, 240);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 33);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnActivate
            // 
            btnActivate.Location = new Point(543, 240);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(75, 33);
            btnActivate.TabIndex = 5;
            btnActivate.Text = "Activate";
            btnActivate.UseVisualStyleBackColor = true;
            btnActivate.Click += btnActivate_Click;
            // 
            // btnDeactivate
            // 
            btnDeactivate.Location = new Point(654, 240);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(89, 33);
            btnDeactivate.TabIndex = 6;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = true;
            btnDeactivate.Click += btnDeactivate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 186);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 186);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 9;
            label2.Text = "TableName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(426, 188);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 10;
            label3.Text = "capacity";
            label3.Click += label3_Click;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(543, 186);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(215, 27);
            txtCapacity.TabIndex = 11;
            txtCapacity.TextChanged += txtCapacity_TextChanged;
            // 
            // TableManagement
            // 
            ClientSize = new Size(784, 336);
            Controls.Add(txtCapacity);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeactivate);
            Controls.Add(btnActivate);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(txtTableName);
            Controls.Add(dataGridViewTables);
            Name = "TableManagement";
            Text = "Table Management";
            Load += TableManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTables).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTables;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnDeactivate;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtCapacity;
    }


}