using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.IServices
{
   public interface IColorService
    {
        Task<Color> InsertColor(Color color);
        Task<IEnumerable<Color>> GetColors();
        Task<Color> GetColor(int Id);
        Task<Color> DeleteColor(Color color);
        Task<Color> UpdateColor(Color OldData, Color UpdateData);
    }
}
