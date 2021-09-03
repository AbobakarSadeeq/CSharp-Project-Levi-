using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class OperatingSystemVersion
    {
   
        public int OSV_Id { get; set; }
        public string OSVName { get; set; }
        public int OperatingSystemId { get; set; }
        public OperatingSystems OperatingSystemss { get; set; }
    }
}
