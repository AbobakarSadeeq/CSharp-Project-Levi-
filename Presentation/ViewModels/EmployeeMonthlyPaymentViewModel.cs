using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class EmployeeMonthlyPaymentViewModel
    {
        
        public int EmployeeMonthlyPaymentId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Payment_At { get; set; }
        public bool Payment { get; set; }

        [ForeignKey("Employee")]
        public int Employee_ID { get; set; }
        public Employee Employee { get; set; }
    }
}
