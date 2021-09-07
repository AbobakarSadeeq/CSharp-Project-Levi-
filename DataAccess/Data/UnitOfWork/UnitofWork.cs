using Bussiness_Core.Entities_Repositories;
using Bussiness_Core.IUnitOfWork;
using DataAccess.Data.DataContext_Class;
using DataAccess.Data.Repositories_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DataContext _DataContext;

        public ICategoryRepository _CategoryRepository { get; init; }
        public IBrandRepository _BrandRepository { get; init; }

        public IColorRepository _ColorRepository { get; init; }

        public IinternetNetworkRepository _IinternetNetworkRepository { get; init; }

        public IOperatingSystemRepository _OperatingSystemRepository { get; init; }

        public IOSVersionRepository _OSVersionRepository { get; init; }

        public IMobileRepository _MobileRepository { get; init; }

        public UnitofWork(DataContext DataContext) 
        {
            // Last Database Connection.
            _DataContext = DataContext;


            // DI of IRepository to Repository.
            _CategoryRepository = new CategoryRepository(_DataContext);
            _BrandRepository = new BrandRepository(_DataContext);
            _ColorRepository = new ColorRepository(_DataContext);
            _IinternetNetworkRepository = new InternetNetworkRepository(_DataContext);
            _OperatingSystemRepository = new OperatingSystemRepository(_DataContext);
            _OSVersionRepository = new OSVersionRepository(_DataContext);
            _MobileRepository = new MobileRepository(_DataContext);



        }

        public async Task<int> CommitAsync()
        {
          return await _DataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _DataContext.Dispose();
        }

       
    }
}
