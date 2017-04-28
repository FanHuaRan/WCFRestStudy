using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using MusicStoreWcfRestContract;
using cache = MusicStoreWcfRestContract.EnableCacheServiceContract;
using baseService = MusicStoreWcfRestService;
using System.ServiceModel.Web;
using System.Net;
namespace MusicStoreWcfRestService.EnableCache
{
    /// <summary>
    /// 带输出缓存的艺术家服务实现
    /// 2017/04/22 fhr
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFArtistService : cache.IWCFArtistService
    {
        private IWCFArtistService artistServiceDelegate = new MusicStoreWcfRestService.WCFArtistService();

        public IEnumerable<Artist> FindAll()
        {
            return artistServiceDelegate.FindAll();
        }

        public Artist FindById(string id)
        {
            return artistServiceDelegate.FindById(id);
        }

        public IEnumerable<Artist> FindByName(string name)
        {
            return artistServiceDelegate.FindByName(name);
        }

        public Artist Save(Artist artist)
        {
            return artistServiceDelegate.Save(artist);
        }

        public Artist Update(string id, Artist artist)
        {
            return artistServiceDelegate.Update(id, artist);
        }

        public void Delete(string id)
        {
            artistServiceDelegate.Delete(id);
        }
    }
}
