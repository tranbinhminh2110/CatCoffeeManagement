using Entities;
using Repositories.Auth;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatCoffee
{
    public partial class BookingHistoryForm : Form
    {
        private readonly ICoffeeShopManagerRepository<Booking> _bookingRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ICoffeeShopStaffRepository _staffRepository;

        public BookingHistoryForm(
            ICoffeeShopManagerRepository<Booking> bookingRepository,
            ISessionRepository sessionRepository,
            ICoffeeShopStaffRepository staffRepository)
        {
            InitializeComponent();
            _bookingRepository = bookingRepository;
            _sessionRepository = sessionRepository;
            _staffRepository = staffRepository;
        }

        private int userId;

        private async Task LoadBookingHistoryAsync()
        {
            try
            {
                userId = (int)Session.Get("userId");

                var customer = _sessionRepository.GetUserById(userId);
                if (customer != null)
                {
                    int customerId = customer.CustomerId;
                    List<Booking> bookingHistory = await _bookingRepository.GetBookingHistoryForCustomerAsync(customerId);

                    dataGridViewBookingHistory.DataSource = bookingHistory.Select(b => new
                    {
                        b.BookingId,
                        b.BookingCode,
                        b.BookingStartTime,
                        b.BookingEndTime,
                        b.BookingEnabled
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("No customer found in session.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookingHistory.SelectedRows.Count > 0)
            {
                int bookingId = (int)dataGridViewBookingHistory.SelectedRows[0].Cells["BookingId"].Value;
                var booking = await _staffRepository.GetBookingByIdAsync(bookingId);

                if (booking == null)
                {
                    MessageBox.Show("Booking not found.");
                    return;
                }

                if (booking.BookingEnabled != false)
                {
                    MessageBox.Show("Cannot cancel a booking that is already enabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    await _staffRepository.DeleteAsync(booking);
                    MessageBox.Show("Booking successfully canceled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadBookingHistoryAsync(); // Refresh the booking history
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error canceling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BookingHistoryForm_Load(object sender, EventArgs e)
        {
            await LoadBookingHistoryAsync();
        }
    }
}
