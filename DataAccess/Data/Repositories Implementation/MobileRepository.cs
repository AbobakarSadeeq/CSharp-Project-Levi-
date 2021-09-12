using Bussiness_Core.Entities;
using Bussiness_Core.Entities_Repositories;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccess.Data.DataContext_Class;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Presentation.AppSettingClasses;
using Presentation.ViewModels;
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
        private readonly Cloudinary _cloudinary;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
            
        public MobileRepository(DataContext DataContext, IOptions<CloudinarySettings> cloudinaryConfig) : base(DataContext)
        {
            _DataContext = DataContext;
            _cloudinaryConfig = cloudinaryConfig;


            Account acc = new Account(
                 _cloudinaryConfig.Value.CloudName,
                  _cloudinaryConfig.Value.ApiKey,
                  _cloudinaryConfig.Value.ApiSecret
                                                      );

            _cloudinary = new Cloudinary(acc);
        }
        public async Task<MobileImages> GetSinglePhoto(int Id)
        {
            return await _DataContext.MobileImages.FirstOrDefaultAsync(a => a.MobileImages_Id == Id);
        }

        public MobileImages DeleteMobileImage(MobileImages mobileImages)
        {
            var deletePrams = new DeletionParams(mobileImages.PublicId);
            var cloudinaryDeletePhoto =  _cloudinary.Destroy(deletePrams);
            if (cloudinaryDeletePhoto.Result == "ok")
            {
                _DataContext.MobileImages.Remove(mobileImages);
            }
            return mobileImages;

        }

        public async Task<IEnumerable<Mobile>> GetMobiles()
        {
            var Data = await _DataContext.Mobiles.Include(a =>a.MobileImagess).Include(a=>a.Color).Include(a=>a.Brand).ToListAsync();
            return Data;
        }

        public async Task<Mobile> GetSingleMobile(int Id)
        {
            var getById = await _DataContext.Mobiles
                .Include(a => a.NetworksMobiles)
                .Include(a => a.MobileFrontCameras)
                .Include(a => a.MobileBackCameras)
                .Include(a => a.MobileImagess)
                .Include(a => a.Brand)
                .Include(a => a.Color)
                .Include(a => a.OperatingSystemVersion)
                .Include(a => a.OperatingSystemVersion.OperatingSystemss)
                .Include(a => a.NetworksMobiles)

                .SingleOrDefaultAsync(a=>a.Mobile_Id== Id);
            return getById;
        }

      

        public async Task<Mobile> InsertingMobileNetwork(Mobile mobileData, List<NetworksMobile> NetworkIds, List<MobileFrontCamera> mobileFrontCameras, List<MobileBackCamera> mobileBackCameras, List<IFormFile> File)
        {


            foreach (var networkId in NetworkIds)
            {
                await _DataContext.NetworksMobiles.AddAsync(new NetworksMobile { InternetNetworkId = networkId.InternetNetworkId, MobileId = mobileData.Mobile_Id });
            }

            foreach (var frontCamera in mobileFrontCameras)
            {
                await _DataContext.MobileFrontCameras.AddAsync(new MobileFrontCamera { CameraDetail = frontCamera.CameraDetail, MobileId = mobileData.Mobile_Id });
            }
            foreach (var backCamera in mobileBackCameras)
            {
                await _DataContext.MobileBackCameras.AddAsync(new MobileBackCamera { CameraDetail = backCamera.CameraDetail, MobileId = mobileData.Mobile_Id });
            }


            // Uploading Image:

            foreach (var file in File)
            {
                var uploadResult = new ImageUploadResult();
                if(File.Count > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadparams = new ImageUploadParams
                        {
                            File = new FileDescription(file.Name, stream),
                            // we can also crop the image if we want here means when user could upload his large size or big shape of image then crop it all its around thing just focus it on the face only
                            // it will crop the image automatically for us. 
                            Transformation = new Transformation()
                            .Width(824).Height(536)

                        };
                        // Uploading the image on clodinary server and could take a while
                        uploadResult = _cloudinary.Upload(uploadparams);
                    }
                }
                    mobileData.MobileImagess.
                    Add(new MobileImages { MobileId = mobileData.Mobile_Id,
                    PublicId = uploadResult.PublicId, URL = uploadResult.Url.ToString() });
            }




            return mobileData;
        }

        public Mobile DeleteMobile(Mobile mobile)
        {
            foreach (var item in mobile.MobileImagess)
            {
                var deletePrams = new DeletionParams(item.PublicId);
                var cloudinaryDeletePhoto = _cloudinary.Destroy(deletePrams);
                if (cloudinaryDeletePhoto.Result == "ok")
                {
                    _DataContext.Mobiles.Remove(mobile);
                }
            }
            return mobile;
        }

        public async Task<MobileFrontCamera> GetMobileFrontCamera(int Id)
        {
            return await _DataContext.MobileFrontCameras.FirstOrDefaultAsync(a=>a.MobileFrontCamera_Id == Id);
        }

        public async Task<MobileBackCamera> GetMobileBackCamera(int Id)
        {
            return await _DataContext.MobileBackCameras.FirstOrDefaultAsync(a => a.MobileBackCamera_Id == Id);

        }

        public async Task<NetworksMobile> GetNetworksMobile(int Id)
        {
            return await _DataContext.NetworksMobiles.FirstOrDefaultAsync(a => a.MobileNetwork_Id == Id);

        }

     


    }

 }
    