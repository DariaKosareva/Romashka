using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Ромашка.database.User;
using static Ромашка.database;

namespace Ромашка
{
    public partial class Chemistry : Form
    {
        private User user;

        int i = 1, j = 1, k = 1, o = 1;
        int El1i = 0, El2i = 0, El3i = 0;
        string FileN = "";
        Thread f1f2;
        public void PlaySound()
        {
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.water);
            soundPlayer.Load();
            soundPlayer.Play();
        }
        public class Formule
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Formul { get; set; }
            public string El1 { get; set; }
            public int El1Ind { get; set; }
            public string El2 { get; set; }
            public int El2Ind { get; set; }
            public string El3 { get; set; }
            public int El3Ind { get; set; }

        }
        private void Cleaning()
        {
            chart1.Series[0].Points.Clear();
            i = 1;
            j = 1;
            k = 1;
            o = 1;
            pictureBox9.Height = 37;
            pictureBox8.Height = 37;
            pictureBox7.Height = 37;
            pictureBox10.Height = 37;
            pictureBox11.Height = 37;
            pictureBox12.Height = 37;
            pictureBox13.Height = 37;
            pictureBox14.Height = 37;
            pictureBox15.Height = 37;
            pictureBox16.Height = 0;
            pictureBox17.Height = 0;
            pictureBox18.Height = 0;
            pictureBox19.Height = 0;
            pictureBox20.Height = 0;
            label11.Visible = false;
        }
        private void SaveChartToImage(Chart chart, string Name)
        {

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Сохранить изображение как ...";
                sfd.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";
                sfd.AddExtension = true;
                sfd.FileName = Name;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1: chart.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp); break;
                        case 2: chart.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); break;
                        case 3: chart.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); break;
                    }
                }
            }
        }

        private void UpdateChart()
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].Points.AddXY(label1.Text, j - 1);
            chart1.Series["Series1"].Points.AddXY(label2.Text, k - 1);
            chart1.Series["Series1"].Points.AddXY(label3.Text, o - 1);
            chart1.Invalidate();
            chart1.Update();
        }

        public void prob1(int i, int j)
        {
            if (j > 0)
            {
                switch (i)
                {
                    case 1:
                        {
                            PlaySound();
                            timer2.Start();
                            pictureBox16.BackColor = Color.FromArgb(192, 255, 192);
                            break;
                        }
                    case 2:
                        {
                            PlaySound();
                            timer2.Start();
                            pictureBox17.BackColor = Color.FromArgb(192, 255, 192);
                            break;
                        }
                    case 3:
                        {
                            PlaySound();
                            timer2.Start();
                            pictureBox18.BackColor = Color.FromArgb(192, 255, 192);
                            break;
                        }
                    case 4:
                        {
                            PlaySound();
                            timer2.Start();
                            pictureBox19.BackColor = Color.FromArgb(192, 255, 192);
                            break;
                        }
                    case 5:
                        {
                            PlaySound();
                            timer2.Start();
                            pictureBox20.BackColor = Color.FromArgb(192, 255, 192);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                timer1.Start();
            }
        }
        public void prob2(int i, int k)
        {
            if (k > 0)
            {
                switch (i)
                {
                    case 1:
                        {
                            PlaySound();
                            timer3.Start();
                            pictureBox16.BackColor = Color.FromArgb(255, 192, 192);
                            break;
                        }
                    case 2:
                        {
                            PlaySound();
                            timer3.Start();
                            pictureBox17.BackColor = Color.FromArgb(255, 192, 192);
                            break;
                        }
                    case 3:
                        {
                            PlaySound();
                            timer3.Start();
                            pictureBox18.BackColor = Color.FromArgb(255, 192, 192);
                            break;
                        }
                    case 4:
                        {
                            PlaySound();
                            timer3.Start();
                            pictureBox19.BackColor = Color.FromArgb(255, 192, 192);
                            break;
                        }
                    case 5:
                        {
                            PlaySound();
                            timer3.Start();
                            pictureBox20.BackColor = Color.FromArgb(255, 192, 192);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                timer1.Start();
            }
        }
        public void prob3(int i, int o)
        {
            if (o > 0)
            {
                switch (i)
                {
                    case 1:
                        {
                            PlaySound();
                            timer4.Start();
                            pictureBox16.BackColor = Color.FromArgb(255, 192, 255);
                            break;
                        }
                    case 2:
                        {
                            PlaySound();
                            timer4.Start();
                            pictureBox17.BackColor = Color.FromArgb(255, 192, 255);
                            break;
                        }
                    case 3:
                        {
                            PlaySound();
                            timer4.Start();
                            pictureBox18.BackColor = Color.FromArgb(255, 192, 255);
                            break;
                        }
                    case 4:
                        {
                            PlaySound();
                            timer4.Start();
                            pictureBox19.BackColor = Color.FromArgb(255, 192, 255);
                            break;
                        }
                    case 5:
                        {
                            PlaySound();
                            timer4.Start();
                            pictureBox20.BackColor = Color.FromArgb(255, 192, 255);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                timer1.Start();
            }
        }

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public Chemistry(User obj)
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
            prob1(i, j);
        }

        private void Chemistry_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateChart();
            switch (i)
            {
                case 1:
                    {
                        pictureBox16.Height += 2;
                        if (pictureBox16.Height == pictureBox16.MaximumSize.Height)
                        {
                            timer1.Stop();
                            i++;
                        }
                        break;
                    }
                case 2:
                    {
                        pictureBox17.Height += 2;
                        if (pictureBox17.Height == pictureBox17.MaximumSize.Height)
                        {
                            timer1.Stop();
                            i++;
                        }
                        break;
                    }
                case 3:
                    {
                        pictureBox18.Height += 2;
                        if (pictureBox18.Height == pictureBox18.MaximumSize.Height)
                        {
                            timer1.Stop();
                            i++;
                        }
                        break;
                    }
                case 4:
                    {
                        pictureBox19.Height += 2;
                        if (pictureBox19.Height == pictureBox19.MaximumSize.Height)
                        {
                            timer1.Stop();
                            i++;
                        }
                        break;
                    }
                case 5:
                    {
                        pictureBox20.Height += 2;
                        if (pictureBox20.Height == pictureBox20.MaximumSize.Height)
                        {
                            timer1.Stop();
                            i++;
                        }
                        break;
                    }
                default:
                    {
                        timer1.Stop();
                        break;
                    }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            Cleaning();
            chart1.Visible = true;
            Random random = new Random();
            int Ind = random.Next(1, 11);
            List<Formule> list = new List<Formule>();
            list.Add(new Formule { Index = 1, Name = "Кетен", Formul = "C2H2O", El1 = "C", El1Ind = 2, El2 = "H", El2Ind = 2, El3 = "O", El3Ind = 1});
            list.Add(new Formule { Index = 2, Name = "Карбонат кальция", Formul = "Ca(CO)3", El1 = "Ca", El1Ind = 1, El2 = "C", El2Ind = 0, El3 = "CO", El3Ind = 3 });
            list.Add(new Formule { Index = 3, Name = "Карбонат натрия", Formul = "Na2CO3", El1 = "Na", El1Ind = 2, El2 = "C", El2Ind = 0, El3 = "CO", El3Ind = 3 });
            list.Add(new Formule { Index = 4, Name = "Глиоксаль", Formul = "H2C2O2", El1 = "H2", El1Ind = 1, El2 = "C2", El2Ind = 1, El3 = "O2", El3Ind = 1 });
            list.Add(new Formule { Index = 5, Name = "Перманганат калия", Formul = "KMnO4", El1 = "K", El1Ind = 1, El2 = "Mn", El2Ind = 1, El3 = "O2", El3Ind = 2 });
            list.Add(new Formule { Index = 6, Name = "Хлорат калия", Formul = "KClO3", El1 = "K", El1Ind = 1, El2 = "Cl", El2Ind = 1, El3 = "O", El3Ind = 3 });
            list.Add(new Formule { Index = 7, Name = "Иодная кислота", Formul = "H5IO6", El1 = "H5", El1Ind = 1, El2 = "I1", El2Ind = 1, El3 = "O2", El3Ind = 3 });
            list.Add(new Formule { Index = 8, Name = "Иодноватая кислота", Formul = "HIO3", El1 = "I", El1Ind = 1, El2 = "OH", El2Ind = 1, El3 = "O", El3Ind = 2 });
            list.Add(new Formule { Index = 9, Name = "Оксид алюминия", Formul = "Al2O3", El1 = "Al", El1Ind = 2, El2 = "O2", El2Ind = 0, El3 = "O", El3Ind = 3 });
            list.Add(new Formule { Index = 10, Name = "Бромноватая кислота", Formul = "HBrO3", El1 = "OH", El1Ind = 1, El2 = "Br", El2Ind = 1, El3 = "O", El3Ind = 2 });
            var disk = list.Where(x => (Ind == x.Index));
            foreach (var a in disk)
            {
                chart1.Titles.Clear();
                FileN = a.Name;
                chart1.Titles.Add(a.Name);
                label10.Text = a.Name;
                label4.Text = a.Formul;
                label1.Text = a.El1;
                label2.Text = a.El2;
                label3.Text = a.El3;
                El1i = a.El1Ind;
                El2i = a.El2Ind;
                El3i = a.El3Ind;
            }
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label10.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            prob1(i, j);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            prob1(i, j);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            prob1(i, j);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            prob2(i, k);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            prob2(i, k);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            prob2(i, k);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            prob2(i, k);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            prob3(i, o);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            prob3(i, o);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            prob3(i, o);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (j - 1 == El1i && k - 1 == El2i && o - 1 == El3i)
            {
                label11.Text = "Элемент составлен правильно!";
                button6.Visible = true;
            }
            else
            {
                label11.Text = "Элемент составлен неправильно!";
            }
            label11.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveChartToImage(chart1, FileN);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            prob3(i, o);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button6.Visible = false; 
            Cleaning();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            switch (j)
            {
                case 3:
                    {
                        pictureBox7.Height -= 2;
                        if (pictureBox7.Height == pictureBox7.MinimumSize.Height)
                        {
                            timer2.Stop();
                            j++;
                        }
                        break;
                    }
                case 2:
                    {
                        pictureBox8.Height -= 2;
                        if (pictureBox8.Height == pictureBox8.MinimumSize.Height)
                        {
                            timer2.Stop();
                            j++;
                        }
                        break;
                    }
                case 1:
                    {
                        pictureBox9.Height -= 2;
                        if (pictureBox9.Height == pictureBox9.MinimumSize.Height)
                        {
                            timer2.Stop();
                            j++;
                        }
                        break;
                    }
                default:
                    {
                        timer2.Stop();
                        break;
                    }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            switch (k)
            {
                case 3:
                    {
                        pictureBox12.Height -= 2;
                        if (pictureBox12.Height == pictureBox12.MinimumSize.Height)
                        {
                            timer3.Stop();
                            k++;
                        }
                        break;
                    }
                case 2:
                    {
                        pictureBox11.Height -= 2;
                        if (pictureBox11.Height == pictureBox11.MinimumSize.Height)
                        {
                            timer3.Stop();
                            k++;
                        }
                        break;
                    }
                case 1:
                    {
                        pictureBox10.Height -= 2;
                        if (pictureBox10.Height == pictureBox10.MinimumSize.Height)
                        {
                            timer3.Stop();
                            k++;
                        }
                        break;
                    }
                default:
                    {
                        timer3.Stop();
                        break;
                    }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            switch (o)
            {
                case 3:
                    {
                        pictureBox15.Height -= 2;
                        if (pictureBox15.Height == pictureBox15.MinimumSize.Height)
                        {
                            timer4.Stop();
                            o++;
                        }
                        break;
                    }
                case 2:
                    {
                        pictureBox14.Height -= 2;
                        if (pictureBox14.Height == pictureBox14.MinimumSize.Height)
                        {
                            timer4.Stop();
                            o++;
                        }
                        break;
                    }
                case 1:
                    {
                        pictureBox13.Height -= 2;
                        if (pictureBox13.Height == pictureBox13.MinimumSize.Height)
                        {
                            timer4.Stop();
                            o++;
                        }
                        break;
                    }
                default:
                    {
                        timer4.Stop();
                        break;
                    }
            }
        }
    }
}
