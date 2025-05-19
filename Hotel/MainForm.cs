using System;
using System.Windows.Forms;

namespace Hotel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            BookingForm bookingForm = new BookingForm();
            bookingForm.Show();
        }

        private void btnManageReservations_Click(object sender, EventArgs e)
        {
            ReservationsForm reservationsForm = new ReservationsForm();
            reservationsForm.Show();
        }

        private void btnManageGuests_Click(object sender, EventArgs e)
        {
            GuestsForm guestsForm = new GuestsForm();
            guestsForm.Show();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            ManageRoomsForm manageRoomsForm = new ManageRoomsForm();
            manageRoomsForm.Show();
        }

        private void btnManageServices_Click(object sender, EventArgs e)
        {
            ServicesForm servicesForm = new ServicesForm();
            servicesForm.Show();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}