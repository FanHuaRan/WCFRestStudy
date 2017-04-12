using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using MusicStoreWcfRestContract;
using MusicStoreBIL.Daos;
using System.ServiceModel.Web;
using System.Net;
using MusicStoreUtils;
namespace MusicStoreWcfRestService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFArtistService : IWCFArtistService
    {
        private ArtistDao artistDao = new ArtistDao();
        public IEnumerable<Artist> FindAll()
        {
            return artistDao.FindAll();
        }

        public Artist FindById(string id)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            else
            {
                return artistDao.FindById(realId);
            }
        }

        public IEnumerable<Artist> FindByName(string name)
        {
            return artistDao.FindByLinq(p => p.Name == name);
        }

        public Artist Save(Artist artist)
        {
            if (EntityValidatorUtil.Validate<Artist>(artist))
            {
                return artistDao.Save(artist);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
        }

        public Artist Update(string id, Artist artist)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            if (EntityValidatorUtil.Validate<Artist>(artist))
            {
                return artistDao.Save(artist);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
        }

        public void Delete(string id)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                artistDao.DeleteById(realId);
            }
        }
    }
}
