using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class MobileFrontCamera
    {
        [Key]
        public int MobileFrontCamera_Id { get; set; }
        public string CameraDetail { get; set; }
        [ForeignKey("Mobile")]
        public int MobileId { get; set; }
        public Mobile Mobile { get; set; }
    }
}
