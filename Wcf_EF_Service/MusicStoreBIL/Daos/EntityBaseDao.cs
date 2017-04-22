using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MusicStoreDAL.EntityContext;
using MusicStoreUtils;

namespace MusicStoreBIL.Daos
{
    /// <summary>
    /// 使用EF的实体访问泛型基类
    /// 2016/12/26 fhr
    /// </summary>
    public class EntityBaseDao<T> :IEntityBaseDao<T> where T : class
    {
        protected readonly MusicStoreContext context = new MusicStoreContext();
        public MusicStoreContext Context
        {
            get { return this.context; }
        }
        public virtual void Delete(T obj)
        {
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }
        public virtual void DeleteById(long id)
        {
            var model = FindById(id);
            if (model != null)
            {
                context.Set<T>().Remove(model);
                context.SaveChanges();
            }
        }
        public virtual T Save(T obj)
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

        public virtual T Update(T obj)
        {
            var key = ObjectRefletUtil.GetMainKeyValue(obj);
            var oldObj = context.Set<T>().Find(key);
            if (oldObj == null)
            {
                return null;
            }
            ObjectRefletUtil.SetValue<T>(oldObj, obj);
            context.Entry<T>(oldObj).State = EntityState.Modified;
            context.SaveChanges();
            return oldObj;
        }

        public virtual T Update(T obj, Func<T, object> getPkHandler)
        {
            var key = getPkHandler.Invoke(obj);
            var oldObj = context.Set<T>().Find(key);
            if (oldObj == null)
            {
                return null;
            }
            context.Entry<T>(oldObj).State = EntityState.Modified;
            context.SaveChanges();
            return oldObj;
        }

        public virtual IEnumerable<T> FindAll()
        {
            return context.Set<T>().Select(p => p).ToList<T>();
        }

        public virtual T FindById(long id)
        {
            return context.Set<T>().Find(id);
        }
        public virtual IEnumerable<T> FindByLinq(Func<T, bool> expression)
        {
            return context.Set<T>()
                .Where(expression)
                .Select(p => p)
                .ToList();
        }
        public virtual IEnumerable<object> FindByWhereAndSelect(Func<T, bool> whereExpression, Func<T, object> selectExpression)
        {
            return context.Set<T>()
                .Where(whereExpression)
                .Select(selectExpression)
                .ToList();
        }
        public virtual IEnumerable<V> FindBySelect<V>(Func<T, V> selectExpression)
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
        public virtual IEnumerable<T> SimpleCompositeFind(params Func<T, bool>[] delegates)
        {
            if (delegates.Length == 0)
            {
                return new List<T>();
            }
            var objects = context.Set<T>().Where(delegates[0]).Select(p => p);
            for (int i = 1; i < delegates.Length; i++)
            {
                var condition = delegates[i];
                objects = objects.Where(condition).Select(p => p).AsQueryable<T>();
            }
            return objects.ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
