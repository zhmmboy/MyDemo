using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    class Student
    {
        public string UID { get; set; }
        public string UName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region 值类型/引用类型，值传递，引用传递

            //Student stu = new Student()
            //{
            //    UID = "0001",
            //    UName = "Tom"
            //};

            //string str = "aaaaa。";

            //int a = 10;
            //Console.WriteLine("之前的a:"+a.ToString());
            //Console.WriteLine("之前的str:" + str);
            //Console.WriteLine("之前的stu:" + JsonConvert.SerializeObject(stu)) ;
            //DoInt(ref a);
            //DoStr(str);
            //DoStu(stu);
            //Console.WriteLine("之后的a:" + a.ToString());
            //Console.WriteLine("之后的str:" + str);
            //Console.WriteLine("之后的stu:" + JsonConvert.SerializeObject(stu));

            #endregion

            #region 数据结构1 内存上连续存储，节约空间，可以索引访问，读取快，增删慢
            //Array 固定长度，申明时就固定
            int[] arrInt = new int[] { 1, 2, 3, 4 };
            foreach(var item in arrInt)
            {
                Console.WriteLine("item1:" + item);
            }

            //ArrayList 不固定长度,存储类型为object,避免不了装箱和拆箱操作
            //内存上连续分配的存储空间，访问快，增删慢
            ArrayList lstArr = new ArrayList();
            lstArr.Add(1);
            lstArr.Add(2);
            lstArr.Add(3);
            lstArr.Add(4);
            lstArr.Add(5);
            foreach(var item in lstArr)
            {
                Console.WriteLine("item2：" + item);
            }

            #endregion

            #region 数据结构2

            //非连续存放 存储数据+地址 找数据只能顺序查找，读取慢，增删快
            //链表 LinkedList
            //泛型，链表都不是连续存储的，没有元素都记录有前后节点，节点值可以重复，不能根据索引下标访问，只能一个个顺序查找，读取慢，增删快
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddBefore(new LinkedListNode<int>(1), 10);




            #endregion


            Console.ReadKey();

        }

        

        /// <summary>
        /// 做一些操作
        /// </summary>
        static void DoInt(ref int a)
        {
            a = 1000;
        }

        /// <summary>
        /// 做一些操作
        /// </summary>
        static void DoStr(string a)
        {
            a = "ddddddd";
        }

        /// <summary>
        /// 做一些操作
        /// </summary>
        static void DoStu(Student stu)
        {
            stu.UName = "Jack";
        }
    }
}
