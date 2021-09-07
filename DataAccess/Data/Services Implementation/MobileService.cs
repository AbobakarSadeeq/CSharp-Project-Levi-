using Bussiness_Core.Entities;
using Bussiness_Core.IServices;
using Bussiness_Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Services_Implementation
{
    public class MobileService : IMobileService
    {
        private readonly IUnitofWork _unitOfWork;

        public MobileService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Mobile> DeleteMobile(Mobile Mobile)
        {
            _unitOfWork._MobileRepository.DeleteAsync(Mobile);
            await _unitOfWork.CommitAsync();
            return Mobile;
        }

        public async Task<Mobile> GetMobile(int Id)
        {
            return await _unitOfWork._MobileRepository.GetSingleMobile(Id);
        }

        public async Task<IEnumerable<Mobile>> GetMobiles()
        {
            return await _unitOfWork._MobileRepository.GetMobiles();
        }

        public async Task<Mobile> InsertMobile(Mobile mobile, List<int> NetworkIds, List<MobileFrontCamera> mobileFrontCameras, List<MobileBackCamera> mobileBackCameras)
        {
            await _unitOfWork._MobileRepository.AddAsync(mobile);
            await _unitOfWork.CommitAsync();
            await _unitOfWork._MobileRepository.InsertingMobileNetwork(mobile, NetworkIds, mobileFrontCameras, mobileBackCameras);
            await _unitOfWork.CommitAsync();
            return mobile;
        }

    

        public async Task<Mobile> UpdateMobile(Mobile OldData, Mobile NewData)
        {
            OldData.MobileName = NewData.MobileName;
            OldData.Processor  = NewData.Processor;
            OldData.Storage= NewData.Storage;
            OldData.BatteryMah = NewData.BatteryMah;
            OldData.Ram = NewData.Ram;
            OldData.LaunchData= NewData.LaunchData;
            OldData.MobileWeight= NewData.MobileWeight;
            OldData.ScreenSize= NewData.ScreenSize;
            OldData.ScreenType= NewData.ScreenType;
            OldData.Charger = NewData.Charger;
            OldData.Resolution= NewData.Resolution;
            OldData.HeadPhoneJack= NewData.HeadPhoneJack;
            OldData.Bluetooth= NewData.Bluetooth;
            OldData.Wifi= NewData.Wifi;
            OldData.USBConnector= NewData.USBConnector;
            OldData.BrandId= NewData.BrandId;
            OldData.OSVersionId= NewData.OSVersionId;
            OldData.ColorId= NewData.ColorId;
            OldData.MobilePrice= NewData.MobilePrice;
            OldData.SellUnits= NewData.SellUnits;
            OldData.StockAvailiability = NewData.StockAvailiability;
            OldData.Quantity= NewData.Quantity;
            OldData.Modified_At= DateTime.Now;
            OldData.SellUnits = NewData.SellUnits;      
            OldData.NetworksMobiles = NewData.NetworksMobiles;
            OldData.MobileBackCameras = NewData.MobileBackCameras;
            OldData.MobileFrontCameras = NewData.MobileFrontCameras;
            await _unitOfWork.CommitAsync();
            return OldData;
        }
    }
}
