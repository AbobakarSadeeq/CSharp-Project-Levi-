using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class Carousel
    {
        [Key]
        public int CarouselID { get; set; }
        public string URL { get; set; }
        public string PublicId { get; set; }
        public int ImagePriority { get; set; }
        public string ImageTitle { get; set; }
        public string ImageDescription { get; set; }
    }
}
