using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class UserAddress
    {
        [Key]
        public int UserAddressId { get; set; }
        public string CompleteAddress { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("City")]
        public int City_ID { get; set; }
        public City  City { get; set; }
        [ForeignKey("User")]
        public string User_ID { get; set; }
        public CustomIdentity User  { get; set; }


    }
}
