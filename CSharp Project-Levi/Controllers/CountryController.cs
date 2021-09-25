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
    public class CountryController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public CountryController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var getCountriesFromServer = await dataContext.Countries.ToListAsync();
            var convertingToViewModel = mapper.Map<List<CountryViewModel>>(getCountriesFromServer);
            return Ok(convertingToViewModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCountry(int Id)
        {
            var getCountryFromServer = await dataContext.Countries.SingleOrDefaultAsync(a => a.CountryId == Id);
            var convertingToViewModel = mapper.Map<CountryViewModel>(getCountryFromServer);
            return Ok(convertingToViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCountry(CountryViewModel viewModel)
        {
            var convertViewModel = mapper.Map<Country>(viewModel);
            await dataContext.Countries.AddAsync(convertViewModel);
            await dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.CountryId}", viewModel);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCountry(int Id)
        {
            var getCountryFromServer = await dataContext.Countries.SingleOrDefaultAsync(a => a.CountryId == Id);
             dataContext.Countries.Remove(getCountryFromServer);
            await dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditCountry(CountryViewModel viewModel)
        {
            var oldData = await dataContext.Countries.SingleOrDefaultAsync(a => a.CountryId == viewModel.CountryId);
            oldData.CountryName = viewModel.CountryName;
            await dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.CountryId}", viewModel);

        }




    }
}
