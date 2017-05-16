using System;
using System.Collections.Generic;

namespace MusicStoreRest_DI_Sample.Models
{
    /// <summary>
    /// Album µÃÂ
    /// 2017/05/16 fhr
    /// </summary>
    public  class Album
    {
        public  int AlbumId { get; set; }
        public  int GenreId { get; set; }
        public  int ArtistId { get; set; }
        public  string Title { get; set; }
        public  decimal Price { get; set; }
        public  string AlbumArtUrl { get; set; }
    }
}
