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
    //[RoutePrefix("api/Artists")]
    public class ArtistsController : ApiController
    {
        private ArtistDao artistDao = new ArtistDao();
        // GET api/artists
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return artistDao.FindAll();
        }

        // GET api/artists/5
        [HttpGet]
        //[Route("api/Artists/{id:int}")]
        public Artist Get(int id)
        {
            return artistDao.FindById(id);
        }
        // POST api/artists
        [HttpPost]
        public void Post([FromBody]Artist artist)
        {
            //先校验
            if (ModelState.IsValid)
            {
                artistDao.Save(artist);
            }
        }

        // PUT api/artists/5
        [HttpPut]
        public void Put(int id, [FromBody]Artist artist)
        {
            if (artistDao.FindById(id) != null && ModelState.IsValid)
            {
                artistDao.Update(artist);
            }
        }
        
        // DELETE api/artists/5
        [HttpDelete]
        public void Delete(int id)
        {
            artistDao.DeleteById(id);
        }
    }
}
