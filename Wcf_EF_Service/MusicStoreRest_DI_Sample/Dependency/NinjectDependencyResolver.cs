using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;
using MusicStoreRest_DI_Sample.Repositorys;
using MusicStoreRest_DI_Sample.Repositorys.Impl;
using MusicStoreRest_DI_Sample.Services;
using MusicStoreRest_DI_Sample.Services.Impl;
using Ninject.Syntax;
using System.Diagnostics.Contracts;
namespace MusicStoreRest_DI_Sample.Dependency
{
    /// <summary>
    /// 依赖注入容器，实现IDependencyResolver（IDependencyResolver继承自IDependencyScope）
    /// 前者接口代表依赖注入容器，后者代表依赖注入范围
    /// 2017/05/16 fhr
    /// </summary>
    public class NinjectDependencyResolver : NinjectDependencyScope,IDependencyResolver
    {
        /// <summary>
        /// Ninject依赖注入内核  实际上是个容器
        /// </summary>
        private IKernel kernel;
        /// <summary>
        /// 构造方法中注入了IKernel 非必需
        /// </summary>
        /// <param name="kernel"></param>
        public NinjectDependencyResolver(IKernel kernel)
            :base(kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            this.kernel = kernel;
            this.AddBindings();
        }
        /// <summary>
        /// 开始作用域 
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel);
        }
        /// <summary>
        /// 为容器添加组件
        /// </summary>
        private void AddBindings()
        {
            this.kernel.Bind<IAlbumRepository>().To<AlbumRepository>();
            this.kernel.Bind<IAlbumService>().To<AlbumService>();
        }
    }
    /// <summary>
    /// 依赖注入作用范围
    /// 2017/05/16
    /// </summary>
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);
            this.resolver = resolver;
        }

        public void Dispose()
        {
            resolver = null;
        }

        public object GetService(Type serviceType)
        {
            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return resolver.GetAll(serviceType);
        }
    }
}