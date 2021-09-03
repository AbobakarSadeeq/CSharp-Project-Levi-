using Bussiness_Core.Entities;
using Bussiness_Core.IServices;
using Bussiness_Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Services_Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork _unitofWork;

        public CategoryService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<Category> DeleteCategory(Category category)
        {
           _unitofWork._CategoryRepository.DeleteAsync(category);
            await _unitofWork.CommitAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
         return await _unitofWork._CategoryRepository.GetAllSync();
        }

        public async Task<Category> GetCategory(int Id)
        {
          return await _unitofWork._CategoryRepository.GetByKeyAsync(Id);
        }

        public async Task<Category> InsertCategory(Category category)
        {
            await _unitofWork._CategoryRepository.AddAsync(category);
            await _unitofWork.CommitAsync();
            return category; 
        }

        public async Task<Category> UpdateCategory(Category oldData, Category newData)
        {
            oldData.CategoryName = newData.CategoryName;
            await _unitofWork.CommitAsync();
            return oldData;
        }
    }
}
