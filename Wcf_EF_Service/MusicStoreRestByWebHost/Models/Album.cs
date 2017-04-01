using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreRestByWebHost.Models;
using System.Runtime.Serialization;

namespace MusicStoreRestByWebHost.Models
{
    //UI不准许绑定AlbumId属性
    [Bind(Exclude = "AlbumId")]
    [DataContract]
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

        [DataMember]
        public virtual Genre Genre { get; set; }
        [DataMember]
        public virtual Artist Artist { get; set; }
    }
}