using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Collections;

namespace winMap
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]  
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]   

    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str_url = Application.StartupPath + "\\IndexMap.html";  
             Uri url = new Uri(str_url);  
             webBrowser1.Url = url;  
             webBrowser1.ObjectForScripting = this;
             timer1.Enabled = true;  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try  
           {  
               string tag_lng = webBrowser1.Document.GetElementById("mouselng").InnerText;  
               string tag_lat = webBrowser1.Document.GetElementById("mouselat").InnerText;  
               double dou_lng, dou_lat;  
               if (double.TryParse(tag_lng, out dou_lng) && double.TryParse(tag_lat, out dou_lat))  
               {  
                   this.toolStripStatusLabel1.Text ="当前坐标："+ dou_lng.ToString("F5") + "," + dou_lat.ToString("F5");  
               }  
           }  
           catch (Exception ee)  
           { 
               //MessageBox.Show(ee.Message); 
           }  

        }

        //开启测距工具按钮  
      private void btnOpenDistance_Click(object sender, EventArgs e)  
      {  
          webBrowser1.Document.InvokeScript("openGetDistance");  
      }

      private void button2_Click(object sender, EventArgs e)
      {
          webBrowser1.Document.InvokeScript("PUTANDSEND");  
      }  
             //得到Radiobutton的值  
      public string setWhichCar()  
      {  
           return "1"; 
      }
        //将从JS里得到的汽车数据显示到文本框内，并且存入数据库  
      public void PutIntotextBox(object markerIndex, object carNumber, object JSlng, object JSlat)
      {
          string str=  markerIndex.ToString()+" "+  (string)carNumber+" "+ JSlng.ToString()+" "+JSlat.ToString();
          MessageBox.Show(str);
      }

        #region 画轨迹
      int Rows_Num = 0;
        double[] pointArr;
       public void whichCarData()  
       {        
               //OleDbDataReader DR = DBfunction.getread(limit_sql);  
               ArrayList a = new ArrayList();

               for (int i = 0; i < 10; i++)
               {
                   int lng = 108 + i/2;
                   int lat = 36 - i;
                   a.Add(lng.ToString());//经度  
                   a.Add(lat.ToString());//纬度  
                   Rows_Num++; 
               }  
               if (Rows_Num == 0)  
                   MessageBox.Show("该车辆，无历史信息！");  
               else  
               {
                   pointArr = new double[2*Rows_Num];
                   for (int i = 0; i <= 2 * Rows_Num - 1; i++)  
                   {  
                       pointArr[i] = Convert.ToDouble(a[i]);  
                   }  
  
                   webBrowser1.Document.InvokeScript("DrawOrit1");  
               }  
       }  
      //辅助方法  
       //获取计数  
       public int getRowsNumber()  
       {  
           return Rows_Num;  
       }

       public void ClearRows_num()
       {
           Rows_Num = 0;
       }
//根据索引获取特定坐标  
       public double Getpoints(int index)  
       { return pointArr[index]; } 

        #endregion

       private void button3_Click(object sender, EventArgs e)
       {
           whichCarData();
       }

        //开启画图工具按钮 
       private void btnDrawPicture_Click(object sender, EventArgs e)  
      {  
          if (radio_Circle.Checked)  
          { webBrowser1.Document.InvokeScript("drawCircle"); }  
          else  
          { webBrowser1.Document.InvokeScript("drawRec"); }  
      }

       public int Danger_Num = 0;
       public double SearchAllCars(int index)  
        {   
            //string sql="select * from 汽车轨迹数据";  
            //OleDbDataReader dr= DBfunction.getread(sql);  
           ArrayList allCars = new ArrayList();
           for (int i = 0; i < 10; i++)
           {
               int lng = 108 + i / 2;
               int lat = 36 - i;
               allCars.Add(lng.ToString());//经度  
               allCars.Add(lat.ToString());//纬度  
               Danger_Num++;
           }
           Danger_Num = 10;
           double[] sendto_JS = new double[2 * Danger_Num];  
            if (Danger_Num == 0)
                MessageBox.Show("该车辆，无历史信息！");
            else
            {
                pointArr = new double[2 * Danger_Num];
                for (int i = 0; i <= 2 * Danger_Num - 1; i++)
                {
                    sendto_JS[i] = Convert.ToDouble(allCars[i]);
                } 
            }  
            return sendto_JS[index];  
        }  
        //全局变量，返回有危险的车辆个数  
        public int GetdangerNum()  
        { return Danger_Num; }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SearchAllCars(0);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
