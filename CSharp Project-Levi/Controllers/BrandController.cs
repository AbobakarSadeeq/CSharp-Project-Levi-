using AutoMapper;
using Bussiness_Core.Entities;
using Bussiness_Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project_Levi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _BrandService;
        public BrandController(IMapper mapper, IBrandService BrandService)
        {
            _mapper = mapper;
            _BrandService = BrandService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBrand(int Id)
        {
            var detailData = await _BrandService.GetBrand(Id);
            var convertingData = _mapper.Map<BrandViewModel>(detailData);
            return Ok(convertingData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var fullDetails = await _BrandService.GetBrands();
            var convertingData = _mapper.Map<List<BrandViewModel>>(fullDetails);
            return Ok(convertingData);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandViewModel viewModel)
        {
            var convertingModel = _mapper.Map<Brand>(viewModel);
            await _BrandService.InsertBrand(convertingModel);
            return Ok("Done Inserting!");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var findingData = await _BrandService.GetBrand(Id);
            await _BrandService.DeleteBrand(findingData);
            return Ok("Done Deleting!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(BrandViewModel viewModel)
        {
            var newData = _mapper.Map<Brand>(viewModel);
            var oldData = await _BrandService.GetBrand(newData.Brand_Id);
            await _BrandService.UpdateBrand(oldData, newData);
            return Ok("Done Updating!");
        }
    }
}
