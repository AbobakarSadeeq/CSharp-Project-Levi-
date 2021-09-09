using Bussiness_Core.Entities;
using Bussiness_Core.IRepositories;
using Microsoft.AspNetCore.Http;
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
        Task<Mobile> InsertingMobileNetwork(Mobile mobile, List<NetworksMobile> NetworkIds, List<MobileFrontCamera> mobileFrontCameras, List<MobileBackCamera> mobileBackCameras, List<IFormFile> File);
        Task<MobileImages> GetSinglePhoto(int Id);
        Task<MobileImages> DeleteMobileImage(MobileImages  mobileImages);
        Task<Mobile> DeleteMobile(Mobile mobile);
        Task<MobileFrontCamera> GetMobileFrontCamera(int Id);
        Task<MobileBackCamera> GetMobileBackCamera(int Id);
        Task<NetworksMobile> GetNetworksMobile(int Id);



    }
}
