using MusicStoreRestByWebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreRestByWebHost.Daos
{
    public class AlbumDao : EntityBaseDao<Album>
    {
        public override Album Update(Album obj)
        {
            return base.Update(obj,p=>p.AlbumId);
        }
    }
}