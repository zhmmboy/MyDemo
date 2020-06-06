using MyDemo.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDemo.MVC.Controllers
{
    [CheckLoginFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["userName"] = (Session["LoginUser"] as dynamic).userName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}