using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IServices
{
   public interface IOSVersionService
    {
        Task<IEnumerable<OperatingSystemVersion>> GetOperatingSystemVersions();
        Task<OperatingSystemVersion> GetOperatingSystemVersion(int Id);
        Task<OperatingSystemVersion> InsertOperatingSystemVersion(OperatingSystemVersion operatingSystemVersion);
        Task<OperatingSystemVersion> DeleteOperatingSystemVersion(OperatingSystemVersion operatingSystemVersion);
        Task<OperatingSystemVersion> UpdateOperatingSystemVersion(OperatingSystemVersion OldData, OperatingSystemVersion NewData);
    }
}
