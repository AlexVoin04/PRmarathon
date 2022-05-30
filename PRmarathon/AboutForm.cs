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
    public partial class AboutForm : Form
    {
        public DateTime endDate;
        public void Date()
        {
            endDate = new DateTime(2022, 5, 11, 8, 30, 0);
            timer1.Start();
        }
        public AboutForm()
        {
            InitializeComponent();
            Date();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MapForm f1 = new MapForm();
            f1.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = string.Format("{0:dd} дней {0:hh} ч. {0:mm} м. {0:ss} сек. до старта марафона!", endDate - DateTime.Now);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            SetRoundedShape(button2, 10);
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
