using MusicStoreRestByWebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreRestByWebHost.Daos
{
    public class GenreDao : EntityBaseDao<Genre>
    {
        public override Genre Update(Genre obj)
        {
            return base.Update(obj,p=>p.GenreId);
        }
    }
}