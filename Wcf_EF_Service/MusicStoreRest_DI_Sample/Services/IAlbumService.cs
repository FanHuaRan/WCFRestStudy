using MusicStoreRest_DI_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreRest_DI_Sample.Services
{
    /// <summary>
    /// Album服务接口
    /// 2017/05/16 fhr
    /// </summary>
    public interface IAlbumService
    {
        Album FindOne(object id);

        IEnumerable<Album> FindAll();

        object Save(Album album);

        void Update(Album album);

        void Delete(object id);
    }
}
