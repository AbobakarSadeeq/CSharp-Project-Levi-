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
   public class InternetNetworkService : IinternetNetworkService
    {
        private readonly IUnitofWork _unitofWork;

        public InternetNetworkService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<InternetNetwork> DeleteInternetNetwork(InternetNetwork internetNetwork)
        {
            _unitofWork._IinternetNetworkRepository.DeleteAsync(internetNetwork);
            await _unitofWork.CommitAsync();
            return internetNetwork;
        }

        public async Task<IEnumerable<InternetNetwork>> GetInternetNetworks()
        {
            return await _unitofWork._IinternetNetworkRepository.GetAllSync();
        }

        public async Task<InternetNetwork> GetInternetNetwork(int Id)
        {
            return await _unitofWork._IinternetNetworkRepository.GetByKeyAsync(Id);
        }

        public async Task<InternetNetwork> InsertInternetNetwork(InternetNetwork internetNetwork)
        {
            await _unitofWork._IinternetNetworkRepository.AddAsync(internetNetwork);
            await _unitofWork.CommitAsync();
            return internetNetwork;
        }

        public async Task<InternetNetwork> UpdateInternetNetwork(InternetNetwork oldData, InternetNetwork newData)
        {
            oldData.NetworkName = newData.NetworkName;
            await _unitofWork.CommitAsync();
            return oldData;
        }
    }
}
