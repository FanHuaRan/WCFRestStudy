using MusicStoreRest_DI_Sample.Models;
using MusicStoreRest_DI_Sample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStoreRest_DI_Sample.Controllers
{
    /// <summary>
    /// Albums控制器
    /// 2017/05/16 fhr
    /// </summary>
    public class AlbumsController : ApiController
    {
        private IAlbumService _albumService = null;
        //albumService通过构造方法进行注入
        public AlbumsController(IAlbumService albumService)
        {
            this._albumService = albumService;
        }
        //也可以通过属性进行注入
        //public IAlbumService AlbumService
        //{
        //    get { return _albumService; }
        //    set { _albumService = value; }
        //}
        // GET api/albums
        public IEnumerable<Album> Get()
        {
            return _albumService.FindAll();
        }

        // GET api/albums/5
        public IHttpActionResult Get(int id)
        {
            var album = _albumService.FindOne(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        // POST api/albums
        public IHttpActionResult Post([FromBody]Album value)
        {
            var id = _albumService.Save(value);
            value.AlbumId=(int)id;
            return Created<Album>(string.Format("api/albums/{0}", id), value);
        }

        // PUT api/albums/5
        public IHttpActionResult Put(int id, [FromBody]Album value)
        {
            if (value.AlbumId != id)
            {
                return BadRequest("wrong url and data!");
            }
            _albumService.Delete(id);
            return Ok();
        }

        // DELETE api/albums/5
        public void Delete(int id)
        {
            _albumService.Delete(id);
        }
    }
}