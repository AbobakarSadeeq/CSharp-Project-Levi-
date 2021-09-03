using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class OperatingSystemVersionViewModel
    {
        public int OSV_Id { get; set; }
        public string OSVName { get; set; }
        public int OperatingSystemId { get; set; }
        public OperatingSystems OperatingSystemss { get; set; }
    }
}
