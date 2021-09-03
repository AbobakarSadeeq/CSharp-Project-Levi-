using AutoMapper;
using Bussiness_Core.Entities;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.AutoMapper
{
   public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<Color, ColorViewModel>().ReverseMap();
            CreateMap<InternetNetwork, InternetNetworkViewModel>().ReverseMap();
            CreateMap<OperatingSystems, OperatingSystemViewModel>().ReverseMap();
            CreateMap<OperatingSystemVersion, OperatingSystemVersionViewModel>().ReverseMap();



        }
    }
}
