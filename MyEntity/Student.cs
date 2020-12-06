using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntity
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        public string UID { get; set; }
        public string UName { get; set; }
        public int UAge { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }

        public override bool Equals(object obj)
        {
            var stu = obj as Student;
            return stu.UID == this.UID &&
                    stu.UName == this.UName &&
                    stu.UAge == this.UAge &&
                    stu.Address == this.Address &&
                    stu.Mobile == this.Mobile;
        }
    }
}
