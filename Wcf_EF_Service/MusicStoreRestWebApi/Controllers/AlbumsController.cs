using MusicStoreBIL.Daos;
using MusicStoreDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MusicStoreRestWebApi.Controllers
{
    /// <summary>
    /// 解析器有问题，全部自己解析为json
    /// </summary>
    public class AlbumsController : ApiController
    {
        private readonly AlbumDao albumDao = new AlbumDao();
        // GET api/albums
        public IHttpActionResult Get(int? genreId, string title, decimal minPrice = 0, decimal maxPrice = 998)
        {
            //IEnumerable<Album> albums = albumDao.FindAll();
            //return Json<IEnumerable<Album>>(albums);
            List<Func<Album, bool>> conditions = new List<Func<Album, bool>>();
            conditions.Add(album => album.Price >= minPrice && album.Price <= maxPrice);
            if (genreId != null)
            {
                conditions.Add(album => album.GenreId == genreId.Value);
            }
            if (title != null)
            {
                conditions.Add(album => album.Title == title);
            }
            return Json<IEnumerable<Album>>(albumDao.SimpleCompositeFind(conditions.ToArray()));
        }
        // GET api/albums
        //public IEnumerable<Album> Get()
        //{
        //    return albumDao.FindAll();
        //}

        // GET api/albums/5
        public IHttpActionResult Get(int id)
        {
            return Json<Album>(albumDao.FindById(id));
        }

        // POST api/albums
        public void Post([FromBody]Album album)
        {
            //先校验
            if (ModelState.IsValid)
            {
                albumDao.Save(album);
            }
        }

        // PUT api/albums/5
        public void Put(int id, [FromBody]Album album)
        {
            if (albumDao.FindById(id) != null && ModelState.IsValid)
            {
                albumDao.Update(album);
            }
        }

        // DELETE api/albums/5
        public void Delete(int id)
        {
            albumDao.DeleteById(id);
        }
        //GET 
        [System.Web.Http.Route("api/Albums/Search")]
        public IEnumerable<Album> GetSearch(int? genreId/*, string title, decimal minPrice=0, decimal maxPrice=998*/)
        {
            List<Func<Album, bool>> conditions = new List<Func<Album, bool>>();
         //   conditions.Add(album => album.Price >= minPrice && album.Price <= maxPrice);
            if (genreId != null)
            {
                conditions.Add(album => album.GenreId == genreId);
            }
            //if (title != null)
            //{
            //    conditions.Add(album => album.Title == title);
            //}
            albumDao.SimpleCompositeFind(conditions.ToArray());
            return null;
        }
    }
}
