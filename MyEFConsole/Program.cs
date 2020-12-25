using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ///开始执行主数据
                using (var db = new StudentDBContext())
                {
                    //var cls = new Classes();
                    //cls.CID = "C001";
                    //cls.CName = "一年级（小班）";
                    //cls.AddUserID = 1;
                    //cls.Persons = 35;
                    //cls.AddDate = DateTime.Now;

                    ////不进行模型属性验证
                    //db.Configuration.AutoDetectChangesEnabled = false;
                    //db.Configuration.ValidateOnSaveEnabled = false;

                    //db.Classes.Add(cls);
                    //db.SaveChanges();

                    //cls = new Classes();
                    //cls.CID = "C002";
                    //cls.CName = "二年级";
                    //cls.AddUserID = 1;
                    //cls.Persons = 220;
                    //cls.AddDate = DateTime.Now;

                    //db.Classes.Add(cls);
                    //db.SaveChanges();

                    //Console.WriteLine("查询一条记录");
                    //var singleCls = db.Classes.Where(t => t.CID == "C001").FirstOrDefault();
                    //Console.WriteLine("我查询到了C001的记录：" + JsonConvert.SerializeObject(singleCls));

                    #region 使用 Entry 对象修改EF数据
                    //var singleCls = new Classes();
                    //singleCls.CID = "C001";
                    //singleCls.CName = "一年级（实验1班）";
                    //singleCls.Persons = 150;
                    //singleCls.AddUserID = 1;
                    //singleCls.AddDate = DateTime.Now;

                    //Console.WriteLine("我修改了记录：");

                    //DbEntityEntry<Classes> cls = db.Entry<Classes>(singleCls);
                    //cls.State = System.Data.Entity.EntityState.Unchanged;
                    //cls.Property("CName").IsModified = true;
                    //cls.Property("Persons").IsModified = true;
                    //db.SaveChanges();

                    #endregion


                    #region 使用Attach修改EF数据

                    //var singleCls = new Classes();
                    //singleCls.CID = "C001";
                    //singleCls.CName = "一年级（实验1班）";
                    //singleCls.Persons = 150;
                    //singleCls.AddUserID = 1;
                    //singleCls.AddDate = DateTime.Now;

                    //db.Classes.Attach(singleCls);
                    //singleCls.CName = "一年级（小实验班）";
                    //singleCls.Persons = 55;
                    //db.SaveChanges(); 

                    #endregion

                    #region EF 删除

                    //Console.WriteLine("删除二年级的信息。");
                    //var single = db.Classes.Where(t => t.CID == "C002").FirstOrDefault();
                    //db.Classes.Remove(single);
                    //db.SaveChanges();

                    #endregion

                    #region EF 事务处理


                    #endregion

                    #region EF 并发处理


                    #endregion

                    #region 使用EF的注意事项

                    //IQueryable会将查询语法转化为SQL查询语句，去数据库查询；IEnumerable则查询整张表，加载到内存中，再进行筛选。
                    //所以，当查询的数据量较大的时候，则使用IQueryable。反之，数据量较小，则使用IEnumerable,这样效率更高。
                    //注意: IQueryable 是延迟查询
                    //其特点是：读到词句代码时不会立即执行，而是在进行数据绑定时执行
                    //优点：此期间可以进行添加查询条件，以减少数据库查询内容，来减少内存占用量。
                    //在使用add()方法时，EF会进行数据的验证（很影响速度），数据的验证关闭方法：
                    //DBclient.Configuration.AutoDetectChangesEnabled = false;
                    //DBclient.Configuration.ValidateOnSaveEnabled = false;

                    //EF 如何关闭自动检测_MigrationHistory
                    //新增实体操作时会自动检测两遍Migrationhistory表，虽然是几毫秒的时间 但是性能啊 关注细节

                    //产生这个问题 主要是数据库初始化策略问题，

                    //一：数据库不存在时重新创建数据库

                    //Database.SetInitializer<testContext>(new CreateDatabaseIfNotExists<testContext>());

                    //                    二：每次启动应用程序时创建数据库

                    //Database.SetInitializer<testContext>(new DropCreateDatabaseAlways<testContext>());
                    //                    三：模型更改时重新创建数据库

                    //Database.SetInitializer<testContext>(new DropCreateDatabaseIfModelChanges<testContext>());

                    //                    四：从不创建数据库

                    //Database.SetInitializer<testContext>(null);
                    //Database.SetInitializer<EFDBContext>(null); 增加这句代码就可以了

                    #endregion

                }

                Console.WriteLine("执行完成");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                var msg = ex.ToString();

                throw;
            }

        }
    }
}
