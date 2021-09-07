using AutoMapper;
using Bussiness_Core.Entities;
using Bussiness_Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.MobileViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project_Levi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMobileService _MobileService;
        public MobileController(IMapper mapper, IMobileService MobileService)
        {
            _mapper = mapper;
            _MobileService = MobileService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMobile(int Id)
        {
            var detailData = await _MobileService.GetMobile(Id);
            return Ok(detailData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMobile()
        {
            var fullDetails = await _MobileService.GetMobiles();
            return Ok(fullDetails);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMobile(InsertMobileViewModel  insertMobileViewModel)
        {
            var convertingModel = _mapper.Map<Mobile>(insertMobileViewModel);
            var gettingInternetNetworkData = insertMobileViewModel.InternetNetworkId;
            var gettingFrontCameraDetails = insertMobileViewModel.FrontCameras;
            var gettingBackCameraDetails = insertMobileViewModel.BackCameras;
            await _MobileService.InsertMobile(convertingModel, gettingInternetNetworkData,  gettingFrontCameraDetails, gettingBackCameraDetails);
            return Ok("Done Inserting!");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var findingData = await _MobileService.GetMobile(Id);
            await _MobileService.DeleteMobile(findingData);
            return Ok("Done Deleting!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMobileViewModel viewModel)
        {
            var newData = _mapper.Map<Mobile>(viewModel);
            newData.MobileFrontCameras = viewModel.FrontCameras;
            newData.MobileBackCameras= viewModel.BackCameras;
            newData.NetworksMobiles = viewModel.networksMobiles;
            var oldData = await _MobileService.GetMobile(newData.Mobile_Id);
            await _MobileService.UpdateMobile(oldData, newData);
            return Ok("Done Updating!");
        }
    }
}
