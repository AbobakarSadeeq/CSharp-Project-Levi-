using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class OperatingSystemViewModel
    {
        public int OperatingSystem_Id { get; set; }
        public string OperatingName { get; set; }
        public DateTime? Created_At { get; set; } = DateTime.Now;
    }
}
