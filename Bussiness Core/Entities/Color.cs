using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class Color
    {
        [Key]
        public int Color_Id { get; set; }
        public string ColorName { get; set; }
    }
}
