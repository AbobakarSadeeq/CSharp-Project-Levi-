using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime?  OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        [ForeignKey("CustomIdentity")]
        public string CustomIdentityId { get; set; }
        public CustomIdentity CustomIdentity { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
