using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class CreateEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DathOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public string EmployeeHireDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string RoleName { get; set; }
        public EmployeeMonthlyPayment EmployeeMonthlyPayment { get; set; }
        public DateTime? Modified_At { get; set; }
    }
}
