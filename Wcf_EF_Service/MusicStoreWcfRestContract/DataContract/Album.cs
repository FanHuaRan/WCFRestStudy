using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// 专辑实体
    /// 2017/04/01 fhr
    /// Bind特性表示在ASP.NET MVC中让UI不准许绑定AlbumId属性
    /// DataContract是数据契约特性，表示我们的Album对象可以实例化，NameSpace是其XML命名空间
    /// </summary>
    [Bind(Exclude = "AlbumId")]
    [DataContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public class Album
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        [DataMember]
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [DataMember]
        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [DataMember]
        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }
        //IgnoreDataMember标识该属性不参与序列化
        //和不加DataMember是一样的效果
        [IgnoreDataMember]
        public virtual Genre Genre { get; set; }
        [IgnoreDataMember]
        public virtual Artist Artist { get; set; }
    }
}