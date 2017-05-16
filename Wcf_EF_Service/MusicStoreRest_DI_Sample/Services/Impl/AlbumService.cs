using MusicStoreRest_DI_Sample.Models;
using MusicStoreRest_DI_Sample.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreRest_DI_Sample.Services.Impl
{
    /// <summary>
    /// Album服务实现
    /// 2017/05/16 fhr
    /// </summary>
    public class AlbumService:IAlbumService
    {
        private IAlbumRepository _albumRepository;

        //albumRepository会通过构造方法进行注入
        public AlbumService(IAlbumRepository albumRepository)
        {
            this._albumRepository = albumRepository;
        }
        //也可以通过属性进行注入
        //public IAlbumRepository AlbumRepository
        //{
        //    get { return _albumRepository; }
        //    set { _albumRepository = value; }
        //}
        public Album FindOne(object id)
        {
            return _albumRepository.FindOne(id);
        }

        public IEnumerable<Album> FindAll()
        {
            return _albumRepository.FindAll();
        }

        public object Save(Album album)
        {
            return _albumRepository.Save(album);
        }

        public void Update(Album album)
        {
            _albumRepository.Update(album);
        }

        public void Delete(object id)
        {
            _albumRepository.Delete(id);
        }
    }
}