using AutoMapper;
using Bussiness_Core.Entities;
using Bussiness_Core.IServices;
using CloudinaryDotNet.Actions;
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
        public async Task<IActionResult> CreateMobile([FromForm]InsertMobileViewModel  insertMobileViewModel)
        {
            var convertingModel = _mapper.Map<Mobile>(insertMobileViewModel);
            var gettingInternetNetworkData = insertMobileViewModel.MobileNetworks;
            var gettingFrontCameraDetails = insertMobileViewModel.FrontCameras;
            var gettingBackCameraDetails = insertMobileViewModel.BackCameras;
            var gettingMobileImages = insertMobileViewModel.File;
            await _MobileService.InsertMobile(convertingModel, gettingInternetNetworkData, gettingFrontCameraDetails, gettingBackCameraDetails, gettingMobileImages);
            return Created($"{Request.Scheme://request.host}{Request.Path}/{insertMobileViewModel.Mobile_Id}", insertMobileViewModel);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var findingData = await _MobileService.GetMobile(Id);
            await _MobileService.DeleteMobile(findingData);
            foreach (var item in findingData.MobileImagess)
            {
                await _MobileService.DeleteMobileImage(item);
            }
            return Ok();
        }

        [HttpDelete("DeletingSingleMobileImage/{Id}")]
        public async Task<IActionResult> DeletingPhoto(int Id)
        {
            var findingData = await _MobileService.GetMobileImage(Id);
           await _MobileService.DeleteMobileImage(findingData);
            return Ok();
        } 

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateMobileViewModel viewModel)
        {
            var newData = _mapper.Map<Mobile>(viewModel);
            var oldData = await _MobileService.GetMobile(newData.Mobile_Id);
            await _MobileService.UpdateMobile(oldData, newData);

            if (viewModel.networksMobiles != null)
            {
                foreach (var item in viewModel.networksMobiles)
                {
                    var convertNewData = new NetworksMobile
                    {
                        MobileId = viewModel.Mobile_Id,
                        MobileNetwork_Id = item.MobileNetwork_Id,
                        InternetNetworkId = item.InternetNetworkId
                    };
                    
                    // Adding Data
                    if (item.MobileNetwork_Id == 0)
                    {
                        await _MobileService.AddMobileNetwork(convertNewData);
                    }else if (item.check == false)
                    {
                        var gettingData = await _MobileService.GetNetworkMobile(convertNewData.MobileNetwork_Id);
                        await _MobileService.DeleteMobileNetwork(gettingData);
                    }
                    else
                    {
                        var networkMobileOldData = await _MobileService.GetNetworkMobile(item.MobileNetwork_Id);
                        await _MobileService.UpdateNetworkMobile(networkMobileOldData, convertNewData);
                    }
                   
                }
            }


            if (viewModel.File != null)
            {
                await _MobileService.UpdateSingleMobileImage(oldData, viewModel.File);

            }

            if (viewModel.FrontCameras.Count > 0 || viewModel.FrontCameras != null)
            {
                foreach (var item in viewModel.FrontCameras)
                {
                    var frontCameraOldData = await _MobileService.GetMobileFrontCamera(item.MobileFrontCamera_Id);
                    await _MobileService.UpdateMobileFrontCamera(frontCameraOldData, item);
                }
            }
            
            if(viewModel.BackCameras.Count > 0 || viewModel.FrontCameras != null)
            {
                foreach (var item in viewModel.BackCameras)
                {
                    var frontCameraOldData = await _MobileService.GetMobileBackCamera(item.MobileBackCamera_Id);
                    await _MobileService.UpdateMobileBackCamera(frontCameraOldData, item);
                }
            }
           
    
           

             

            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.Mobile_Id}", viewModel);

        }
    }
}
