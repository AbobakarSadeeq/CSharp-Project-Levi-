using Bussiness_Core.Entities;
using Bussiness_Core.Entities_Repositories;
using DataAccess.Data.DataContext_Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories_Implementation
{
    public class BrandRepository :  Repository<int, Brand>, IBrandRepository
    {
        private readonly DataContext _DataContext;
        public BrandRepository(DataContext DataContext) : base(DataContext)
        {
            _DataContext = DataContext;
        }
       

        public async Task<Brand> GetCategoryOnlyBrand(int Id)
        {
            return await _DataContext.Brands.Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Brand_Id == Id);
        }

        public async Task<IEnumerable<Brand>> GetCategoryBrands()
        {
            return await _DataContext.Brands.Include(a => a.Category)
                .ToListAsync();

        }
    }
}
