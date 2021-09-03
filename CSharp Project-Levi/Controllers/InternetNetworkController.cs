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
    public class InternetNetworkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IinternetNetworkService _InternetNetworkService;
        public InternetNetworkController(IMapper mapper, IinternetNetworkService InternetNetworkService)
        {
            _mapper = mapper;
            _InternetNetworkService = InternetNetworkService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetInternetNetwork(int Id)
        {
            var detailData = await _InternetNetworkService.GetInternetNetwork(Id);
            var convertingData = _mapper.Map<InternetNetwork>(detailData);
            return Ok(convertingData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInternetNetwork()
        {
            var fullDetails = await _InternetNetworkService.GetInternetNetworks();
            var convertingData = _mapper.Map<List<InternetNetwork>>(fullDetails);
            return Ok(convertingData);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(InternetNetworkViewModel viewModel)
        {
            var convertingModel = _mapper.Map<InternetNetwork>(viewModel);
            await _InternetNetworkService.InsertInternetNetwork(convertingModel);
            return Ok("Done Inserting!");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var findingData = await _InternetNetworkService.GetInternetNetwork(Id);
            await _InternetNetworkService.DeleteInternetNetwork(findingData);
            return Ok("Done Deleting!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(InternetNetworkViewModel viewModel)
        {
            var newData = _mapper.Map<InternetNetwork>(viewModel);
            var oldData = await _InternetNetworkService.GetInternetNetwork(newData.InternetNetwork_Id);
            await _InternetNetworkService.UpdateInternetNetwork(oldData, newData);
            return Ok("Done Updating!");
        }
    }
}
