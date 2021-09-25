using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class CityViewModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        [ForeignKey("Country")]
        public int Country_ID { get; set; }
        public CountryViewModel Country { get; set; }
    }
}
