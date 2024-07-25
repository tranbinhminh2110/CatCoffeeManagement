using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
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
    public partial class ShopForm : Form
    {
        private readonly ICustomerRepository<Shop> _repository;
        private readonly CoffeeCatContext _dbContext;
        private readonly SessionRepository _sessionRepository;
        public User? LoggedInUser { get; set; }
        private int _selectedShopId;

        private int _bookingId;
        public ShopForm(ICustomerRepository<Shop> repository, CoffeeCatContext dbContext, SessionRepository sessionRepository)
        {
            _repository = repository;

            InitializeComponent();
            _dbContext = dbContext;
            _sessionRepository = sessionRepository;
        }
        private int userId;
        private int? shopId;
        private int role;

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text.Trim();

            IQueryable<Shop> shopsQuery = await _repository.GetShopEnableAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                shopsQuery = shopsQuery.Where(s => s.ShopName.Contains(searchString));
            }



            dataGridViewShops.DataSource = await shopsQuery.ToListAsync();
        }

        private void dataGridViewShops_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Authenticate()
        {
            userId = (int)Session.Get("userId");
            if (userId == null)
            {
                MessageBox.Show("Please log in first.", "Authentication Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); // Close the form or redirect to login form
            }
        }

        private void Authorization()
        {
            role = (int)Session.Get("role");
            if (role != 4)
            {
                MessageBox.Show("You are not authorized to access this page.", "Authorization Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); // Close the form or redirect to error form
            }
        }

        private void SetUserSession()
        {
            userId = (int)Session.Get("userId");
            if (userId != null)
            {
                LoggedInUser = _sessionRepository.GetUserById(userId);
            }
        }

        private async void ShopForm_Load(object sender, EventArgs e)
        {
            Authenticate();
            Authorization();
            SetUserSession();
            userId = (int)Session.Get("userId");
            shopId = (int?)Session.Get("shopId");
            role = (int)Session.Get("role");
            IQueryable<Shop> shopsQuery = await _repository.GetShopEnableAsync();
            dataGridViewShops.DataSource = await shopsQuery.ToListAsync();
            {
                lblWelcome.Text = "Hello " + LoggedInUser.CustomerName;
            }

        }
        private async void dataGridViewShops_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewShops.Rows[e.RowIndex];
                _selectedShopId = (int)row.Cells["ShopId"].Value; // Điều chỉnh tên cột ShopId nếu cần
            }
        }

        private async void btnShowMenus_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi form danh sách khu vực
                var menusForm = new MenusForm(new CustomerRepository<MenuItem>(_dbContext), _selectedShopId); // Truyền shopId vào constructor của AreasForm
                menusForm.ShowDialog(); // Hiển thị form danh sách khu vực
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing Areas form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnShowbookingHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi form danh sách khu vực
                var bookingHistoryForm = new BookingHistoryForm(new CoffeeShopManagerRepository<Booking>(_dbContext), new SessionRepository(_dbContext), new CoffeeShopStaffRepository(_dbContext));
                bookingHistoryForm.ShowDialog(); // Hiển thị form danh sách khu vực
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing Areas form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnShowAreas_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi form danh sách khu vực
                var areasForm = new AreasForm(new CustomerRepository<Area>(_dbContext), _selectedShopId, new CoffeeCatContext()); // Truyền shopId vào constructor của AreasForm
                areasForm.ShowDialog(); // Hiển thị form danh sách khu vực
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing Areas form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {


            // Xóa các giá trị session liên quan
            Session.Clear();

            // Đóng form hiện tại
            this.Close();


            LoginForm loginForm = new LoginForm(new SignInRepository(_dbContext), new CoffeeCatContext());
            loginForm.Show();
        }
    }
}
