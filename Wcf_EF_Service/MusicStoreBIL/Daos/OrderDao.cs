using MusicStoreBIL.Daos;
using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreBIL.Daos
{
    /// <summary>
    /// 订单DAO
    /// 2017/04/01 fhr
    /// </summary>
    public class OrderDao:EntityBaseDao<Order>
    {
        public override Order Update(Order obj)
        {
            return base.Update(obj,p=>p.OrderId);
        }
    }
}