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
   public class OperatingSystemService : IOperatingSystemService
    {
        private readonly IUnitofWork _unitOfWork;

        public OperatingSystemService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperatingSystems> DeleteOperatingSystem(OperatingSystems operatingSystems)
        {
            _unitOfWork._OperatingSystemRepository.DeleteAsync(operatingSystems);
            await _unitOfWork.CommitAsync();
            return operatingSystems;
        }

        public async Task<OperatingSystems> GetOperatingSystem(int Id)
        {
            return await _unitOfWork._OperatingSystemRepository.GetByKeyAsync(Id);
        }

        public async Task<IEnumerable<OperatingSystems>> GetOperatingSystems()
        {
            return await _unitOfWork._OperatingSystemRepository.GetAllSync();
        }

        public async Task<OperatingSystems> InsertOperatingSystem(OperatingSystems operatingSystems)
        {
            await _unitOfWork._OperatingSystemRepository.AddAsync(operatingSystems);
            await _unitOfWork.CommitAsync();
            return operatingSystems;
        }

        public async Task<OperatingSystems> UpdateOperatingSystem(OperatingSystems OldData, OperatingSystems NewData)
        {
            OldData.OperatingName = NewData.OperatingName;
            await _unitOfWork.CommitAsync();
            return OldData;
        }
    }
}
