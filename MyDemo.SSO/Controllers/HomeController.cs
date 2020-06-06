using MyDemo.SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using WebGrease;

namespace MyDemo.SSO.Controllers
{
    
    public class HomeController : Controller
    {
        [CheckLoginFilter]
        public ActionResult Index()
        {
            return View();
        }

        [CheckLoginFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CheckLoginFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// SSO登陆页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            var userCookie = HttpContext.Request.Cookies["userCookie"];
            if (userCookie!=null && !string.IsNullOrWhiteSpace(userCookie.Value))
            {
                //跳转到用户页面
                string returnUrl = Request.QueryString["ReturnUrl"];
                Response.Redirect(returnUrl + "?SID=" + userCookie.Value);
            }
            else
            {
                Response.RedirectToRoute("Default");
            }

            return View();
        }

        public static List<SysInfo> lstSystem = new List<SysInfo>(){
                                                new SysInfo  {
                                                    SID="1001",
                                                    SName="人事考勤系统",
                                                    Ticket="TK1001"
                                                },new SysInfo{
                                                    SID="1002",
                                                    SName="营销系统",
                                                    Ticket="TK1002"
                                                }
                                            };

        /// <summary>
        /// SSO登陆页面执行模拟登陆操作
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginUser()
        {
            string SID = Request.QueryString["SID"];
            List<string> lstSID = lstSystem.Select(t => t.SID).ToList();
            if (!string.IsNullOrWhiteSpace(SID) && lstSID.Contains(SID))
            {
                //登陆票据
                var single = lstSystem.FirstOrDefault(t => t.SID == SID);

                Session["LoginUser"] = single;
                Session.Timeout = 10;

                //保持当前用户登陆票据
                HttpContext.Response.Cookies.Add(new HttpCookie("userCookie")
                {
                    Domain = "",
                    Value = single.SID
                });

                //跳转到用户页面
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    Response.Redirect(returnUrl + "?SID=" + single.SID);
                }
                else
                {
                    Response.RedirectToRoute("Default");
                }
            }
            else
            {
                //跳转到登陆页面
                ViewBag.msg = "用户名或密码错误，登陆失败。";
            }

            return View();
        }
    }
}