using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyEFConsole
{
    /// <summary>
    /// 学生班级关系表
    /// </summary>
    public class StuClassesRelation
    {
        [Key]
        public string UID { get; set; }
        public string CID { get; set; }
    }
}
