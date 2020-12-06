using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Concurrent;
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
        public int UAage { get; set; }

        public override bool Equals(object obj)
        {
            var stu = obj as Student;
            return stu.UID == this.UID &&
                    stu.UName == this.UName &&
                    stu.UAage == this.UAage;
        }
    }

    /// <summary>
    /// 员工计数器
    /// </summary>
    class StuCount:IComparable
    {
        public string UID { get; set; }
        public string UName { get; set; }
        public int Count { get; set; }

        public int CompareTo(object obj)
        {
            var req = obj as StuCount;
            return (this.UID == req.UID &&
                this.UName == req.UName &&
                this.Count == req.Count) ? 1 : 0;
        }
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

            #region 数据结构1 Array/ArrayList 数组 内存上连续存储，节约空间，可以索引访问，读取快，增删慢
            //Array 固定长度，申明时就固定
            //int[] arrInt = new int[] { 1, 2, 3, 4 };
            //foreach (var item in arrInt)
            //{
            //    Console.WriteLine("item1:" + item);
            //}

            //ArrayList 不固定长度,存储类型为object,避免不了装箱和拆箱操作
            //内存上连续分配的存储空间，访问快，增删慢
            //ArrayList lstArr = new ArrayList();
            //lstArr.Add(1);
            //lstArr.Add(2);
            //lstArr.Add(3);
            //lstArr.Add(4);
            //lstArr.Add(5);
            //foreach (var item in lstArr)
            //{
            //    Console.WriteLine("item2：" + item);
            //}

            #endregion

            #region 数据结构2 List 泛型数组 

            //非连续存放 存储数据+地址 找数据只能顺序查找，读取慢，增删快
            //链表 List
            //泛型，链表都不是连续存储的，没有元素都记录有前后节点，节点值可以重复，不能根据索引下标访问，只能一个个顺序查找，读取慢，增删快
            //List<int> lst = new List<int>();
            //lst.Add(1);
            //lst.Add(2);
            //lst.Add(3);
            //foreach (var i in lst)
            //{
            //    Console.WriteLine("i:" + i.ToString());
            //}

            #endregion

            #region 数据结构3 LinkedList 链表

            //非连续存放 存储数据+地址 找数据只能顺序查找，读取慢，增删快
            //链表 LinkedList
            //泛型，链表都不是连续存储的，没有元素都记录有前后节点，节点值可以重复，不能根据索引下标访问，只能一个个顺序查找，读取慢，增删快
            //try
            //{
            //    LinkedList<string> linkedList = new LinkedList<string>();
            //    linkedList.AddLast("1");
            //    linkedList.AddLast(new LinkedListNode<string>("2"));

            //    var node2 = linkedList.Find("2");
            //    linkedList.AddBefore(node2, "3");

            //    var node3 = linkedList.Find("3");
            //    linkedList.AddAfter(node3, "0");

            //    foreach(var item in linkedList)
            //    {
            //        Console.WriteLine("item:"+item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            #endregion

            #region 数据结构4 Stack 栈

            //Console.WriteLine("栈操作");
            //Stack<int> stackInt = new Stack<int>();
            ////入栈
            //stackInt.Push(1);
            //stackInt.Push(2);
            //stackInt.Push(3);
            //stackInt.Push(4);
            //stackInt.Push(5);
            //stackInt.Push(6);
            ////出栈
            //foreach (var s in stackInt)
            //{
            //    Console.WriteLine(s.ToString());
            //}

            ////出栈操作
            //var a = stackInt.Peek();
            //Console.WriteLine("我获取了一个值：" + a);
            //Console.WriteLine("剩下的值：");
            //foreach (var s in stackInt)
            //{
            //    Console.WriteLine(s.ToString());
            //}

            //a = stackInt.Pop();
            //Console.WriteLine("我获取同时移除了一个值：" + a);
            //Console.WriteLine("剩下的值：");
            //foreach (var s in stackInt)
            //{
            //    Console.WriteLine(s.ToString());
            //}

            //stackInt.Reverse();
            //Console.WriteLine("反转以后的值：");
            //foreach (var s in stackInt)
            //{
            //    Console.WriteLine(s.ToString());
            //}
            #endregion

            #region 数据结构5 队列

            //Queue queue = new Queue();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //queue.Enqueue(4);
            //queue.Enqueue(5);
            //queue.Enqueue(6);

            //Console.WriteLine("入队了几个数据对象：");
            //foreach (var item in queue)
            //{
            //    Console.WriteLine("queue:" + item);
            //}

            //var a = queue.Peek();
            //var a2 = queue.Peek();
            //Console.WriteLine("把前两个对象的出队了,但是并没有删除");
            //foreach (var item in queue)
            //{
            //    Console.WriteLine("queue:" + item);
            //}
            //var b = queue.Dequeue();
            //var b2 = queue.Dequeue();
            //Console.WriteLine("把前两个对象的出队了,同时删除");
            //foreach (var item in queue)
            //{
            //    Console.WriteLine("queue:" + item);
            //}

            #endregion

            #region 数据结构6 HashSet 元素之间没有关系，动态增加容量，去重
            //一般使用场景，统计用户IP地址，IP投票， 交叉并补，二次好友/间接关注/粉丝集合
            //也是泛型集合
            try
            {
                //字符串去重复
                //HashSet<string> hasSet = new System.Collections.Generic.HashSet<string>();
                //hasSet.Add(JsonConvert.SerializeObject( new Student() { UID = "001", UName = "Tom" }));
                //hasSet.Add(JsonConvert.SerializeObject(new Student() { UID = "001", UName = "Tom" }));
                //hasSet.Add(JsonConvert.SerializeObject(new Student() { UID = "002", UName = "Jack" }));

                //foreach (var item in hasSet)
                //{
                //    Console.WriteLine("item:" + item);
                //}

                //复杂对象去重复
                //HashSet<Student> hasSet = new System.Collections.Generic.HashSet<Student>();
                //hasSet.Add(new Student() { UID = "001", UName = "Tom" });
                //hasSet.Add(new Student() { UID = "001", UName = "Tom" });
                //hasSet.Add(new Student() { UID = "002", UName = "Jack" });

                //foreach (var item in hasSet)
                //{
                //    Console.WriteLine("item:" + JsonConvert.SerializeObject(item));
                //}

                //hasset的存储是无序的
                //HashSet<int> hasInt = new HashSet<int>();
                //hasInt.Add(1);
                //hasInt.Add(2);
                //hasInt.Add(3);
                //hasInt.Add(4);
                //hasInt.Add(5);
                //hasInt.Add(6);
                //hasInt.Add(7);
                //hasInt.Add(8);
                //Console.WriteLine("hasSet的无序存放:");
                //foreach (var item in hasInt)
                //{
                //    Console.WriteLine("item:" + item);
                //}
            }
            catch (Exception e)
            {
                throw e;
            }

            #endregion

            #region 数据集合7 去重&&排序
            //使用场景，排名统计
            //复杂类型
            //SortedSet<StuCount> sortedInt = new SortedSet<StuCount>();
            //sortedInt.Add(new StuCount() { UID = "001", UName = "Tom", Count = 103 });
            //sortedInt.Add(new StuCount() { UID = "001", UName = "Tom", Count = 103 });
            //sortedInt.Add(new StuCount() { UID = "002", UName = "Jack", Count = 66 });
            //sortedInt.Add(new StuCount() { UID = "003", UName = "Luk", Count = 53 });
            //sortedInt.Add(new StuCount() { UID = "004", UName = "Tim", Count = 23 });

            //简单类型
            //SortedSet<int> sortedInt = new SortedSet<int>();
            //sortedInt.Add(1);
            //sortedInt.Add(2);
            //sortedInt.Add(2);
            //sortedInt.Add(2);
            //sortedInt.Add(3);
            //sortedInt.Add(4);

            //Console.WriteLine("排序&&去重的集合：");
            //foreach (var item in sortedInt)
            //{
            //    Console.WriteLine("item:" + JsonConvert.SerializeObject(item));
            //}

            #endregion

            #region 数据结构8 hastable

            //key-value键值对，一段有限的连续空间存放键值对（开辟的空间比用的多，hash是用空间换性能）；
            //基于key散列计算得到地址值，这样读取，增删改都快，一次定位。
            //如果出现两个key计算得到的散列结果一致，则第二个在第一个的基础上+1
            //

            //散列算法解释：
            //散列算法是把任意长度的输入，转换为固定长度的输出。且不能有输入推算出输出，这个的输出就是指我们常说的散列值，理论上来说存在两个相同的散列值，
            //但是这种出现的几率几乎是不可能的，所有我们会忽略（尽管真的可能存在）。
            //对应散列算法常用的场景为；文件校验，密码存储，数字签名等场合。

            //开发中常用的散列算法为：MD5,SHA-1

            //object:key  object:value
            //Hashtable ht = new Hashtable();
            //ht.Add("key1", "1");
            //ht.Add("key2", "2");
            //ht.Add("key3", "3");
            //ht.Add("key4", "4");
            //ht.Add("key5", "5");
            //ht["key6"] = "6";
            //ht["key7"] = "7";
            //ht["key8"] = "8";
            //ht["key9"] = "9";

            //Console.WriteLine("HT对象输出：");
            //foreach (DictionaryEntry item in ht)
            //{
            //    Console.WriteLine("item key:" + item.Key.ToString());
            //    Console.WriteLine("item value:" + item.Value.ToString());
            //}

            #endregion

            #region 数据结构9 Dictionary 数据字典

            //Dictionary<int, string> dic = new Dictionary<int, string>();
            //dic.Add(1, "1");
            //dic.Add(10, "10");
            //dic.Add(9, "9");
            //dic.Add(7, "7");
            //dic.Add(12, "12");

            //Console.WriteLine("数据字典：");
            //foreach (var item in dic)
            //{
            //    Console.WriteLine("item:" + item.Value.ToString());
            //}

            #endregion

            #region 数据结构11 有序字典

            //SortedDictionary<decimal, string> sortedDic = new SortedDictionary<decimal, string>();
            //sortedDic.Add(1, "1");
            //sortedDic.Add(10, "10");
            //sortedDic.Add(9, "9");
            //sortedDic.Add(7, "7");
            //sortedDic.Add(12, "12");
            //sortedDic[12] = "13";


            //Console.WriteLine("数据字典（有序的集合）：");
            //foreach (var item in sortedDic)
            //{
            //    Console.WriteLine("item:" + item.Value.ToString());
            //}

            #endregion

            #region 数据集合12 有序集合

            SortedList sortedList = new SortedList();
            sortedList.Add(1, "1");
            sortedList.Add(10, "10");
            sortedList.Add(9, "9");
            sortedList.Add(7, "7");
            sortedList.Add(12, "12");
            sortedList[12] = "13";
            Console.WriteLine("有序集合：");
            foreach (var item in sortedList.GetKeyList())
            {
                Console.WriteLine("item:" + sortedList[item].ToString());
            }

            #endregion


            #region 线程安全的队列

            //1.线程安全的队列
            ConcurrentQueue<int> queue = new System.Collections.Concurrent.ConcurrentQueue<int>();
            queue.Enqueue(1);
            int i;
            queue.TryPeek(out i);
            queue.TryDequeue(out i);

            //线程安全的栈
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();
            concurrentStack.Push(1);
            concurrentStack.TryPeek(out i);
            concurrentStack.TryPop(out i);

            //线程安全的对象
            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();
            concurrentBag.Add(1);
            concurrentBag.Add(2);
            concurrentBag.Add(3);
            concurrentBag.Add(4);

            //线程安全的字典
            ConcurrentDictionary<int, string> dicInt = new System.Collections.Concurrent.ConcurrentDictionary<int, string>();
            dicInt[1] = "001";
            dicInt[2] = "002";
            dicInt[3] = "003";
            dicInt[4] = "004";
            dicInt[5] = "005";

            #endregion


            Console.ReadKey();
        }


        /// <summary>
        /// 为了测试git，这是一个测试方法
        /// </summary>
        static void TestMethod1()
        {

        }


        /// <summary>
        /// 为了测试git，这是一个测试方法
        /// </summary>
        static void TestMethod2()
        {

        }


        /// <summary>
        /// 为了测试git，这是一个测试方法
        /// </summary>
        static void TestMethod3()
        {

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
