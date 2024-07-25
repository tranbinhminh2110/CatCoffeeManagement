using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Admin;
using Repositories.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatCoffee
{
    public partial class LoginForm : Form
    {
        private readonly ISignInRepository _signInRepository;
        private readonly CoffeeCatContext _dbContext;
 
        public LoginForm(ISignInRepository signInRepository, CoffeeCatContext dbContext)
        {
            _signInRepository = signInRepository;
            _dbContext = dbContext;

            InitializeComponent();

            txtPassword.PasswordChar = '•';


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private async Task SignInAsync(string email, string password)
        {
            var user = await _signInRepository.SignIn(email, password);

            if (user != null)
            {
                if (!(user.CustomerEnabled ?? false))
                {
                    MessageBox.Show("Your account is disabled. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

              
                    Session.Set("userId", user.CustomerId);
                    Session.Set("role", user.RoleId);
                    Session.Set("shopId", user.ShopId);
               

                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to another form or main application window
                string pageIndex = RoleDivision(user.RoleId ?? 0);
                Form nextForm = GetFormByRole(pageIndex);
                this.Hide();
                nextForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(new RegisterRepository(_dbContext),new CoffeeCatContext());
            registerForm.ShowDialog();
           
        }

        private string RoleDivision(int role)
        {
            switch (role)
            {
                case 1:
                    return "Admin";
                case 2:
                    return "Owner";
                case 3:
                    return "Staff";
                default:
                    return "Customer";
            }
        }

        private Form GetFormByRole(string role)
        {
            switch (role)
            {
                case "Admin":
                    return new AdminForm(new AdminRepository(_dbContext), new SessionRepository(_dbContext), new CoffeeCatContext());
                case "Owner":
                    return new ShopManagement(new CoffeeShopManagerRepository<Shop>(_dbContext), new SessionRepository(_dbContext), new CoffeeCatContext());// Replace with your actual repositories
                case "Staff":
                    return new StaffHomeForm(new CoffeeShopStaffRepository(_dbContext), new SessionRepository(_dbContext), new CoffeeCatContext());
                default:
                    return new ShopForm(new CustomerRepository<Shop>(_dbContext),new CoffeeCatContext(),new SessionRepository(_dbContext));
            }
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            await SignInAsync(email, password);
        }
    }
}
    
    