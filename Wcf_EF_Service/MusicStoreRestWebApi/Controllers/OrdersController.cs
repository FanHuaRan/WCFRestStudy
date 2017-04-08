using MusicStoreDAL.Models;
using MusicStoreRestByWebHost.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStoreRestWebApi.Controllers
{
    public class OrdersController : ApiController
    {
        private OrderDao orderDao = new OrderDao();
        // GET api/orders
        public IEnumerable<Order> Get()
        {
            return orderDao.FindAll();
        }

        // GET api/orders/5
        public Order Get(int id)
        {
            return orderDao.FindById(id);
        }

        // POST api/orders
        public void Post([FromBody]Order order)
        {
            //先校验
            if (ModelState.IsValid)
            {
                orderDao.Save(order);
            }
        }

        // PUT api/orders/5
        public void Put(int id, [FromBody]Order order)
        {
            if (orderDao.FindById(id) != null && ModelState.IsValid)
            {
                orderDao.Update(order);
            }
        }

        // DELETE api/orders/5
        public void Delete(int id)
        {
            orderDao.DeleteById(id);
        }
    }
}
