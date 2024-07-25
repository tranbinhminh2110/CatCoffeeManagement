namespace CatCoffee
{
    partial class LoginForm
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
            label2 = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnSignIn = new Button();
            btnRegister = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 119);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 165);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 1;
            label2.Text = "password";
            label2.Click += LoginForm_Load;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(255, 119);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(301, 27);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(255, 165);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(301, 27);
            txtPassword.TabIndex = 3;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(362, 231);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(94, 29);
            btnSignIn.TabIndex = 4;
            btnSignIn.Text = "Login";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(436, 294);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnGoToRegister_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(116, 298);
            label3.Name = "label3";
            label3.Size = new Size(314, 20);
            label3.TabIndex = 6;
            label3.Text = "If you don't have an account, please click here.";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnRegister);
            Controls.Add(btnSignIn);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnSignIn;
        private Button btnRegister;
        private Label label3;
    }
}