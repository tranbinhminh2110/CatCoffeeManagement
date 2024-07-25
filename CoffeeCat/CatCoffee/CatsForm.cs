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
    public partial class CatsForm : Form
    {
        private readonly ICustomerRepository<Cat> _repository;
        private readonly int _areaId;

        public CatsForm(ICustomerRepository<Cat> repository, int areaId)
        {
            _repository = repository;
            _areaId = areaId;
            InitializeComponent();
        }

        private async void CatsForm_Load(object sender, EventArgs e)
        {
            await LoadCatsAsync();
        }

        private async Task LoadCatsAsync()
        {
            try
            {
                IQueryable<Cat> catsQuery = await _repository.GetCatEnableAsync();
                List<Cat> cats = await catsQuery.Where(c => c.AreaId == _areaId).ToListAsync();

                // Hiển thị danh sách mèo lên DataGridView
                dataGridViewCats.DataSource = cats;
                dataGridViewCats.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Cats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
