using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MusicStoreRestByWebApi.ViewModels
{
    [DataContract]
    public class AlbumSearchParam
    {
        [DataMember]
        public int? GenreId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public decimal? MinPrice { get; set; }
        [DataMember]
        public decimal? MaxPrice { get; set; }
    }
}