using Bussiness_Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IServices
{
   public interface ICarouselService
    {
        Task<IEnumerable<Carousel>> GetCarousel();
        Task<Carousel> GetCarouselById(int Id);
        Task<Carousel> InsertCarousel(Carousel carousel, IFormFile File);
        Task<Carousel> DeleteCarousel(Carousel carousel);
        Task<Carousel> UpdateCarousel(Carousel OldData, Carousel NewData);
    }
}
