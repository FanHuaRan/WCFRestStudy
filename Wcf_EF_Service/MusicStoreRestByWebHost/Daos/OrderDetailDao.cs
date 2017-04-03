using MusicStoreRestByWebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreRestByWebHost.Daos
{
    public class OrderDetailDao:EntityBaseDao<OrderDetail>
    {
        public override OrderDetail Update(OrderDetail obj)
        {
            return base.Update(obj,p=>p.OrderDetailId);
        }
    }
}