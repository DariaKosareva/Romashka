using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ромашка.database;
using static Ромашка.Liter;
using System.Data.SQLite;

namespace Ромашка
{
    public partial class CheckZap : Form
    {

        Thread f1f2;

        User user = new User();

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }
        public CheckZap(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void CheckZap_Load(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("DataSource=Teacher.db"))
            {
                string login = user.Login;
                connection.Open();
                string query = "SELECT * FROM Studies";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                int y = 50;

                while (reader.Read())
                {
                    if (reader["Login"].ToString() == login)
                    {
                        string data1 = reader["Name"].ToString();
                        string data2 = reader["FatherName"].ToString();
                        string data3 = reader["LastName"].ToString();
                        string data4 = reader["Study"].ToString();
                        string data5 = "Преподаватель:  " + reader["TeacherName"].ToString();
                        string data6 = reader["TeacherLastName"].ToString();
                        string data7 = "Дата: " + reader["Date"].ToString();
                        string data8 = "Цена: " + reader["Price"].ToString();

                        Panel panel = new Panel();
                        panel.BackColor = Color.LightGray;
                        panel.BorderStyle = BorderStyle.Fixed3D;
                        panel.Padding = new Padding(10);
                        panel.Margin = new Padding(0, 0, 0, 10);

                        Label label1 = new Label();
                        label1.Text = data1;
                        label1.Font = new Font("Arial", 12, FontStyle.Bold);
                        label1.AutoSize = true;
                        label1.Location = new Point(10, 10);
                        panel.Controls.Add(label1);

                        Label label2 = new Label();
                        label2.Text = data2;
                        label2.Font = new Font("Arial", 12, FontStyle.Bold);
                        label2.AutoSize = true;
                        label2.Location = new Point(label1.Right + 10, 10);
                        panel.Controls.Add(label2);

                        Label label3 = new Label();
                        label3.Text = data3;
                        label3.Font = new Font("Arial", 12, FontStyle.Bold);
                        label3.AutoSize = true;
                        label3.Location = new Point(label2.Right + 10, 10);
                        panel.Controls.Add(label3);

                        Label label4 = new Label();
                        label4.Text = data4;
                        label4.AutoSize = true;
                        label4.Font = new Font("Arial", 12);
                        label4.Location = new Point(10, 37);
                        panel.Controls.Add(label4);

                        Label label5 = new Label();
                        label5.Text = data5;
                        label5.AutoSize = true;
                        label5.Font = new Font("Arial", 12);
                        label5.Location = new Point(10, 70);
                        panel.Controls.Add(label5);
                        label1.AutoSize = true;

                        Label label6 = new Label();
                        label6.Text = data6;
                        label6.Font = new Font("Arial", 12);
                        label6.Location = new Point(label5.Right + 2, 70);
                        label6.AutoSize = true;
                        panel.Controls.Add(label6);

                        Label label7 = new Label();
                        label7.Text = data7;
                        label7.Font = new Font("Arial", 12);
                        label7.AutoSize = true;
                        label7.Location = new Point(10, 102);
                        panel.Controls.Add(label7);

                        Label label8 = new Label();
                        label8.Text = data8;
                        label8.Font = new Font("Arial", 12);
                        label8.AutoSize = true;
                        label8.Location = new Point(10, 134);
                        panel.Controls.Add(label8);


                        panel.Location = new Point(10, y);
                        panel.Size = new Size(620, 160);
                        Controls.Add(panel);

                        PictureBox pictureBox1 = new PictureBox();
                        pictureBox1.Image = Properties.Resources.flower_9591128;
                        pictureBox1.Location = new Point(panel.Width - 160, 5);
                        pictureBox1.Size = new Size(150, 150);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        panel.Controls.Add(pictureBox1);

                        y += panel.Height + 10;
                    }
                }

                reader.Close();
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openHP);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }
    }
}
