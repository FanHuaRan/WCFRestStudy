using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MusicStoreDAL.Models
{
    /// <summary>
    /// 订单细节 对应一种专辑
    /// </summary>
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

        //[DataMember]
        //public virtual Album Album { get; set; }

        //[DataMember]
        //public virtual Order Order { get; set; }
    }
}
