using MusicStoreDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract
{
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFAlbumService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Album/FindAll", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<Album> FindAll();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Album/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
         Album FindOne(Int32 id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Album/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Album Create(Album album);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Album/Update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Album Update(Album album);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Album/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void delete(Int32 id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Album/Search?", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<Album> search(Int32? genreId, String title, decimal minPrice = 0, decimal maxPrice = 10000);
    }
}
