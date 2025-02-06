using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static Ромашка.database;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
using System.Data.SqlClient;
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace Ромашка
{
    public partial class seeteach : Form
    {
        Thread f1f2;
        User user = new User();
        bool boo = false;
        public seeteach(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void SendEmail(string userEmail, string lastName, string name, string subject, string date)
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
                mailMessage.Subject = "Запись в 'Ромашку'";

                StringBuilder bodyBuilder = new StringBuilder();
                bodyBuilder.AppendLine($"Уважаемый покупатель, Вы записаны на занятие в Учреждение внеклассного образования 'Ромашка'!");
                bodyBuilder.AppendLine($"Ваш преподаватель - {lastName} {name}");
                bodyBuilder.AppendLine($"Предмет, на который вы были записаны - {subject}");
                bodyBuilder.AppendLine($"Дата занятия - {date}");
                bodyBuilder.AppendLine($"Вскоре мы свяжемся с вами для уточнения записи!");
                bodyBuilder.AppendLine("С любовью, 'Ромашка'");

                mailMessage.Body = bodyBuilder.ToString();

                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

            }
            catch
            {
                MessageBox.Show("Ошибка при отправлении уведомления на почту");
            }
        }

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        private void seeteach_Load(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("DataSource=Teacher.db"))
            {
                connection.Open();
                string query = "SELECT * FROM Teacher";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                int y = 50;

                while (reader.Read())
                {
                    string data1 = reader["Name"].ToString();
                    string data2 = reader["FatherName"].ToString();
                    string data3 = reader["LastName"].ToString();
                    string data4 = reader["Study"].ToString();
                    string data5 = "Цена " + reader["Price"].ToString();
                    string data6 = "Возраст " + reader["Age"].ToString();
                    string data7 = "Пол " + reader["Sex"].ToString();

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
                    label4.Font = new Font("Arial", 12);
                    label4.Location = new Point(10, 37);
                    panel.Controls.Add(label4);

                    Label label5 = new Label();
                    label5.Text = data5;
                    label5.Font = new Font("Arial", 12);
                    label5.Location = new Point(10, 70);
                    panel.Controls.Add(label5);
                    label1.AutoSize = true;

                    Label label6 = new Label();
                    label6.Text = data6;
                    label6.Font = new Font("Arial", 12);
                    label6.Location = new Point(10, 102);
                    label1.AutoSize = true;
                    panel.Controls.Add(label6);

                    Label label7 = new Label();
                    label7.Text = data7;
                    label7.Font = new Font("Arial", 12);
                    label1.AutoSize = true;
                    label7.Location = new Point(10, 134);
                    panel.Controls.Add(label7);

                    string price = reader["Price"].ToString();
                    string date = "00.00.00"; 

                    DateTimePicker dateTimePicker = new DateTimePicker();
                    dateTimePicker.Format = DateTimePickerFormat.Short;
                    dateTimePicker.ShowUpDown = true;
                    dateTimePicker.Location = new Point(10, 166);

                    Button okButton = new Button();
                    okButton.Text = "OK";
                    okButton.Font = new Font("Arial", 9);
                    okButton.Location = new Point(10, 198);
                    okButton.Click += (senderBut, eBut) =>
                    {
                        date = dateTimePicker.Value.ToShortDateString();
                        DateTime dateFromString = DateTime.Parse(date);
                        DateTime currentDate = DateTime.Today;
                        int comparisonResult = DateTime.Compare(dateFromString, currentDate);
                        if (comparisonResult < 0)
                        {
                            MessageBox.Show("Дата не может быть раньше времени записи!");
                        }
                        else if (comparisonResult > 0)
                        {
                            boo = true;
                        }
                        else
                        {
                            MessageBox.Show("Нелзя записаться на сегодня!");
                        }
                        
                    };

                    Button button = new Button();
                    button.Text = "Записать";
                    button.Font = new Font("Arial", 9);
                    button.Location = new Point(10, 230);
                    string name = data1;
                    string lastName = data3;
                    string study = reader["Study"].ToString();


                    button.Click += (buttonSender, buttonEvent) =>
                    {
                        if (boo == true)
                        {

                            using (var connection2 = new SQLiteConnection("DataSource=Teacher.db"))
                            {
                                connection2.Open();
                                string query2 = $"INSERT INTO Studies (Name, LastName, FatherName, Study, TeacherName, TeacherLastName, Date, Price, Login) VALUES (@Name, @LastName, @FatherName, @Study, @TeacherName, @TeacherLastName, @Date, @Price, @Login)";
                                using (SQLiteCommand command2 = new SQLiteCommand(query2, connection2))
                                {
                                    command2.Parameters.AddWithValue("@Name", user.Name);
                                    command2.Parameters.AddWithValue("@LastName", user.LastName);
                                    command2.Parameters.AddWithValue("@FatherName", user.FatherName);
                                    command2.Parameters.AddWithValue("@Study", study);
                                    command2.Parameters.AddWithValue("@TeacherName", name);
                                    command2.Parameters.AddWithValue("@TeacherLastName", lastName);
                                    command2.Parameters.AddWithValue("@Date", date);
                                    command2.Parameters.AddWithValue("@Price", price);
                                    command2.Parameters.AddWithValue("@Login", user.Login);

                                    int rowsAffected = command2.ExecuteNonQuery();
                                }
                                MessageBox.Show("Вы были успешно записаны!");
                                boo = false;
                                SendEmail(user.Email, lastName, name, study, date);
                                connection2.Close();

                            }

                        }

                    };

                    byte[] imageData = (byte[])reader["Photo"];
                    Image image;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        image = Image.FromStream(ms);
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = image;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new Point(340, 10);
                    pictureBox.Size = new Size(250, 250);
                    panel.Controls.Add(pictureBox);

                    panel.Controls.Add(dateTimePicker);
                    panel.Controls.Add(okButton);
                    panel.Controls.Add(button);

                    panel.Location = new Point(10, y);
                    panel.Size = new Size(600, 270);
                    Controls.Add(panel);

                    y += panel.Height + 10;


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
