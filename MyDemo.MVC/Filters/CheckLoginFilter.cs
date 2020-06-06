using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyDemo.MVC.Filters
{
    public class CheckLoginFilter : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //验证当前用户是否登陆
            //if (HttpContext.Current.Session["LoginUser"] != null)
            var userCookie = HttpContext.Current.Request.Cookies["userCookie"];
            if (userCookie != null)
            {
                string SID = userCookie.Value;
                if (!string.IsNullOrWhiteSpace(SID))
                {
                   HttpContext.Current.Session["LoginUser"] = new { userId = 1001, userName = "zmm" };
                   HttpContext.Current.Session.Timeout = 10;
                    
                    //跳转登陆成功页面
                    return true;
                }
                else
                {
                    return false;
                }
            } else if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.QueryString["SID"]))
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("userCookie")
                {
                    Domain = "",
                    Value = "1001"
                });

                HttpContext.Current.Session["LoginUser"] = new { userId = 1001, userName = "zmm" };
                HttpContext.Current.Session.Timeout = 10;

                //跳转登陆成功页面
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 当执行action之前发送
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string path = HttpContext.Current.Request.RawUrl;

            ////跳转到登陆页面
            //var route = new RouteValueDictionary()
            //    {
            //        { "Controller","Login"},
            //        { "Action","Index"},
            //        { "ReturnUrl",path }
            //    };

            ////跳转登陆页
            //filterContext.Result = new RedirectToRouteResult(route);
            filterContext.Result = new RedirectResult("http://ssosite.com/Home/Login?SID=1001&ReturnUrl=http://prosite1.com/" + HttpContext.Current.Request.RawUrl);

            //base.HandleUnauthorizedRequest(filterContext);
        }
    }
}