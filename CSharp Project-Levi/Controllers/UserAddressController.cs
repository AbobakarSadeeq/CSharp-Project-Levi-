using AutoMapper;
using Bussiness_Core.Entities;
using DataAccess.Data.DataContext_Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project_Levi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public UserAddressController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserAddress(string UserId)
        {
            var gettingData = await dataContext.UserAddresses
                .Include(a=>a.City)
                .Include(a=>a.City.Country)
                .SingleOrDefaultAsync(a => a.User_ID == UserId);
            if(gettingData == null)
            {
                return Ok(true);
            }
            var convertViewModel = mapper.Map<UserAddressViewModel>(gettingData);
            return Ok(convertViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserAddress(UserAddressViewModel viewModel)
        {
            var convertingViewModel = mapper.Map<UserAddress>(viewModel);
            await dataContext.UserAddresses.AddAsync(convertingViewModel);
            await dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.UserAddressId}", viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> EditUserAddress([FromForm] UserAddressViewModel viewModel)
        {
            var oldData = await dataContext.UserAddresses.SingleOrDefaultAsync(a => a.User_ID == viewModel.User_ID);
            oldData.PhoneNumber = viewModel.PhoneNumber;
            oldData.CompleteAddress = viewModel.CompleteAddress;
            oldData.City_ID = viewModel.City_ID;
            oldData.User_ID = oldData.User_ID;
            await dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.UserAddressId}", viewModel);

        }
    }
}
