using Entities;
using Repositories;
using Repositories.Auth;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CatCoffee
{
    public partial class ShopManagement : Form
    {
        private readonly ICoffeeShopManagerRepository<Shop> _shopRepository;
        private readonly CoffeeCatContext _catContext;
        private readonly ISessionRepository _sessionRepository;
        private int userId;
        private int? shopId;
        private int SelectedShopId;
        public ShopManagement(ICoffeeShopManagerRepository<Shop> shopRepository, ISessionRepository sessionRepository, CoffeeCatContext catContext)
        {
            InitializeComponent();
            _shopRepository = shopRepository;
            _sessionRepository = sessionRepository;
            Load += async (sender, e) => await LoadShopsAsync();

            userId = (int)Session.Get("userId");
            shopId = (int?)Session.Get("shopId");
            _catContext = catContext;
        }

        private async Task LoadShopsAsync()
        {
            try
            {
                // Lấy giá trị userId và shopId từ session
                userId = (int)Session.Get("userId");
                shopId = (int?)Session.Get("shopId");

                // Kiểm tra xem shopId đã có giá trị chưa
                if (shopId.HasValue)
                {
                    Shop shop = await _shopRepository.GetShopByIdAsync(shopId.Value);

                    if (shop != null)
                    {
                        var shops = new List<Shop> { shop };
                        dataGridViewShops.DataSource = shops.Select(s => new
                        {
                            s.ShopId,
                            s.ShopName,
                            s.ShopAddress,
                            s.ShopEmail,
                            s.ShopTelephone,
                            s.ShopEnabled
                        }).ToList();
                    }
                    else
                    {
                        // Hiển thị thông báo khi không tìm thấy cửa hàng
                        MessageBox.Show($"Shop not found for user with ID {userId}.", "No Shop Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xóa dữ liệu hiển thị trong dataGridViewShops
                        dataGridViewShops.DataSource = null;
                    }
                }
                else
                {
                    // Nếu shopId không có giá trị, thông báo và xóa dữ liệu
                    MessageBox.Show("No shop is linked to the current user.", "No Shop Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewShops.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


            LoginForm loginForm = new LoginForm(new SignInRepository(_catContext), new CoffeeCatContext());
            loginForm.Show();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            userId = (int)Session.Get("userId");
            User user = _sessionRepository.GetUserById(userId);
           

            if (user.Shop != null)
            {
                MessageBox.Show("You already have a linked shop. You cannot create a new one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string shopName = txtShopName.Text.Trim();
            string shopAddress = txtAddress.Text.Trim();
            string shopEmail = txtEmail.Text.Trim();
            string shopPhone = txtPhone.Text.Trim();

            // Kiểm tra tính hợp lệ của dữ liệu nhập vào
            if (string.IsNullOrEmpty(shopName) || string.IsNullOrEmpty(shopAddress) || string.IsNullOrEmpty(shopEmail) || string.IsNullOrEmpty(shopPhone))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tính hợp lệ của email
            if (!Regex.IsMatch(shopEmail, @"^[^@\s]+@gmail\.com$"))
            {
                MessageBox.Show("Email must be a valid Gmail address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tính hợp lệ của số điện thoại
            if (!Regex.IsMatch(shopPhone, @"^0\d{9}$"))
            {
                MessageBox.Show("Phone number must be 10 digits and start with 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var shop = new Shop
            {
                ShopName = shopName,
                ShopAddress = shopAddress,
                ShopEnabled = true,
                ShopTelephone = shopPhone,
                ShopEmail = shopEmail,
                Users = new List<User> { user } // Assuming Users is a collection in Shop
            };

            try
            {
                await _shopRepository.AddAsync(shop);
                MessageBox.Show("Shop successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại shopId trong session
                shopId = shop.ShopId;
                Session.Set("shopId", shopId);

                await LoadShopsAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating shop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewShops_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewShops.Rows[e.RowIndex];

                // Lấy giá trị từ DataGridViewRow và hiển thị lên các TextBox
                txtShopName.Text = row.Cells["ShopName"].Value.ToString();
                txtAddress.Text = row.Cells["ShopAddress"].Value.ToString();
                txtPhone.Text = row.Cells["ShopTelephone"].Value.ToString();
                txtEmail.Text = row.Cells["ShopEmail"].Value.ToString();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            shopId = (int?)Session.Get("shopId");
            userId = (int)Session.Get("userId");
            User user = _sessionRepository.GetUserById(userId);
            if (dataGridViewShops.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewShops.SelectedRows[0].Index;
                SelectedShopId = (int)dataGridViewShops.Rows[selectedRowIndex].Cells["ShopId"].Value;

                var shop = await _shopRepository.GetShopByIdAsync(shopId);

                if (shop != null)
                {
                    
                  

                    string shopName = txtShopName.Text.Trim();
                    string shopAddress = txtAddress.Text.Trim();
                    string shopEmail = txtEmail.Text.Trim();
                    string shopPhone = txtPhone.Text.Trim();

                    // Kiểm tra tính hợp lệ của dữ liệu nhập vào
                    if (string.IsNullOrEmpty(shopName) || string.IsNullOrEmpty(shopAddress) || string.IsNullOrEmpty(shopEmail) || string.IsNullOrEmpty(shopPhone))
                    {
                        MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra tính hợp lệ của email
                    if (!Regex.IsMatch(shopEmail, @"^[^@\s]+@gmail\.com$"))
                    {
                        MessageBox.Show("Email must be a valid Gmail address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra tính hợp lệ của số điện thoại
                    if (!Regex.IsMatch(shopPhone, @"^0\d{9}$"))
                    {
                        MessageBox.Show("Phone number must be 10 digits and start with 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    shop.ShopName = shopName;
                    shop.ShopAddress = shopAddress;
                    shop.ShopTelephone = shopPhone;
                    shop.ShopEmail = shopEmail;

                    try
                    {
                        await _shopRepository.UpdateAsync(shop);
                        MessageBox.Show("Shop successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadShopsAsync();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating shop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a shop to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void btnActivate_Click(object sender, EventArgs e)
        {
           
            if (dataGridViewShops.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewShops.SelectedRows[0].Index;
                SelectedShopId = (int)dataGridViewShops.Rows[selectedRowIndex].Cells["ShopId"].Value;
                shopId = (int?)Session.Get("shopId");
                var shop = await _shopRepository.GetShopByIdAsync(shopId);
                userId = (int)Session.Get("userId");
                if (shop != null)
                {

                    shop.ShopEnabled = true;

                    try
                    {
                        await _shopRepository.UpdateAsync(shop);
                        MessageBox.Show("Shop successfully activated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadShopsAsync();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error activating shop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a shop to activate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeactivate_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewShops.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewShops.SelectedRows[0].Index;
                SelectedShopId = (int)dataGridViewShops.Rows[selectedRowIndex].Cells["ShopId"].Value;
               /* shopId = (int?)Session.Get("shopId");*/
                var shop = await _shopRepository.GetShopByIdAsync(shopId);

                if (shop != null)
                {
                    

                    shop.ShopEnabled = false;

                    try
                    {
                        await _shopRepository.UpdateAsync(shop);
                        MessageBox.Show("Shop successfully deactivated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadShopsAsync();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deactivating shop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a shop to deactivate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ClearForm()
        {
            txtShopName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        private void ShopManagement_Load(object sender, EventArgs e)
        {
            // Load initial data or perform initialization tasks if needed
        }
        private void BtnManageAreas_Click(object sender, EventArgs e)
        {
            if (dataGridViewShops.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewShops.SelectedRows[0].Index;
                SelectedShopId = (int)dataGridViewShops.Rows[selectedRowIndex].Cells["ShopId"].Value;

                // Chuyển sang form quản lý khu vực (AreaManager) và truyền ShopId
                AreaManager areaManagerForm = new AreaManager(new CoffeeShopManagerRepository<Area>(_catContext), new SessionRepository(_catContext), new CoffeeCatContext(), SelectedShopId);
                areaManagerForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a shop first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnManageMenus_Click(object sender, EventArgs e)
        {
            if (dataGridViewShops.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewShops.SelectedRows[0].Index;
                SelectedShopId = (int)dataGridViewShops.Rows[selectedRowIndex].Cells["ShopId"].Value;

                // Chuyển sang form quản lý khu vực (AreaManager) và truyền ShopId
                MenuItemManagementForm menurForm = new MenuItemManagementForm(new CoffeeShopManagerRepository<MenuItem>(_catContext), SelectedShopId);
                menurForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a shop first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dataGridViewShops_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click events if needed
        }

    }
}
