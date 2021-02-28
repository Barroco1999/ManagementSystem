using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 myform = new Form2();   //新窗口
            myform.Show();
            this.Close(); //关闭
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string sql = "select * from building_information";
            MySqlDataAdapter da = new MySqlDataAdapter();//实例化MysqlDataAdapter
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            da.SelectCommand = cmd1;//设置为已实例化MysqlDataAdapter的查询命令
            DataSet ds1 = new DataSet();//实例化DataSet
            da.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            conn.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8");       //连接数据库
            cn.Open();                                                                            //打开连接的数据库
            MySqlDataAdapter dap = new MySqlDataAdapter("SELECT * FROM building_information", cn);    //建立SQL语句与数据库的连接
            DataSet ds = new DataSet();                                                                //实例化DataSet类
            dap.Fill(ds, "Table");                                                                     //添加SQL语句并执行
            string[] arylist = new string[ds.Tables[0].Columns.Count];                            //按照列数定义字符串数组
            for (int i = 0; i < 1; i++)                               //遍历列
            {
                arylist[i] = ds.Tables[0].Columns[i].ColumnName;                                 //获取数据表中的列名
            }
            for (int j = 0; j < 1; j++)
            {
                comboBox1.Items.Add(arylist[j]);                                                        //将列名添加到comboBox1控件中
            }
            for (int t = 2; t < 3; t++)                               //遍历列
            {
                arylist[t] = ds.Tables[0].Columns[t].ColumnName;                                 //获取数据表中的列名
            }
            for (int a = 2; a < 3; a++)
            {
                comboBox2.Items.Add(arylist[a]);                                                        //将列名添加到comboBox1控件中
            }
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        MySqlConnection conn;

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)//comboBox2下拉框选择笫一项
            {
                /*MySqlConnection cn = new MySqlConnection("server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8");       //连接数据库
                cn.Open();*/
                conn = new MySqlConnection("server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from building_information where building_num like '%" + textBox1.Text + "%'", conn);
                string sqlSel = "select count(*) from building_information where building_num ='" + textBox1.Text.Trim() + "'";
                MySqlCommand com = new MySqlCommand(sqlSel, conn);
                if(Convert.ToInt32(com.ExecuteScalar()) <= 0)
                {
                    MessageBox.Show("未找到该楼号！显示失败！");
                    textBox1.Text = " ";
                }
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, "building_information");
                dataGridView1.DataSource = ds.Tables["building_information"];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == 0)//comboBox2下拉框选择笫一项
            {
                string str = "server=127.0.0.1;database=mydatabase;uid=root;pwd= ;charset=utf8";    //数据库连接语句
                MySqlConnection connection = new MySqlConnection(str);   //连接数据库
                connection.Open();  //打开数据库连接
                string sql = "update building_information set date='" + textBox3.Text + "' where building_num='" + textBox2.Text + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                string sqlSel = "select count(*) from building_information where building_num ='" + textBox2.Text.Trim() + "'";
                MySqlCommand com = new MySqlCommand(sqlSel, connection);
                if (Convert.ToInt32(com.ExecuteScalar()) <= 0)
                {
                    MessageBox.Show("未找到该楼号！修改失败！");
                    textBox2.Text = " ";
                }
                else
                    MessageBox.Show("修改成功！");
                command.ExecuteNonQuery();
                connection.Close();
                
            }
        }
    }
}
