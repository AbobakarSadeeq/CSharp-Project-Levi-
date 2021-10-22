using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class AccountBalance
    {
        [Key]
        public int BalanceAccountId { get; set; }
        public int Balance { get; set; }
        [ForeignKey("User")]
        public string User_ID { get; set; }
        public CustomIdentity User { get; set; }

        public DateTime? Created_At { get; set; } = DateTime.Now;
        public DateTime? Modified_At { get; set; }
    }
}
