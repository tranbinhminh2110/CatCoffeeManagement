using Repositories.Auth;
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
using Entities;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;
using System.Data.Common;

namespace CatCoffee
{

    public partial class StaffHomeForm : Form
    {
        private readonly ICoffeeShopStaffRepository _coffeeShopStaffRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly CoffeeCatContext _catContext;
        public StaffHomeForm(ICoffeeShopStaffRepository coffeeShopStaffRepository, ISessionRepository sessionRepository, CoffeeCatContext catContext)
        {
            InitializeComponent();
            _coffeeShopStaffRepository = coffeeShopStaffRepository;
            _sessionRepository = sessionRepository;
            Load += async (sender, e) => await LoadBookingsAsync();
            _catContext = catContext;
        }
        private int userId;
        private int? shopId;
        private int role;
        private async Task LoadBookingsAsync()
        {
            Authenticate();
            Authorization();

            userId = (int)Session.Get("userId");
            var staff = _sessionRepository.GetUserById(userId);
            if (staff != null)
            {
                var bookings = await _coffeeShopStaffRepository.GetBookingsByShopIdAsync(staff.ShopId);
                dataGridViewBookings.DataSource = bookings.Select(s => new
                {
                    s.BookingId,
                    s.BookingCode,
                    s.BookingEnabled,
                    s.BookingStartTime,
                    s.BookingEndTime,
               
                }).ToList();
            }
            else
            {
                MessageBox.Show("Staff not found or not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private async void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewBookings.SelectedRows[0].Index;
                int bookingId = (int)dataGridViewBookings.Rows[selectedRowIndex].Cells["BookingId"].Value;

                var booking = await _coffeeShopStaffRepository.GetBookingByIdAsync(bookingId);

                booking.BookingEnabled = true;
                await _coffeeShopStaffRepository.UpdateAsync(booking);

                MessageBox.Show("Booking confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadBookingsAsync();
            }
            else
            {
                MessageBox.Show("Please select a booking to confirm.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Authenticate()
        {
            userId = (int)Session.Get("userId");
            if (userId == null)
            {
                MessageBox.Show("Please log in first.", "Authentication Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); // Close the form or redirect to login form
            }
        }

        private void Authorization()
        {
            role = (int)Session.Get("role");
            if (role != 3)
            {
                MessageBox.Show("You are not authorized to access this page.", "Authorization Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); // Close the form or redirect to error form
            }
        }

        private void StaffHomeForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
