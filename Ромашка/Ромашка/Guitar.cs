using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static Ромашка.database.User;
using static Ромашка.database;

namespace Ромашка
{
    public partial class Guitar : Form
    {
        private User user;
        Thread f1f2;
        string[] music = new string[8];
        int index = 0;
        static string note = "";
        public class Melody
        {
            public int Index { get; set; }
            public string Sentesnse { get; set; }
            public string Name { get; set; }

        }

        private void playSimpleSound(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.firstr);
                        soundPlayer.Load();
                        soundPlayer.Play();
                        break;
                    }
                case 2:
                    {
                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.secstr);
                        soundPlayer.Load();
                        soundPlayer.Play();
                        break;
                    }
                case 3:
                    {
                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.thistr);
                        soundPlayer.Load();
                        soundPlayer.Play();
                        break;
                    }
                case 4:
                    {
                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.forstr);
                        soundPlayer.Load();
                        soundPlayer.Play();
                        break;
                    }
                case 5:
                    {
                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.fifstr);
                        soundPlayer.Load();
                        soundPlayer.Play();
                        break;
                    }
                case 6:
                    {
                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.sixstr);
                        soundPlayer.Load();
                        soundPlayer.Play();
                        break;
                    }
            }


        }

        static string play(string song, ref int i)
        {
            note = song;
            i++;
            return note;
        }

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public Guitar(User obj)
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                music[index] = play("пауза", ref index);
            }
            catch
            {
                label5.Text = "Слишком много нот!";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            label3.Visible = true;
            label7.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            Random random = new Random();
            int Ind = random.Next(1, 17);
            List<Melody> list = new List<Melody>();
            list.Add(new Melody { Index = 1, Sentesnse = "6-3-2-3-1-3-2-3", Name = "Перебор Восьмерка(Б3231323)!" });
            list.Add(new Melody { Index = 2, Sentesnse = "6-3-2-1-2-3-пауза-пауза", Name = "Перебор Шестерка(Б32123)!" });
            list.Add(new Melody { Index = 3, Sentesnse = "5-1-2-3-1-2-3-1", Name = "Перебор Scorpions!" });
            list.Add(new Melody { Index = 4, Sentesnse = "5-3-2-3-4-3-2-3", Name = "Перебор Четверка(БЗ23)!" });
            list.Add(new Melody { Index = 5, Sentesnse = "6-3-2-1-5-3-2-1", Name = "Перебор Четверка(БЗ21)!" });
            list.Add(new Melody { Index = 6, Sentesnse = "6-3-1-2-5-3-1-2", Name = "Перебор Четверка(БЗ22)!" });
            list.Add(new Melody { Index = 7, Sentesnse = "6-1-2-3-5-1-2-3", Name = "Перебор Четверка(Б123)!" });
            list.Add(new Melody { Index = 8, Sentesnse = "6-2-1-3-5-2-1-3", Name = "Перебор Четверка(Б213)!" });
            list.Add(new Melody { Index = 9, Sentesnse = "6-1-2-5-1-2-пауза-пауза", Name = "Перебор Шестерка(Б12Б12)!" });
            list.Add(new Melody { Index = 10, Sentesnse = "6-3-2-1-2-3-2-3", Name = "Перебор Восьмерка(Б3212323)!" });
            list.Add(new Melody { Index = 11, Sentesnse = "6-3-2-3-1-2-3-2", Name = "Перебор Восьмерка(Б3231232)!" });
            list.Add(new Melody { Index = 12, Sentesnse = "6-3-1-3-5-3-1-2", Name = "Перебор Восьмерка(Костер)!" });
            list.Add(new Melody { Index = 13, Sentesnse = "1-2-3-1-2-3-1-2", Name = "Перебор Восьмерка(12312312)!" });
            list.Add(new Melody { Index = 14, Sentesnse = "6-4-3-2-1-2-3-4", Name = "Перебор Длинная Восьмерка!" });
            list.Add(new Melody { Index = 15, Sentesnse = "6-1-2-3-4-1-2-3", Name = "Перебор Восьмерка(Б1234123)!" });
            list.Add(new Melody { Index = 16, Sentesnse = "6-4-3-4-5-4-3-4", Name = "Перебор Восьмерка(Вороны-ДДТ)!" });
            var disk = list.Where(x => (Ind == x.Index));
            foreach (var a in disk)
            {
                label3.Text = a.Sentesnse;
                label7.Text = a.Name;
            }
            index = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label5.Text = $"{music[0]}-{music[1]}-{music[2]}-{music[3]}-{music[4]}-{music[5]}-{music[6]}-{music[7]}";
            label4.Visible = true;
            label5.Visible = true;
            if (label5.Text == label3.Text)
            {
                label6.Text = "Правильно сыгранный перебор!";
            }
            else
            {
                label6.Text = "Неправильно сыгранный перебор!";
            }
            label6.Visible = true;
            index = 0;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                music[index] = play("1", ref index);
                playSimpleSound(1);
            }
            catch
            {
                label5.Text = "Слишком много нот!";
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                music[index] = play("2", ref index);
                playSimpleSound(2);
            }
            catch
            {
                label5.Text = "Слишком много нот!";
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                music[index] = play("3", ref index);
                playSimpleSound(3);
            }
            catch
            {
                label5.Text = "Слишком много нот!";
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                music[index] = play("4", ref index);
                playSimpleSound(4);
            }
            catch
            {
                label5.Text = "Слишком много нот!";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                music[index] = play("5", ref index);
                playSimpleSound(5);

            }
            catch
            {
                label5.Text = "Слишком много нот!";
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                music[index] = play("6", ref index);
                playSimpleSound(6);

            }
            catch
            {
                label5.Text = "Слишком много нот!";
            }
        }
    }
}
