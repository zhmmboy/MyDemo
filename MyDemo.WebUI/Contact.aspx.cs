using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDemo.WebUI
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //测试多线程
        protected void btnClick_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 100; i++)
            {
                Thread t = new Thread(UpdateScore);
                t.Start();

                Thread t2 = new Thread(UpdateScore);
                t2.Start();

                Thread t3 = new Thread(UpdateScore);
                t3.Start();

                Thread t4 = new Thread(UpdateScore);
                t4.Start();
            }
        }


        /// <summary>
        /// 修复分数
        /// </summary>
        private void UpdateScore()
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=TestDB;uid=sa;pwd=sa123;");
            SqlCommand sqlCmd = new SqlCommand("select Score from StudentScores2 where UID = 1 ", sqlConn);
            if (sqlConn.State == System.Data.ConnectionState.Closed)
            {
                sqlConn.Open();
            }
            var obj = sqlCmd.ExecuteScalar();
            if (obj != null)
            {
                var totalScore = Convert.ToInt32(obj);

                if (totalScore > 0)
                {
                    //总分-1
                    sqlCmd = new SqlCommand("update StudentScores2 set Score = Score - 1 where UID = 1 ", sqlConn);
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }
    }
}