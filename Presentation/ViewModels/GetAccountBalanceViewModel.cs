using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class GetAccountBalanceViewModel
    {
        public int Balance { get; set; }
        public string UserName { get; set; }
        public DateTime? Created_At { get; set; } = DateTime.Now;
        public DateTime? Modified_At { get; set; }
    }
}
