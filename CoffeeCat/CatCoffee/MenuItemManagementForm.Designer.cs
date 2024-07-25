namespace CatCoffee
{
    partial class MenuItemManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
  
        private System.Windows.Forms.DataGridView dataGridViewMenuItems;
        private System.Windows.Forms.TextBox txtMenuItemName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnDeactivate;
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
            dataGridViewMenuItems = new DataGridView();
            txtMenuItemName = new TextBox();
            txtPrice = new TextBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnActivate = new Button();
            btnDeactivate = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMenuItems).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMenuItems
            // 
            dataGridViewMenuItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMenuItems.Location = new Point(12, 12);
            dataGridViewMenuItems.Name = "dataGridViewMenuItems";
            dataGridViewMenuItems.RowHeadersWidth = 51;
            dataGridViewMenuItems.Size = new Size(733, 191);
            dataGridViewMenuItems.TabIndex = 0;
            dataGridViewMenuItems.CellClick += dataGridViewMenuItems_CellClick;
            // 
            // txtMenuItemName
            // 
            txtMenuItemName.Location = new Point(96, 209);
            txtMenuItemName.Name = "txtMenuItemName";
            txtMenuItemName.Size = new Size(203, 27);
            txtMenuItemName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(96, 242);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(203, 27);
            txtPrice.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(305, 209);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(85, 27);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(305, 242);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(85, 27);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnActivate
            // 
            btnActivate.Location = new Point(407, 242);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(95, 27);
            btnActivate.TabIndex = 6;
            btnActivate.Text = "Activate";
            btnActivate.UseVisualStyleBackColor = true;
            btnActivate.Click += btnActivate_Click;
            // 
            // btnDeactivate
            // 
            btnDeactivate.Location = new Point(407, 209);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(95, 27);
            btnDeactivate.TabIndex = 7;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = true;
            btnDeactivate.Click += btnDeactivate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 216);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 8;
            label1.Text = "ItemName";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 249);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 9;
            label2.Text = "Price";
            label2.Click += label2_Click;
            // 
            // MenuItemManagementForm
            // 
            ClientSize = new Size(755, 291);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeactivate);
            Controls.Add(btnActivate);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(txtPrice);
            Controls.Add(txtMenuItemName);
            Controls.Add(dataGridViewMenuItems);
            Name = "MenuItemManagementForm";
            Text = "Menu Item Management";
            Load += MenuItemManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMenuItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label label1;
        private Label label2;
    }
}