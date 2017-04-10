﻿using MusicStoreBIL.Daos;
using MusicStoreDAL.Models;
using MusicStoreRestWebApi.ViewModels;
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
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            IEnumerable<Album> albums = albumDao.FindAll();
            return Json<IEnumerable<Album>>(albums);
        }
        // GET api/albums
        //public IEnumerable<Album> Get()
        //{
        //    return albumDao.FindAll();
        //}

        // GET api/albums/5
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json<Album>(albumDao.FindById(id));
        }

        // POST api/albums
         [System.Web.Http.HttpPost]
        public void Post([FromBody]Album album)
        {
            //先校验
            if (ModelState.IsValid)
            {
                albumDao.Save(album);
            }
        }

        // PUT api/albums/5
         [System.Web.Http.HttpPut]
        public void Put(int id, [FromBody]Album album)
        {
            if (albumDao.FindById(id) != null && ModelState.IsValid)
            {
                albumDao.Update(album);
            }
        }

        // DELETE api/albums/5
         [System.Web.Http.HttpDelete]
        public void Delete(int id)
        {
            albumDao.DeleteById(id);
        }
        [System.Web.Http.HttpGet]
         public IHttpActionResult GetSearch([FromUri]AlbumSearchParam albumSearchParam)
        {
            List<Func<Album, bool>> conditions = new List<Func<Album, bool>>();
            if (albumSearchParam.GenreId!= null)
            {
                conditions.Add(album => album.GenreId == albumSearchParam.GenreId);
            }
            if (albumSearchParam.Title != null)
            {
                conditions.Add(album => album.Title == albumSearchParam.Title);
            }
            if (albumSearchParam.MinPrice != null)
            {
                conditions.Add(album => album.Price >= albumSearchParam.MinPrice);
            }
            if (albumSearchParam.MaxPrice != null)
            {
                conditions.Add(album => album.Price <= albumSearchParam.MaxPrice);
            }
            return Json<IEnumerable<Album>>(albumDao.SimpleCompositeFind(conditions.ToArray()));
        }
    }
}