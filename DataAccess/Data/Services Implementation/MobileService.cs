using Bussiness_Core.Entities;
using Bussiness_Core.IServices;
using Bussiness_Core.IUnitOfWork;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Presentation.AppSettingClasses;
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
             _unitOfWork._MobileRepository.DeleteMobile(Mobile);
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

        public async Task<Mobile> InsertMobile(Mobile mobile, List<NetworksMobile> NetworkIds, List<MobileFrontCamera> mobileFrontCameras, List<MobileBackCamera> mobileBackCameras, List<IFormFile> File)
        {
            await _unitOfWork._MobileRepository.AddAsync(mobile);
            await _unitOfWork.CommitAsync();
            await _unitOfWork._MobileRepository.InsertingMobileNetwork(mobile, NetworkIds, mobileFrontCameras, mobileBackCameras, File);
            await _unitOfWork.CommitAsync();
            return mobile;
        }
        public async  Task<MobileImages> DeleteMobileImage(MobileImages mobileImages)
        {
             _unitOfWork._MobileRepository.DeleteMobileImage(mobileImages);
            await _unitOfWork.CommitAsync();
            return mobileImages;
        }


        public async Task<Mobile> UpdateMobile(Mobile OldData, Mobile NewData)
        {
            OldData.MobileName = NewData.MobileName;
            OldData.Processor = NewData.Processor;
            OldData.Storage = NewData.Storage;
            OldData.BatteryMah = NewData.BatteryMah;
            OldData.Ram = NewData.Ram;
            OldData.LaunchDate = NewData.LaunchDate;
            OldData.MobileWeight = NewData.MobileWeight;
            OldData.ScreenSize = NewData.ScreenSize;
            OldData.ScreenType = NewData.ScreenType;
            OldData.Charger = NewData.Charger;
            OldData.Resolution = NewData.Resolution;
            OldData.HeadPhoneJack = NewData.HeadPhoneJack;
            OldData.Bluetooth = NewData.Bluetooth;
            OldData.Wifi = NewData.Wifi;
            OldData.USBConnector = NewData.USBConnector;
            OldData.BrandId = NewData.BrandId;
            OldData.OSVersionId = NewData.OSVersionId;
            OldData.ColorId = NewData.ColorId;
            OldData.MobilePrice = NewData.MobilePrice;
            OldData.StockAvailiability = NewData.StockAvailiability;
            OldData.Quantity = NewData.Quantity;
            OldData.SellUnits = OldData.SellUnits;
            OldData.Modified_At = DateTime.Now;
            await _unitOfWork.CommitAsync();
            return OldData;
        }

        public async Task<MobileImages> GetMobileImage(int Id)
        {
            return await _unitOfWork._MobileRepository.GetSinglePhoto(Id);
        }

        public async Task<MobileFrontCamera> GetMobileFrontCamera(int Id)
        {
            return await _unitOfWork._MobileRepository.GetMobileFrontCamera(Id);

        }

        public async Task<MobileFrontCamera> UpdateMobileFrontCamera(MobileFrontCamera OldData, MobileFrontCamera NewData)
        {
            OldData.CameraDetail = NewData.CameraDetail;
            await _unitOfWork.CommitAsync();
            return OldData;
        }

        public async Task<MobileBackCamera> GetMobileBackCamera(int Id)
        {
            return await _unitOfWork._MobileRepository.GetMobileBackCamera(Id);
        }

        public async Task<MobileBackCamera> UpdateMobileBackCamera(MobileBackCamera OldData, MobileBackCamera NewData)
        {
            OldData.CameraDetail = NewData.CameraDetail;
            await _unitOfWork.CommitAsync();
            return OldData;
        }

        public async Task<NetworksMobile> GetNetworkMobile(int Id)
        {
            return await _unitOfWork._MobileRepository.GetNetworksMobile(Id);

        }

        public async Task<NetworksMobile> UpdateNetworkMobile(NetworksMobile OldData, NetworksMobile NewData)
        {
            OldData.InternetNetworkId = NewData.InternetNetworkId;
            await _unitOfWork.CommitAsync();
            return OldData;
        }

        public async Task<Mobile> UpdateSingleMobileImage(Mobile mobile, List<IFormFile> File)
        {
             _unitOfWork._MobileRepository.UpdateMobileImage(mobile, File);
            await _unitOfWork.CommitAsync();
            return mobile;
        }

        public async Task<NetworksMobile> AddMobileNetwork(NetworksMobile networksMobile)
        {
            await _unitOfWork._MobileRepository.AddingMobileInternet(networksMobile);
            await _unitOfWork.CommitAsync();
            return networksMobile;
        }

        public async Task<NetworksMobile> DeleteMobileNetwork(NetworksMobile networksMobile)
        {
            _unitOfWork._MobileRepository.DeletingMobileNetwork(networksMobile);
           await _unitOfWork.CommitAsync();
            return networksMobile;
        }
    }
}
