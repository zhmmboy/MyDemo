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
                    //cls.CID = "C003";
                    //cls.CName = "三年级";
                    //cls.AddUserID = 1;
                    //cls.Persons = 430;
                    //cls.AddDate = DateTime.Now;

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
                    Console.WriteLine("删除二年级的信息。");
                    var single = db.Classes.Where(t => t.CID == "C002").FirstOrDefault();
                    db.Classes.Remove(single);
                    db.SaveChanges();
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
