using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDemo.WebUI
{
    public partial class SiteMaster : MasterPage
    {
        public string LoginUserName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //验证登陆
            new BasePage().IsLogin();
            LoginUserName = (Session["LoginUser"] as dynamic).userName;
        }
    }
}