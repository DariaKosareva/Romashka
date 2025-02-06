using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ромашка.database.User;
using static Ромашка.database;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;

namespace Ромашка
{
    public partial class Registr : Form
    {

        Thread f1f2;
        User user = new User();


        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public void openL(object obj)
        {
            Application.Run(new LogIn(user));
        }

        public Registr(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openHP);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openL);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User user = new User();

            string Name, LastName, FatherName, Login, Telephone, Password, Email;
            Name = textBox1.Text;
            LastName = textBox2.Text;
            FatherName = textBox3.Text;
            Telephone = textBox4.Text;
            Login = textBox5.Text;
            Password = textBox6.Text;
            Email = textBox7.Text;

            try
            {
                if (textBox8.Text == "")
                {
                    MessageBox.Show("Вы не ввели код!");
                }
                else if (Int32.Parse(textBox8.Text) == randomNumber)
                {
                    try
                    {
                        int count = 0;
                        string login = textBox5.Text;
                        string query = $"SELECT * FROM Users WHERE Login = @Login";
                        using (var connection = new SQLiteConnection("DataSource=Teacher.db"))
                        {
                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {

                                connection.Open();
                                command.Parameters.AddWithValue("@Login", login);
                                using (SQLiteDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        if (reader["Login"].ToString() != "")
                                        {
                                            count = 1;
                                        }
                                    }

                                }

                                connection.Close();
                            }

                        }

                        if (count > 0)
                        {
                            MessageBox.Show("Такой логин уже есть!");
                        }
                        else
                        {
                            if (!char.IsDigit(textBox4.Text, 0))
                            {
                                MessageBox.Show("Введенный телефон не является числом!");
                            }
                            else if (textBox4.Text != null && textBox4.Text.Length > 12)
                            {
                                MessageBox.Show("Число значений в телефоне не может привышать 12!");
                            }
                            else
                            {
                                using (var connection = new SQLiteConnection("DataSource=Teacher.db"))
                                {
                                    connection.Open();
                                    string query2 = "INSERT INTO Users (Name, LastName, FatherName, Telephone, Login, Password, Email) VALUES (@Name, @LastName, @FatherName, @Telephone, @Login, @Password, @Email)";
                                    using (SQLiteCommand command2 = new SQLiteCommand(query2, connection))
                                    {
                                        command2.Parameters.AddWithValue("@Name", Name);
                                        command2.Parameters.AddWithValue("@LastName", LastName);
                                        command2.Parameters.AddWithValue("@FatherName", FatherName);
                                        command2.Parameters.AddWithValue("@Telephone", Telephone);
                                        command2.Parameters.AddWithValue("@Login", Login);
                                        command2.Parameters.AddWithValue("@Password", Password);
                                        command2.Parameters.AddWithValue("@Email", Email);

                                        int rowsAffected = command2.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Вы успешно зарегестрированы!");

                                    connection.Close();
                                }
                            }

                        }
                    }

                    catch (SQLiteException ex)
                    {
                        if (ex.Message.Contains("NOT NULL"))
                        {
                            MessageBox.Show("Поля не должны быть пустыми!", "Ошибка!");
                        }
                        else
                        {
                            MessageBox.Show("Произошла ошибка при добавлении записи: " + ex.Message, "Ошибка!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка!");
                    }
                }
                else
                {
                    MessageBox.Show("Код введен неправильно!");
                }
            }
            catch
            {
                MessageBox.Show("Значение введено некорректно!");
            }

        }

        int randomNumber;

        private void SendEmail(string userEmail, int kod)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "romashka.uwo1@gmail.com";
                string smtpPassword = "xedh ortq uyjc sudx";

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("no-reply@example.com");
                mailMessage.To.Add(new MailAddress(userEmail));
                mailMessage.Subject = "Код подтверждения приложения 'Ромашка'";

                StringBuilder bodyBuilder = new StringBuilder();
                bodyBuilder.AppendLine($"Уважаемый учащийся, ваш код доступа: {kod}");
                bodyBuilder.AppendLine("Ромашка");

                mailMessage.Body = bodyBuilder.ToString();

                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

            }
            catch
            {
                MessageBox.Show("Лол кек чебурек");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //marievaijong@gmail.com
            if (textBox7.Text != "")
            {
                string email = textBox7.Text;
                string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]";

                if (Regex.IsMatch(email, pattern))
                {
                    Random random = new Random();
                    randomNumber = random.Next(1000, 10000);
                    SendEmail(email, randomNumber);
                }
                else
                {
                    MessageBox.Show("Значение не соответствует шаблону email.", "Результат");
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели E-mail!");
            }
        }
    }
}

