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
    public class WCFArtsitService
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
    //@RequestMapping(produces = MediaType.APPLICATION_JSON_VALUE)
    //@ResponseBody
    //@ResponseStatus(HttpStatus.OK)
    //public List<Artist> findAll(){
    //    return artistService.findArtists();
    //}
    //@RequestMapping(value="/{id}",produces = MediaType.APPLICATION_JSON_VALUE)
    //@ResponseStatus(HttpStatus.OK)
    //@ResponseBody
    //public Artist findOne(@PathVariable("id") Integer id) {
    //    return artistService.findArtistById(id);
    //}
    //@RequestMapping(value="/search",produces = MediaType.APPLICATION_JSON_VALUE)
    //@ResponseStatus(HttpStatus.OK)
    //@ResponseBody
    //public List<Artist> search(@RequestParam(value="name",required=false)String name){
    //    if(name!=null||name.equals("")){
    //        return artistService.findArtistByName(name);
    //    }
    //    return artistService.findArtists();
    //}
    }
}
