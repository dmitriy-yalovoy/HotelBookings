using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ServicesForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public ServicesForm()
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

        private void btnAddService_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridViewServices.DataSource;
            DataRow newRow = dataTable.NewRow();
            dataTable.Rows.Add(newRow);
            dataGridViewServices.CurrentCell = dataGridViewServices.Rows[dataGridViewServices.Rows.Count - 1].Cells[0];
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Services", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                DataTable dataTable = (DataTable)dataGridViewServices.DataSource;
                adapter.Update(dataTable);
            }
            MessageBox.Show("Изменения сохранены.", "Успех");
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {

                int serviceID = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["ServiceID"].Value);


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Services WHERE ServiceID = @ServiceID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ServiceID", serviceID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }


                DataTable dataTable = (DataTable)dataGridViewServices.DataSource;
                dataTable.Rows.RemoveAt(dataGridViewServices.SelectedRows[0].Index);

                MessageBox.Show("Услуга удалена.", "Успех");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите услугу для удаления.", "Ошибка");
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
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}