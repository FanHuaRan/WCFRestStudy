using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreBIL.Daos
{
    /// <summary>
    /// 艺术家DAO
    /// 2017/04/01 fhr
    /// </summary>
    public class ArtistDao : EntityBaseDao<Artist>
    {
        public override Artist Update(Artist obj)
        {
            return base.Update(obj, p => p.ArtistId);
        }
    }
}