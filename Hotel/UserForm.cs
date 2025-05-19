using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class UserForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";
        private int selectedRoomID;
        private decimal roomPrice;

        public UserForm()
        {
            InitializeComponent();
            LoadRoomDetails();
        }

        private void LoadRoomDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT RoomID, RoomNumber, RoomTypeID, Price, IsAvailable FROM Rooms WHERE RoomID IN (1, 2, 3)";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 3)
                {
                    labelRoom1Description.Text = $"Одноместная комната {dataTable.Rows[0]["RoomNumber"]}:\nЦена: {dataTable.Rows[0]["Price"]}";
                    labelRoom2Description.Text = $"Двухместная комната {dataTable.Rows[1]["RoomNumber"]}:\nЦена: {dataTable.Rows[1]["Price"]}";
                    labelRoom3Description.Text = $"Люкс комната {dataTable.Rows[2]["RoomNumber"]}:\nЦена: {dataTable.Rows[2]["Price"]}";
                }
            }
        }

        private void btnSelectRoom1_Click(object sender, EventArgs e)
        {
            selectedRoomID = 1;
            roomPrice = GetRoomPrice(selectedRoomID);
            OpenPaymentForm();
        }

        private void btnSelectRoom2_Click(object sender, EventArgs e)
        {
            selectedRoomID = 2;
            roomPrice = GetRoomPrice(selectedRoomID);
            OpenPaymentForm();
        }

        private void btnSelectRoom3_Click(object sender, EventArgs e)
        {
            selectedRoomID = 3;
            roomPrice = GetRoomPrice(selectedRoomID);
            OpenPaymentForm();
        }

        private decimal GetRoomPrice(int roomID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Price FROM Rooms WHERE RoomID = @RoomID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomID);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
                else
                {
                    throw new Exception("Цена комнаты не найдена.");
                }
            }
        }

        private void OpenPaymentForm()
        {
            DateTime checkInDate = dateTimePickerCheckIn.Value;
            DateTime checkOutDate = dateTimePickerCheckOut.Value;

            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Дата выезда должна быть позже даты заезда.", "Ошибка");
                return;
            }

           
            PaymentForm paymentForm = new PaymentForm(checkInDate, checkOutDate, selectedRoomID, roomPrice);
            paymentForm.Show();
            this.Hide();
        }
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
           
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}