namespace CatCoffee
{
    partial class ShopManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewShops;
        private Label lblShopName;
        private TextBox txtShopName;
        private Label lblAddress;
        private TextBox txtAddress;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnActivate;
        private Button btnDeactivate;
        private Label label1;
        private Label label2;
        private TextBox txtEmail;
        private MaskedTextBox txtPhone;
        private Button button2;
        private Button button3;
        private Button button4;

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

        private void InitializeComponent()
        {
            dataGridViewShops = new DataGridView();
            lblShopName = new Label();
            txtShopName = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnActivate = new Button();
            btnDeactivate = new Button();
            label1 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            txtPhone = new MaskedTextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShops).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewShops
            // 
            dataGridViewShops.AllowUserToAddRows = false;
            dataGridViewShops.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShops.Location = new Point(20, 49);
            dataGridViewShops.Margin = new Padding(4, 5, 4, 5);
            dataGridViewShops.MultiSelect = false;
            dataGridViewShops.Name = "dataGridViewShops";
            dataGridViewShops.RowHeadersWidth = 51;
            dataGridViewShops.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShops.Size = new Size(639, 249);
            dataGridViewShops.TabIndex = 0;
            dataGridViewShops.CellClick += dataGridViewShops_CellClick;
            dataGridViewShops.CellContentClick += dataGridViewShops_CellContentClick;
            // 
            // lblShopName
            // 
            lblShopName.AutoSize = true;
            lblShopName.Location = new Point(16, 321);
            lblShopName.Margin = new Padding(4, 0, 4, 0);
            lblShopName.Name = "lblShopName";
            lblShopName.Size = new Size(90, 20);
            lblShopName.TabIndex = 1;
            lblShopName.Text = "Shop Name:";
            // 
            // txtShopName
            // 
            txtShopName.Location = new Point(113, 316);
            txtShopName.Margin = new Padding(4, 5, 4, 5);
            txtShopName.Name = "txtShopName";
            txtShopName.Size = new Size(265, 27);
            txtShopName.TabIndex = 2;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(386, 321);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(65, 20);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(459, 316);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 27);
            txtAddress.TabIndex = 4;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(139, 407);
            btnCreate.Margin = new Padding(4, 5, 4, 5);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 35);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(278, 407);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnActivate
            // 
            btnActivate.Location = new Point(413, 407);
            btnActivate.Margin = new Padding(4, 5, 4, 5);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(100, 35);
            btnActivate.TabIndex = 8;
            btnActivate.Text = "Activate";
            btnActivate.UseVisualStyleBackColor = true;
            btnActivate.Click += btnActivate_Click;
            // 
            // btnDeactivate
            // 
            btnDeactivate.Location = new Point(559, 407);
            btnDeactivate.Margin = new Padding(4, 5, 4, 5);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(100, 35);
            btnDeactivate.TabIndex = 9;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = true;
            btnDeactivate.Click += btnDeactivate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(386, 377);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 10;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 377);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 11;
            label2.Text = "Phone:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(459, 372);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 12;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(113, 370);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(265, 27);
            txtPhone.TabIndex = 13;
            // 
            // button2
            // 
            button2.Location = new Point(687, 107);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 15;
            button2.Text = "Area";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnManageAreas_Click;
            // 
            // button3
            // 
            button3.Location = new Point(687, 185);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 16;
            button3.Text = "Item";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnManageMenus_Click;
            // 
            // button4
            // 
            button4.Location = new Point(687, 12);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 17;
            button4.Text = "Logout";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnLogout_Click;
            // 
            // ShopManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeactivate);
            Controls.Add(btnActivate);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtShopName);
            Controls.Add(lblShopName);
            Controls.Add(dataGridViewShops);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ShopManagement";
            Text = "ShopManagement";
            Load += ShopManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewShops).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
