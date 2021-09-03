using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
  public  class OperatingSystems
    {
        [Key]
        public int OperatingSystem_Id { get; set; }
        public string OperatingName { get; set; }
        public DateTime? Created_At { get; set; } = DateTime.Now;
    }
}
