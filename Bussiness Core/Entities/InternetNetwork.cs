using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class InternetNetwork
    {
        [Key]
        public int InternetNetwork_Id { get; set; }
        public string NetworkName { get; set; }
    }
}
