using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ManagerGuestsForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public ManagerGuestsForm()
        {
            InitializeComponent();
            LoadSearchCriteria();
            LoadGuests();
        }

        private void LoadSearchCriteria()
        {
            comboBoxSearchCriteria.Items.Add("FirstName");
            comboBoxSearchCriteria.Items.Add("LastName");
            comboBoxSearchCriteria.Items.Add("Email");
            comboBoxSearchCriteria.Items.Add("Phone");
            comboBoxSearchCriteria.Items.Add("ServiceID");
            comboBoxSearchCriteria.SelectedIndex = 0;
        }

        private void LoadGuests()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT GuestID, FirstName, LastName, Email, Phone, ServiceID FROM Guests";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewGuests.DataSource = dataTable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string searchCriteria = comboBoxSearchCriteria.SelectedItem.ToString();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadGuests();
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT GuestID, FirstName, LastName, Email, Phone, ServiceID FROM Guests " +
                               $"WHERE {searchCriteria} LIKE @SearchText";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewGuests.DataSource = dataTable;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadGuests();
            txtSearch.Clear();
            comboBoxSearchCriteria.SelectedIndex = 0;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGuests();
        }
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}