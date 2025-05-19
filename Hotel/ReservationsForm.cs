using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ReservationsForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public ReservationsForm()
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

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            
            DataTable dataTable = (DataTable)dataGridViewReservations.DataSource;
            DataRow newRow = dataTable.NewRow();
            dataTable.Rows.Add(newRow);
            dataGridViewReservations.CurrentCell = dataGridViewReservations.Rows[dataGridViewReservations.Rows.Count - 1].Cells[0];
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Reservations", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                DataTable dataTable = (DataTable)dataGridViewReservations.DataSource;
                adapter.Update(dataTable);
            }
            MessageBox.Show("Изменения сохранены.", "Успех");
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count > 0)
            {
                
                int reservationID = Convert.ToInt32(dataGridViewReservations.SelectedRows[0].Cells["ReservationID"].Value);

                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Reservations WHERE ReservationID = @ReservationID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ReservationID", reservationID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                DataTable dataTable = (DataTable)dataGridViewReservations.DataSource;
                dataTable.Rows.RemoveAt(dataGridViewReservations.SelectedRows[0].Index);

                MessageBox.Show("Бронирование удалено.", "Успех");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите бронирование для удаления.", "Ошибка");
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
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}