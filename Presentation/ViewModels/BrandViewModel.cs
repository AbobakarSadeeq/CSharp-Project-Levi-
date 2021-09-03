using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class BrandViewModel
    {
        public int Brand_Id { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
