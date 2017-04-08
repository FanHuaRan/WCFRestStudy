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
    public class GenresController : ApiController
    {
        private GenreDao genreDao = new GenreDao();

        // GET api/genres
        public IEnumerable<Genre> Get()
        {
            return genreDao.FindAll();
        }

        // GET api/genres/5
        public Genre Get(int id)
        {
            return genreDao.FindById(id);
        }

        // POST api/genres
        public void Post([FromBody]Genre genre)
        {
            //先校验
            if (ModelState.IsValid)
            {
                genreDao.Save(genre);
            }
        }

        // PUT api/genres/5
        public void Put(int id, [FromBody]Genre genre)
        {
            if (genreDao.FindById(id) != null && ModelState.IsValid)
            {
                genreDao.Update(genre);
            }
        }

        // DELETE api/genres/5
        public void Delete(int id)
        {
            genreDao.DeleteById(id);
        }
    }
}
