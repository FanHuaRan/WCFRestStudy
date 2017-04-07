using MusicStoreRestByWebHost.Daos;
using MusicStoreRestByWebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MusicStoreRestByWebHost.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFAlbumService
    {
        // 要使用 HTTP GET，请添加 [WebGet] 特性。(默认 ResponseFormat 为 WebMessageFormat.Json)
        // 要创建返回 XML 的操作，
        //     请添加 [WebGet(ResponseFormat=WebMessageFormat.Xml)]，
        //     并在操作正文中包括以下行:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // 在此处添加操作实现
            return;
        }

        // 在此处添加更多操作并使用 [OperationContract] 标记它们
        #region Fields
        private AlbumDao albumDao = new AlbumDao();
        #endregion
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Album/FindAll", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public List<Album> FindAll()
        {
            return albumDao.FindAll();
        }
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Album/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Album FindOne(Int32 id)
        {
            return albumDao.FindById(id);
        }
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Album/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Album Create(Album album)
        {
            try
            {
                return albumDao.Save(album);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Album/Update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public Album Update(Album album)
        {
            try
            {
                return albumDao.Update(album);
            }
            catch (Exception)
            {
                return null;
            }

        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Album/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public void delete(Int32 id)
        {
            albumDao.DeleteById(id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Album/Search?", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public List<Album> search(Int32? genreId, String title, decimal minPrice = 0, decimal maxPrice = 10000)
        {
            List<Func<Album, bool>> querys = new List<Func<Album, bool>>();
            if (genreId != null)
            {
                querys.Add(p => p.GenreId == genreId);
            }
            if (title != null && !(title == ""))
            {
                querys.Add(p => p.GenreId == genreId);
            }
            querys.Add(p => (p.Price >= minPrice) && (p.Price <= maxPrice));
            return albumDao.SimpleCompositeFind(querys.ToArray());
        }
    }
}
