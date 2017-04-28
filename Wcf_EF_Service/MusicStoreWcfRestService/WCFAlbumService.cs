using MusicStoreBIL.Daos;
using MusicStoreUtils;
using MusicStoreWcfRestContract;
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
namespace MusicStoreWcfRestService
{
    /// <summary>
    /// 专辑服务实现
    /// 2017/04/05 fhr
    /// AspNetCompatibilityRequirements特性表示服务是否与ASP.NET兼容，兼容方可使用相关web特性
    /// ServiceBehavior为服务行为特性，这儿指定服务为多线程模式、单例
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFAlbumService : IWCFAlbumService
    {
        private AlbumDao albumDao = new AlbumDao();
        public Album Create(Album album)
        {
            if (EntityValidatorUtil.Validate<Album>(album))
            {
                var result=albumDao.Save(album);
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
                return result;
            }
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
            return null;
        }

        public IEnumerable<Album> FindAll()
        {
            return albumDao.FindAll();
        }

        public Album FindOne(string id)
        {
            var id2 = int.Parse(id);
            var album = albumDao.FindById(id2);
            if (album == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            return album;
        }

        public Album Update(Album album)
        {
            if (albumDao.FindById(album.AlbumId) == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                if (EntityValidatorUtil.Validate<Album>(album))
                {
                    var result = albumDao.Save(album);
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                    return result;
                }
            }
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
            return null;
        }

        public void Delete(string id)
        {
            var id2 = int.Parse(id);
            var album = albumDao.FindById(id2);
            if (album == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            albumDao.DeleteById(id2);
        }

        public IEnumerable<Album> search(int genreId, string title, decimal minPrice =-1, decimal maxPrice=-1)
        {
            var conditions = new List<Func<Album, bool>>();
            if (genreId != 0)
            {
                conditions.Add(album => album.GenreId == genreId);
            }
            if (title != null && title!="")
            {
                conditions.Add(album => album.Title == title);
            }
            if (minPrice != -1)
            {
                conditions.Add(album => album.Price >= minPrice);
            }
            if (maxPrice != -1)
            {
                conditions.Add(album => album.Price < maxPrice);
            }
            return albumDao.SimpleCompositeFind(conditions.ToArray());
        }
    }
}
