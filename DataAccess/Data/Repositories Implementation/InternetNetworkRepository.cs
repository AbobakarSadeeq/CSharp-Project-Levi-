using Bussiness_Core.Entities;
using Bussiness_Core.Entities_Repositories;
using DataAccess.Data.DataContext_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories_Implementation
{
   public class InternetNetworkRepository : Repository<int, InternetNetwork>, IinternetNetworkRepository
    {

        private readonly DataContext _DataContext;

        public InternetNetworkRepository(DataContext DataContext) : base(DataContext)
        {
            _DataContext = DataContext;
        }
    }
}
