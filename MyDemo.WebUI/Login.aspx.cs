using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDemo.WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["LoginUser"] = new { userId = 100, userName = "zmm" };
            Session.Timeout = 10;

            string path = "Default.aspx";
            if (!string.IsNullOrWhiteSpace(Request.QueryString["returnUrl"]))
            {
                path = Request.QueryString["returnUrl"];
            }

            HttpContext.Current.Response.Redirect(path);
        }
    }
}