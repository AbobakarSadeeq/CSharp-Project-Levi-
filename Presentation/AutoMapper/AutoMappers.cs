using AutoMapper;
using Bussiness_Core.Entities;
using Presentation.ViewModels;
using Presentation.ViewModels.Identity;
using Presentation.ViewModels.MobileViewModels;
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
            CreateMap<Mobile, InsertMobileViewModel>().ReverseMap();
            CreateMap<Mobile, UpdateMobileViewModel>().ReverseMap();
            CreateMap<Mobile, MobileViewModel>().ReverseMap();
            CreateMap<MobileImages, ImageInsertingViewModel>().ReverseMap();
            CreateMap<NetworksMobile, NetworksMobileViewModel>().ReverseMap();
            CreateMap<Carousel, CarouselViewModel>().ReverseMap();
            CreateMap<UserImage, PhotoForCreationViewModel>().ReverseMap();
            CreateMap<UserImage, PhotoForReturnViewModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<City, CityViewModel>().ReverseMap();
            CreateMap<UserAddress, UserAddressViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<EmployeeMonthlyPayment, EmployeeMonthlyPaymentViewModel>().ReverseMap();
            CreateMap<EmployeeMonthlyPayment, CreateEmployeeViewModel>().ReverseMap();







        }
    }
}
