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
    public partial class HowLongForm : Form
    {
        public Image img1 = Properties.Resources.f1_car;
        public Image img2 = Properties.Resources.worm;
        public Image img3 = Properties.Resources.sloth;
        public Image img4 = Properties.Resources.capybara;
        public Image img5 = Properties.Resources.jaguar;
        public Image img6 = Properties.Resources.airbus_a380;
        public Image img7 = Properties.Resources.pair_of_havaianas;
        public Image img8 = Properties.Resources.football_field;
        public Image img9 = Properties.Resources.ronaldinho;
        public Image img10 = Properties.Resources.bus;
        public DateTime endDate;
        public void Date()
        {
            endDate = new DateTime(2022, 5, 11, 8, 30, 0);
            timer1.Start();
        }

        public HowLongForm()
        {
            
            InitializeComponent();
            Date();
            label4.Text = "";
            label5.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            Close();
        }

        public void Result(string name, double S, double v)
        {
            double ch = S / v;
            var chres = Math.Truncate(ch);
            double mvspom = ch - chres;
            double min = mvspom * 60;
            var mres = Math.Truncate(min);
            double sec = min - mres;
            double sres = sec * 60;
            label5.Text = $"{name} движется со скоростью {v} км/ч, поэтому\nон преодолеет марафон за {Math.Round(chres, 0)} часов {Math.Round(mres, 0)} минут {Math.Round(sres, 0)} секунд";
        }

        public void ResultRast(string name, double dl, double rast)
        {
            double el = rast / dl;
            var cel = Math.Truncate(el);
            double ost = el - cel;
            if(ost > 0)
            {
                cel += 1;
            }
            label5.Text = $"{name} имеет длину {dl}м. {cel} таких вписалось\nбы в длинну марафона. ";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img1;
            label4.Left = 100;
            label4.Text = "Автомобиль Формулы-1";
            string name = label4.Text;
            double S = 42;
            double v = 345;
            label5.Left = 34;
            Result(name, S, v);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img2;
            label4.Left = 160;
            label4.Text = "Червяк";
            string name = label4.Text;
            double S = 42;
            double v = 0.03;
            label5.Left = 34;
            Result(name, S, v);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img3;
            label4.Left = 160;
            label4.Text = "Ленивец";
            string name = label4.Text;
            double S = 42;
            double v = 0.12;
            label5.Left = 34;
            Result(name, S, v);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img4;
            label4.Left = 160;
            label4.Text = "Капибара";
            string name = label4.Text;
            double S = 42;
            double v = 35;
            label5.Left = 34;
            Result(name, S, v);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img5;
            label4.Left = 170;
            label4.Text = "Ягуар";
            string name = label4.Text;
            double S = 42;
            double v = 80;
            label5.Left = 34;
            Result(name, S, v);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img6;
            label4.Left = 150;
            label4.Text = "Airbus A380";
            string name = label4.Text;
            double dl = 73;
            double rast = 42000;
            label5.Left = 34 + 25;
            ResultRast(name, dl, rast);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img7;
            label4.Left = 155;
            label4.Text = "Havaianas";
            string name = label4.Text;
            double dl = 0.245;
            double rast = 42000;
            label5.Left = 34;
            ResultRast(name, dl, rast);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img8;
            label4.Left = 145;
            label4.Text = "Футбольное поле";
            string name = label4.Text;
            double dl = 105;
            double rast = 42000;
            label5.Left = 34;
            ResultRast(name, dl, rast);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img9;
            label4.Left = 155;
            label4.Text = "Роналдиньо";
            string name = label4.Text;
            double dl = 1.81;
            double rast = 42000;
            label5.Left = 34;
            ResultRast(name, dl, rast);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = img10;
            label4.Left = 160;
            label4.Text = "Автобус";
            string name = label4.Text;
            double dl = 10;
            double rast = 42000;
            label5.Left = 34 + 30;
            ResultRast(name, dl, rast);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = string.Format("{0:dd} дней {0:hh} ч. {0:mm} м. {0:ss} сек. до старта марафона!", endDate - DateTime.Now);
        }

        private void HowLongForm_Load(object sender, EventArgs e)
        {
            SetRoundedShape(button1, 10);
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
