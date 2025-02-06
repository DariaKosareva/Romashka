using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ромашка.database.User;
using static Ромашка.database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ромашка
{
    public partial class Admin : Form
    {

        User user = new User();
        Thread f1f2;
        public enum Subj
        {
            Гитара,
            Китайский,
            Литература,
            Физика,
            Химия,
            Культуролог,
            Натуралист,
            Русский,
            Пианино,
            Балет,
            Вальс,
            Цимбалы,
            Вышивание,
            Вязание,
            Рукоделие
        }

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public Admin(User obj)
        {
            InitializeComponent();
            user = obj;
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openHP);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
            comboBox1.DataSource = Enum.GetValues(typeof(Subj));
            using (var connection = new SQLiteConnection("DataSource=Teacher.db"))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    string name = "SELECT * FROM Users";
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(name, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    string name = "SELECT * FROM Teacher";
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(name, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                }

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    string name = "SELECT * FROM Studies";
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(name, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView3.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Study = textBox1.Text;
            string sql = "DELETE FROM Users WHERE Study = @Study";
            string sql2 = "DELETE FROM Studies WHERE Study = @Study";
            using (var connection = new SQLiteConnection("DataSource=Teacher.db"))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Study", Study);
                    int rowsAffected = command.ExecuteNonQuery();
                }

                using (SQLiteCommand command = new SQLiteCommand(sql2, connection))
                {
                    command.Parameters.AddWithValue("@Study", Study);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Пользователь успешно удален.");
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином не найден.");
                    }
                    textBox1.Text = "";
                }
                connection.Close();
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                try
                {
                    string Name, LastName, FatherName, Study, Price, Age, Sex;
                    Name = textBox2.Text;
                    LastName = textBox3.Text;
                    FatherName = textBox4.Text;
                    Price = textBox6.Text;
                    Study = comboBox1.Text;
                    Age = textBox7.Text;
                    Sex = "";

                    if (radioButton1.Checked)
                    {
                        Sex = "Мужской";
                    }
                    else if (radioButton2.Checked)
                    {
                        Sex = "Женский";
                    }

                    if (int.TryParse(Price, out int number))
                    {
                        if (number >= 20 && number <= 40)
                        {
                            if (int.TryParse(Age, out int number2))
                            {
                                if (number2 >= 19 && number2 <= 35)
                                {
                                    byte[] imageBytes = ImageToByteArray(pictureBox.Image);
                                    string connectionString = "Data Source=Teacher.db;Version=3;";
                                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                                    {
                                        connection.Open();
                                        string query2 = "INSERT INTO Teacher (Name, LastName, FatherName, Price, Study, Age, Sex, Photo) VALUES (@Name, @LastName, @FatherName, @Price, @Study, @Age, @Sex, @Photo)";
                                        using (SQLiteCommand command2 = new SQLiteCommand(query2, connection))
                                        {
                                            command2.Parameters.AddWithValue("@Name", Name);
                                            command2.Parameters.AddWithValue("@LastName", LastName);
                                            command2.Parameters.AddWithValue("@FatherName", FatherName);
                                            command2.Parameters.AddWithValue("@Price", Price);
                                            command2.Parameters.AddWithValue("@Study", Study);
                                            command2.Parameters.AddWithValue("@Age", Age);
                                            command2.Parameters.AddWithValue("@Sex", Sex);
                                            command2.Parameters.AddWithValue("@Photo", imageBytes);
                                            int rowsAffected = command2.ExecuteNonQuery();
                                        }
                                        connection.Close();
                                    }
                                    MessageBox.Show("Преподаватель успешно добавлен!");
                                }
                                else
                                {
                                    MessageBox.Show("Возраст не находится в диапазоне от 19 до 35.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Возраст не является числом.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Цена не находится в диапазоне от 20 до 40.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Цена не число.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении фотографии учителя: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Загрузите фотографию учителя перед сохранением.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Выберите фотографию учителя";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox.Image = Image.FromFile(imagePath);
            }
        }

        private void Admin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
