using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Mobile_Id { get; set; }
        public Mobile Mobile { get; set; }
        public int Order_Id { get; set; }
        public Order Order { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
