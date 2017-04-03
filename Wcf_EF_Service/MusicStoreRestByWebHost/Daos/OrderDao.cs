﻿using MusicStoreRestByWebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreRestByWebHost.Daos
{
    public class OrderDao:EntityBaseDao<Order>
    {
        public override Order Update(Order obj)
        {
            return base.Update(obj,p=>p.OrderId);
        }
    }
}