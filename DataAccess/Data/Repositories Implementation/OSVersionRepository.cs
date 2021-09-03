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
   public class OSVersionRepository :  Repository<int, OperatingSystemVersion>, IOSVersionRepository
   {
        private readonly DataContext _DataContext;
        public OSVersionRepository(DataContext DataContext) : base(DataContext)
        {
            _DataContext = DataContext;
        }
    

       

        public async Task<IEnumerable<OperatingSystemVersion>> GetOperatingSystemOSV()
        {
            return await _DataContext.OperatingSystemVersions.Include(a => a.OperatingSystemss)
                .ToListAsync();
        }

        public async Task<OperatingSystemVersion> GetOperatingSystemOnlyOSV(int Id)
        {
            return await _DataContext.OperatingSystemVersions.Include(a => a.OperatingSystemss)
                .FirstOrDefaultAsync(a => a.OSV_Id == Id);
        }
    }
}
