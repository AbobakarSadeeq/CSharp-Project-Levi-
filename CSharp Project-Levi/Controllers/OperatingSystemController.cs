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
    public class OperatingSystemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOperatingSystemService _OperatingSystemService;
        public OperatingSystemController(IMapper mapper, IOperatingSystemService OperatingSystemService)
        {
            _mapper = mapper;
            _OperatingSystemService = OperatingSystemService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOperatingSystem(int Id)
        {
            var detailData = await _OperatingSystemService.GetOperatingSystem(Id);
            var convertingData = _mapper.Map<OperatingSystemViewModel>(detailData);
            return Ok(convertingData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperatingSystem()
        {
            var fullDetails = await _OperatingSystemService.GetOperatingSystems();
            var convertingData = _mapper.Map<List<OperatingSystemViewModel>>(fullDetails);
            return Ok(convertingData);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOperatingSystem(OperatingSystemViewModel viewModel)
        {
            var convertingModel = _mapper.Map<OperatingSystems>(viewModel);
            await _OperatingSystemService.InsertOperatingSystem(convertingModel);
            return Ok("Done Inserting!");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var findingData = await _OperatingSystemService.GetOperatingSystem(Id);
            await _OperatingSystemService.DeleteOperatingSystem(findingData);
            return Ok("Done Deleting!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(OperatingSystemViewModel viewModel)
        {
            var newData = _mapper.Map<OperatingSystems>(viewModel);
            var oldData = await _OperatingSystemService.GetOperatingSystem(newData.OperatingSystem_Id);
            await _OperatingSystemService.UpdateOperatingSystem(oldData, newData);
            return Ok("Done Updating!");
        }
    }
}
