using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDemo.WebUI
{
    public class BasePage
    {
        public void IsLogin()
        {
            if(HttpContext.Current.Session["LoginUser"]!=null)
            {
                //登陆成功
            }
            else
            {
                //登陆失败
                HttpContext.Current.Response.Redirect("/Login.aspx");
            }
        }

    }
}