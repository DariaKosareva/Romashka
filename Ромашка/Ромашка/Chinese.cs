using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using static Ромашка.database.User;
using static Ромашка.database;

namespace Ромашка
{
    public partial class Chinese : Form
    {
        Thread f1f2;
        private User user;

        public void openHP(object obj)
        {
            Application.Run(new Home(user));
        }
        public class Symbols
        {
            public int Index { get; set; }
            public string Sentesnse { get; set; }
            public string SentesnseR { get; set; }
            public string Symb1 { get; set; }
            public string ToolTip1 { get; set; }
            public string Symb2 { get; set; }
            public string ToolTip2 { get; set; }
            public string Symb3 { get; set; }
            public string ToolTip3 { get; set; }
            public string Symb4 { get; set; }
            public string ToolTip4 { get; set; }

        }

        public Chinese(User obj)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Chinese_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Random random = new Random();
            int Ind = random.Next(1, 11);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Книга1.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            List<Symbols> list = new List<Symbols>();
            int i = 1;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("num");
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                        if (childnode.Name == "Chiierog")
                        {
                            textBox5.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Chitrans")
                        {
                            label12.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Ie1")
                        {
                            label7.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Ie1Trans")
                        {
                            label13.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Ie2")
                        {
                            label8.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Ie2Trans")
                        {
                            label14.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Ie3")
                        {
                            label9.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Ie3Trans")
                        {
                            label15.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Ie4")
                        {
                            label10.Text = childnode.InnerText;
                        }
                        if (childnode.Name == "Ie4Trans")
                        {
                            label16.Text = childnode.InnerText;
                        }
                        list.Add(new Symbols { Index = i, Sentesnse = textBox5.Text, SentesnseR = label12.Text, Symb1 = label7.Text, ToolTip1 = label13.Text, Symb2 = label8.Text, ToolTip2 = label14.Text, Symb3 = label9.Text, ToolTip3 = label15.Text, Symb4 = label10.Text, ToolTip4 = label16.Text });
                    }
                    i++;
                }
            }

            
            var disk = list.Where(x => (Ind == x.Index));
            foreach (var a in disk)
            {
                int In = random.Next(1, 4);
                label12.Text = a.SentesnseR;
                label3.Text = a.Symb1;
                label4.Text = a.Symb2;
                label5.Text = a.Symb3;
                label6.Text = a.Symb4;
                textBox5.Text = a.Sentesnse;
                switch (In)
                {
                    case 1:
                        {
                            label10.Text = a.Symb1;
                            label8.Text = a.Symb2;
                            label9.Text = a.Symb3;
                            label7.Text = a.Symb4;
                            toolTip1.SetToolTip(this.label7, a.ToolTip4);
                            toolTip2.SetToolTip(this.label8, a.ToolTip2);
                            toolTip3.SetToolTip(this.label9, a.ToolTip3);
                            toolTip4.SetToolTip(this.label10, a.ToolTip1);
                            break;
                        }
                    case 2:
                        {
                            label9.Text = a.Symb1;
                            label7.Text = a.Symb2;
                            label10.Text = a.Symb3;
                            label8.Text = a.Symb4;
                            toolTip1.SetToolTip(this.label7, a.ToolTip2);
                            toolTip2.SetToolTip(this.label8, a.ToolTip4);
                            toolTip3.SetToolTip(this.label9, a.ToolTip1);
                            toolTip4.SetToolTip(this.label10, a.ToolTip3);
                            break;
                        }
                    case 3:
                        {
                            label8.Text = a.Symb1;
                            label9.Text = a.Symb2;
                            label7.Text = a.Symb3;
                            label10.Text = a.Symb4;
                            toolTip1.SetToolTip(this.label7, a.ToolTip3);
                            toolTip2.SetToolTip(this.label8, a.ToolTip1);
                            toolTip3.SetToolTip(this.label9, a.ToolTip2);
                            toolTip4.SetToolTip(this.label10, a.ToolTip4);
                            break;
                        }
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            if (textBox1.Text == label3.Text)
            {
                pictureBox3.BackColor = Color.Green;
            }
            else
            {
                pictureBox3.BackColor = Color.Red;
            }
            if (textBox2.Text == label4.Text)
            {
                pictureBox4.BackColor = Color.Green;
            }
            else
            {
                pictureBox4.BackColor = Color.Red;
            }
            if (textBox3.Text == label5.Text)
            {
                pictureBox5.BackColor = Color.Green;
            }
            else
            {
                pictureBox5.BackColor = Color.Red;
            }
            if (textBox4.Text == label6.Text)
            {
                pictureBox6.BackColor = Color.Green;
            }
            else
            {
                pictureBox6.BackColor = Color.Red;
            }
        }

        private void Chinese_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                foreach (TextBox TBox in Controls.OfType<TextBox>())
                {
                    TBox.Clear();
                }
                label12.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
        }
    }
}
