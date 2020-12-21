using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFConsole
{
    /// <summary>
    /// EF DBContext对象
    /// </summary>
    class StudentDBContext : DbContext
    {
        public StudentDBContext() : base("StudentDBFirst")
        {

        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StuClassesRelation> StuClassesRelation { get; set; }
    }
}
