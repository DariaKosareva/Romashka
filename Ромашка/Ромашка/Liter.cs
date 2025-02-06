using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ромашка.database.User;
using static Ромашка.database;


namespace Ромашка
{
    public partial class Liter : Form
    {
        string selectedIt1 = "";
        private User user;
        string selectedIt2 = "";

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Style1 { get; set; }
            public string Style2 { get; set; }
            public string Contry { get; set; }
            public int Year { get; set; }
            public Image PictureWay { get; set; }
        }

        Thread f1f2;

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public Liter(User obj)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIt1 = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIt2 = comboBox2.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            List<Book> list = new List<Book>();
            list.Add(new Book { Title = "Система спаси-себя-сам для главного злодея", Author = "Мосян Тунсю", Style1 = "Исекай", Style2 = "Юмор", Contry = "Китай", Year = 2014, PictureWay = Properties.Resources.SVSSS });
            list.Add(new Book { Title = "Подручный бездарной Луизы", Author = "Нобору Ямагути", Style1 = "Исекай", Style2 = "Приключения", Contry = "Япония", Year = 2006, PictureWay = Properties.Resources.PLN });
            list.Add(new Book { Title = "Великий детектив из другого мира", Author = "Катадзато Камоме", Style1 = "Исекай", Style2 = "Детектив", Contry = "Япония", Year = 2013, PictureWay = Properties.Resources.VD });
            list.Add(new Book { Title = "Единственный исход злодейки - смерть", Author = "Квон Гёыль", Style1 = "Исекай", Style2 = "Романтика", Contry = "Южная Корея", Year = 2020, PictureWay = Properties.Resources.DITOE });
            list.Add(new Book { Title = "Апокалипсис Минофра", Author = "Казуно Фифу", Style1 = "Исекай", Style2 = "Апокалипсис", Contry = "Япония", Year = 2017, PictureWay = Properties.Resources.AM });
            list.Add(new Book { Title = "Злодейский путь!..", Author = "Эл Моргот", Style1 = "Исекай", Style2 = "Фэнтези", Contry = "Беларусь", Year = 2019, PictureWay = Properties.Resources.WW });
            list.Add(new Book { Title = "Гарри Поттер", Author = "Джоан Роулинг", Style1 = "Юмор", Style2 = "Приключения", Contry = "Великобритания", Year = 1997, PictureWay = Properties.Resources.HP });
            list.Add(new Book { Title = "Монолог фармацевта", Author = "Нацу Хьюга", Style1 = "Юмор", Style2 = "Детектив", Contry = "Япония", Year = 2011, PictureWay = Properties.Resources.MF });
            list.Add(new Book { Title = "Гипотеза любви", Author = "Али Хейзелвуд", Style1 = "Юмор", Style2 = "Романтика", Contry = "Италия", Year = 2022, PictureWay = Properties.Resources.LiveLib });
            list.Add(new Book { Title = "Благие знамения", Author = "Терри Пратчетт, Нил Гейман", Style1 = "Юмор", Style2 = "Апокалипсис", Contry = "Великобритания", Year = 1990, PictureWay = Properties.Resources.GO });
            list.Add(new Book { Title = "Сердца Пандоры", Author = "Дзюн Мотидзуки", Style1 = "Юмор", Style2 = "Фэнтези", Contry = "Япония", Year = 2006, PictureWay = Properties.Resources.PH });
            list.Add(new Book { Title = "Далекие Странники", Author = "Прист", Style1 = "Приключения", Style2 = "Детектив", Contry = "Китай", Year = 2010, PictureWay = Properties.Resources.WoH });
            list.Add(new Book { Title = "Благословение Небожителей", Author = "Мосян Тунсю", Style1 = "Приключения", Style2 = "Романтика", Contry = "Китай", Year = 2017, PictureWay = Properties.Resources.TGCF });
            list.Add(new Book { Title = "Индиана Джонс", Author = "Джеймс Кан", Style1 = "Приключения", Style2 = "Апокалипсис", Contry = "Великобритания", Year = 2008, PictureWay = Properties.Resources.IJ });
            list.Add(new Book { Title = "Ведьмак", Author = "Анджей Сапковский", Style1 = "Приключения", Style2 = "Фэнтези", Contry = "Польша", Year = 1992, PictureWay = Properties.Resources.TW });
            list.Add(new Book { Title = "Злодейка, перевернувшая песочные часы", Author = "Сансоби", Style1 = "Детектив", Style2 = "Романтика", Contry = "Южная Корея", Year = 2018, PictureWay = Properties.Resources.TRVH });
            list.Add(new Book { Title = "Человек-бензопила", Author = "Тацуки Фудзимото", Style1 = "Детектив", Style2 = "Апокалипсис", Contry = "Япония", Year = 2018, PictureWay = Properties.Resources.CM });
            list.Add(new Book { Title = "Магистр дьявольского культа", Author = "Мосян Тунсю", Style1 = "Детектив", Style2 = "Фэнтези", Contry = "Китай", Year = 2015, PictureWay = Properties.Resources.MDZS });
            list.Add(new Book { Title = "Девергент", Author = "Вероника Рот", Style1 = "Романтика", Style2 = "Апокалипсис", Contry = "Америка", Year = 2011, PictureWay = Properties.Resources.D });
            list.Add(new Book { Title = "Черная зима", Author = "Джун Ина", Style1 = "Романтика", Style2 = "Фэнтези", Contry = "Южная Корея", Year = 2019, PictureWay = Properties.Resources.BW });
            list.Add(new Book { Title = "Точка зрения всеведующего читателя", Author = "Син-Шон", Style1 = "Апокалипсис", Style2 = "Фэнтези", Contry = "Южная Корея", Year = 2018, PictureWay = Properties.Resources.TORW });
            var disk = list.Where(x => ((selectedIt1 == x.Style1 && selectedIt2 == x.Style2) || (selectedIt1 == x.Style2 && selectedIt2 == x.Style1)));
            foreach (var a in disk)
            {
                pictureBox1.Image = a.PictureWay;
                label3.Visible = true; label4.Visible = true; label5.Visible = true; label6.Visible = true; label7.Visible = true; label8.Visible = true; label9.Visible = true; label10.Visible = true; label11.Visible = true; label12.Visible = true; label13.Visible = true;
                label4.Text = a.Title;
                label6.Text = a.Author;
                label8.Text = a.Style1;
                label9.Text = a.Style2;
                label11.Text = a.Contry;
                label13.Text = a.Year.ToString();
            }
        }
    }
}
