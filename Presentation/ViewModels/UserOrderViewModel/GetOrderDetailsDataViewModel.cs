using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels.UserOrderViewModel
{
   public class GetOrderDetailsDataViewModel
    {
        // Product
        public string ProductName { get; set; }
        public int MobileId { get; set; }

        // Order Detail
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
