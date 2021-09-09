using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class MobileViewModel
    {
        public int Mobile_Id { get; set; }
        public string MobileName { get; set; }
        public string Storage { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int MobilePrice { get; set; }
        public ICollection<MobileImages> MobileImagess { get; set; }
        public MobileViewModel()
        {
            MobileImagess = new HashSet<MobileImages>();
        }
    }
}
