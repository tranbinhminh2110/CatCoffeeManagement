namespace CatCoffee
{
    partial class AdminForm
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
            lblWelcome = new Label();
            dataGridViewUsers = new DataGridView();
            btnBan = new Button();
            btnUnban = new Button();
            btnLogout = new Button();
            name = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            txtShopOwnerPassword = new TextBox();
            txtShopOwnerName = new TextBox();
            txtShopOwnerEmail = new TextBox();
            txtPhone = new MaskedTextBox();
            btnCreateShopOwner = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(13, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(71, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(12, 65);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.Size = new Size(638, 256);
            dataGridViewUsers.TabIndex = 1;
            // 
            // btnBan
            // 
            btnBan.Location = new Point(668, 65);
            btnBan.Name = "btnBan";
            btnBan.Size = new Size(120, 29);
            btnBan.TabIndex = 2;
            btnBan.Text = "Ban";
            btnBan.UseVisualStyleBackColor = true;
            btnBan.Click += btnBan_Click;
            // 
            // btnUnban
            // 
            btnUnban.Location = new Point(668, 114);
            btnUnban.Name = "btnUnban";
            btnUnban.Size = new Size(120, 29);
            btnUnban.TabIndex = 3;
            btnUnban.Text = "Unban";
            btnUnban.UseVisualStyleBackColor = true;
            btnUnban.Click += btnUnban_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(702, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(12, 334);
            name.Name = "name";
            name.Size = new Size(46, 20);
            name.TabIndex = 5;
            name.Text = "name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 385);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 6;
            label2.Text = "email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(321, 334);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 7;
            label3.Text = "password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(321, 392);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 8;
            label1.Text = "telephone";
            // 
            // txtShopOwnerPassword
            // 
            txtShopOwnerPassword.Location = new Point(434, 334);
            txtShopOwnerPassword.Name = "txtShopOwnerPassword";
            txtShopOwnerPassword.Size = new Size(216, 27);
            txtShopOwnerPassword.TabIndex = 9;
            // 
            // txtShopOwnerName
            // 
            txtShopOwnerName.Location = new Point(64, 334);
            txtShopOwnerName.Name = "txtShopOwnerName";
            txtShopOwnerName.Size = new Size(196, 27);
            txtShopOwnerName.TabIndex = 10;
            // 
            // txtShopOwnerEmail
            // 
            txtShopOwnerEmail.Location = new Point(64, 385);
            txtShopOwnerEmail.Name = "txtShopOwnerEmail";
            txtShopOwnerEmail.Size = new Size(196, 27);
            txtShopOwnerEmail.TabIndex = 11;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(434, 385);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(216, 27);
            txtPhone.TabIndex = 13;
            // 
            // btnCreateShopOwner
            // 
            btnCreateShopOwner.Location = new Point(668, 171);
            btnCreateShopOwner.Name = "btnCreateShopOwner";
            btnCreateShopOwner.Size = new Size(120, 29);
            btnCreateShopOwner.TabIndex = 14;
            btnCreateShopOwner.Text = "CreateOwner";
            btnCreateShopOwner.UseVisualStyleBackColor = true;
            btnCreateShopOwner.Click += btnCreateShopOwner_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCreateShopOwner);
            Controls.Add(txtPhone);
            Controls.Add(txtShopOwnerEmail);
            Controls.Add(txtShopOwnerName);
            Controls.Add(txtShopOwnerPassword);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(name);
            Controls.Add(btnLogout);
            Controls.Add(btnUnban);
            Controls.Add(btnBan);
            Controls.Add(dataGridViewUsers);
            Controls.Add(lblWelcome);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private DataGridView dataGridViewUsers;
        private Button btnBan;
        private Button btnUnban;
        private Button btnLogout;
        private Label name;
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox txtShopOwnerPassword;
        private TextBox txtShopOwnerName;
        private TextBox txtShopOwnerEmail;
        private MaskedTextBox txtPhone;
        private Button btnCreateShopOwner;
    }
}