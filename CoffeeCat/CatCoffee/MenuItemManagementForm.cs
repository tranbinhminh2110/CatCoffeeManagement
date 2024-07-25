using Entities; // Import các thực thể cần thiết từ project Entities
using Repositories; // Import các repository cần thiết
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatCoffee
{
    public partial class MenuItemManagementForm : Form
    {
        private readonly ICoffeeShopManagerRepository<MenuItem> _menuItemRepository;
        private readonly int _shopId;

        public MenuItemManagementForm(ICoffeeShopManagerRepository<MenuItem> menuItemRepository, int shopId)
        {
            InitializeComponent();
            _menuItemRepository = menuItemRepository;
            _shopId = shopId;

            Load += async (sender, e) => await LoadMenuItemsAsync();
        }

        private async Task LoadMenuItemsAsync()
        {
            try
            {
                var menuItems = await _menuItemRepository.GetAllMenuItemByShopIdAsync(_shopId);
                if (menuItems != null && menuItems.Count > 0)
                {
                    dataGridViewMenuItems.DataSource = menuItems;
                    CustomizeDataGridView();
                }
                else
                {
                    MessageBox.Show("No menu items found for this shop.", "No Menu Items Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewMenuItems.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading menu items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                var menuItem = new MenuItem
                {
                    ItemName = txtMenuItemName.Text,
                    ItemPrice = price,
                    ItemEnabled = true,
                    ShopId = _shopId
                };

                try
                {
                    await _menuItemRepository.AddAsync(menuItem);
                    MessageBox.Show("Menu item successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadMenuItemsAsync();
                    ClearMenuItemForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating menu item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewMenuItems.SelectedRows.Count > 0)
            {
                if (decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    int selectedRowIndex = dataGridViewMenuItems.SelectedRows[0].Index;
                    int menuItemId = (int)dataGridViewMenuItems.Rows[selectedRowIndex].Cells["ItemId"].Value;

                    var menuItem = await _menuItemRepository.GetMenuItemsByIdAsync(menuItemId);
                    if (menuItem != null)
                    {
                        menuItem.ItemName = txtMenuItemName.Text;
                        menuItem.ItemPrice = price;
                        try
                        {
                            await _menuItemRepository.UpdateAsync(menuItem);
                            MessageBox.Show("Menu item successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadMenuItemsAsync();
                            ClearMenuItemForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating menu item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a menu item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewMenuItems.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewMenuItems.SelectedRows[0].Index;
                int menuItemId = (int)dataGridViewMenuItems.Rows[selectedRowIndex].Cells["ItemId"].Value;

                var menuItem = await _menuItemRepository.GetMenuItemsByIdAsync(menuItemId);
                if (menuItem != null)
                {
                    menuItem.ItemEnabled = true;
                    try
                    {
                        await _menuItemRepository.UpdateAsync(menuItem);
                        MessageBox.Show("Menu item successfully activated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadMenuItemsAsync();
                        ClearMenuItemForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error activating menu item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a menu item to activate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewMenuItems.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewMenuItems.SelectedRows[0].Index;
                int menuItemId = (int)dataGridViewMenuItems.Rows[selectedRowIndex].Cells["ItemName"].Value;

                var menuItem = await _menuItemRepository.GetMenuItemsByIdAsync(menuItemId);
                if (menuItem != null)
                {
                    menuItem.ItemEnabled = false;
                    try
                    {
                        await _menuItemRepository.UpdateAsync(menuItem);
                        MessageBox.Show("Menu item successfully deactivated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadMenuItemsAsync();
                        ClearMenuItemForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deactivating menu item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a menu item to deactivate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewMenuItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMenuItems.Rows[e.RowIndex];
                txtMenuItemName.Text = row.Cells["ItemName"].Value.ToString();
                txtPrice.Text = row.Cells["ItemPrice"].Value.ToString();
            }
        }

        private void ClearMenuItemForm()
        {
            txtMenuItemName.Clear();
            txtPrice.Clear();
        }

        private void CustomizeDataGridView()
        {
            dataGridViewMenuItems.Columns["ItemId"].Visible = false;
            dataGridViewMenuItems.Columns["ShopId"].Visible = false;
            dataGridViewMenuItems.Columns["Shop"].Visible = false;
            dataGridViewMenuItems.Columns["Bookings"].Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItemManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
