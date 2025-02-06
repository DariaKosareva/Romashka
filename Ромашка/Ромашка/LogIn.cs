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
using System.Data.SQLite;

namespace Ромашка
{
    public partial class LogIn : Form
    {
        User user = new User();

        bool sidebarExpand;
        Thread f1f2;

        public void openReg(object obj)
        {
            Application.Run(new Registr(user));

        }

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public void openS(object obj)
        {
            Application.Run(new SignIn(user));
        }

        public void openA(object obj)
        {
            Application.Run(new About(user));
        }

        public void openM(object obj)
        {
            Application.Run(new MiniGames(user));
        }

        public void openC(object obj)
        {
            Application.Run(new Contacts(user));
        }

        public void openAdmin(object obj)
        {
            Application.Run(new Admin(user));
        }
        public LogIn(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openA);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void HomePage_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openHP);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openS);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            user.Name = "";
            user.LastName = "";
            user.FatherName = "";
            user.Telephone = "";
            user.Login = "";
            user.Password = "";
            user.Email = "";
            MessageBox.Show("Вы успешно вышли из аккаунта!");
        }

        private void MiniGames_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openM);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void Contacts_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openC);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openReg);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        /*
            
            }*/

        private void button3_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM Users WHERE Login = @Login";
            using (var connection = new SQLiteConnection("DataSource=Teacher.db"))

            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", user.Login);
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reader.Close();
                            MessageBox.Show("Сначала выйдите из аккаунта!");
                        }
                        else
                        {
                            if (textBox1.Text == "admin" && textBox2.Text == "admin")
                            {
                                reader.Close();
                                MessageBox.Show("Добро пожаловать, Админ! Выводим данные.");
                                this.Close();
                                f1f2 = new Thread(openAdmin);
                                f1f2.SetApartmentState(ApartmentState.STA);
                                f1f2.Start();
                            }
                            else if (textBox1.Text == "" || textBox2.Text == "")
                            {
                                reader.Close();
                                MessageBox.Show("Пожалуйста, введите данные.");
                            }
                            else
                            {
                                reader.Close();
                                string login = textBox1.Text;
                                string query2 = $"SELECT * FROM Users WHERE Login = @Login";
                                using (var connection2 = new SQLiteConnection("DataSource=Teacher.db"))

                                {
                                    using (SQLiteCommand command2 = new SQLiteCommand(query2, connection2))
                                    {
                                        command.Parameters.AddWithValue("@Login", login);
                                        connection2.Open();
                                        using (SQLiteDataReader reader2 = command.ExecuteReader())
                                        {
                                            if (reader2.Read())
                                            {
                                                if (textBox2.Text == reader2["Password"].ToString())
                                                {
                                                    user.Name = reader2["Name"].ToString();
                                                    user.LastName = reader2["LastName"].ToString();
                                                    user.FatherName = reader2["FatherName"].ToString();
                                                    user.Telephone = reader2["Telephone"].ToString();
                                                    user.Login = reader2["Login"].ToString();
                                                    user.Password = reader2["Password"].ToString();
                                                    user.Email = reader2["Email"].ToString();
                                                    MessageBox.Show("Вы успешно вошли в аккаунт!");
                                                    textBox1.Text = "";
                                                    textBox1.ReadOnly = true;
                                                    textBox2.Text = "";
                                                    textBox2.ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Вы неправильно ввели пароль!");
                                                }
                                            }
                                            reader2.Close();
                                        }
                                        connection2.Close();
                                    }
                                }

                            }
                        }
                        connection.Close();
                    }
                }
            }
        }
    }
}
