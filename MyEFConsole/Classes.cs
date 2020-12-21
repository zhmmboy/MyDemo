using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFConsole
{
    /// <summary>
    /// 班级类
    /// </summary>
    public class Classes
    {
        [Key]
        public string CID { get; set; }
        public string CName { get; set; }
        public int Persons { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
    }
}
