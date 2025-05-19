using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ManagerRoomsForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public ManagerRoomsForm()
        {
            InitializeComponent();
            LoadSearchCriteria();
            LoadRooms();
        }

        private void LoadSearchCriteria()
        {
            comboBoxSearchCriteria.Items.Add("RoomID");
            comboBoxSearchCriteria.Items.Add("RoomNumber");
            comboBoxSearchCriteria.Items.Add("RoomTypeID");
            comboBoxSearchCriteria.Items.Add("Price");
            comboBoxSearchCriteria.Items.Add("IsAvailable");
            comboBoxSearchCriteria.SelectedIndex = 0;
        }

        private void LoadRooms()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT RoomID, RoomNumber, RoomTypeID, Price, IsAvailable FROM Rooms";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewRooms.DataSource = dataTable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string searchCriteria = comboBoxSearchCriteria.SelectedItem.ToString();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadRooms();
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT RoomID, RoomNumber, RoomTypeID, Price, IsAvailable FROM Rooms " +
                               $"WHERE {searchCriteria} LIKE @SearchText";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewRooms.DataSource = dataTable;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadRooms();
            txtSearch.Clear();
            comboBoxSearchCriteria.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}