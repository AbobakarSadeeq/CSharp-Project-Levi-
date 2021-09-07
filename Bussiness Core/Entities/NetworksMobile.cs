using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class NetworksMobile
    {
        [Key]
        public int MobileNetwork_Id { get; set; }
        [ForeignKey("Mobile")]
        public int MobileId { get; set; }
        public Mobile Mobile { get; set; }
        [ForeignKey("InternetNetwork")]

        public int InternetNetworkId { get; set; }
        public InternetNetwork InternetNetwork { get; set; }
    }
}
