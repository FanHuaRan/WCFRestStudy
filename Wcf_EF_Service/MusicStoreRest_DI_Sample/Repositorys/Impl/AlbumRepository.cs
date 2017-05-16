using MusicStoreRest_DI_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;
namespace MusicStoreRest_DI_Sample.Repositorys.Impl
{
    /// <summary>
    /// Album仓库实现
    /// 2017/05/16 fhr
    /// </summary>
    public class AlbumRepository : IAlbumRepository
    {
        //这儿使用list存在线程问题
        private static List<Album> _albums = new List<Album>()
        {
            new Album(){AlbumId=1, ArtistId=1,GenreId=1,Title="music1"},
            new Album(){AlbumId=2,ArtistId=1,GenreId=1,Title="music2"},
            new Album(){AlbumId=3,ArtistId=1,GenreId=1,Title="music3"}
        };
        public Album FindOne(object id)
        {
            return _albums.Where(p => p.AlbumId == (int)id).FirstOrDefault();
        }

        public IEnumerable<Album> FindAll()
        {
            return _albums;
        }

        public object Save(Album album)
        {
            album.AlbumId = _albums.Count() + 1;
            _albums.Add(album);
            return album.AlbumId;
        }

        public void Update(Album album)
        {
            for (int i = 0; i < _albums.Count; i++)
            {
                var value = _albums[i];
                if (value.AlbumId == album.AlbumId)
                {
                    _albums[i] = album;
                    break;
                }
            }
        }

        public void Delete(object id)
        {
            var album = _albums.Where(p => p.AlbumId == (int)id).FirstOrDefault();
            if (album != null)
            {
                _albums.Remove(album);
            }
        }
    }
}