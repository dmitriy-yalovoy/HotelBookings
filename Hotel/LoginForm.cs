using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Hotel
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Data Source=dmitriyalovoy;Initial Catalog=HotelBooking;Integrated Security=True;";
        private bool passwordVisible = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string name = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Role FROM Users WHERE username = @Username AND password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", name);
                    command.Parameters.AddWithValue("@Password", password);

                    string role = (string)command.ExecuteScalar();

                    if (role != null)
                    {
                        switch (role)
                        {
                            case "Admin":
                                MainForm mainForm = new MainForm();
                                mainForm.Show();
                                this.Hide();
                                break;
                            case "Manager":
                                ManagerForm managerForm = new ManagerForm();
                                managerForm.Show();
                                this.Hide();
                                break;
                            case "User":
                                UserForm userForm = new UserForm();
                                userForm.Show();
                                this.Hide();
                                break;
                            default:
                                MessageBox.Show("Неизвестная роль пользователя.", "Ошибка");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message, "Ошибка");
            }
        


            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите имя.", "Ошибка");
                return;
            }

            if (!Regex.IsMatch(name, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Имя может содержать только буквы латиницы.", "Ошибка");
                return;
            }


            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль.", "Ошибка");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов.", "Ошибка");
                return;
            }

            if (password == "12345678" || password.ToLower() == "password")
            {
                MessageBox.Show("Этот пароль слишком простой.  Пожалуйста, выберите более надежный пароль.", "Ошибка");
                return;
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]).+$"))
            {
                MessageBox.Show("Пароль должен содержать как минимум одну заглавную букву, одну строчную букву, одну цифру и один специальный символ.", "Ошибка");
                return;
            }

        }

        private void buttonTogglePassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            textBoxPassword.PasswordChar = passwordVisible ? '\0' : '*';
            buttonTogglePassword.Text = passwordVisible ? "Скрыть" : "Показать";
        }
    }
}


