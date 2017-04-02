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
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "Albums", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
	public List<Album> findAll(){
		return albumService.findAlbums();
	}
    [OperationContract]
   [WebInvoke(Method = "GET", UriTemplate = "Album/id", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
	public Album findOne(Int32? id) {
		return albumService.findAlbumById(id);
	}
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "Album", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
	public Album create(Album album) {
		return albumService.createAlbum(album);
	}
	[OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "Album", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
	public Album update(Integer id,Album album) {
		Album originAlbum=null;
		if(id==null||(originAlbum=albumService.findAlbumById(id))==null){
			throw new AlbumNotFoundException();
		}
		return albumService.editAlbum(album);
	}

	[OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "Album", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
	public void delete(@PathVariable("id") Integer id) {
		albumService.deleteAlbum(id);
	}
	
	[OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "Album", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
	public List<Album> search(@RequestParam(value="genreId",required=false)Integer genreId,
							  @RequestParam(value="title",required=false)String title,
							  @RequestParam(value="minPrice",required=false,defaultValue="0")Double minPrice,
							  @RequestParam(value="maxPrice",required=false,defaultValue="100000")Double maxPrice) {
		String hqlString="from Album album ";
		List<String> whereHQLS=new ArrayList<String>();
		if(genreId!=null){
			whereHQLS.add(String.format("album.genreId = %d",genreId));
		}
		if(title!=null&&!title.equals("")){
			whereHQLS.add(String.format("album.title = '%s'",title));
		}
		whereHQLS.add(String.format(" album.price between %f and %f ",minPrice,maxPrice));
		hqlString+=whereHQLS.stream().collect(Collectors.joining(" and ", "where ", " "));
		return albumService.findAlbums(hqlString);
	}
    }
}
