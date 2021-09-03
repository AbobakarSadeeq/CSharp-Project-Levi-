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
    public class OSVersionService : IOSVersionService
    {
        private readonly IUnitofWork _unitOfWork;

        public OSVersionService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperatingSystemVersion> DeleteOperatingSystemVersion(OperatingSystemVersion operatingSystemVersion)
        {
            _unitOfWork._OSVersionRepository.DeleteAsync(operatingSystemVersion);
            await _unitOfWork.CommitAsync();
            return operatingSystemVersion;
        }

        public async Task<OperatingSystemVersion> GetOperatingSystemVersion(int Id)
        {
            return await _unitOfWork._OSVersionRepository.GetOperatingSystemOnlyOSV(Id);
        }

        public async Task<IEnumerable<OperatingSystemVersion>> GetOperatingSystemVersions()
        {
            return await _unitOfWork._OSVersionRepository.GetOperatingSystemOSV();
        }

        public async Task<OperatingSystemVersion> InsertOperatingSystemVersion(OperatingSystemVersion OperatingSystemVersion)
        {
            await _unitOfWork._OSVersionRepository.AddAsync(OperatingSystemVersion);
            await _unitOfWork.CommitAsync();
            return OperatingSystemVersion;
        }

        public async Task<OperatingSystemVersion> UpdateOperatingSystemVersion(OperatingSystemVersion OldData, OperatingSystemVersion NewData)
        {
            OldData.OSVName = NewData.OSVName;
            OldData.OperatingSystemId = NewData.OperatingSystemId;
            await _unitOfWork.CommitAsync();
            return OldData;
        }
    }
}
