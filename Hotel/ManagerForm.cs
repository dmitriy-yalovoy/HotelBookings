using System;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }


        private void btnManageReservations_Click(object sender, EventArgs e)
        {
            ManagerReservationsForm reservationsForm = new ManagerReservationsForm();
            reservationsForm.Show();
        }

        private void btnManageGuests_Click(object sender, EventArgs e)
        {
            ManagerGuestsForm guestsForm = new ManagerGuestsForm();
            guestsForm.Show();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            ManagerRoomsForm manageRoomsForm = new ManagerRoomsForm();
            manageRoomsForm.Show();
        }

        private void btnManageServices_Click(object sender, EventArgs e)
        {
            ManagerServicesForm servicesForm = new ManagerServicesForm();
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