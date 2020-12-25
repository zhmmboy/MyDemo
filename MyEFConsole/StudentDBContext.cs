using MyEFConsole.Migrations;
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
            //程序运行时，始终删除重新创建数据库
            //Database.SetInitializer<StudentDBContext>(new DropCreateDatabaseAlways<StudentDBContext>());
            //第一次创建数据库时使用
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentDBContext>());
            //取消当模型发生改变时自动删除数据库重新创建的设置
            //Database.SetInitializer<StudentDBContext>(null);
            //根据最新迁移文件生成数据库
            Database.SetInitializer<StudentDBContext>(new MigrateDatabaseToLatestVersion<StudentDBContext, Configuration>());
        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StuClassesRelation> StuClassesRelation { get; set; }
    }
}
