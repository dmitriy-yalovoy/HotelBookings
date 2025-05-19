using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Hotel
{
    public partial class PaymentForm : Form
    {
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private int selectedRoomID;
        private decimal roomPrice;
        private decimal servicePrice; 
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";

        public PaymentForm(DateTime checkInDate, DateTime checkOutDate, int selectedRoomID, decimal roomPrice)
        {
            InitializeComponent();
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.selectedRoomID = selectedRoomID;
            this.roomPrice = roomPrice;
            LoadServicePrice();
            CalculateTotal();
        }

        private void LoadServicePrice()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(Price) FROM Services";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    servicePrice = Convert.ToDecimal(result);
                }
                else
                {
                    servicePrice = 0; 
                }
            }
        }

        private void CalculateTotal()
        {
            int daysOfStay = (checkOutDate - checkInDate).Days;
            if (daysOfStay == 0)
            {
                daysOfStay = 1; 
            }
            labelDaysOfStay.Text = $"Количество суток: {daysOfStay}";

            decimal totalRoomPrice = roomPrice * daysOfStay;
            labelRoomPrice.Text = $"Цена комнаты: {totalRoomPrice}";

            decimal totalServicePrice = checkBoxService.Checked ? servicePrice * daysOfStay : 0;
            decimal vat = (totalRoomPrice + totalServicePrice) * 0.05m;
            labelVAT.Text = $"НДС: {vat}";

            decimal total = totalRoomPrice + totalServicePrice + vat;
            labelTotal.Text = $"Итого: {total}";
        }

        private void checkBoxService_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToWord();
        }

        private void SaveToWord()
        {
            try
            {
               
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    Document wordDoc = wordApp.Documents.Add();

                   
                    wordApp.Selection.Font.Name = "Times New Roman";
                    wordApp.Selection.Font.Size = 14;

                 
                    Paragraph hotelNameParagraph = wordDoc.Paragraphs.Add();
                    hotelNameParagraph.Range.Text = "Отель \"Элеон\"";
                    hotelNameParagraph.Range.Font.Name = "Times New Roman";
                    hotelNameParagraph.Range.Font.Size = 18;
                    hotelNameParagraph.Range.Font.Bold = 1;
                    hotelNameParagraph.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    hotelNameParagraph.Range.InsertParagraphAfter();

                    
                    string roomType = GetRoomType(selectedRoomID);

                    
                    Table table = wordDoc.Tables.Add(wordApp.Selection.Range, 6, 2);
                    table.Borders.Enable = 1;

                    table.Cell(1, 1).Range.Text = "Дата заезда";
                    table.Cell(1, 2).Range.Text = checkInDate.ToShortDateString();

                    table.Cell(2, 1).Range.Text = "Дата выезда";
                    table.Cell(2, 2).Range.Text = checkOutDate.ToShortDateString();

                    table.Cell(3, 1).Range.Text = "Тип комнаты";
                    table.Cell(3, 2).Range.Text = roomType;

                    table.Cell(4, 1).Range.Text = "Количество суток";
                    table.Cell(4, 2).Range.Text = labelDaysOfStay.Text.Replace("Количество суток: ", "");

                    table.Cell(5, 1).Range.Text = "Цена комнаты";
                    table.Cell(5, 2).Range.Text = labelRoomPrice.Text.Replace("Цена комнаты: ", "");

                    table.Cell(6, 1).Range.Text = "Итого";
                    table.Cell(6, 2).Range.Text = labelTotal.Text.Replace("Итого: ", "");

                    
                    wordDoc.SaveAs2(filePath);
                    wordDoc.Close();
                    wordApp.Quit();

                    MessageBox.Show("Информация сохранена в Word.", "Успех");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в Word: {ex.Message}", "Ошибка");
            }
        }

        private string GetRoomType(int roomID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT RoomType FROM RoomType WHERE RoomTypeID = (SELECT RoomTypeID FROM Rooms WHERE RoomID = @RoomID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomID);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
                else
                {
                    return "Неизвестный тип комнаты";
                }
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