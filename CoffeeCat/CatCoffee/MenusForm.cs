using Entities;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatCoffee
{
    public partial class MenusForm : Form
    {
        private readonly ICustomerRepository<MenuItem> _repository;
        private int _shopId;

        public MenusForm(ICustomerRepository<MenuItem> repository, int shopId)
        {
            _repository = repository;
            _shopId = shopId;
            InitializeComponent();
        }

        private async void MenusForm_Load(object sender, EventArgs e)
        {
            await LoadMenuItemsAsync();
        }

        private async Task LoadMenuItemsAsync()
        {
            try
            {
                IQueryable<MenuItem> menuQuery = await _repository.GetMenuItemEnableAsync();
                menuQuery = menuQuery.Where(m => m.ShopId == _shopId);

                List<MenuItem> menuItems = await menuQuery.ToListAsync();

                dataGridViewMenuItems.DataSource = menuItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Menu Items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
