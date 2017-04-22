using MusicStoreDAL.EntityContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreBIL.Daos
{
    /// <summary>
    /// 实体访问基本接口
    /// 2016/12/26 fhr
    /// </summary>
    interface IEntityBaseDao<T> : IDisposable
    {
        /// <summary>
        /// EF上下文get属性
        /// </summary>
        MusicStoreContext Context { get; }
        /// <summary>
        /// 根据ID进行查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(Int64 id);
        /// <summary>
        /// 根据ID进行删除
        /// </summary>
        /// <param name="obj"></param>
        void Delete(T obj);
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T Save(T obj);
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T Update(T obj);
        /// <summary>
        /// 更新对象 同时加一个获取对象主键的委托
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="getPkHandler"></param>
        /// <returns></returns>
        T Update(T obj, Func<T, object> getPkHandler);
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();
        /// <summary>
        /// 简单的组合查询
        /// 条件没有、则返回0记录
        /// </summary>
        /// <param name="delegates"></param>
        /// <returns></returns>
        IEnumerable<T> SimpleCompositeFind(params Func<T, bool>[] delegates);
        /// <summary>
        /// 通过单LINQ进行查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> FindByLinq(Func<T, bool> expression);
        /// <summary>
        /// 查询并选择
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="selectExpression"></param>
        /// <returns></returns>
        IEnumerable<object> FindByWhereAndSelect(Func<T, bool> whereExpression, Func<T, object> selectExpression);
        /// <summary>
        /// 选择
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="selectExpression"></param>
        /// <returns></returns>
        IEnumerable<V> FindBySelect<V>(Func<T, V> selectExpression);
        /// <summary>
        /// 根据主键删除对象
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(Int64 id);
    }
}
