using Bussiness_Core.Entities;
using Bussiness_Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities_Repositories
{
   public interface ICategoryRepository : IRepository<int, Category>
    {
        // Extra Querries if you want to implement here.
    }
}
