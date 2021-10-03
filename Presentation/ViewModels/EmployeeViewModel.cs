using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DathOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EmployeeHireDate { get; set; }
        [ForeignKey("User")]
        public string User_ID { get; set; }
        public CustomIdentity User { get; set; }
        public string RoleName { get; set; }

    }
}
