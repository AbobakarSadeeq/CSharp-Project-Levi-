using Bussiness_Core.Entities;
using Bussiness_Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities_Repositories
{
    public interface IMobileRepository : IRepository<int, Mobile>
    {
        Task<IEnumerable<Mobile>> GetMobiles();
        Task<Mobile> GetSingleMobile(int Id);
        Task<Mobile> InsertingMobileNetwork(Mobile mobile, List<int> NetworkIds, List<MobileFrontCamera> mobileFrontCameras, List<MobileBackCamera> mobileBackCameras);

    }
}
