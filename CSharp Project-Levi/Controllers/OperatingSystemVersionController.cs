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
    public class OperatingSystemVersionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOSVersionService  _OSVersionService;
        public OperatingSystemVersionController(IMapper mapper, IOSVersionService OSVersionService)
        {
            _mapper = mapper;
            _OSVersionService = OSVersionService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOSVersion(int Id)
        {
            var detailData = await _OSVersionService.GetOperatingSystemVersion(Id);
            var convertingData = _mapper.Map<OperatingSystemVersion>(detailData);
            return Ok(convertingData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOSVersion()
        {
            var fullDetails = await _OSVersionService.GetOperatingSystemVersions();
            var convertingData = _mapper.Map<List<OperatingSystemVersion>>(fullDetails);
            return Ok(convertingData);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOSVersion(OperatingSystemVersion viewModel)
        {
            var convertingModel = _mapper.Map<OperatingSystemVersion>(viewModel);
            await _OSVersionService.InsertOperatingSystemVersion(convertingModel);
            return Ok("Done Inserting!");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var findingData = await _OSVersionService.GetOperatingSystemVersion(Id);
            await _OSVersionService.DeleteOperatingSystemVersion(findingData);
            return Ok("Done Deleting!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(OperatingSystemVersionViewModel viewModel)
        {
            var newData = _mapper.Map<OperatingSystemVersion>(viewModel);
            var oldData = await _OSVersionService.GetOperatingSystemVersion(newData.OSV_Id);
            await _OSVersionService.UpdateOperatingSystemVersion(oldData, newData);
            return Ok("Done Updating!");
        }
    }
}
