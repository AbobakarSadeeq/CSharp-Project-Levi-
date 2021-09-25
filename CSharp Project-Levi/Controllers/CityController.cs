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
    public class CityController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public CityController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var getCitiesFromServer = await dataContext.Cities.ToListAsync();
            var convertingToViewModel = mapper.Map<List<CityViewModel>>(getCitiesFromServer);
            return Ok(convertingToViewModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCity(int Id)
        {
            var getCityFromServer = await dataContext.Cities.SingleOrDefaultAsync(a => a.CityId == Id);
            var convertingToViewModel = mapper.Map<CityViewModel>(getCityFromServer);
            return Ok(convertingToViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCountry(CityViewModel viewModel)
        {
            var convertViewModel = mapper.Map<City>(viewModel);
            await dataContext.Cities.AddAsync(convertViewModel);
            await dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.CityId}", viewModel);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCity(int Id)
        {
            var getCityFromServer = await dataContext.Cities.SingleOrDefaultAsync(a => a.CityId == Id);
            dataContext.Cities.Remove(getCityFromServer);
            await dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditCity(CityViewModel viewModel)
        {
            var oldData = await dataContext.Cities.SingleOrDefaultAsync(a => a.CityId == viewModel.CityId);
            oldData.CityName = viewModel.CityName;
            oldData.Country_ID = viewModel.Country_ID;
            await dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.CityId}", viewModel);

        }

    }
}
