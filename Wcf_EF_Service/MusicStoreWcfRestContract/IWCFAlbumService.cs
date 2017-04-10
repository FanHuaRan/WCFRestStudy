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
        //[WebInvoke(Method = "GET", UriTemplate = "FindAll", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [WebInvoke(Method = "GET", UriTemplate = "FindAll")]
        IEnumerable<Album> FindAll();
        [OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [WebInvoke(Method = "GET", UriTemplate = "FindOne/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Album FindOne(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Album Create(Album album);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Album Update(Album album);

        [OperationContract]
        //[WebInvoke(Method = "DELETE", UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [WebInvoke(Method = "DELETE", UriTemplate = "Delete/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void delete(string id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "Search?", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        //IEnumerable<Album> search(Int32? genreId, String title, decimal minPrice = 0, decimal maxPrice = 10000);
    }
}
