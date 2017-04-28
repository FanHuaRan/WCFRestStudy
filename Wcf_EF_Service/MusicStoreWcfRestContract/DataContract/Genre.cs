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
    /// 流派实体
    /// 2017/04/01 fhr
    /// </summary>
    [Bind(Exclude = "GenreId")]
    [DataContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public class Genre
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "An Genre Name is required")]
        [DataMember]
        public string Name { get; set; }
        //[Required(ErrorMessage = "An Genre Description is required")]
        [StringLength(100)]
        [DataMember]
        public string Description { get; set; }
    }
}