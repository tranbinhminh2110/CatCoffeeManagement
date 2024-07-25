using System;
using System.Windows.Forms;
using Entities;
using Repositories.Auth;
using Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CatCoffee
{
    public partial class RegisterForm : Form
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly CoffeeCatContext _catContext;
        public RegisterForm(IRegisterRepository registerRepository, CoffeeCatContext catContext)
        {
            InitializeComponent();
            _registerRepository = registerRepository;
            _catContext = catContext;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            int roleId = 4; // Assuming the role ID is 4 for this example

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                MessageBox.Show("Phone number must be 10 digits and start with 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@gmail\.com$"))
            {
                MessageBox.Show("Email must be a valid Gmail address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                MessageBox.Show("Password must be at least 8 characters long, and include at least one uppercase letter, one number, and one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool emailExists = await _registerRepository.EmailExistsAsync(email);

            if (emailExists)
            {
                MessageBox.Show("Email already exists .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = new User
            {
                CustomerEmail = email,
                CustomerTelephone = phone,
                CustomerName = userName,
                CustomerEnabled = true,
                CustomerPassword = password,
                RoleId = roleId
                // Add other properties if needed
            };

            try
            {
                await _registerRepository.RegisterAsync(user);
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển hướng qua trang login
                LoginForm loginForm = new LoginForm(new SignInRepository(_catContext), new CoffeeCatContext());
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
