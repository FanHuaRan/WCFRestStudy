using MusicStoreWcfRestContract;
using cache = MusicStoreWcfRestContract.EnableCacheServiceContract;
using baseService = MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.Net;
namespace MusicStoreWcfRestService.EnableCache
{
    /// <summary>
    /// 带输出缓存的流派服务实现
    /// 2017/04/22 fhr
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFGenreService : cache.IWCFGenreService
    {
        private IWCFGenreService genreServiceDelegate = new MusicStoreWcfRestService.WCFGenreService();

        public void Delete(string id)
        {
            genreServiceDelegate.Delete(id);
        }

        public IEnumerable<Genre> FindAll()
        {
            return genreServiceDelegate.FindAll();
        }

        public Genre FindById(string id)
        {
            return genreServiceDelegate.FindById(id);
        }

        public IEnumerable<Genre> FindByName(string name)
        {
            return genreServiceDelegate.FindByName(name);
        }

        public Genre Save(Genre genre)
        {
            return genreServiceDelegate.Save(genre);
        }

        public Genre Update(string id, Genre genre)
        {
            return genreServiceDelegate.Update(id,genre);
        }
    }
}
