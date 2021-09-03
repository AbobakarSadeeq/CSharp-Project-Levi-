using Bussiness_Core.Entities;
using Bussiness_Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IServices
{
   public interface IinternetNetworkService 
    {
        Task<IEnumerable<InternetNetwork>> GetInternetNetworks();
        Task<InternetNetwork> GetInternetNetwork(int Id);
        Task<InternetNetwork> InsertInternetNetwork(InternetNetwork internetNetwork);
        Task<InternetNetwork> DeleteInternetNetwork(InternetNetwork internetNetwork);
        Task<InternetNetwork> UpdateInternetNetwork(InternetNetwork OldData, InternetNetwork NewData);
    }
}
