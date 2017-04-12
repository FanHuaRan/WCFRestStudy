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
        [WebInvoke(Method = "GET", UriTemplate = "")]
        IEnumerable<Album> FindAll();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Album FindOne(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Album Create(Album album);

        [OperationContract]
        [WebInvoke(Method = "Put", UriTemplate = "", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Album Update(Album album);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void Delete(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Search?genreId={genreId}&title={title}&minPrice={minPrice}&maxPrice={maxPrice}",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Album> search(int genreId, string title, decimal minPrice =-1, decimal maxPrice=-1);
    }
}
