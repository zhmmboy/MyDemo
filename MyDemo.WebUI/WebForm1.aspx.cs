using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDemo.WebUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                for (var i = 0; i < 1000; i++)
                {
                    //Thread:

                    //Thread t = new Thread(UpdateScore);
                    //t.Start();

                    //Thread t2 = new Thread(UpdateScore);
                    //t2.Start();

                    //Task: 对象练习
                    //Task对象几种启动线程的方式
                    //Task t = new Task(UpdateScore);
                    //t.Start();

                    //Task.Run(() =>
                    //{
                    //    UpdateScore();
                    //});

                    //new TaskFactory().StartNew(() =>
                    //{
                    //    UpdateScore();
                    //});                   
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        private static object lockObject = new object();

        /// <summary>
        /// 修复分数
        /// </summary>
        private void UpdateScore()
        {
            lock (lockObject)
            {
                SqlConnection sqlConn = new SqlConnection("server=.;database=TestDB;uid=sa;pwd=sa123;");
                try
                {
                    using (sqlConn)
                    {
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
                                //总分 - 1
                                sqlCmd = new SqlCommand("update StudentScores2 set Score = Score - 1 where UID = 1 ", sqlConn);
                                sqlCmd.ExecuteNonQuery();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {

                }
            }
        }
    }
}