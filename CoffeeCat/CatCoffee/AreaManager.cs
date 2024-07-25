using Entities; // Import các thực thể cần thiết từ project Entities
using Repositories; // Import các repository cần thiết
using Repositories.Auth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatCoffee
{
    public partial class AreaManager : Form
    {
        private readonly ICoffeeShopManagerRepository<Area> _areaRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly CoffeeCatContext _catContext;
        private readonly int _shopId;
        private int userId;
        private int shopId;
        private int selectedAreaId;
        public AreaManager(ICoffeeShopManagerRepository<Area> areaRepository, ISessionRepository sessionRepository, CoffeeCatContext catContext, int shopId)
        {
            InitializeComponent();
            _areaRepository = areaRepository;
            _sessionRepository = sessionRepository;
            _shopId = shopId;

            Load += async (sender, e) => await LoadAreasAsync();


            _catContext = catContext;
        }

        private async Task LoadAreasAsync()
        {
            try
            {
   

                if (_shopId != null)
                {
                    var areas = await _areaRepository.GetAreaByShopIdAsync(_shopId);

                    if (areas != null && areas.Count > 0)
                    {
                        dataGridViewAreas.DataSource = areas;
                        
                        CustomizeDataGridView();
                    }
                    else
                    {
                        MessageBox.Show($"No areas found for shop with ID {_shopId}.", "No Areas Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewAreas.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("No shop is linked to the current user.", "No Shop Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewAreas.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading areas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreateArea_Click(object sender, EventArgs e)
        {
            var area = new Area
            {
                AreaName = txtAreaName.Text,
                // Assuming AreaEnabled default value is true upon creation
                AreaEnabled = true,
                ShopId = _shopId// Assigning current shopId to the new area
            };

            try
            {
                await _areaRepository.AddAsync(area);
                MessageBox.Show("Area successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadAreasAsync();
                ClearAreaForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating area: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdateArea_Click(object sender, EventArgs e)
        {
            if (dataGridViewAreas.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewAreas.SelectedRows[0].Index;
                int areaId = (int)dataGridViewAreas.Rows[selectedRowIndex].Cells["AreaId"].Value;

                var area = await _areaRepository.GetAreaByIdAsync(areaId);

                if (area != null)
                {
                   /* shopId = (int)Session.Get("ShopId");*/
                    if (area.ShopId != _shopId)
                    {
                        MessageBox.Show("You are not authorized to update this area.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    area.AreaName = txtAreaName.Text;

                    try
                    {
                        await _areaRepository.UpdateAsync(area);
                        MessageBox.Show("Area successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadAreasAsync();
                        ClearAreaForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating area: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an area to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void ClearAreaForm()
        {
            txtAreaName.Clear();
        }

        private void CustomizeDataGridView()
        {
            // Customize DataGridView appearance and behavior as needed
            dataGridViewAreas.Columns["AreaId"].Visible = false;
            dataGridViewAreas.Columns["Shop"].Visible = false;
            dataGridViewAreas.Columns["Cats"].Visible = false;
            dataGridViewAreas.Columns["Tables"].Visible = false;// Optionally hide AreaId column
            // Add additional customization here if required
        }

        private void AreaManager_Load(object sender, EventArgs e)
        {
            // Perform any initialization tasks if needed
        }

        private void dataGridViewAreas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAreas.Rows[e.RowIndex];
                txtAreaName.Text = row.Cells["AreaName"].Value.ToString();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session values
            Session.Remove("userId");
            Session.Remove("shopId");
            Session.Remove("roleId");

            // Close current form
            this.Close();

            // Redirect to login form
            LoginForm loginForm = new LoginForm(new SignInRepository(_catContext), new CoffeeCatContext());
            loginForm.Show();
        }
        private async void btnActivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewAreas.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewAreas.SelectedRows[0].Index;
                int areaId = (int)dataGridViewAreas.Rows[selectedRowIndex].Cells["AreaId"].Value;

                var area = await _areaRepository.GetAreaByIdAsync(areaId);

                if (area != null)
                {
                    area.AreaEnabled = true;

                    try
                    {
                        await _areaRepository.UpdateAsync(area);
                        MessageBox.Show("Area successfully activated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadAreasAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error activating area: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an area to activate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewAreas.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewAreas.SelectedRows[0].Index;
                int areaId = (int)dataGridViewAreas.Rows[selectedRowIndex].Cells["AreaId"].Value;

                var area = await _areaRepository.GetAreaByIdAsync(areaId);

                if (area != null)
                {
                    area.AreaEnabled = false;

                    try
                    {
                        await _areaRepository.UpdateAsync(area);
                        MessageBox.Show("Area successfully deactivated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadAreasAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deactivating area: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an area to deactivate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCatManagement_Click(object sender, EventArgs e)
        {
            if (dataGridViewAreas.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewAreas.SelectedRows[0].Index;
                selectedAreaId = (int)dataGridViewAreas.Rows[selectedRowIndex].Cells["AreaId"].Value;

                // Chuyển sang form quản lý khu vực (AreaManager) và truyền ShopId
                CatManagement areaManagerForm = new CatManagement(new CoffeeShopManagerRepository<Cat>(_catContext), new CoffeeCatContext(), selectedAreaId);
                areaManagerForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a shop first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTableManagement_Click(object sender, EventArgs e)
        {
            if (dataGridViewAreas.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewAreas.SelectedRows[0].Index;
                selectedAreaId = (int)dataGridViewAreas.Rows[selectedRowIndex].Cells["AreaId"].Value;

                // Chuyển sang form quản lý khu vực (AreaManager) và truyền ShopId
                TableManagement taManagerForm = new TableManagement(new CoffeeShopManagerRepository<Table>(_catContext), selectedAreaId);
                taManagerForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a shop first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtAreaName_TextChanged(object sender, EventArgs e)
        {

        }

    }
}