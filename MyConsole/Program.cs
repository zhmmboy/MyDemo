using MyEntity;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyConsole
{
    /// <summary>
    /// 员工计数器
    /// </summary>
    class StuCount : IComparable
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
        static int index = 0;

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

            //SortedList sortedList = new SortedList();
            //sortedList.Add(1, "1");
            //sortedList.Add(10, "10");
            //sortedList.Add(9, "9");
            //sortedList.Add(7, "7");
            //sortedList.Add(12, "12");
            //sortedList[12] = "13";
            //Console.WriteLine("有序集合：");
            //foreach (var item in sortedList.GetKeyList())
            //{
            //    Console.WriteLine("item:" + sortedList[item].ToString());
            //}

            #endregion

            #region 线程安全的队列

            //1.线程安全的队列
            //ConcurrentQueue<int> queue = new System.Collections.Concurrent.ConcurrentQueue<int>();
            //queue.Enqueue(1);
            //int i;
            //queue.TryPeek(out i);
            //queue.TryDequeue(out i);

            ////线程安全的栈
            //ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();
            //concurrentStack.Push(1);
            //concurrentStack.TryPeek(out i);
            //concurrentStack.TryPop(out i);

            ////线程安全的对象
            //ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();
            //concurrentBag.Add(1);
            //concurrentBag.Add(2);
            //concurrentBag.Add(3);
            //concurrentBag.Add(4);

            ////线程安全的字典
            //ConcurrentDictionary<int, string> dicInt = new System.Collections.Concurrent.ConcurrentDictionary<int, string>();
            //dicInt[1] = "001";
            //dicInt[2] = "002";
            //dicInt[3] = "003";
            //dicInt[4] = "004";
            //dicInt[5] = "005";

            #endregion

            #region 泛型委托

            //Action<int> a = new Action<int>(TestMethod1);
            //Console.WriteLine("我是无返回值的泛型委托Action：");
            //a(10);

            //Console.WriteLine("我是有返回值的泛型委托Fun:");
            //Func<int, string> f = new System.Func<int, string>(TestMethod2);
            //var rt = f(18);
            //Console.WriteLine("我的返回值为：" + rt);

            //int[] arrInt = new int[] { 1, 2, 3, 4, 5 };
            //Array.Find(arrInt, t => t > 10);

            ////无返回值，一个参数的委托
            //Action<int> a = new Action<int>(Add);
            //a(1000);


            ////有返回值两个参数的委托
            //Func<int, int, int> f = new Func<int, int, int>(Add2);
            //f(12, 20);


            //List<Student> lstStu = new List<Student>();
            //lstStu.Add(new Student("001", "Tom", 12, "测试地址", "137348934301"));
            //lstStu.Add(new Student("002", "Tom2", 20, "测试地址2", "137348934302"));
            //lstStu.Add(new Student("003", "Tom3", 18, "测试地址3", "137348934303"));
            //lstStu.Add(new Student("004", "Tom4", 19, "测试地址4", "137348934304"));
            //lstStu.Add(new Student("005", "Tom5", 30, "测试地址5", "137348934305"));
            //lstStu.Add(new Student("006", "Tom6", 32, "测试地址6", "137348934306"));

            ////这是一个返回bool类型的委托，有且只有一个参数
            //Predicate<Student> p = new Predicate<Student>(Select);
            //Func<Student, bool> f2 = new Func<Student, bool>(Select);
            //var lstStuNew = lstStu.Where(f2).ToList();
            //lstStuNew.ForEach(t => Console.WriteLine("筛选出来的人员姓名：" + JsonConvert.SerializeObject(t)));
            #endregion

            #region Linq 

            //List<Student> lstStu = new List<Student>();
            //for (var i = 0; i < 100; i++)
            //    lstStu.Add(new Student() { UID = "00" + i, UName = "Tom" + i, UAge = 20 + i });

            //Console.WriteLine("查询50岁以上的人:");
            //var lstGenThan50 = (from lst in lstStu where lst.UAge > 50 select lst).ToList();
            //lstGenThan50.ForEach(t => Console.WriteLine(JsonConvert.SerializeObject(t)));

            #endregion

            #region 匿名方法

            //匿名方法是通过delegate关键字创建委托实例来声明的，例如：

            //NumberChanage nc = delegate (int i)
            //{
            //    Console.WriteLine("使用匿名方法实现委托。" + i);
            //};
            //nc(100);

            //NumberChanage nc2 = new NumberChanage(Add);
            //nc2(200);

            #endregion

            #region Lambda 是一种匿名函数，类似于函数式编程的表达式
            //lambda表达式简化了编程中的代码量
            //可以包含表达式和语句
            //可以创建委托或者表达式目录树类型
            //所有表达式都使用 => 表示，运算符读作 goes to
            //表达式左边为输入参数(如果有)，右边为表达式或者语句块
            //例如:
            //delegate int del(int i,int j);
            //del myDel = (x,y)=> x * y;
            //

            //del myDel = (x, y) => x * y;
            //var sum = myDel(10, 6);
            //Console.Write("结果：" + sum);

            //List<Student> lstStu = new List<Student>();
            //lstStu.Add(new Student("001", "Tom", 12, "测试地址", "137348934301"));
            //lstStu.Add(new Student("002", "Tom2", 20, "测试地址2", "137348934302"));
            //lstStu.Add(new Student("003", "Tom3", 18, "测试地址3", "137348934303"));
            //lstStu.Add(new Student("004", "Tom4", 19, "测试地址4", "137348934304"));
            //lstStu.Add(new Student("005", "Tom5", 30, "测试地址5", "137348934305"));
            //lstStu.Add(new Student("006", "Tom6", 32, "测试地址6", "137348934306"));

            ////查询年龄大于20的人
            ////匿名方法
            //IEnumerable<Student> q = lstStu.Where(delegate (Student s) { return s.UAge > 20; });
            //foreach(var item in q)
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //}

            //lambda表达式常用语句块
            //单参数，隐式类型=>表达式
            //x => x * 1;
            //多参数，隐式类型=>表达式
            //(x,y)=>x*y;
            //多参数，隐式类型语句块
            //(x,y)=>{x * y;};
            //单参数，显示表达式
            //(int i)=x=>x;
            //多参数，显示表达式
            //(int a,int b)=x=>x*y;

            //NumberChanage nc = (x, y) =>
            //{
            //    Console.WriteLine("这是lambda表达式。测试结果为：" + x * y);
            //    return x * y;
            //};
            //nc(2000, 10);

            //IEnumerable<Student> lstQuery = lstStu.Where(delegate (Student s) { return s.UAge > 20; });

            #endregion

            #region Lambda 表达式树

            //List<Student> lstStu = new List<Student>();
            //lstStu.Add(new Student("001", "Tom", 12, "测试地址", "137348934301"));
            //lstStu.Add(new Student("002", "Tom2", 20, "测试地址2", "137348934302"));
            //lstStu.Add(new Student("003", "Tom3", 18, "测试地址3", "137348934303"));
            //lstStu.Add(new Student("004", "Tom4", 19, "测试地址4", "137348934304"));
            //lstStu.Add(new Student("005", "Tom5", 30, "测试地址5", "137348934305"));
            //lstStu.Add(new Student("006", "Tom6", 32, "测试地址6", "137348934306"));

            //Expression<Func<int, int, int, int, int>> func = (x, y, z, r) => (z + r) * (x + y);
            //var compile=func.Compile();
            //var rt = compile(1, 2, 3, 4);
            //Console.WriteLine("最简单的表达式树生成的结果为：" + rt);

            //表达式参数声明
            //ParameterExpression a = Expression.Parameter(typeof(int), "x");
            //ParameterExpression b = Expression.Parameter(typeof(int), "y");
            //ParameterExpression c = Expression.Parameter(typeof(int), "z");
            //ParameterExpression d = Expression.Parameter(typeof(int), "r");

            //Expression exp = Expression.Add(a, b);
            //Expression exp2 = Expression.Add(c, d);

            //Expression exp3 = Expression.Multiply(exp, exp2);

            //Expression<Func<int, int, int, int, int>> func = Expression.Lambda<Func<int, int, int, int, int>>(exp3, a, b, c, d);
            //var com=func.Compile();
            //var rt = com(1, 2, 3, 4);
            //Console.WriteLine("复杂一点的Expression表达式:" + rt);

            //ParameterExpression a = Expression.Parameter(typeof(int), "x");
            //ParameterExpression b = Expression.Parameter(typeof(int), "y");
            //ParameterExpression c = Expression.Parameter(typeof(int), "z");
            //ParameterExpression d = Expression.Parameter(typeof(int), "r");

            //Expression exp = Expression.Add(a, b);
            //Expression exp2 = Expression.Multiply(c, d);
            //Expression exp3 = Expression.Subtract(exp, exp2);


            //Expression<Func<int, int, int, int, int>> fun = Expression.Lambda<Func<int, int, int, int, int>>(exp3, a, b, c, d);
            //var com=fun.Compile();
            //var rt = com.Invoke(1, 2, 3, 4);

            //Console.WriteLine("表达式树测试结果：" + rt.ToString());

            #endregion


            #region 多线程编程,模拟并发操作

            ////声明3个线程
            //Task task = new Task(mehtod);
            //task.Start();
            //task.Wait(5000);

            //Task task2 = new Task(mehtod2);
            //task2.Start();

            //Task task3 = new Task(mehtod3);
            //task3.Start();

            ////有一个执行完成，就继续执行
            //Task.WaitAny(task, task2, task3);
            //Console.WriteLine("有一个执行完成，就继续执行");


            ////等待所有执行完成，就继续执行
            //Task.WaitAll(task, task2, task3);
            //Console.WriteLine("等待所有执行完成，就继续执行");

            //带返回值的线程
            //Task<int> task4 = Task.Run(() => TaskAdd(10, 20));
            //Console.WriteLine("我拿到了线程的返回值：" + task4.Result);

            //异步线程
            //Console.WriteLine("我开启了一个子线程。。。。");
            //var rt = TaskAddAsync(10, 30);
            //Console.WriteLine("主线程继续干活....");
            //var value = rt.Result;
            //Console.WriteLine("我拿到了异步线程的返回值：" + value);

            //Console.WriteLine("我需要从百度拿点东西...");
            //Task<string> s = GetHtml();
            //Console.WriteLine("我是主线程，不管他，我们继续吃饭");

            //Console.WriteLine("我已经成功从百度拿到了东西，大小为：" + s.Result.Length);
            //Console.WriteLine("我目前的状态为 s.IsCanceled:" + s.IsCanceled + "  s.IsCompleted:" + s.IsCompleted + "   s.IsFaulted:" + s.IsFaulted);

            //CancellationTokenSource source = new CancellationTokenSource();
            //CancellationToken token = source.Token;
            //ManualResetEvent ev = new ManualResetEvent(true);


            //Task t = new Task(async () =>
            //{
            //    if (token.IsCancellationRequested)
            //        return;

            //    //初始化设置为true时，这里则不阻塞
            //    ev.WaitOne();

            //    await Task.Delay(10000);

            //}, token);

            //t.Start();
            //source.Cancel();
            //ev.Set();
            //ev.Reset();


            #endregion

            #region 并行编程 Parallel对象



            #endregion


            //SqlConnection sqlConn = new SqlConnection("server=.;database=TestDB;uid=sa;pwd=sa123");
            using (SqlConnection sqlConn = new SqlConnection("server=.;database=TestDB;uid=sa;pwd=sa123"))
            {
                if(sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }

                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM TestDB.DBO.StudentScores2", sqlConn);
                SqlDataAdapter sqlada = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sqlada.Fill(ds);

                ConcurrentQueue<string> strQueue = new ConcurrentQueue<string>();
                ConcurrentBag<int> strBag = new ConcurrentBag<int>();
                for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strQueue.Enqueue(ds.Tables[0].Rows[i]["UID"].ToString());
                }

                Console.WriteLine("模拟开始10w个线程");
                while (!strQueue.IsEmpty)
                {
                    Console.WriteLine("当前在执行的线程数：" + strBag.Count);
                    if (strBag.Count < 3)
                    {
                        string str = string.Empty;
                        if (strQueue.TryDequeue(out str))
                        {
                            Task.Factory.StartNew(() =>
                            {
                                strBag.Add(1);
                                Console.WriteLine("开启了一个线程1。。");
                                //Thread.Sleep(3000);
                                Console.WriteLine("线程执行完成1。。我消费了：" + str);
                                //sqlCmd = new SqlCommand("UPDATE TestDB.DBO.StudentScores2 SET Remark='" + str + "' where uid="+str, sqlConn);
                                //sqlCmd.CommandTimeout = 1000 * 50;
                                //sqlCmd.ExecuteNonQuery();

                            }).ContinueWith((t) =>
                            {
                                int num = 0;
                                strBag.TryTake(out num);
                            });
                        }
                        string str2 = string.Empty;
                        if (strQueue.TryDequeue(out str2))
                        {
                            Task.Factory.StartNew(() =>
                            {
                                strBag.Add(1);

                                Console.WriteLine("开启了一个线程2。。");
                                //Thread.Sleep(3000);
                                Console.WriteLine("线程执行完成2。。我消费了：" + str2);
                                //sqlCmd = new SqlCommand("UPDATE TestDB.DBO.StudentScores2 SET Remark='" + str2 + "' where uid=" + str2, sqlConn);
                                //sqlCmd.CommandTimeout = 1000 * 50;
                                //sqlCmd.ExecuteNonQuery();                                

                            }).ContinueWith((t) =>
                            {
                                int num = 0;
                                strBag.TryTake(out num);
                            });
                        }
                        string str3 = string.Empty;
                        if (strQueue.TryDequeue(out str3))
                        {
                            Task.Factory.StartNew(() =>
                            {
                                strBag.Add(1);

                                Console.WriteLine("开启了一个线程3。。");
                                //Thread.Sleep(3000);
                                Console.WriteLine("线程执行完成3。。我消费了：" + str3);
                                //sqlCmd = new SqlCommand("UPDATE TestDB.DBO.StudentScores2 SET Remark='" + str3 + "' where uid=" + str3, sqlConn);
                                //sqlCmd.CommandTimeout = 1000 * 50;
                                //sqlCmd.ExecuteNonQuery();

                            }).ContinueWith((t) =>
                            {
                                int num = 0;
                                strBag.TryTake(out num);
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine("当前在执行的线程数：" + strBag.Count + ";目前不执行，等待上次开启的线程结束。。。。");
                        Thread.Sleep(1000);
                    }
                }
                Console.WriteLine("模拟结束。一共开启了多个线程：" + index);
                Console.ReadKey();
            }
        }

        static void mehtod()
        {
            Console.WriteLine("这是方法1,我暂停了5s后继续执行。");
        }

        static void mehtod2()
        {
            Console.WriteLine("这是方法2");

        }

        static void mehtod3()
        {
            Console.WriteLine("这是方法3");

        }

        /// <summary>
        /// 这是一个带返回值的线程方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int TaskAdd(int x, int y)
        {
            return x * y;
        }

        async static Task<int> TaskAddAsync(int x, int y)
        {
            await Task.Delay(1000);
            Console.WriteLine("我是子线程，我正在休息1s后继续执行");
            return 1000;
        }

        /// <summary>
        /// 模拟从百度下载页面内容
        /// </summary>
        /// <returns></returns>
        async static Task<string> GetHtml()
        {
            try
            {
                Console.WriteLine("我是子线程，我正在偷偷的从百度下载东西,预计5s完成。");
                await Task.Delay(5000);
                HttpClient http = new HttpClient();

                return await http.GetStringAsync("http://www.baidu.com");
            }
            catch (Exception)
            {

            }
            return string.Empty;
        }

        /// <summary>
        /// 修复分数
        /// </summary>
        static void UpdateScore()
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=TestDB;uid=sa;pwd=sa123;");
            SqlCommand sqlCmd = new SqlCommand("select Score from StudentScores2 where UID = 1 ", sqlConn);
            if (sqlConn.State == System.Data.ConnectionState.Closed)
            {
                sqlConn.Open();
            }
            var obj = sqlCmd.ExecuteScalar();
            if (obj != null)
            {
                var totalScore = Convert.ToInt32(obj);

                Console.WriteLine("当前分数为：" + totalScore);

                if (totalScore > 0)
                {
                    //总分-1
                    sqlCmd = new SqlCommand("update StudentScores2 set Score = Score - 1 where UID = 1 ", sqlConn);
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }



        delegate int NumberChanage(int n, int y);

        delegate int del(int i, int j);

        static void Add(int i)
        {
            Console.WriteLine("这是一个拥有一个参数无返回值的委托方法" + i);
        }

        /// <summary>
        /// 这是一个有返回值，两个参数的委托
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int Add2(int x, int y)
        {
            Console.WriteLine("这是一个有返回值，两个参数的委托。返回值为：" + x * y);
            return x * y;
        }

        /// <summary>
        /// 这是一个参数，而且只能有一个参数，返回bool类型的委托
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static bool Select(Student s)
        {
            return s.UAge > 30;
        }

        /// <summary>
        /// 为了测试git，这是一个测试方法
        /// </summary>
        static void TestMethod1<T>(T t)
        {
            Console.WriteLine("我是 TestMethod1 方法。传入的参数为：" + t);
        }

        /// <summary>
        /// 为了测试git，这是一个测试方法
        /// </summary>
        static string TestMethod2(int age)
        {
            Console.WriteLine("我是 TestMethod2 方法。");
            return string.Format("我今年 {0} 岁了。", age);
        }

        /// <summary>
        /// 为了测试git，这是一个测试方法
        /// </summary>
        static void TestMethod3()
        {
            Console.WriteLine("我是 TestMethod3 方法。");
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
