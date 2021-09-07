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
    public class ColorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IColorService _ColorService;
        public ColorController(IMapper mapper, IColorService ColorService)
        {
            _mapper = mapper;
            _ColorService = ColorService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetColor(int Id)
        {
            var detailData = await _ColorService.GetColor(Id);
            var convertingData = _mapper.Map<ColorViewModel>(detailData);
            return Ok(convertingData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColor()
        {
            var fullDetails = await _ColorService.GetColors();
            var convertingData = _mapper.Map<List<ColorViewModel>>(fullDetails);
            return Ok(convertingData);
        }
        [HttpPost]
        public async Task<IActionResult> CreateColor(ColorViewModel viewModel)
        {
            var convertingModel = _mapper.Map<Color>(viewModel);
            await _ColorService.InsertColor(convertingModel);
            return Ok("Done Inserting!");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var findingData = await _ColorService.GetColor(Id);
            await _ColorService.DeleteColor(findingData);
            return Ok("Done Deleting!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(ColorViewModel viewModel)
        {
            var newData = _mapper.Map<Color>(viewModel);
            var oldData = await _ColorService.GetColor(newData.Color_Id);
            await _ColorService.UpdateColor(oldData, newData);
            return Ok("Done Updating!");
        }
    }
}
