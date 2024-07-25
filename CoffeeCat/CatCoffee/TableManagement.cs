using Entities;
using Repositories;
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
    public partial class TableManagement : Form
    {
        private readonly ICoffeeShopManagerRepository<Table> _tableRepository;
        private readonly int _areaId;

        public TableManagement(ICoffeeShopManagerRepository<Table> tableRepository, int areaId)
        {
            InitializeComponent();
            _tableRepository = tableRepository;
            _areaId = areaId;

            Load += async (sender, e) => await LoadTablesAsync();
        }

        private async Task LoadTablesAsync()
        {
            try
            {
                var tables = await _tableRepository.GetTableByAreaIdAsync(_areaId);
                if (tables != null)
                {
                    dataGridViewTables.DataSource = tables;
                    CustomizeDataGridView();
                }
                else
                {
                    MessageBox.Show("No tables found for this area.", "No Tables Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewTables.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCapacity.Text, out int tableCapacity))
            {
                MessageBox.Show("Please enter a valid number for table capacity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var table = new Table
            {

                TableName = txtTableName.Text,
                TableEnabled = true,
                TableCapacity = tableCapacity,
                AreaId = _areaId
            };

            try
            {
                await _tableRepository.AddAsync(table);
                MessageBox.Show("Table successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadTablesAsync();
                ClearTableForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCapacity.Text, out int tableCapacity))
            {
                MessageBox.Show("Please enter a valid number for table capacity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGridViewTables.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewTables.SelectedRows[0].Index;
                int tableId = (int)dataGridViewTables.Rows[selectedRowIndex].Cells["TableId"].Value;

                var table = await _tableRepository.GetTableByIdAsync(tableId);
                if (table != null)
                {
                    table.TableName = txtTableName.Text;
                    table.TableCapacity = tableCapacity;
                    try
                    {
                        await _tableRepository.UpdateAsync(table);
                        MessageBox.Show("Table successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTablesAsync();
                        ClearTableForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a table to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewTables.SelectedRows[0].Index;
                int tableId = (int)dataGridViewTables.Rows[selectedRowIndex].Cells["TableId"].Value;

                var table = await _tableRepository.GetTableByIdAsync(tableId);
                if (table != null)
                {
                    table.TableEnabled = true;
                    try
                    {
                        await _tableRepository.UpdateAsync(table);
                        MessageBox.Show("Table successfully activated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTablesAsync();
                        ClearTableForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error activating table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a table to activate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewTables.SelectedRows[0].Index;
                int tableId = (int)dataGridViewTables.Rows[selectedRowIndex].Cells["TableId"].Value;

                var table = await _tableRepository.GetTableByIdAsync(tableId);
                if (table != null)
                {
                    table.TableEnabled = false;

                    try
                    {
                        await _tableRepository.UpdateAsync(table);
                        MessageBox.Show("Table successfully deactivated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTablesAsync();
                        ClearTableForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deactivating table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a table to deactivate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearTableForm()
        {
            txtTableName.Clear();
        }

        private void CustomizeDataGridView()
        {
            // Customize DataGridView appearance and behavior as needed
            dataGridViewTables.Columns["TableId"].Visible = false;
            dataGridViewTables.Columns["Area"].Visible = false;
            dataGridViewTables.Columns["Bookings"].Visible = false;
            // Add additional customization here if required
        }

        private void dataGridViewTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewTables.Rows[e.RowIndex];
                txtTableName.Text = row.Cells["TableName"].Value.ToString();
                txtCapacity.Text = row.Cells["TableCapacity"].Value.ToString();
            }
        }

        private void TableManagement_Load(object sender, EventArgs e)
        {

        }

        private void txtCapacity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
