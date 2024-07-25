using Entities; // Import các thực thể cần thiết từ project Entities
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Repositories; // Import các repository cần thiết
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatCoffee
{
    public partial class CatManagement : Form
    {
        private readonly ICoffeeShopManagerRepository<Cat> _catRepository;
        private readonly CoffeeCatContext _catContext;
        private readonly int _areaId;

        public CatManagement(CoffeeShopManagerRepository<Cat> catRepository, CoffeeCatContext catContext, int areaId)
        {
            InitializeComponent();
            _catRepository = catRepository;
            _catContext = catContext;
            _areaId = areaId;

            Load += async (sender, e) => await LoadCatsAsync();
        }

        private async Task LoadCatsAsync()
        {
            try
            {
                var cats = await _catRepository.GetCatByAreaIdAsync(_areaId);

                if (cats != null)
                {
                    dataGridViewCats.DataSource = cats;
                    CustomizeDataGridView();
                }
                else
                {
                    MessageBox.Show($"No cats found for shop with ID {_areaId}.", "No Cats Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewCats.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            dataGridViewCats.Columns["CatId"].Visible = false;
            dataGridViewCats.Columns["Area"].Visible = false;
            dataGridViewCats.Columns["CatImage"].Visible = false;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            var cat = new Cat
            {
                CatName = txtCatName.Text,
                CatEnabled = true,
                AreaId = _areaId
            };

            try
            {
                await _catRepository.AddAsync(cat);
                MessageBox.Show("Cat successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadCatsAsync();
                ClearCatForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating cat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCats.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewCats.SelectedRows[0].Index;
                int catId = (int)dataGridViewCats.Rows[selectedRowIndex].Cells["CatId"].Value;

                var cat = await _catRepository.GetCatByIdAsync(catId);

                if (cat != null)
                {
                    cat.CatName = txtCatName.Text;

                    try
                    {
                        await _catRepository.UpdateAsync(cat);
                        MessageBox.Show("Cat successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadCatsAsync();
                        ClearCatForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating cat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a cat to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            /*if (dataGridViewCats.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewCats.SelectedRows[0].Index;
                int catId = (int)dataGridViewCats.Rows[selectedRowIndex].Cells["CatId"].Value;

                try
                {
                    await _catRepository.DeleteAsync(catId);
                    MessageBox.Show("Cat successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCatsAsync();
                    ClearCatForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting cat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a cat to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCats.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewCats.SelectedRows[0].Index;
                int catId = (int)dataGridViewCats.Rows[selectedRowIndex].Cells["CatId"].Value;

                var cat = await _catRepository.GetCatByIdAsync(catId);

                if (cat != null)
                {
                    cat.CatEnabled = true;

                    try
                    {
                        await _catRepository.UpdateAsync(cat);
                        MessageBox.Show("Cat successfully activated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadCatsAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error activating cat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a cat to activate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCats.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewCats.SelectedRows[0].Index;
                int catId = (int)dataGridViewCats.Rows[selectedRowIndex].Cells["CatId"].Value;

                var cat = await _catRepository.GetCatByIdAsync(catId);

                if (cat != null)
                {
                    cat.CatEnabled = false;

                    try
                    {
                        await _catRepository.UpdateAsync(cat);
                        MessageBox.Show("Cat successfully deactivated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadCatsAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deactivating cat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a cat to deactivate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewCats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewCats.Rows[e.RowIndex];
                txtCatName.Text = row.Cells["CatName"].Value.ToString();
            }
        }

        private void ClearCatForm()
        {
            txtCatName.Clear();
        }

        private void CatManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
