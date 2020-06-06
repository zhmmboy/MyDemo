using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDemo.MVC.Controllers
{
    /// <summary>
    /// 这是登陆Controller
    /// </summary>
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUser()
        {
            Session["LoginUser"] = new { userId = 100, userName = "zmm" };
            Session.Timeout = 10;

            var path = Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrWhiteSpace(path))
            {
                Response.Redirect(path);
            }
            else
            {
                Response.Redirect("/Home/Index");
            }

            return View();
        }
    }
}