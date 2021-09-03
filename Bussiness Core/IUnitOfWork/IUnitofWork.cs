using Bussiness_Core.Entities;
using Bussiness_Core.Entities_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IUnitOfWork
{
    public interface IUnitofWork
    {
        ICategoryRepository _CategoryRepository { get; }
        IBrandRepository _BrandRepository { get; }
        IColorRepository _ColorRepository { get; }
        IinternetNetworkRepository _IinternetNetworkRepository { get; }
        IOperatingSystemRepository _OperatingSystemRepository { get; }
        IOSVersionRepository _OSVersionRepository{ get; }

        Task<int> CommitAsync();
        void Dispose();
    }
}
