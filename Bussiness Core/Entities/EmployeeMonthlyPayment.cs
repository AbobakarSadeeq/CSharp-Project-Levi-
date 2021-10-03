using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class EmployeeMonthlyPayment
    {
        [Key]
        public int EmployeeMonthlyPaymentId {   get; set; }
        public bool Payment { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Payment_At { get; set; }
        [ForeignKey("Employee")]
        public int Employee_ID { get; set; }
        public Employee Employee { get; set; }
    }
}
