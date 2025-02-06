using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using static Ромашка.database.User;
using static Ромашка.database;

namespace Ромашка
{


    public partial class Loading : Form
    {
        User user = new User();
        float initialPercentage = 0;
        private int directionY = 1; 
        Thread f1f2;

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        public void open(object obj)
        {
            Application.Run(new Home(user));
        }
        
        public Loading()
        {
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            infoLabel.BackColor = Color.Transparent;
            dateLabel.BackColor = Color.Transparent;
            timeLabel.BackColor = Color.Transparent;

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            timer3.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox5.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox8.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox6.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox7.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox9.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox12.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox14.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox16.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox13.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox15.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox17.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            timer1.Start();
            timer2.Start();

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            Random random = new Random();
            int proc = random.Next(0, 21);
            initialPercentage += proc;
            if (initialPercentage > 100)
            {
                initialPercentage = 100;
            }

            label1.Text = (int)initialPercentage + " %";

            if ((int)initialPercentage == 100)
            {
                label1.Text = "100 %";
                this.timer2.Stop();
                button1.Visible = true;
                button2.Visible = true;
            }
            
        }


        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            int step = 5; 
                if (panel2.Top + panel2.Height >= 350 && directionY == 1)
                {
                    directionY = -1;
                }
                else if (panel2.Top <= 0 && directionY == -1)
                {
                    directionY = 1;
                }
                panel2.Top += step * directionY;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(open);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void Loading_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Ромашка - приложение для записи на наши уроки. Нажмите на элемент, чтобы получить помощь.", "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void panel2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Это панель с анимацией.");
        }

        private void button1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Это кнопка, чтобы зайти в приложение.");
        }

        private void button2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Это кнопка, чтобы выйти из приложения.");
        }

        private void label1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Это процент загрузки.");
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show("Это панель состояния, показывающая время.");
        }
    }
}
