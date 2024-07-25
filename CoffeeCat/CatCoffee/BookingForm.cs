using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Entities; // Import thêm namespace Entities để có thể sử dụng đối tượng Table
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Auth; // Import thêm namespace Repositories để sử dụng các repository

namespace CatCoffee
{
    public partial class BookingForm : Form
    {
        private readonly ICoffeeShopManagerRepository<Booking> _bookingRepository; // Đổi tên để phản ánh repository thích hợp
        private readonly ICoffeeShopManagerRepository<Table> _tableRepository;
        private readonly ICoffeeShopManagerRepository<MenuItem> _itemRepository;
        private readonly ICustomerRepository<MenuItem> _repository;
        private readonly CoffeeCatContext _catContext;
        private int _areaId;
        private int _shopId;
        private List<int> _selectedTableIds = new List<int>();
        private List<int> _selectedItemIds = new List<int>();
        private int userId;
        private int itemId;
        private int tableId;
        public BookingForm(int areaId, int shopId, ICoffeeShopManagerRepository<Booking> bookingRepository, ICoffeeShopManagerRepository<Table> tableRepository, ICoffeeShopManagerRepository<MenuItem> itemRepository, ICustomerRepository<MenuItem> repository, CoffeeCatContext catContext)
        {
            InitializeComponent();
            _areaId = areaId;
            _shopId = shopId;
            _catContext = catContext;
            _repository = repository;
            userId = (int)Session.Get("userId");
            _itemRepository = itemRepository;
            _tableRepository = tableRepository;
            _bookingRepository = bookingRepository; // Lưu repository được inject

            UpdateMinDate();
            InitializeTimeComboBoxes(); // Khởi tạo danh sách thời gian trong ComboBoxes
            InitializeDataGridView(); // Khởi tạo DataGridView
        }

        private void UpdateMinDate()
        {
            dateTimePickerBookingDate.MinDate = DateTime.Today;
        }

        private void InitializeTimeComboBoxes()
        {
            // Thêm các giờ bắt đầu và kết thúc mẫu vào ComboBoxes
            comboBoxStartTime.Items.AddRange(new object[] { "07:00 AM", "09:00 AM", "01:00 PM", "03:00 PM" });
            comboBoxEndTime.Items.AddRange(new object[] { "09:00 AM", "11:00 AM", "03:00 PM", "05:00 PM" });

            // Mặc định chọn giờ đầu tiên trong danh sách
            comboBoxStartTime.SelectedIndex = 0;
            comboBoxEndTime.SelectedIndex = 0;
        }

        private void InitializeDataGridView()
        {
            // Thiết lập DataGridView
            dataGridViewAvailableTables.AutoGenerateColumns = false;
            dataGridViewAvailableTables.Columns.Add("TableId", "Table ID");
            dataGridViewAvailableTables.Columns.Add("TableName", "Table Name");
            dataGridViewAvailableTables.Columns.Add("Capacity", "Capacity");
            dataGridViewAvailableTables.Columns.Add("Status", "Status");

            // Cài đặt để chỉ đọc (read-only)
            dataGridViewAvailableTables.ReadOnly = true;
        }
        private void DataGridViewAvailableTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAvailableTables.Rows[e.RowIndex];
                tableId = (int)row.Cells["TableId"].Value;

                // Add the selected table id to the list
                _selectedTableIds.Add(tableId);
            }
        }
        private void DataGridViewItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewItems.Rows[e.RowIndex];
                itemId = (int)row.Cells["ItemId"].Value;

                // Add the selected table id to the list
                _selectedItemIds.Add(itemId);
            }
        }
        private async void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            DateTime bookingDate = dateTimePickerBookingDate.Value.Date;
            TimeSpan startTime = GetSelectedTime(comboBoxStartTime);
            TimeSpan endTime = GetSelectedTime(comboBoxEndTime);

            DateTime bookingStartTime = bookingDate.Add(startTime);
            DateTime bookingEndTime = bookingDate.Add(endTime);

            if (bookingStartTime >= bookingEndTime)
            {
                MessageBox.Show("The end time must be greater than the start time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Gọi repository để lấy danh sách bàn khả dụng
                List<Table> availableTables = await _bookingRepository.GetAvailableTablesAsync(_areaId, bookingStartTime, bookingEndTime);

                // Hiển thị danh sách bàn trong DataGridView
                DisplayAvailableTables(availableTables);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving available tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Xóa nội dung form để chuẩn bị cho lần nhập tiếp theo

        }

        private TimeSpan GetSelectedTime(ComboBox comboBox)
        {
            string selectedTime = comboBox.SelectedItem.ToString();
            DateTime parsedTime = DateTime.ParseExact(selectedTime, "hh:mm tt", CultureInfo.InvariantCulture);
            return parsedTime.TimeOfDay;
        }

        private void DisplayAvailableTables(List<Table> tables)
        {

            dataGridViewAvailableTables.Rows.Clear();


            foreach (var table in tables)
            {
                dataGridViewAvailableTables.Rows.Add(table.TableId, table.TableName, table.TableCapacity, table.TableStatus);
            }
        }
        private string GenerateBookingCode()
        {
            string code = "BOOK" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return code;
        }


        private async void btnBook_Click(object sender, EventArgs e)
        {

            DateTime bookingDate = dateTimePickerBookingDate.Value.Date;
            TimeSpan startTime = GetSelectedTime(comboBoxStartTime);
            TimeSpan endTime = GetSelectedTime(comboBoxEndTime);

            DateTime bookingStartTime = bookingDate.Add(startTime);
            DateTime bookingEndTime = bookingDate.Add(endTime);

            if (bookingStartTime >= bookingEndTime || _selectedTableIds.Count == 0)
            {
                MessageBox.Show("Please select valid booking time and at least one table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem đã chọn bàn và thời gian hợp lệ
            // Đảm bảo DataGridView đã hiển thị danh sách các bàn khả dụng và đã được người dùng chọn trước khi nhấn nút Book

            // Tạo mã đặt bàn
            string bookingCode = GenerateBookingCode();

            Task<Table> tableTask = _tableRepository.GetTableByIdAsync(tableId);
            ICollection<Table> tables = new List<Table> { await tableTask };
            Task<MenuItem> itemTask = _itemRepository.GetMenuItemsByIdAsync(itemId);
            ICollection<MenuItem> items = new List<MenuItem> { await itemTask };
            var booking = new Booking
            {
                BookingCode = bookingCode,
                BookingStartTime = bookingStartTime,
                BookingEndTime = bookingEndTime,
                Tables = tables,
                Items = items,
                BookingEnabled = false,
                CustomerId = userId // Giả sử userId đã được thiết lập từ session
            };

            try
            {

                await _bookingRepository.AddAsync(booking);


                await _bookingRepository.AddTablesToBookingAsync(booking.BookingId, _selectedTableIds);


                MessageBox.Show("Booking successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var bookingHistoryForm = new BookingHistoryForm(new CoffeeShopManagerRepository<Booking>(_catContext), new SessionRepository(_catContext), new CoffeeShopStaffRepository(_catContext));
                bookingHistoryForm.ShowDialog();
                this.Close();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ClearForm()
        {
            dateTimePickerBookingDate.Value = DateTime.Today;
            comboBoxStartTime.SelectedIndex = 0;
            comboBoxEndTime.SelectedIndex = 0;
        }

        private async void BookingForm_Load(object sender, EventArgs e)
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

                dataGridViewItems.DataSource = menuItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Menu Items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerBookingDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
