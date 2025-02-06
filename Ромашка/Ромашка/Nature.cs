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
using System.Timers;
using System.Windows.Forms;
using static Ромашка.database.User;
using static Ромашка.database;

namespace Ромашка
{
    public partial class Nature : Form
    {
        User user = new User();
        int[] rainSpeeds = { 4, 6, 8, 3, 5 };
        int moveCount = 1;
        int rCount = 0;
        int moveCountSun = 0;
        Thread f1f2;
        int i = 1;

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public Nature(User obj)
        {
            InitializeComponent();
            user = obj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openHP);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                label2.Visible = false;
                Size size = new Size(44, 46);
                pictureBox5.Size = size;
                pictureBox5.Location = new Point(309, 200);
                timer1.Start();
                i++;
            }
            else if (i >= 5)
            {
                label2.Text = "Цветок уже выращен!";
                label2.Visible = true;
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox5.Top + pictureBox5.Height <= 450)
            {
                pictureBox5.Top += 5;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (i == 2)
            {
                label2.Visible = false;
                pictureBox7.Image = Properties.Resources.seeds_5698569;
                pictureBox7.Location = new Point(380, 200);
                timer2.Start();
            }
            else if (i >= 5)
            {
                label2.Text = "Цветок уже выращен!";
                label2.Visible = true;
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (i == 3)
            {
                label2.Visible = false;
                pictureBox9.Visible = true;
                pictureBox10.Visible = true;
                pictureBox11.Visible = true;
                pictureBox12.Visible = true;
                pictureBox13.Visible = true;
                timer3.Start();

                i++;
            }
            else if (i >= 5)
            {
                label2.Text = "Цветок уже выращен!";
                label2.Visible = true;
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (i == 4)
            {
                Size size = new Size(567, 534);
                pictureBox6.Size = size;
                pictureBox6.Location = new Point(-152, -183);
                label2.Visible = false;
                timer4.Start();
                i++;
            }
            else if (i >= 5)
            {
                label2.Text = "Цветок уже выращен!";
                label2.Visible = true;
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (moveCount <= 5)
            {
                if (moveCount % 2 == 1)
                {
                    pictureBox7.Top -= 10;
                }
                else
                {
                    pictureBox7.Top += 10;
                }
                moveCount++;
            }
            else
            {
                pictureBox8.Visible = true;
                i++;
                pictureBox7.Visible = false;
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (rCount <= 100)
            {
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            pictureBox9.Location = new Point(pictureBox9.Location.X, pictureBox9.Location.Y + rainSpeeds[i]);
                            if (pictureBox9.Location.Y > panel1.Size.Height + pictureBox9.Size.Height)
                            {
                                pictureBox9.Location = new Point(pictureBox9.Location.X, panel1.Top - pictureBox9.Size.Height);
                            }
                            break;
                        case 1:
                            pictureBox10.Location = new Point(pictureBox10.Location.X, pictureBox10.Location.Y + rainSpeeds[i]);
                            if (pictureBox10.Location.Y > panel1.Size.Height + pictureBox10.Size.Height)
                            {
                                pictureBox10.Location = new Point(pictureBox10.Location.X, panel1.Top - pictureBox10.Size.Height);
                            }
                            break;
                        case 2:
                            pictureBox11.Location = new Point(pictureBox11.Location.X, pictureBox11.Location.Y + rainSpeeds[i]);
                            if (pictureBox11.Location.Y > panel1.Size.Height + pictureBox11.Size.Height)
                            {
                                pictureBox11.Location = new Point(pictureBox11.Location.X, panel1.Top - pictureBox11.Size.Height);
                            }
                            break;
                        case 3:
                            pictureBox12.Location = new Point(pictureBox12.Location.X, pictureBox12.Location.Y + rainSpeeds[i]);
                            if (pictureBox12.Location.Y > panel1.Size.Height + pictureBox12.Size.Height)
                            {
                                pictureBox12.Location = new Point(pictureBox12.Location.X, panel1.Top - pictureBox12.Size.Height);
                            }
                            break;
                        case 4:
                            pictureBox13.Location = new Point(pictureBox13.Location.X, pictureBox13.Location.Y + rainSpeeds[i]);
                            if (pictureBox13.Location.Y > panel1.Size.Height + pictureBox13.Size.Height)
                            {
                                pictureBox13.Location = new Point(pictureBox13.Location.X, panel1.Top - pictureBox13.Size.Height);
                            }
                            break;
                    }
                }
                if (rCount == 50)
                {
                    pictureBox3.BackColor = Color.Brown;
                }
                rCount++;
            }
            else
            {
                pictureBox4.Visible = false;
                pictureBox2.BackColor = Color.Brown;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                pictureBox11.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                Size size = new Size(71, 87);
                pictureBox8.Size = size;
                pictureBox8.Image = Properties.Resources.fruit_12915457;
                pictureBox8.Location = new Point(300, 290);
                timer3.Stop();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (moveCountSun <= 100)
            {
                if (moveCountSun == 49)
                {
                    pictureBox2.BackColor = Color.FromArgb(166, 117, 64);
                }
                moveCountSun++;
            }
            else
            {
                label3.Visible = true;
                pictureBox3.BackColor = Color.FromArgb(166, 117, 64);
                Size size = new Size(159, 189);
                pictureBox8.Size = size;
                Random random = new Random();
                int Ind = random.Next(1, 7);
                switch (Ind)
                {
                    case 1:
                        {
                            pictureBox8.Image = Properties.Resources.chamomile_5344236;
                            label3.Text = "Это была ромашка!";
                            break;
                        }
                    case 2:
                        {
                            pictureBox8.Image = Properties.Resources.flower_14826677;
                            label3.Text = "Это была лилия!";
                            break;
                        }
                    case 3:
                        {
                            pictureBox8.Image = Properties.Resources.nature_12658818;
                            label3.Text = "Это был тюльпан!";
                            break;
                        }
                    case 4:
                        {
                            pictureBox8.Image = Properties.Resources.tulip_10132895;
                            label3.Text = "Это был тюльпан!";
                            break;
                        }
                    case 5:
                        {
                            pictureBox8.Image = Properties.Resources.tulip_4750904;
                            label3.Text = "Это был тюльпан!";
                            break;
                        }
                    case 6:
                        {
                            pictureBox8.Image = Properties.Resources.tulip_6509318;
                            label3.Text = "Это был тюльпан!";
                            break;
                        }
                }
                pictureBox6.Visible = false;
                pictureBox8.Location = new Point(250, 220);
                i++;
                timer4.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            Size size3 = new Size(91, 91);
            pictureBox6.Size = size3;
            pictureBox6.Location = new Point(18, 18);
            pictureBox6.Visible = true;
            label2.Visible = false;
            i = 1;
            Size size = new Size(44, 39);
            pictureBox8.Size = size;
            pictureBox8.Image = Properties.Resources.plant_8809609;
            pictureBox8.Location = new Point(300, 322);
            pictureBox4.Visible = true;
            pictureBox8.Visible = false;
            Size size2 = new Size(59, 59);
            pictureBox5.Size = size2;
            pictureBox5.Location = new Point(465, 35);
            pictureBox7.Visible = true;
            pictureBox7.Location = new Point(142, 18);
            pictureBox7.Image = Properties.Resources.flour_931694;
            moveCount = 1;
            rCount = 0;
            moveCountSun = 0;
            pictureBox2.BackColor = Color.FromArgb(166, 117, 64);
            pictureBox3.BackColor = Color.FromArgb(166, 117, 64);
        }

        private void Nature_Load(object sender, EventArgs e)
        {

        }
    }
}
