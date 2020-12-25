using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyEFConsole
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        public Student() { }

        [Key]
        [MaxLength(36)]
        public string UID { get; set; }
        public string UName { get; set; }
        public int UAge { get; set; }
        //身高
        public int Hight { get; set; }
        public string IDCard { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
    }
}
