﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 myform = new Form2();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8");       //连接数据库
            cn.Open();                                                                            //打开连接的数据库
            MySqlDataAdapter dap = new MySqlDataAdapter("SELECT * FROM migrants_information", cn);    //建立SQL语句与数据库的连接
            DataSet ds = new DataSet();                                                                //实例化DataSet类
            dap.Fill(ds, "Table");                                                                     //添加SQL语句并执行
            string[] arylist = new string[ds.Tables[0].Columns.Count];                            //按照列数定义字符串数组
            for (int i = 3; i < 4; i++)                               //遍历列
            {
                arylist[i] = ds.Tables[0].Columns[i].ColumnName;                                 //获取数据表中的列名
            }
            for (int j = 3; j < 4; j++)
            {
                comboBox1.Items.Add(arylist[j]);                                                        //将列名添加到comboBox1控件中
            }
            for (int t = 1; t < 6; t++)                               //遍历列
            {
                arylist[t] = ds.Tables[0].Columns[t].ColumnName;                                 //获取数据表中的列名
            }
            for (int a = 1; a < 6; a++)
            {
                comboBox2.Items.Add(arylist[a]);                                                        //将列名添加到comboBox1控件中
            }
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        MySqlConnection conn;

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要删除该行吗?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //获取点击datagridview1的行的 行号
                int r = this.dataGridView1.CurrentRow.Index;
                //获取此行的 员工编号 的值
                string yuangong = this.dataGridView1.Rows[r].Cells["ID_num"].Value.ToString();
                //删除 datagridview1 的选中行
                this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[r]);
                //删除数据库的 house_num) 的对应行
                string str = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";  //数据库链接字符串
                MySqlConnection conn = new MySqlConnection(str);                            //实例化链接
                conn.Open();                        //打了链接
                string sql = "delete from migrants_information where ID_num='" + yuangong + "'";

                MySqlCommand sda = new MySqlCommand(sql, conn);
                sda.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string constr = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";
            MySqlConnection conn = new MySqlConnection(constr);//创建数据库连接
            conn.Open();//打开连接
                        //往表 Tittle里插入指定内容。
            string str = string.Format("insert into migrants_information (ID_num,name,tel,in_time,out_time,item) values ('{0}','{1}','{2}','{3}','{4}','{5}')", textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
            MySqlCommand cmd = new MySqlCommand(str, conn);//对指定的连接conn执行SQL数据操作语句    
            int i = cmd.ExecuteNonQuery();//执行指定的sql操作语句。数据库表里的数据就被更新了,i表示受影响的行数。
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)//comboBox2下拉框选择笫一项
            {
                conn = new MySqlConnection("server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from migrants_information where in_time like '%" + textBox1.Text + "%'", conn);
                string sqlSel = "select count(*) from migrants_information where in_time ='" + textBox1.Text.Trim() + "'";
                MySqlCommand com = new MySqlCommand(sqlSel, conn);
                if (Convert.ToInt32(com.ExecuteScalar()) <= 0)
                {
                    MessageBox.Show("未找到该时间！显示失败！");
                    textBox1.Text = " ";
                }
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, "migrants_information");
                dataGridView1.DataSource = ds.Tables["migrants_information"];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == 0)//comboBox2下拉框选择笫一项
            {
                string str = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";    //数据库连接语句
                MySqlConnection connection = new MySqlConnection(str);   //连接数据库
                connection.Open();  //打开数据库连接
                string sql = "update migrants_information set name='" + textBox9.Text + "' where ID_num='" + textBox8.Text + "'";
                string sqlSel = "select count(*) from migrants_information where ID_num ='" + textBox8.Text.Trim() + "'";
                MySqlCommand com = new MySqlCommand(sqlSel, connection);
                if (Convert.ToInt32(com.ExecuteScalar()) <= 0)
                {
                    MessageBox.Show("未找到该身份证号！修改失败！");
                    textBox8.Text = " ";
                }
                else
                    MessageBox.Show("修改成功！");    
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            if (this.comboBox2.SelectedIndex == 1)//comboBox2下拉框选择笫二项
            {
                string str = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";    //数据库连接语句
                MySqlConnection connection = new MySqlConnection(str);   //连接数据库
                connection.Open();  //打开数据库连接
                string sql = "update migrants_information set building_num='" + textBox9.Text + "' where ID_num='" + textBox8.Text + "'";
                string sqlSel = "select count(*) from migrants_information where ID_num ='" + textBox8.Text.Trim() + "'";
                MySqlCommand com = new MySqlCommand(sqlSel, connection);
                if (Convert.ToInt32(com.ExecuteScalar()) <= 0)
                {
                    MessageBox.Show("未找到该身份证号！修改失败！");
                    textBox8.Text = " ";
                }
                else
                    MessageBox.Show("修改成功！");
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            if (this.comboBox2.SelectedIndex == 2)//comboBox2下拉框选择笫三项
            {
                string str = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";    //数据库连接语句
                MySqlConnection connection = new MySqlConnection(str);   //连接数据库
                connection.Open();  //打开数据库连接
                string sql = "update migrants_information set tel='" + textBox9.Text + "' where ID_num='" + textBox8.Text + "'";
                string sqlSel = "select count(*) from migrants_information where ID_num ='" + textBox8.Text.Trim() + "'";
                MySqlCommand com = new MySqlCommand(sqlSel, connection);
                if (Convert.ToInt32(com.ExecuteScalar()) <= 0)
                {
                    MessageBox.Show("未找到该身份证号！修改失败！");
                    textBox8.Text = " ";
                }
                else
                    MessageBox.Show("修改成功！");
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            if (this.comboBox2.SelectedIndex == 3)//comboBox2下拉框选择笫四项
            {
                string str = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";    //数据库连接语句
                MySqlConnection connection = new MySqlConnection(str);   //连接数据库
                connection.Open();  //打开数据库连接
                string sql = "update migrants_information set project='" + textBox9.Text + "' where ID_num='" + textBox8.Text + "'";
                string sqlSel = "select count(*) from migrants_information where ID_num ='" + textBox8.Text.Trim() + "'";
                MySqlCommand com = new MySqlCommand(sqlSel, connection);
                if (Convert.ToInt32(com.ExecuteScalar()) <= 0)
                {
                    MessageBox.Show("未找到该身份证号！修改失败！");
                    textBox8.Text = " ";
                }
                else
                    MessageBox.Show("修改成功！");
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            if (this.comboBox2.SelectedIndex == 4)//comboBox2下拉框选择笫五项
            {
                string str = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";    //数据库连接语句
                MySqlConnection connection = new MySqlConnection(str);   //连接数据库
                connection.Open();  //打开数据库连接
                string sql = "update migrants_information set date='" + textBox9.Text + "' where ID_num='" + textBox8.Text + "'";
                string sqlSel = "select count(*) from migrants_information where ID_num ='" + textBox8.Text.Trim() + "'";
                MySqlCommand com = new MySqlCommand(sqlSel, connection);
                if (Convert.ToInt32(com.ExecuteScalar()) <= 0)
                {
                    MessageBox.Show("未找到该身份证号！修改失败！");
                    textBox8.Text = " ";
                }
                else
                    MessageBox.Show("修改成功！");
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connString = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string sql = "select * from migrants_information";
            MySqlDataAdapter da = new MySqlDataAdapter();//实例化MysqlDataAdapter
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            da.SelectCommand = cmd1;//设置为已实例化MysqlDataAdapter的查询命令
            DataSet ds1 = new DataSet();//实例化DataSet
            da.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
