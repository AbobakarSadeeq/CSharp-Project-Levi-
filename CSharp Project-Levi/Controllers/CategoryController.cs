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
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(IMapper mapper, ICategoryService  categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategory(int Id)
        {
            var detailData = await _categoryService.GetCategory(Id);
            var convertingData = _mapper.Map<Category>(detailData);
            return Ok(convertingData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var fullDetails = await _categoryService.GetCategories();
            var convertingData = _mapper.Map<List<Category>>(fullDetails);
            return Ok(convertingData);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel  viewModel)
        {
            var convertingModel = _mapper.Map<Category>(viewModel);
            await _categoryService.InsertCategory(convertingModel);
            return Ok("Done Inserting!");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var findingData = await _categoryService.GetCategory(Id);
            await _categoryService.DeleteCategory(findingData);
            return Ok("Done Deleting!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryViewModel viewModel)
        {
            var newData = _mapper.Map<Category>(viewModel);
            var oldData = await _categoryService.GetCategory(newData.Category_Id);
            await _categoryService.UpdateCategory(oldData, newData);
            return Ok("Done Updating!");
        }
    }
}
