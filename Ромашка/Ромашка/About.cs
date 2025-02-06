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
using System.IO;
using static Ромашка.database.User;
using static Ромашка.database;


namespace Ромашка
{
    public partial class About : Form
    {

        bool sidebarExpand;
        Thread f1f2;

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public void openS(object obj)
        {
            Application.Run(new SignIn(user));
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
        private User user;

        public About(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomePage_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openHP);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openS);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void ReadFileAndUpdateTextBox()
        {
            string filePath = "txt.txt";
            if (File.Exists(filePath))
            {
                try
                {
                    string fileContent = File.ReadAllText(filePath);

                    Invoke((MethodInvoker)delegate
                    {
                        textBox1.Text = fileContent;
                    });
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        textBox1.Text = "Ошибка чтения файла: " + ex.Message;
                    });
                }
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    textBox1.Text = "Файл не найден.";
                });
            }
        }


        private void About_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(ReadFileAndUpdateTextBox);
            thread.Start();
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
    }
}
