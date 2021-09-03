using Bussiness_Core.Entities;
using Bussiness_Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities_Repositories
{
   public interface IBrandRepository : IRepository<int, Brand>
    {
        // Relationship between Category and Brands

        Task<IEnumerable<Brand>> GetCategoryBrands();
        Task<Brand> GetCategoryOnlyBrand(int Id);
    }
}
