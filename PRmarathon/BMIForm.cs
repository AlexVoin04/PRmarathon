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
    public partial class BMIForm : Form
    {
        public DateTime endDate;
        public void Date()
        {
            endDate = new DateTime(2022, 5, 11, 8, 30, 0);
            timer1.Start();
        }

        public static bool flag1 = false;
        public static bool flag2 = false;
        public BMIForm()
        {
            InitializeComponent();
            Date();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((flag1 == true)||(flag2 ==true))
            {
                flag1 = false;
                flag2 = false;
                trackBar1.Enabled = true;
                trackBar1.Value = 0;
                trackBar1.Enabled = false;
                lb_Result.Left = 398;
                string Rost = textBox1.Text;
                string Ves = textBox2.Text;
                if (double.TryParse(Rost, out var r) && double.TryParse(Ves, out var v))
                {
                    if (r > 0 && v > 0 && r<300 && v < 400 )
                    {
                        r /= 100;
                        double Result = Math.Round(v / (r * r), 1);
                        lb_Result.Text = $"{Result}";
                        if (Result < 18.5)
                        {
                            bt_Result.BackgroundImage = Properties.Resources.underweigt;
                            bt_Result.Text = "Недостаточный";
                            trackBar1.Enabled = true;
                            trackBar1.Value = 5 * ((int)Result);
                            trackBar1.Enabled = false;
                            if (Result < 10)
                            {
                                lb_Result.Left += trackBar1.Value - 6;
                            }
                            else if(Result >= 10)
                            {
                                lb_Result.Left += trackBar1.Value - 10;
                            }
                        }
                        else if ((Result >= 18.5) && (Result <= 24.9))
                        {
                            bt_Result.BackgroundImage = Properties.Resources.healthy;
                            bt_Result.Text = "Здоровый";
                            if (Result > 22) 
                            {
                                trackBar1.Enabled = true;
                                trackBar1.Value = 90 + (15 * ((int)Result / 4));
                                trackBar1.Enabled = false;
                                lb_Result.Left += trackBar1.Value-20;
                            }
                            else
                            {
                                trackBar1.Enabled = true;
                                trackBar1.Value = 90 + (15 * ((int)Result / 6));
                                trackBar1.Enabled = false;
                                lb_Result.Left += trackBar1.Value-15;
                            }    
                        }
                        else if ((Result >= 25) && (Result <= 29.9))
                        {
                            bt_Result.BackgroundImage = Properties.Resources.over;
                            bt_Result.Text = "Избыточный";
                            trackBar1.Enabled = true;
                            if(Result > 27)
                            {
                                trackBar1.Value = 170 + (17 * ((int)Result / 4));
                                lb_Result.Left += trackBar1.Value - 30;
                            }
                            else
                            {
                                trackBar1.Value = 170 + (17 * ((int)Result / 7));
                                lb_Result.Left += trackBar1.Value - 20;
                            }
                            trackBar1.Enabled = false;
                        }
                        else if (Result > 30)
                        {
                            bt_Result.BackgroundImage = Properties.Resources.obese;
                            bt_Result.Text = "Ожирение";
                           
                            if (265 + (3 * (int)Result)>400)
                            {
                                trackBar1.Enabled = true;
                                trackBar1.Value = 400;
                                trackBar1.Enabled = false;
                                lb_Result.Left = 758;
                                MessageBox.Show($"ВАШ ВЕС СЛИШКОМ БОЛЬШОЙ!!!\nНемедленно займитесь спортом.\nВаш BMI = {Result}");
                                
                            }
                            else if (265 + (3 * (int)Result) <= 400)
                            {
                                trackBar1.Enabled = true;
                                trackBar1.Value = 265 + (3 * (int)Result);
                                trackBar1.Enabled = false;
                                lb_Result.Left += trackBar1.Value-40;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("НЕКОРЕКТНЫЙ ВВОД ДАННЫХ!!!");
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

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            lb_Result.Text = "0";
            lb_Result.Left = 398;
            bt_Result.BackgroundImage = null;
            bt_Result.Text = "";
            trackBar1.Enabled = true;
            trackBar1.Value = 0;
            trackBar1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag1 = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag2 = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = string.Format("{0:dd} дней {0:hh} ч. {0:mm} м. {0:ss} сек. до старта марафона!", endDate - DateTime.Now);
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

        private void BMIForm_Load(object sender, EventArgs e)
        {
            SetRoundedShape(button1, 10);
            SetRoundedShape(button4, 10);
            SetRoundedShape(button5, 10);
        }
    }
}
