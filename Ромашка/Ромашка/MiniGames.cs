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
    public partial class MiniGames : Form
    {

        bool sidebarExpand;
        Thread f1f2;
        User user = new User();

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

        public void openA(object obj)
        {
            Application.Run(new About(user));
        }

        public void openC(object obj)
        {
            Application.Run(new Contacts(user));
        }

        public void openGuitar(object obj)
        {
            Application.Run(new Guitar(user));
        }

        public void openChinese(object obj)
        {
            Application.Run(new Chinese(user));
        }

        public void openLiter(object obj)
        {
            Application.Run(new Liter(user));
        }

        public void openChemistry(object obj)
        {
            Application.Run(new Chemistry(user));
        }

        public void openCulture(object obj)
        {
            Application.Run(new Culture(user));
        }

        public void openNature(object obj)
        {
            Application.Run(new Nature(user));
        }

        public MiniGames(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void MiniGames_Load(object sender, EventArgs e)
        {
        }

        private void HomePage_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openHP);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openGuitar);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openChinese);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openLiter);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openChemistry);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openCulture);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openNature);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
