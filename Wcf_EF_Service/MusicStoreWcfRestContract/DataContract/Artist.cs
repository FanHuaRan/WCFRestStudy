using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// 艺术家实体
    /// 2017/04/01 fhr
    /// </summary>
    [Bind(Exclude = "AlbumId")]
    [DataContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public class Artist
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "An Artist Name is required")]
        [DataMember]
        public string Name { get; set; }
    }
}