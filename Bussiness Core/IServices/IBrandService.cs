using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IServices
{
   public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetBrands();
        Task<Brand> GetBrand(int Id);
        Task<Brand> InsertBrand(Brand brand);
        Task<Brand> DeleteBrand(Brand brand);
        Task<Brand> UpdateBrand(Brand OldData, Brand NewData); 
    }
}
