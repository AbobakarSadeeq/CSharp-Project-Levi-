using Bussiness_Core.Entities;
using Bussiness_Core.Entities_Repositories;
using DataAccess.Data.DataContext_Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories_Implementation
{
    public class MobileRepository : Repository<int, Mobile>, IMobileRepository
    {
        private readonly DataContext _DataContext;
        public MobileRepository(DataContext DataContext) : base(DataContext)
        {
            _DataContext = DataContext;
        }

        public async Task<IEnumerable<Mobile>> GetMobiles()
        {
            var Data = await _DataContext.Mobiles.ToListAsync();
            return Data;
        }

        public async Task<Mobile> GetSingleMobile(int Id)
        {
            var getById = await _DataContext.Mobiles.Include(a => a.NetworksMobiles)
                .Include(a=>a.MobileFrontCameras)
                .Include(a=>a.MobileBackCameras)
                .SingleOrDefaultAsync(a=>a.Mobile_Id== Id);
            return getById;
        }

        public async Task<Mobile> InsertingMobileNetwork(Mobile mobileData, List<int> NetworkIds, List<MobileFrontCamera> mobileFrontCameras, List<MobileBackCamera> mobileBackCameras)
        {
            // Adding the InternetNetwork Data to another table.
            foreach (var networkId in NetworkIds)
            {
               await _DataContext.NetworksMobiles.AddAsync(new NetworksMobile { InternetNetworkId = networkId, MobileId = mobileData.Mobile_Id });
            }

            foreach (var frontCamera in mobileFrontCameras)
            {
                await _DataContext.MobileFrontCameras.AddAsync(new MobileFrontCamera { CameraDetail = frontCamera.CameraDetail, MobileId = mobileData.Mobile_Id });
            }
            foreach (var backCamera in mobileBackCameras)
            {
                await _DataContext.MobileBackCameras.AddAsync(new MobileBackCamera { CameraDetail = backCamera.CameraDetail, MobileId = mobileData.Mobile_Id });

            }


            return mobileData;
        }
    }
}
