using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winMap;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //skinEngine1.SkinFile = "DiamondGreen.ssk";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }
            private void VisitLink()
            {
                // Change the color of the link text by setting LinkVisited
                // to true.
                linkLabel1.LinkVisited = true;
                //Call the Process.Start method to open the default browser
                //with a URL:
                System.Diagnostics.Process.Start("http://www.sdu.edu.cn/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("虚位以待！");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Map().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string connString = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ";
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                MessageBox.Show("连接成功");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }*/
            Form3 myform = new Form3();   //新窗口
            myform.Show();
            this.Close(); //关闭

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 myform = new Form4();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 myform = new Form5();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 myform = new Form6();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 myform = new Form7();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 myform = new Form8();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 myform = new Form9();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 myform = new Form10();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }
    }
}
