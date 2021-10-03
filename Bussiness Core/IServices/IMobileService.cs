using Bussiness_Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IServices
{
    public interface IMobileService
    {
        Task<ICollection<Mobile>> GetMobiles();
        Task<Mobile> GetMobile(int Id);
        Task<MobileImages> GetMobileImage(int Id);

        Task<Mobile> InsertMobile(Mobile Mobile, List<NetworksMobile> NetworkIds, List<MobileFrontCamera> mobileFrontCameras, List<MobileBackCamera>  mobileBackCameras,  List<IFormFile> File);
        Task<Mobile> UpdateSingleMobileImage(Mobile Mobile, List<IFormFile> File);
        Task<Mobile> DeleteMobile(Mobile Mobile);
        Task<Mobile> UpdateMobile(Mobile OldData, Mobile NewData);
        Task<MobileImages> DeleteMobileImage(MobileImages  mobileImages);




        Task<MobileFrontCamera> GetMobileFrontCamera(int Id);
        Task<MobileFrontCamera> UpdateMobileFrontCamera(MobileFrontCamera OldData, MobileFrontCamera NewData);
        Task<MobileBackCamera> GetMobileBackCamera(int Id);
        Task<MobileBackCamera> UpdateMobileBackCamera(MobileBackCamera OldData, MobileBackCamera NewData);
        Task<NetworksMobile> GetNetworkMobile(int Id);
        Task<NetworksMobile> UpdateNetworkMobile(NetworksMobile OldData, NetworksMobile NewData);
        Task<NetworksMobile> AddMobileNetwork(NetworksMobile networksMobile);
        Task<NetworksMobile> DeleteMobileNetwork(NetworksMobile networksMobile);

    }
}
