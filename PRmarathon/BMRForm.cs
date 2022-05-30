using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRmarathon
{
    public partial class BMRForm : Form
    {
        public DateTime endDate;
        public void Date()
        {
            endDate = new DateTime(2022, 5, 11, 8, 30, 0);
            timer1.Start();
        }
        public static bool flag1 = false;
        public static bool flag2 = false;
        public BMRForm()
        {
            InitializeComponent();
            bt_inf.FlatAppearance.BorderSize = 0;
            bt_inf.FlatStyle = FlatStyle.Flat;
            bt_Close.FlatAppearance.BorderSize = 0;
            bt_Close.FlatStyle = FlatStyle.Flat;
            Date();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flag1 == true)
            {
                flag1 = false;
                string Rost = textBox1.Text;
                string Ves = textBox2.Text;
                string Vozr = textBox3.Text;
                if (double.TryParse(Rost, out var rost) && double.TryParse(Ves, out var ves)&&double.TryParse(Vozr, out var vozr))
                {
                    if (rost > 0 && ves > 0 && rost < 300 && ves < 400 && vozr > 0 && vozr < 160)
                    {
                        double Result = ((10 * ves) + (6.25 * rost) - (5 * vozr) + 5) / 1000;
                        string result = string.Format("{0:f3}", Result);
                        lb_Result.Text = $"{result}";
                        double S1 = Result * 1.2;
                        string s1 = string.Format("{0:f3}", S1);
                        lb_lvl1.Text = $"{s1}";
                        double S2 = Result * 1.375;
                        string s2 = string.Format("{0:f3}", S2);
                        lb_lvl2.Text = $"{s2}";
                        double S3 = Result * 1.55;
                        string s3 = string.Format("{0:f3}", S3);
                        lb_lvl3.Text = $"{s3}";
                        double S4 = Result * 1.725;
                        string s4 = string.Format("{0:f3}", S4);
                        lb_lvl4.Text = $"{s4}";
                        double S5 = Result * 1.9;
                        string s5 = string.Format("{0:f3}", S5);
                        lb_lvl5.Text = $"{s5}";
                    }
                    
                }
                else
                {
                    MessageBox.Show("НЕКОРЕКТНЫЙ ВВОД ДАННЫХ!!!");
                }
            }
            else if (flag2 == true)
            {
                flag2 = false;
                string Rost = textBox1.Text;
                string Ves = textBox2.Text;
                string Vozr = textBox3.Text;
                if (double.TryParse(Rost, out var rost) && double.TryParse(Ves, out var ves) && double.TryParse(Vozr, out var vozr))
                {
                    if (rost > 0 && ves > 0 && rost < 300 && ves < 400 && vozr > 0 && vozr < 160)
                    {
                        double Result = ((10 * ves) + (6.25 * rost) - (5 * vozr) - 161) / 1000;
                        string result = string.Format("{0:f3}", Result);
                        lb_Result.Text = $"{result}";
                        double S1 = Result * 1.2;
                        string s1 = string.Format("{0:f3}", S1);
                        lb_lvl1.Text = $"{s1}";
                        double S2 = Result * 1.375;
                        string s2 = string.Format("{0:f3}", S2);
                        lb_lvl2.Text = $"{s2}";
                        double S3 = Result * 1.55;
                        string s3 = string.Format("{0:f3}", S3);
                        lb_lvl3.Text = $"{s3}";
                        double S4 = Result * 1.725;
                        string s4 = string.Format("{0:f3}", S4);
                        lb_lvl4.Text = $"{s4}";
                        double S5 = Result * 1.9;
                        string s5 = string.Format("{0:f3}", S5);
                        lb_lvl5.Text = $"{s5}";
                    }
                    
                }
                else
                {
                    MessageBox.Show("НЕКОРЕКТНЫЙ ВВОД ДАННЫХ!!!");
                }
            }
            else
            {
                MessageBox.Show("Выберите пол!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag1 = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag2 = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            lb_Result.Text = "0";
            lb_lvl1.Text = "0";
            lb_lvl2.Text = "0";
            lb_lvl3.Text = "0";
            lb_lvl4.Text = "0";
            lb_lvl5.Text = "0";
        }

        private void bt_inf_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = string.Format("{0:dd} дней {0:hh} ч. {0:mm} м. {0:ss} сек. до старта марафона!", endDate - DateTime.Now);
        }

        private void BMRForm_Load(object sender, EventArgs e)
        {
            SetRoundedShape(button1, 10);
            SetRoundedShape(button4, 10);
            SetRoundedShape(button5, 10);
        }
        public static void SetRoundedShape(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }
    }
}
