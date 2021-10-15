using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels.UserOrderViewModel
{
   public class OrderDetailViewModel
    {
        // User Detail
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        // User Address
          public string CompleteAddress { get; set; }
          public string CountryName { get; set; }
          public string CityName { get; set; }
          public string PhoneNumber { get; set; }

        // Order
        public string OrderStatus { get; set; }
        public string OrderDate { get; set; }
        public string ShippedDate { get; set; }

        public ICollection<GetOrderDetailsDataViewModel> OrderDetail { get; set; }

        public OrderDetailViewModel()
        {
            OrderDetail = new List<GetOrderDetailsDataViewModel>();
        }
    }
}
