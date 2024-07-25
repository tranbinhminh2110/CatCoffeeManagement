namespace CatCoffee
{
    partial class CatManagement
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
        private void InitializeComponent()
        {
            dataGridViewCats = new DataGridView();
            txtCatName = new TextBox();
            lblCatName = new Label();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnActivate = new Button();
            btnDeactivate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCats).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCats
            // 
            dataGridViewCats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCats.Location = new Point(12, 12);
            dataGridViewCats.Name = "dataGridViewCats";
            dataGridViewCats.RowHeadersWidth = 51;
            dataGridViewCats.Size = new Size(600, 200);
            dataGridViewCats.TabIndex = 0;
            dataGridViewCats.CellClick += dataGridViewCats_CellClick;
            // 
            // txtCatName
            // 
            txtCatName.Location = new Point(118, 226);
            txtCatName.Name = "txtCatName";
            txtCatName.Size = new Size(200, 27);
            txtCatName.TabIndex = 1;
            // 
            // lblCatName
            // 
            lblCatName.AutoSize = true;
            lblCatName.Location = new Point(30, 233);
            lblCatName.Name = "lblCatName";
            lblCatName.Size = new Size(78, 20);
            lblCatName.TabIndex = 2;
            lblCatName.Text = "Cat Name:";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(30, 305);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 35);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(130, 305);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 35);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnActivate
            // 
            btnActivate.Location = new Point(231, 305);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(75, 35);
            btnActivate.TabIndex = 6;
            btnActivate.Text = "Activate";
            btnActivate.UseVisualStyleBackColor = true;
            btnActivate.Click += btnActivate_Click;
            // 
            // btnDeactivate
            // 
            btnDeactivate.Location = new Point(338, 305);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(90, 35);
            btnDeactivate.TabIndex = 7;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = true;
            btnDeactivate.Click += btnDeactivate_Click;
            // 
            // CatManagement
            // 
            ClientSize = new Size(624, 381);
            Controls.Add(btnDeactivate);
            Controls.Add(btnActivate);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(lblCatName);
            Controls.Add(txtCatName);
            Controls.Add(dataGridViewCats);
            Name = "CatManagement";
            Text = "CatManagement";
            Load += CatManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewCats;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.Label lblCatName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnDeactivate;
    }
}