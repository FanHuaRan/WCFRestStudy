using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreBIL.Daos
{
    /// <summary>
    /// 订单条目DAO
    /// </summary>
    public class OrderDetailDao:EntityBaseDao<OrderDetail>
    {
        public override OrderDetail Update(OrderDetail obj)
        {
            return base.Update(obj,p=>p.OrderDetailId);
        }
    }
}