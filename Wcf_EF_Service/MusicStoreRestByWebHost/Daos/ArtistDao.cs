using MusicStoreRestByWebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreRestByWebHost.Daos
{
    public class ArtistDao : EntityBaseDao<Artist>
    {
        public override Artist Update(Artist obj)
        {
            return base.Update(obj, p => p.ArtistId);
        }
    }
}