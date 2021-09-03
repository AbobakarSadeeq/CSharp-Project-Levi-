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
    public class BrandService : IBrandService
    {
        private readonly IUnitofWork _unitOfWork;

        public BrandService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Brand> DeleteBrand(Brand brand)
        {
             _unitOfWork._BrandRepository.DeleteAsync(brand);
            await _unitOfWork.CommitAsync();
            return brand;
        }

        public async Task<Brand> GetBrand(int Id)
        {
          return  await _unitOfWork._BrandRepository.GetCategoryOnlyBrand(Id);
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _unitOfWork._BrandRepository.GetCategoryBrands();
        }

        public async Task<Brand> InsertBrand(Brand brand)
        {
           await _unitOfWork._BrandRepository.AddAsync(brand);
          await  _unitOfWork.CommitAsync();
            return brand;
        }

        public async Task<Brand> UpdateBrand(Brand OldData, Brand NewData)
        {
            OldData.BrandName = NewData.BrandName;
            OldData.CategoryId = NewData.CategoryId;
            await _unitOfWork.CommitAsync();
            return OldData;
        }
    }
}
