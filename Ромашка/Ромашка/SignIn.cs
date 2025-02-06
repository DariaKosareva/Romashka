using Microsoft.Data.Sqlite;
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
using System.Windows.Forms.DataVisualization.Charting;
using static Ромашка.database.User;
using static Ромашка.database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SQLite;

namespace Ромашка
{
    public partial class SignIn : Form
    {
        User user = new User();
        bool sidebarExpand;
        Thread f1f2;

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public void openA(object obj)
        {
            Application.Run(new About(user));
        }

        public void openL(object obj)
        {
            Application.Run(new LogIn(user));
        }

        public void openM(object obj)
        {
            Application.Run(new MiniGames(user));
        }

        public void openC(object obj)
        {
            Application.Run(new Contacts(user));
        }

        public void openSeeTeach(object obj)
        {
            Application.Run(new seeteach(user));
        }

        public void openCheckZap(object obj)
        {
            Application.Run(new CheckZap(user));
        }


        public SignIn(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openA);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
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

        private void HomePage_Click_1(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openHP);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openL);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
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

        private void button2_Click(object sender, EventArgs e)
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
                            this.Close();
                            f1f2 = new Thread(openSeeTeach);
                            f1f2.SetApartmentState(ApartmentState.STA);
                            f1f2.Start();
                        }
                        else
                        {
                            MessageBox.Show("Вы не вошли в аккаунт!");
                        }
                    }
                    connection.Close();
                }
            }

        }

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
                            this.Close();
                            f1f2 = new Thread(openCheckZap);
                            f1f2.SetApartmentState(ApartmentState.STA);
                            f1f2.Start();
                        }
                        else
                        {
                            MessageBox.Show("Вы не вошли в аккаунт!");
                        }
                    }
                    connection.Close();
                }
            }
        }
    }
}
