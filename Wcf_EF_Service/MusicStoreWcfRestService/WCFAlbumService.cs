using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFAlbumService : IWCFAlbumService
    {
        public MusicStoreDAL.Models.Album Create(MusicStoreDAL.Models.Album album)
        {
            throw new NotImplementedException();
        }

        public List<MusicStoreDAL.Models.Album> FindAll()
        {
            throw new NotImplementedException();
        }

        public MusicStoreDAL.Models.Album FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public MusicStoreDAL.Models.Album Update(MusicStoreDAL.Models.Album album)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MusicStoreDAL.Models.Album> search(int? genreId, string title, decimal minPrice = 0m, decimal maxPrice = 10000m)
        {
            throw new NotImplementedException();
        }
    }
}
