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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Services_Implementation
{
    public class CarouselService : ICarouselService
    {
        private readonly IUnitofWork _unitOfWork;
       


        public CarouselService(IUnitofWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;

        

        }
        public async Task<Carousel> DeleteCarousel(Carousel carousel)
        {
             _unitOfWork._CarouselRepository.DeleteCarouselImage(carousel);
           await _unitOfWork.CommitAsync();
            return carousel;
        }

        public async Task<IEnumerable<Carousel>> GetCarousel()
        {
            return await _unitOfWork._CarouselRepository.GetAllSync();
        }

        public async Task<Carousel> GetCarouselById(int Id)
        {
            return await _unitOfWork._CarouselRepository.GetByKeyAsync(Id);
        }

        public async Task<Carousel> InsertCarousel(Carousel carousel, IFormFile File)
        {
           await _unitOfWork._CarouselRepository.AddingCarousel(carousel, File);
           await _unitOfWork.CommitAsync();
            return carousel;
        }

        public async Task<Carousel> UpdateCarousel(Carousel OldData, Carousel NewData)
        {
            OldData.ImageTitle = NewData.ImageTitle;
            OldData.ImagePriority = NewData.ImagePriority;
            OldData.ImageDescription = NewData.ImageDescription;
            await _unitOfWork.CommitAsync();
            return OldData;
        }
    }
}
