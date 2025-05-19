using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class GuestsForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public GuestsForm()
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

        private void btnAddGuest_Click(object sender, EventArgs e)
        {

            DataTable dataTable = (DataTable)dataGridViewGuests.DataSource;
            DataRow newRow = dataTable.NewRow();
            dataTable.Rows.Add(newRow);
            dataGridViewGuests.CurrentCell = dataGridViewGuests.Rows[dataGridViewGuests.Rows.Count - 1].Cells[0];
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Guests", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                DataTable dataTable = (DataTable)dataGridViewGuests.DataSource;
                adapter.Update(dataTable);
            }
            MessageBox.Show("Изменения сохранены.", "Успех");
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if (dataGridViewGuests.SelectedRows.Count > 0)
            {

                int guestID = Convert.ToInt32(dataGridViewGuests.SelectedRows[0].Cells["GuestID"].Value);


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Guests WHERE GuestID = @GuestID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GuestID", guestID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }


                DataTable dataTable = (DataTable)dataGridViewGuests.DataSource;
                dataTable.Rows.RemoveAt(dataGridViewGuests.SelectedRows[0].Index);

                MessageBox.Show("Гость удален.", "Успех");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите гостя для удаления.", "Ошибка");
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
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}