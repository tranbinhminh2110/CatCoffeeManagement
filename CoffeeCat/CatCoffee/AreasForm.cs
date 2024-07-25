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
    public partial class AreasForm : Form
    {
        private readonly ICustomerRepository<Area> _areaRepository;
        private readonly int _shopId;
        private readonly CoffeeCatContext _dbContext;
        private int Selected_areaId;
        public AreasForm(ICustomerRepository<Area> areaRepository, int shopId, CoffeeCatContext dbContext)
        {
            _areaRepository = areaRepository;
            _shopId = shopId;
            InitializeComponent();
            _dbContext = dbContext;
        }

        private async void AreasForm_Load(object sender, EventArgs e)
        {
            await LoadAreasAsync();
        }

        private async Task LoadAreasAsync()
        {
            try
            {
                IQueryable<Area> areasQuery = await _areaRepository.GetAreaEnableAsync();
                List<Area> areas = await areasQuery.Where(a => a.ShopId == _shopId).ToListAsync();

                // Hiển thị danh sách khu vực lên DataGridView
                dataGridViewAreas.DataSource = areas;
                dataGridViewAreas.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Areas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void dataGridViewAreas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAreas.Rows[e.RowIndex];
                Selected_areaId = (int)row.Cells["AreaId"].Value; // Điều chỉnh tên cột AreaId nếu cần

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {


            // Xóa các giá trị session liên quan
            Session.Remove("userId");
            Session.Remove("role");
            Session.Remove("shopId");

            // Đóng form hiện tại
            this.Close();


            LoginForm loginForm = new LoginForm(new SignInRepository(_dbContext), new CoffeeCatContext());
            loginForm.Show();
        }
        private async void btnShowTables_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi form danh sách khu vực
                var tablesForm = new TablesForm(new CustomerRepository<Table>(_dbContext), Selected_areaId); // Truyền shopId vào constructor của AreasForm
                tablesForm.ShowDialog(); // Hiển thị form danh sách khu vực
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing Areas form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnShowCats_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi form danh sách khu vực
                var catsForm = new CatsForm(new CustomerRepository<Cat>(_dbContext), Selected_areaId); // Truyền shopId vào constructor của AreasForm
                catsForm.ShowDialog(); // Hiển thị form danh sách khu vực
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing Areas form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi form đặt bàn
                var bookingForm = new BookingForm(Selected_areaId, _shopId,new CoffeeShopManagerRepository<Booking>(_dbContext),new CoffeeShopManagerRepository<Table>(_dbContext), new CoffeeShopManagerRepository<MenuItem>(_dbContext),new CustomerRepository<MenuItem>(_dbContext),new CoffeeCatContext()); // Truyền Selected_areaId và _shopId vào constructor của BookingForm
                bookingForm.ShowDialog(); // Hiển thị form đặt bàn
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing Booking form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewAreas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
