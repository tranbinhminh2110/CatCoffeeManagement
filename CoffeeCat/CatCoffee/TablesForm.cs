using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatCoffee
{
    public partial class TablesForm : Form
    {
        private readonly ICustomerRepository<Table> _tableRepository;
        private readonly int _areaId;

        public TablesForm(ICustomerRepository<Table> tableRepository, int areaId)
        {
            _tableRepository = tableRepository;
            _areaId = areaId;
            InitializeComponent();
        }

        private async void TablesForm_Load(object sender, EventArgs e)
        {
            await LoadTablesAsync();
        }

        private async Task LoadTablesAsync()
        {
            try
            {
                IQueryable<Table> tablesQuery = await _tableRepository.GetTableEnableAsync();
                List<Table> tables = await tablesQuery.Where(t => t.AreaId == _areaId).ToListAsync();

               
                dataGridViewTables.DataSource = tables;
                dataGridViewTables.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
