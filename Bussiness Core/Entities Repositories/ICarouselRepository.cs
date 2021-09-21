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
   public interface ICarouselRepository : IRepository<int, Carousel>
    {
        Carousel DeleteCarouselImage(Carousel carousel);
        Task<Carousel> AddingCarousel(Carousel carousel, IFormFile File);
       
    }
}
