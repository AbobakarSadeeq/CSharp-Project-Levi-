using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
  public class CreateEmployeeMonthlyPaymentViewModel
    {
        public int EmployeeMonthlyPaymentId { get; set; }
        public bool Payment { get; set; }
        public int EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Payment_At { get; set; }
    }
}
