using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IServices
{
    public interface IOperatingSystemService
    {
        Task<IEnumerable<OperatingSystems>> GetOperatingSystems();
        Task<OperatingSystems> GetOperatingSystem(int Id);
        Task<OperatingSystems> InsertOperatingSystem(OperatingSystems operatingSystems);
        Task<OperatingSystems> DeleteOperatingSystem(OperatingSystems operatingSystems);
        Task<OperatingSystems> UpdateOperatingSystem(OperatingSystems OldData, OperatingSystems NewData);
    }
}
