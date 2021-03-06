using Bussiness_Core.Entities;
using Bussiness_Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities_Repositories
{
   public interface IOSVersionRepository : IRepository<int, OperatingSystemVersion>
    {
        // Relationship between Category and Brands

        Task<IEnumerable<OperatingSystemVersion>> GetOperatingSystemOSV();
        Task<OperatingSystemVersion> GetOperatingSystemOnlyOSV(int Id);
    }
}
