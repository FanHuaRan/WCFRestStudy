using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MusicStoreDAL.Models
{
    [DataContract]
    public class Genre
    {
        [DataMember]
        public int GenreId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}