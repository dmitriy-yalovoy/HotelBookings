using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel
{
    public partial class BookingForm : Form
    {
        public BookingForm()
        {
            InitializeComponent();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtRoomID.Text, out int roomID) || !int.TryParse(txtGuestID.Text, out int guestID))
                {
                    MessageBox.Show("Пожалуйста, введите корректные числовые значения для RoomID и GuestID.");
                    return;
                }

                DateTime checkInDate = dateTimePickerCheckIn.Value;
                DateTime checkOutDate = dateTimePickerCheckOut.Value;
                int daysOfStay = (checkOutDate - checkInDate).Days;
                int statusID = 1;

                string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Reservations (RoomID, CheckInDate, CheckOutDate, DaysOfStay, StatusID, GuestID) VALUES (@RoomID, @CheckInDate, @CheckOutDate, @DaysOfStay, @StatusID, @GuestID); SELECT SCOPE_IDENTITY();";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomID", roomID);
                    command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                    command.Parameters.AddWithValue("@DaysOfStay", daysOfStay);
                    command.Parameters.AddWithValue("@StatusID", statusID);
                    command.Parameters.AddWithValue("@GuestID", guestID);

                    connection.Open();
                    int newReservationID = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show($"Бронирование успешно создано. Новый ReservationID: {newReservationID}");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ошибка формата ввода данных: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}