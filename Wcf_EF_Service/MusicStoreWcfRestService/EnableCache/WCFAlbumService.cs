using MusicStoreWcfRestContract;
using cache = MusicStoreWcfRestContract.EnableCacheServiceContract;
using baseService = MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
namespace MusicStoreWcfRestService.EnableCache
{
    /// <summary>
    /// 带输出缓存的专辑服务实现
    /// 使用了代理模式
    /// 2017/04/22 fhr
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFAlbumService : cache.IWCFAlbumService
    {
        private IWCFAlbumService albumServiceDelegate = new baseService.WCFAlbumService();
        public Album Create(Album album)
        {
            return albumServiceDelegate.Create(album);
        }

        public IEnumerable<Album> FindAll()
        {
            return albumServiceDelegate.FindAll();
        }

        public Album FindOne(string id)
        {
            return albumServiceDelegate.FindOne(id);
        }

        public Album Update(Album album)
        {
            return albumServiceDelegate.Update(album);
        }

        public void Delete(string id)
        {
            albumServiceDelegate.Delete(id);
        }

        public IEnumerable<Album> search(int genreId, string title, decimal minPrice =-1, decimal maxPrice=-1)
        {
           return albumServiceDelegate.search(genreId, title, minPrice, maxPrice);
        }
    }
}
