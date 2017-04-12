using MusicStoreBIL.Daos;
using MusicStoreWcfRestContract;
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
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return orderDao.FindAll();
        }

        // GET api/orders/5
        [HttpGet]
        public Order Get(int id)
        {
            return orderDao.FindById(id);
        }

        // POST api/orders
        [HttpPost]
        public void Post([FromBody]Order order)
        {
            //先校验
            if (ModelState.IsValid)
            {
                orderDao.Save(order);
            }
        }

        // PUT api/orders/5
        [HttpPut]
        public void Put(int id, [FromBody]Order order)
        {
            if (orderDao.FindById(id) != null && ModelState.IsValid)
            {
                orderDao.Update(order);
            }
        }

        // DELETE api/orders/5
        [HttpDelete]
        public void Delete(int id)
        {
            orderDao.DeleteById(id);
        }
    }
}
