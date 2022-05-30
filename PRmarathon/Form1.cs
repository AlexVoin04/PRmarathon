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
    public partial class Form1 : Form
    {
        public DateTime endDate; 
        public void Date()
        {
            endDate = new DateTime(2022, 5, 11, 8, 30, 0);
            timer1.Start();
        }
        public Form1()
        {
            InitializeComponent();
            Date();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetRoundedShape(button1, 20);
            SetRoundedShape(button2, 20);
            SetRoundedShape(button3, 20);
            SetRoundedShape(button4, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            AboutForm f1 = new AboutForm();
            f1.ShowDialog();
            Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            HowLongForm f2 = new HowLongForm();
            f2.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            BMIForm f3 = new BMIForm();
            f3.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            BMRForm f4 = new BMRForm();
            f4.ShowDialog();
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
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
    }
}
