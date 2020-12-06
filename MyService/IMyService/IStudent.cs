using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IStudent<T> where T : class, new()
    {
        bool Add(T t);
        bool Delete(T t);
        bool Update(T t);
        bool Query(T t);
    }
}
