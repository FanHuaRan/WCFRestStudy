using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MusicStoreDAL.EntityContext
{
    /// <summary>
    /// EF数据上下文
    /// 2017/04/01 fhr
    /// </summary>
    public class MusicStoreContext:DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public MusicStoreContext()
            : base("musicdb")
        {
            //取消代理类型，这样就失去了延迟加载的功能，否则序列化会出问题
            this.Configuration.ProxyCreationEnabled = false;
        }

        //重写OnModelCreating去掉表名复数
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}