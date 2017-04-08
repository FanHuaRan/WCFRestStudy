using MusicStoreBIL.Daos;
using MusicStoreDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStoreRestWebApi.Controllers
{
    public class OrderDetailsController : ApiController
    {
        private OrderDetailDao orderDetailDao = new OrderDetailDao();
        // GET api/orderdetails
        public IEnumerable<OrderDetail> Get()
        {
            return orderDetailDao.FindAll();
        }

        // GET api/orderdetails/5
        public OrderDetail Get(int id)
        {
            return orderDetailDao.FindById(id);
        }

        // POST api/orderdetails
        public void Post([FromBody]OrderDetail orderDetail)
        {
            //先校验
            if (ModelState.IsValid)
            {
                orderDetailDao.Save(orderDetail);
            }
        }

        // PUT api/orderdetails/5
        public void Put(int id, [FromBody]OrderDetail orderDetail)
        {
            if (orderDetailDao.FindById(id) != null && ModelState.IsValid)
            {
                orderDetailDao.Update(orderDetail);
            }
        }

        // DELETE api/orderdetails/5
        public void Delete(int id)
        {
        }
    }
}
