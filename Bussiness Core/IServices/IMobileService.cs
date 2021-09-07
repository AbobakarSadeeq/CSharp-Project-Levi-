using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IServices
{
    public interface IMobileService
    {
        Task<IEnumerable<Mobile>> GetMobiles();
        Task<Mobile> GetMobile(int Id);
        Task<Mobile> InsertMobile(Mobile Mobile, List<int> NetworkIds, List<MobileFrontCamera> mobileFrontCameras, List<MobileBackCamera>  mobileBackCameras);
        Task<Mobile> DeleteMobile(Mobile Mobile);
        Task<Mobile> UpdateMobile(Mobile OldData, Mobile NewData);
    }
}
