using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ManagerReservationsForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public ManagerReservationsForm()
        {
            InitializeComponent();
            LoadSearchCriteria();
            LoadReservations();
        }

        private void LoadSearchCriteria()
        {
            comboBoxSearchCriteria.Items.Add("ReservationID");
            comboBoxSearchCriteria.Items.Add("UserID");
            comboBoxSearchCriteria.Items.Add("RoomID");
            comboBoxSearchCriteria.Items.Add("CheckInDate");
            comboBoxSearchCriteria.Items.Add("CheckOutDate");
            comboBoxSearchCriteria.Items.Add("DaysOfStay");
            comboBoxSearchCriteria.Items.Add("StatusID");
            comboBoxSearchCriteria.Items.Add("EmployeeID");
            comboBoxSearchCriteria.Items.Add("GuestID");
            comboBoxSearchCriteria.SelectedIndex = 0;
        }

        private void LoadReservations()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ReservationID, UserID, RoomID, CheckInDate, CheckOutDate, DaysOfStay, StatusID, EmployeeID, GuestID FROM Reservations";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewReservations.DataSource = dataTable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string searchCriteria = comboBoxSearchCriteria.SelectedItem.ToString();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadReservations();
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT ReservationID, UserID, RoomID, CheckInDate, CheckOutDate, DaysOfStay, StatusID, EmployeeID, GuestID FROM Reservations " +
                               $"WHERE {searchCriteria} LIKE @SearchText";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewReservations.DataSource = dataTable;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadReservations();
            txtSearch.Clear();
            comboBoxSearchCriteria.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
        }
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
