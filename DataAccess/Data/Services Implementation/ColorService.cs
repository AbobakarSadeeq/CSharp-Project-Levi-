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
   public class ColorService : IColorService
    {
            private readonly IUnitofWork _unitofWork;

            public ColorService(IUnitofWork unitofWork)
            {
                _unitofWork = unitofWork;
            }

            public async Task<Color> DeleteColor(Color color)
            {
                _unitofWork._ColorRepository.DeleteAsync(color);
                await _unitofWork.CommitAsync();
                return color;
            }

            public async Task<IEnumerable<Color>> GetColors()
            {
                return await _unitofWork._ColorRepository.GetAllSync();
            }

            public async Task<Color> GetColor(int Id)
            {
                return await _unitofWork._ColorRepository.GetByKeyAsync(Id);
            }

            public async Task<Color> InsertColor(Color color)
            {
                await _unitofWork._ColorRepository.AddAsync(color);
                await _unitofWork.CommitAsync();
                return color;
            }

            public async Task<Color> UpdateColor(Color oldData, Color newData)
            {
                oldData.ColorName = newData.ColorName;
                await _unitofWork.CommitAsync();
                return oldData;
            }
        }
}
