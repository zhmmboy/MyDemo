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

        /// <summary>
        /// 实现Fluent Api，设置模型的一些属性，映射关系等
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //联合主键
            //modelBuilder.Entity<Classes>().HasKey(t => new { t.CID, t.CName });
            ////非数据库生成
            //modelBuilder.Entity<Classes>().Property(t => t.CID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            ////最大长度
            //modelBuilder.Entity<Classes>().Property(t => t.CName).HasMaxLength(100);
            ////必填项
            //modelBuilder.Entity<Classes>().Property(t => t.CName).IsRequired();
            ////属性不映射到数据库
            //modelBuilder.Entity<Classes>().Ignore(t => t.Floor);
            ////将列名映射到数据库特定的列名
            //modelBuilder.Entity<Classes>().Property(t => t.FloorHeight).HasColumnName("Height");
            //
            base.OnModelCreating(modelBuilder); 
        }

    }
}
