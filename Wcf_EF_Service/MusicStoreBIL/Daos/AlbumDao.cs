using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreBIL.Daos
{
    /// <summary>
    /// 专辑DAO
    /// 2017/04/01 fhr
    /// </summary>
    public class AlbumDao : EntityBaseDao<Album>
    {
        public override Album Update(Album obj)
        {
            return base.Update(obj,p=>p.AlbumId);
        }
    }
}