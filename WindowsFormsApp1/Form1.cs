using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //private object labe14;

        public Form1()
        {
            InitializeComponent();
        }

        int x = 1;//横坐标
        int y = 320;//纵坐标，根据你的窗体的实际高度写
        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            if (x == this.Width)//当出了窗体的右边框后
            {
                x = 1;//横坐标定位到窗体左边框
            }
            label4.Location = new Point(x, y);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //label2.Font = new Font("隶书", 15, FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //label1.Font = new Font("华文彩云",28, FontStyle.Bold);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //label3.Font = new Font("隶书", 15, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("请输入完整！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            else
            if (textBox1.Text == "130019" && textBox2.Text == "zey12345")
            {
                MessageBox.Show("登录成功！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
                Form2 myform = new Form2();   //新窗口
                myform.Show();
                this.Hide(); //隐藏
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 10;
            this.timer1.Enabled = true;
            this.WindowState = FormWindowState.Maximized;
            //this.MaximizeBox = false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label4.Left = label4.Left - 3;
            if (label4.Right < 0)
            {
                label4.Left = this.Width;
            }
        }
    }
}
