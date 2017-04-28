using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Mvc;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// 订单条目 
    /// 2017/04/01 fhr
    /// </summary>
    [Bind(Exclude = "GenreId")]
    [DataContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public class OrderDetail
    {
        [DataMember]
        public int OrderDetailId { get; set; }

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public int AlbumId { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

        [IgnoreDataMember]
        public virtual Album Album { get; set; }

        [IgnoreDataMember]
        public virtual Order Order { get; set; }
    }
}
