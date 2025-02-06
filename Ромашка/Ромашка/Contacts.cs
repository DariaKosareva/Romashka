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


namespace Ромашка
{
    public partial class Contacts : Form
    {
        bool sidebarExpand;
        Thread f1f2;
        private User user;
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

        public void openA(object obj)
        {
            Application.Run(new About(user));
        }

        public Contacts(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void Contacts_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openA);
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public delegate void LinkClickedDelegate(object sender, LinkLabelLinkClickedEventArgs e);

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://twitter.com/home?lang=ru");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://www.instagram.com/");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://www.tiktok.com/ru-RU/");
        }

        private void OpenUrl(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LinkClickedDelegate linkClickedDelegate = null;
            linkClickedDelegate += LinkLabel1_LinkClicked;
            linkClickedDelegate += LinkLabel2_LinkClicked;
            linkClickedDelegate += LinkLabel3_LinkClicked;
            linkClickedDelegate.Invoke(this, new LinkLabelLinkClickedEventArgs(null));
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
