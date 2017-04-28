using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreBIL.Daos
{
    /// <summary>
    /// 流派DAO
    /// 2017/04/01 fhr
    /// </summary>
    public class GenreDao : EntityBaseDao<Genre>
    {
        public override Genre Update(Genre obj)
        {
            return base.Update(obj,p=>p.GenreId);
        }
    }
}