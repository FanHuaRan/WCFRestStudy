using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract.EnableCacheServiceContract
{
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFAlbumService
    {
        [OperationContract]
        [WebGet(UriTemplate = "all")]
        [AspNetCacheProfile("albumCache")]
        IEnumerable<Album> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [AspNetCacheProfile("albumCache")]
        Album FindOne(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "save", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Album Create(Album album);

        [OperationContract]
        [WebInvoke(Method = "Put", UriTemplate = "update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Album Update(Album album);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void Delete(string id);

        [OperationContract]
        [WebGet(UriTemplate = "Search?genreId={genreId}&title={title}&minPrice={minPrice}&maxPrice={maxPrice}",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [AspNetCacheProfile("albumCache")]
        IEnumerable<Album> search(int genreId, string title, decimal minPrice =-1, decimal maxPrice=-1);
    }
}
