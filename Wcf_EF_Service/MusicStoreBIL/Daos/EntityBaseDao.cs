using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MusicStoreDAL.EntityContext;

namespace MusicStoreBIL.Daos
{
    /// <summary>
    /// 实体访问泛型基类
    /// 2016/12/26 fhr
    /// </summary>
    public class EntityBaseDao<T> :IDisposable where T : class
    {
        protected readonly MusicStoreContext context = new MusicStoreContext();
        public void Delete(T obj)
        {
            context.Set<T>().Remove(obj);
            context.SaveChanges(); 
        }

        public T Save(T obj)
        {
            try
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public  T Update(T obj,Func<T,object> getPkHandler)
        {
            object key = getPkHandler.Invoke(obj);
           T oldObj = context.Set<T>().Find(key);
            if (oldObj == null)
            {
                return null;
            }
            context.Entry<T>(oldObj).State = EntityState.Modified;
            context.SaveChanges();
            return oldObj;
        }
        public virtual T Update(T obj)
        {
            return null;
        }

        public  List<T> FindAll()
        {
            return context.Set<T>().Select(p => p).ToList<T>();
        }

        public void DeleteById(long id)
        {
            T model = FindById(id);
            if (model != null)
            {
                context.Set<T>().Remove(model);
                context.SaveChanges();
            }  
        }
        public T FindById(long id)
        {
            return context.Set<T>().Find(id);
        }
        public List<T> FindByLinq(Func<T, bool> expression)
        {
            return context.Set<T>()
                .Where(expression)
                .Select(p => p)
                .ToList();
        }
        public List<object> FindByWhereAndSelect(Func<T, bool> whereExpression, Func<T, object> selectExpression)
        {
            return context.Set<T>()
                .Where(whereExpression)
                .Select(selectExpression)
                .ToList();
        }
        public List<V> FindBySelect<V>(Func<T, V> selectExpression)
        {
            return context.Set<T>()
                .Select(selectExpression)
                .ToList<V>();
        }
        /// <summary>
        /// 自定义的组合查询
        /// 不提倡
        /// </summary>
        /// <param name="delegates"></param>
        /// <returns></returns>
        public List<T> SimpleCompositeFind(params Func<T, bool>[] delegates)
        {
            //return context.Set<T>()
            //    .Where(p => isRight(p, delegates))
            //    .ToList();
            if (delegates.Length == 0)
            {
                return FindAll();
            }
            var objects = context.Set<T>().Select(p => p);
            foreach (var condition in delegates)
            {
                objects =objects.Where(condition).Select(p => p).AsQueryable<T>();
            }
            return objects.ToList();
        }
        private bool isRight(T obj, params Func<T, bool> []delegates)
        {
            foreach (var v in delegates)
            {
                if (!v(obj))
                {
                    return false;
                }
            }
            return true;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
