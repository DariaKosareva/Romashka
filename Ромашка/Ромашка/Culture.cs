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
    public partial class Culture : Form
    {
        private User user;
        public void Making()
        {
            
            
            List<Question> list = new List<Question>();
            list.Add(new Question { Number = 1, Quest = "Во времена эпохи Тан в Китае существовало несколько элементов макияжа: Макияж Будды, рисунок меж бровями, точки на щеках и полосы на скулах. Как назывались точки на щеках?", Answ1 = "Хуадянь", Answ2 = "Мянье", Answ3 = "Эхуань", Answ4 = "Сехун", CorrAnsw = "Мянье", Bitmap = Properties.Resources.Mianye });
            list.Add(new Question { Number = 2, Quest = "о многих частях Африки также распространён известный в России обычай выкупа за невесту. Иногда в качестве выкупа выступает что-то совсем символичное, но чаще вполне реальное — домашний скот, деньги, украшения, зерно и кофейные бобы. Как называется этот выкуп?", Answ1 = "Капулана", Answ2 = "Хамер", Answ3 = "Свази", Answ4 = "Калым", CorrAnsw = "Калым", Bitmap = Properties.Resources.wedding });
            list.Add(new Question { Number = 3, Quest = "Ханбок - это традиционная одежда Южной Кореи, которая состояла из нескольких частей. Одну из них - блузу - носили как мужчины, так и женщины. Как она называлась?", Answ1 = "Чокки", Answ2 = "Чхима", Answ3 = "Чогори", Answ4 = "Магоджа", CorrAnsw = "Чогори", Bitmap = Properties.Resources.hanbok });
            list.Add(new Question { Number = 4, Quest = "Праздник в Беларуси был настоящим праздником урожая, подводил итог труда крестьянина. В церквях освящали новый хлеб, разные овощи, фрукты. Осветив в церкви жито, его перемешивали дома с остальным и откладывали до следующего сева, чтобы новое зерно хорошо росло. Как назывался праздник?", Answ1 = "Дожинки", Answ2 = "Толоки", Answ3 = "Зажинки", Answ4 = "Громницы", CorrAnsw = "Дожинки", Bitmap = Properties.Resources.dozhinki });
            list.Add(new Question { Number = 5, Quest = "Во время священного месяца в Ираке правоверные мусульмане в дневное время постятся, а пищу принимают только с наступлением темноты, поэтому обычный ход событий или деловых отношений в этот период часто нарушается. Как называется этот месяц?", Answ1 = "Сафар", Answ2 = "Шавваль", Answ3 = "Рамадан", Answ4 = "Мухаррам", CorrAnsw = "Рамадан", Bitmap = Properties.Resources.ramadan });
            list.Add(new Question { Number = 6, Quest = "Общепринятая форма приветствия в Непале - сложенные лодочкой ладони, подносимые к лицу (обычно лбу - в случае крайнего уважения, или к подбородку - в обыденной жизни). Каким словом сопровождается жест в обыденной жизни?", Answ1 = "Джутхо", Answ2 = "Намаскар", Answ3 = "Хаджур", Answ4 = "Намасте", CorrAnsw = "Намасте", Bitmap = Properties.Resources.namaste });
            list.Add(new Question { Number = 7, Quest = "В Японии чайная церемония - это ритуал приготовления и подачи чая маття — крепкого зелёного чая с необычным и насыщенным вкусом. Напиток подают с традиционными сладостями. Одинаково важен весь процесс — от приготовления напитка до наслаждения послевкусием. Как называется эта церемония?", Answ1 = "Садо", Answ2 = "Согэцу", Answ3 = "Сёдо", Answ4 = "Охара", CorrAnsw = "Садо", Bitmap = Properties.Resources.sado });
            list.Add(new Question { Number = 8, Quest = "Какой термин в Австрии означает выведение, тренировку и соревнования венских высоколетных голубей?", Answ1 = "Херзунфт", Answ2 = "Мистельбах", Answ3 = "Грен гех", Answ4 = "Яукен", CorrAnsw = "Яукен", Bitmap = Properties.Resources.golub });
            list.Add(new Question { Number = 9, Quest = "Самое главное, что вы должны знать во время посещения Таиланда — это тайский способ приветствия. Тайцы соединяют ладони и склоняют головы в знак приветствия и уважения. Как оно называется?", Answ1 = "Пи", Answ2 = "Ваи", Answ3 = "Нон", Answ4 = "Сан", CorrAnsw = "Ваи", Bitmap = Properties.Resources.wai });
            list.Add(new Question { Number = 10, Quest = "В Австралии есть специальный праздник для отдыха, отмечается он в первый понедельник августа. При этом застолья проходят где угодно - во дворах, парках и даже на мосту. Что это за правздник?", Answ1 = "День Гармонии", Answ2 = "День Смеха", Answ3 = "День Пикника", Answ4 = "День Памяти", CorrAnsw = "День Пикника", Bitmap = Properties.Resources.pday });
            list.Add(new Question { Number = 11, Quest = "По кыргызским традициям, после рождения ребенка один праздник сменялся другим. Когда малыш начинал делать первые шаги, то проводили обряд обрезания пут. Как он назывался?", Answ1 = "мүчол жаш", Answ2 = "тушоо кесүү", Answ3 = "бешик той", Answ4 = "жентек", CorrAnsw = "тушоо кесүү", Bitmap = Properties.Resources.тк });
            list.Add(new Question { Number = 12, Quest = "Существует очень популярная форма искусства в Малави. Одежда с ней создается при помощи воска. Как называется это искусство?", Answ1 = "Чивода", Answ2 = "Индингала", Answ3 = "Мзузу", Answ4 = "Батик", CorrAnsw = "Батик", Bitmap = Properties.Resources.батик });
            list.Add(new Question { Number = 13, Quest = "Рядом с древним поселением в Мавритании находится интересное геологическое образование - \"Глаз Африки\" или \"Глаз Сахары\", оно долго было ориентиром для космонавтов, потому что его хорошо видно из космоса. Как называется это поселение?", Answ1 = "Уадан", Answ2 = "Нуакшот", Answ3 = "Харира", Answ4 = "Зриг", CorrAnsw = "Уадан", Bitmap = Properties.Resources.гс });
            list.Add(new Question { Number = 14, Quest = "В Руанде очень ценится традиционный народный танец, во время исполнения которого сообщаются эпические истории народных героев Руанды. Как называется этот танец?", Answ1 = "Инингири", Answ2 = "Икембе", Answ3 = "Инанга", Answ4 = "Икинимба", CorrAnsw = "Икинимба", Bitmap = Properties.Resources.икинимба });
            list.Add(new Question { Number = 15, Quest = "Готовясь отметить День мертвых, мексиканцы приняли участие веселом шествии скелетов по Мехико. Кто стал лицом празднования дня мертвых и в честь кого делают такой грим?", Answ1 = "Миктлансиуатль", Answ2 = "Гуадалупе", Answ3 = "Катрина", Answ4 = "Миктлан", CorrAnsw = "Катрина", Bitmap = Properties.Resources.катрина });
            list.Add(new Question { Number = 16, Quest = "Главный национальный напиток Бельгии известен во всем мире. Вплоть до 1980-х он продавался даже в школьных столовых и до сих пор — в университетских. Что это за напиток?", Answ1 = "Вино", Answ2 = "Пиво", Answ3 = "Женевер", Answ4 = "Джин", CorrAnsw = "Пиво", Bitmap = Properties.Resources.напитки });
            list.Add(new Question { Number = 17, Quest = "Индуистский праздник поклонения богине, имя которой входит в его название, проводится осенью и продолжается четыре дня. В ходе праздника индуисты также поклоняются Шиве, Лакшми, Ганеше, Сарасвати и Картикее. Что это за праздник?", Answ1 = "Кумбх Мела", Answ2 = "Наг Панчами", Answ3 = "Дурга-пуджа", Answ4 = "Гуди Падва", CorrAnsw = "Дурга-пуджа", Bitmap = Properties.Resources.дп });
            list.Add(new Question { Number = 18, Quest = "Официальный язык в Гибралтаре — английский, однако диалект имеет некоторые особенности. Это смесь английского языка с андалузским, генуэзским, мальтийским диалектами. Как называется этот диалект?", Answ1 = "Янито", Answ2 = "Каспар", Answ3 = "Калентина", Answ4 = "Росто", CorrAnsw = "Янито", Bitmap = Properties.Resources.гибралтар });
            list.Add(new Question { Number = 19, Quest = "Все музыкальные стили, появившиеся в Того, основаны на одном музыкальном инструменте, и большинство из них сопровождается танцами. Одержимость инструментом так сильна, что существует десятки разных видов. Что это за инструмент?", Answ1 = "Трубы", Answ2 = "Пианино", Answ3 = "Гитары", Answ4 = "Барабаны", CorrAnsw = "Барабаны", Bitmap = Properties.Resources.музинстр });
            list.Add(new Question { Number = 20, Quest = "Какой из этих тануев Бразилии зародился в 2000-х годах в фавелах Рио-де-Жанейро и имеет сегодня наибольшую популярность среди молодёжи Рио всех социальных классов?", Answ1 = "Самбо", Answ2 = "Фанк", Answ3 = "Фрево", Answ4 = "Капоэйра", CorrAnsw = "Фанк", Bitmap = Properties.Resources.фанк });
            list.Add(new Question { Number = 21, Quest = "На Доминике находится территории «карибов». Именно так чаще всего называют местные племена, проживавшие на острове еще до прихода сюда европейцев. Какое самоназвание у этого народа?", Answ1 = "Калипонам", Answ2 = "Домник", Answ3 = "Калинаго", Answ4 = "Резня", CorrAnsw = "Калинаго", Bitmap = Properties.Resources.калинаго });
            list.Add(new Question { Number = 22, Quest = "Самая популярная форма ботсванской музыки – это, в принципе, модернизированная музыка зулу и тсвана в сочетании с традиционной джазовой музыкой. Как называется эта музыка?", Answ1 = "Цуцубе", Answ2 = "Мокомото", Answ3 = "Хуру", Answ4 = "Гумба-гумба", CorrAnsw = "Гумба-гумба", Bitmap = Properties.Resources.гг });
            list.Add(new Question { Number = 23, Quest = "В Гуама есть своеобразный язык жестов и мимики, который фактически составляет отдельную коммуникативную систему - многие жесты или выражение лица могут усиливать или ослаблять значение того или иного слова, часто придавая ему совершенно противоположный смысл. Как он называется?", Answ1 = "Тумон-бей", Answ2 = "Чаморро", Answ3 = "Айбро", Answ4 = "Пугуа", CorrAnsw = "Айбро", Bitmap = Properties.Resources.жест });
            list.Add(new Question { Number = 24, Quest = "Тонганская музыка стала популярной лишь с прибытием европейцев на острова. Большинство музыкальных традиций Тонга основано на перкуссии. Что из преведенных ниже вещей называется \"Лали\"?", Answ1 = "Танцы", Answ2 = "Щелевой гонг", Answ3 = "Носовая флейта", Answ4 = "Барабаны", CorrAnsw = "Щелевой гонг", Bitmap = Properties.Resources.тонга });
            list.Add(new Question { Number = 25, Quest = "Есть более 32 потрясающих островов и заливов, которые составляют Сент-Винсент и Гренадины. Из них 9 населены. У этого народа есть множество праздников. 1-ая, 2-я и 3-я серии приключенческих фильмов - Пираты Карибского моря были сняты именно здесь. В каком из приведенных ниже проводится 20 мая?", Answ1 = "День подарков", Answ2 = "Духов день", Answ3 = "Карнавал", Answ4 = "День героев", CorrAnsw = "Духов день", Bitmap = Properties.Resources.свиг });
            list.Add(new Question { Number = 26, Quest = "Осенью, в Лихтенштейне устраивают торжественную встречу стада, возвращающегося с высокогорных пастбищ. Присматривая за коровами, пастухи вырезали из дерева и раскрашивали яркие сердечки для украшения лба лучшей молочной коровы, пристраивая его между высоких и пышных украшений из цветов и ярких лент. Как называется эта встреча?", Answ1 = "Фаснахт", Answ2 = "Кюахлизонтаг", Answ3 = "Функен", Answ4 = "Альпабфарт", CorrAnsw = "Альпабфарт", Bitmap = Properties.Resources.кцк });
            list.Add(new Question { Number = 27, Quest = "Омиш в Хорватии имеет яркую внешность и положение, а также долгую историю пиратства отважных и храбрых жителей Омиша. В середине августа, каждый год здесь проходит реконструкция пиратского морской битвы в местном порту, которое произошло восемь веков назад. Как называется эта реконструкция?", Answ1 = "Гусарска битка", Answ2 = "Синьска Алка", Answ3 = "За крижем", Answ4 = "Велика Госпа", CorrAnsw = "Гусарска битка", Bitmap = Properties.Resources.гб });
            list.Add(new Question { Number = 28, Quest = "Уровень жизни в Либерии низкий, местные жители не могут похвастаться большим выбором блюд. Но широкое использование специй помогает сделать местную кухню разнообразной. Самое известное блюдо - каша из маниоки, заправленная пальмовым маслом. Как она называется?", Answ1 = "Джолоф", Answ2 = "Кассава", Answ3 = "Фуфу", Answ4 = "Эддоэ", CorrAnsw = "Фуфу", Bitmap = Properties.Resources.фуфу });
            list.Add(new Question { Number = 29, Quest = "Этот праздник в Словакии любят особенно дети, которым в этот день дарят сладости и различные мелочи. Обычно вечером почистят ботинки, поставят в окно и утром находят в них приятный сюрприз. Что это за праздник?", Answ1 = "Луция", Answ2 = "Морены", Answ3 = "Микулаш", Answ4 = "Мясопуст", CorrAnsw = "Микулаш", Bitmap = Properties.Resources.мик });
            list.Add(new Question { Number = 30, Quest = "День Святого Патрика (17 марта) - это самый знаменитый «зеленый» праздник Ирландии, который символизирует принятие христианства в стране. Сколько дней длится этот праздник?", Answ1 = "5 дней", Answ2 = "4 дня", Answ3 = "2 дня", Answ4 = "3 дня", CorrAnsw = "5 дней", Bitmap = Properties.Resources.дсп });
            link1:
            Random random = new Random();
            int ind = random.Next(1, 31);
            var disk = list.Where(x => (ind == x.Number));
            foreach (var a in disk)
            {
                if (k > 0)
                {
                    for (int j = 0; j <= k - 1; j++)
                    {
                        if (a.Number != questions[j])
                        {
                            continue;
                        }
                        else
                        {
                            goto link1;
                        }
                    }
                }
                pictureBox1.Image = a.Bitmap;
                label3.Text = a.Number.ToString();
                textBox1.Text = a.Quest;
                button6.Text = a.Answ1;
                button7.Text = a.Answ2;
                button8.Text = a.Answ3;
                button9.Text = a.Answ4;
                label7.Text = a.CorrAnsw;
                questions[k] = a.Number;
            }
            if (k == 9 && label10.Visible == false)
            {
                button10.Visible = false;
                label10.Text = $"Тест окончен! Ваши баллы: {ball}";
            }
            if (label3.Visible == true)
            {
                int num = k + 1;
                label6.Text = num.ToString();
                k++;
            }
        }
        public void Showing()
        {
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            pictureBox1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label9.Visible = true;
        }
        Thread f1f2;
        int k = 0;
        int ball = 0;
        int[] questions = new int[10];
        public class Question
        {
            public int Number { get; set; }
            public string Quest { get; set; }
            public string Answ1 { get; set; }
            public string Answ2 { get; set; }
            public string Answ3 { get; set; }
            public string Answ4 { get; set; }
            public int CorrAnswNum { get; set; }
            public string CorrAnsw { get; set; }
            public Image Bitmap { get; set; }
        }

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }

        public Culture(User obj)
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
            Showing();
            Making();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            k = 0;
            for (int i = 0; i < 10; i++)
            {
                questions[i] = 0;
            }
            ball = 0;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label10.Text = "Такой вопрос уже был! Попробуйте еще раз.";
            label9.Text = "";
            label7.Text = "";
        }


        private void button6_Click(object sender, EventArgs e)
        {
            label9.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label9.Text = button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label9.Text = button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label9.Text = button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label10.Visible == true)
            {
                Showing();
                label10.Visible = false;
            }
            button4.Visible = true;
            Making();
            label7.Visible = false;
            label8.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label7.Text == label9.Text)
            {
                ball += 1;
                label5.Text = ball.ToString();
            }
            label7.Visible = true;
            label8.Visible = true;
            button4.Visible = false;
        }
    }
}
