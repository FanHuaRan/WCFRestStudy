using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using MusicStoreBIL.Daos;
using System.Net;
using MusicStoreUtils;
namespace MusicStoreWcfRestService
{
    /// <summary>
    /// 流派服务实现
    /// 2017/04/05 fhr
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFGenreService : IWCFGenreService
    {
        private GenreDao genreDao = new GenreDao();
        public void Delete(string id)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                genreDao.DeleteById(realId);
            }
        }

        public IEnumerable<Genre> FindAll()
        {
            return genreDao.FindAll();
        }

        public Genre FindById(string id)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            else
            {
                return genreDao.FindById(realId);
            }
        }

        public IEnumerable<Genre> FindByName(string name)
        {
            return genreDao.FindByLinq(p => p.Name == name);
        }

        public Genre Save(Genre genre)
        {
            if (EntityValidatorUtil.Validate<Genre>(genre))
            {
                return genreDao.Save(genre);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
        }

        public Genre Update(string id, Genre genre)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            if (EntityValidatorUtil.Validate<Genre>(genre))
            {
                return genreDao.Save(genre);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
        }
    }
}
