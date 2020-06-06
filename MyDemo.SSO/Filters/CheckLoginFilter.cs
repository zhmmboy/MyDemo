using MyDemo.SSO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyDemo.SSO
{
    public class CheckLoginFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //获取cookie
            var userCookie = HttpContext.Current.Request.Cookies["userCookie"];
            if (userCookie != null && !string.IsNullOrWhiteSpace(userCookie.Value))
            {
                string sID = userCookie.Value;
                if (HttpContext.Current.Session["LoginUser"] != null)
                {
                    //验证cookie
                    var single = (HttpContext.Current.Session["LoginUser"] as SysInfo);
                    //登陆成功
                    if (single != null && single.SID==sID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
            //return base.AuthorizeCore(httpContext);
        }

        /// <summary>
        /// 登陆跳转
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //string returnUrl = HttpContext.Current.Request["returnUrl"];
            //if (!string.IsNullOrWhiteSpace(returnUrl))
            //{
            //    HttpContext.Current.Response.RedirectToRoute(returnUrl);
            //}
            //else
            //{
            var route = new RouteValueDictionary() {
                { "Controller","Home"},
                { "Action","Login"},
                { "ReturnUrl",""}
            };

            HttpContext.Current.Response.RedirectToRoute(route);
            //HttpContext.Current.Response.Redirect("https://localhost:44378/Home/Login");
            //}

            //base.HandleUnauthorizedRequest(filterContext);
        }
    }
}