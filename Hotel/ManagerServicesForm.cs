using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ManagerServicesForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public ManagerServicesForm()
        {
            InitializeComponent();
            LoadSearchCriteria();
            LoadServices();
        }

        private void LoadSearchCriteria()
        {
            comboBoxSearchCriteria.Items.Add("ServiceName");
            comboBoxSearchCriteria.Items.Add("Description");
            comboBoxSearchCriteria.Items.Add("Price");
            comboBoxSearchCriteria.SelectedIndex = 0;
        }

        private void LoadServices()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ServiceID, ServiceName, Description, Price FROM Services";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewServices.DataSource = dataTable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string searchCriteria = comboBoxSearchCriteria.SelectedItem.ToString();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadServices();
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT ServiceID, ServiceName, Description, Price FROM Services " +
                               $"WHERE {searchCriteria} LIKE @SearchText";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewServices.DataSource = dataTable;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadServices();
            txtSearch.Clear();
            comboBoxSearchCriteria.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadServices();
        }
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}