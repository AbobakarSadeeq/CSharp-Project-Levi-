using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels.UserOrderViewModel
{
   public class AddOrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomIdentityId { get; set; }
    }
}
