using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DathOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public string EmployeeHireDate { get; set; }
        [ForeignKey("User")]
        public string User_ID { get; set; }
        public CustomIdentity User { get; set; }
        public EmployeeMonthlyPayment  EmployeeMonthlyPayment { get; set; }
        public string RoleName { get; set; }
        public DateTime? Modified_At { get; set; }
    }
}
