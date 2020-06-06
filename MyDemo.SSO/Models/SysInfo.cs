using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDemo.SSO.Models
{
    public class SysInfo
    {
        public string SID { get; set; }
        public string SName { get; set; }

        /// <summary>
        /// 登陆票据
        /// </summary>
        public string Ticket { get; set; }
    }
}