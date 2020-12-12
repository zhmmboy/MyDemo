using MyEntity;

namespace MyService
{
    /// <summary>
    /// 泛型类，T 必须为引用类型 && 提供一个无参公共构造函数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StudentService<T> : IStudent<T> where T : class, new()
    {
        public StudentService() { }

        public bool AddAsync(Student t)
        {
            return false;
        }

        public bool Add(Student t)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Student t)
        {
            throw new System.NotImplementedException();
        }

        public bool Query(Student t)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 这是一个泛型方法
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveStudent<U>(U model)
        {
            return true;
        }

        public bool Update(Student t)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(T t)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(T t)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(T t)
        {
            throw new System.NotImplementedException();
        }

        public bool Query(T t)
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// 泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TeacherService<T> where T : MyEntity.Student
    {

    }
}
