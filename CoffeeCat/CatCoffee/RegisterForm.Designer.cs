namespace CatCoffee
{
    partial class RegisterForm
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
            email = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            label4 = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            txtUserName = new TextBox();
            txtPhone = new MaskedTextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(129, 75);
            email.Name = "email";
            email.Size = new Size(46, 20);
            email.TabIndex = 0;
            email.Text = "email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 206);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 1;
            label2.Text = "password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 241);
            label3.Name = "label3";
            label3.Size = new Size(121, 20);
            label3.TabIndex = 2;
            label3.Text = "confirmPassword";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 118);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 3;
            label1.Text = "phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(129, 158);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 4;
            label4.Text = "UserName";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(266, 68);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(299, 27);
            txtEmail.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(268, 203);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(299, 27);
            txtPassword.TabIndex = 6;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(268, 241);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(299, 27);
            txtConfirmPassword.TabIndex = 7;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(268, 151);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(299, 27);
            txtUserName.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(266, 112);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(301, 27);
            txtPhone.TabIndex = 9;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(381, 323);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(txtPhone);
            Controls.Add(txtUserName);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(email);
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label email;
        private Label label2;
        private Label label3;
        private Label label1;
        private Label label4;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtUserName;
        private MaskedTextBox txtPhone;
        private Button btnRegister;
    }
}