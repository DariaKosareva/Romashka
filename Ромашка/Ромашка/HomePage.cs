using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using static Ромашка.database.User;
using static Ромашка.database;

namespace Ромашка
{
    public partial class Home : Form
    {
        int[] rainSpeeds = { 4, 6, 8, 3, 5};
        bool sidebarExpand;

        Thread f1f2;
        private User user;

        public void openA(object obj)
        {
            Application.Run(new About(user));
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

        public Home(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer2.Start();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        pictureBox15.Location = new Point(pictureBox15.Location.X, pictureBox15.Location.Y + rainSpeeds[i]);
                        if (pictureBox15.Location.Y > panel3.Size.Height + pictureBox15.Size.Height)
                        {
                            pictureBox15.Location = new Point(pictureBox15.Location.X, 0 - pictureBox15.Size.Height);
                        }
                        break;
                    case 1:
                        pictureBox16.Location = new Point(pictureBox16.Location.X, pictureBox16.Location.Y + rainSpeeds[i]);
                        if (pictureBox16.Location.Y > panel3.Size.Height + pictureBox16.Size.Height)
                        {
                            pictureBox16.Location = new Point(pictureBox16.Location.X, 0 - pictureBox16.Size.Height);
                        }
                        break;
                    case 2:
                        pictureBox17.Location = new Point(pictureBox17.Location.X, pictureBox17.Location.Y + rainSpeeds[i]);
                        if (pictureBox17.Location.Y > panel3.Size.Height + pictureBox17.Size.Height)
                        {
                            pictureBox17.Location = new Point(pictureBox17.Location.X, 0 - pictureBox17.Size.Height);
                        }
                        break;
                    case 3:
                        pictureBox18.Location = new Point(pictureBox18.Location.X, pictureBox18.Location.Y + rainSpeeds[i]);
                        if (pictureBox18.Location.Y > panel3.Size.Height + pictureBox18.Size.Height)
                        {
                            pictureBox18.Location = new Point(pictureBox18.Location.X, 0 - pictureBox18.Size.Height);
                        }
                        break;
                    case 4:
                        pictureBox19.Location = new Point(pictureBox19.Location.X, pictureBox19.Location.Y + rainSpeeds[i]);
                        if (pictureBox19.Location.Y > panel3.Size.Height + pictureBox19.Size.Height)
                        {
                            pictureBox19.Location = new Point(pictureBox19.Location.X, 0 - pictureBox19.Size.Height);
                        }
                        break;
                }
            }
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

        private void SignIn_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openS);
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

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ромашка - приложение для записи на наши уроки. При необходимости помощи звоните по телефону в разделе контакты.", "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
