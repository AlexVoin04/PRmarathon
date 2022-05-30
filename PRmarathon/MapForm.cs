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
    public partial class MapForm : Form
    {
        public Panel pn = new Panel();
        public Image img11 = Properties.Resources.drinks;
        public Image img12 = Properties.Resources.enrgy_bars;
        public Image img13 = Properties.Resources.toilets;
        public Image img14 = Properties.Resources.information;
        public Image img15 = Properties.Resources.medical;
        public MapForm()
        {
            InitializeComponent();
            bt_Close.FlatAppearance.BorderSize = 0;
            bt_Close.FlatStyle = FlatStyle.Flat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            AboutForm f = new AboutForm();
            f.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
            Result("Checkpoint 1","Avenida Rudge");
            pictureBox3.Image = img11;
            label4.ForeColor = Color.Green;
            label4.Text = "Стенд питья";
            pictureBox4.Image = img12;
            label5.ForeColor = Color.Green;
            label5.Text = "Энергетические\nбатончики";
        }
        

        private void MapForm_Load(object sender, EventArgs e)
        {
            SetRoundedShape(button1, 10);
            SetRoundedShape(button2, 30);
            SetRoundedShape(button3, 30);
            SetRoundedShape(button4, 30);
            SetRoundedShape(button5, 30);
            SetRoundedShape(button6, 30);
            SetRoundedShape(button7, 30);
            SetRoundedShape(button8, 30);
            SetRoundedShape(button9, 30);
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            Result("Checkpoint 2","Theatro Municipal");
            Result(1, 1, 1, 1, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
            Result("Checkpoint 3","Parque do Ibirapuera");
            Result(1, 1, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clear();
            Result("Checkpoint 4","Jardim Luzitania");
            Result(1, 1, 1);
            pictureBox6.Image = img15;
            label7.ForeColor = Color.Green;
            label7.Text = "Медицинский пункт";
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clear();
            Result("Checkpoint 5","Iguatemi");
            Result(1, 1, 1);
            pictureBox6.Image = img14;
            label7.ForeColor = Color.Green;
            label7.Text = "Информация";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Clear();
            Result("Checkpoint 6","Rua Lisboa");
            Result(1, 1, 1);
        }
        public void Clear()
        {
            pictureBox3.Image = null;
            label4.Text = "";
            pictureBox4.Image = null;
            label5.Text = "";
            pictureBox5.Image = null;
            label6.Text = "";
            pictureBox6.Image = null;
            label7.Text = "";
            pictureBox7.Image = null;
            label8.Text = "";
        }
        public void Result(int l4, int l5, int l6, int l7, int l8)
        {
            pictureBox3.Image = img11;
            label4.ForeColor = Color.Green;
            label4.Text = "Стенд питья";
            pictureBox4.Image = img12;
            label5.ForeColor = Color.Green;
            label5.Text = "Энергетические\nбатончики";
            pictureBox5.Image = img13;
            label6.ForeColor = Color.Green;
            label6.Text = "Туалет"; 
            pictureBox6.Image = img14;
            label7.ForeColor = Color.Green;
            label7.Text = "Информация";
            pictureBox7.Image = img15;
            label8.ForeColor = Color.Green;
            label8.Text = "Медицинский пункт";
        }
        public void Result(int l4, int l5, int l6)
        {
            pictureBox3.Image = img11;
            label4.ForeColor = Color.Green;
            label4.Text = "Стенд питья";
            pictureBox4.Image = img12;
            label5.ForeColor = Color.Green;
            label5.Text = "Энергетические\nбатончики";
            pictureBox5.Image = img13;
            label6.ForeColor = Color.Green;
            label6.Text = "Туалет";
        }
        public void Result(string name1, string name)
        {
            panel1.Visible = true;
            label10.Text = name;
            label2.Text = name1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Clear();
            Result("Checkpoint 7","Cemitério da Consolação");
            Result(1,1,1,1,1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Clear();
            Result("Checkpoint 8","Cemitério da Consolação");
            Result(1, 1, 1, 1, 1);
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
