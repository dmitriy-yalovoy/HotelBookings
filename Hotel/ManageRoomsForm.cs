using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ManageRoomsForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public ManageRoomsForm()
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

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            
            DataTable dataTable = (DataTable)dataGridViewRooms.DataSource;
            DataRow newRow = dataTable.NewRow();
            dataTable.Rows.Add(newRow);
            dataGridViewRooms.CurrentCell = dataGridViewRooms.Rows[dataGridViewRooms.Rows.Count - 1].Cells[0];
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Rooms", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                DataTable dataTable = (DataTable)dataGridViewRooms.DataSource;
                adapter.Update(dataTable);
            }
            MessageBox.Show("Изменения сохранены.", "Успех");
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count > 0)
            {
               
                int guestID = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["RoomID"].Value);

               
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Rooms WHERE RoomID = @RoomID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomID", guestID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

              
                DataTable dataTable = (DataTable)dataGridViewRooms.DataSource;
                dataTable.Rows.RemoveAt(dataGridViewRooms.SelectedRows[0].Index);

                MessageBox.Show("Комната удалена.", "Успех");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите комнату для удаления.", "Ошибка");
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
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}