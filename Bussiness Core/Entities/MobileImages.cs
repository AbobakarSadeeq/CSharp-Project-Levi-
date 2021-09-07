using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class MobileImages
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public DateTime? DateAdded { get; set; }
        public string PublicId { get; set; }
        [ForeignKey("Mobile")]
        public int MobileId { get; set; }
        public Mobile Mobile { get; set; }
    }
}
