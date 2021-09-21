using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels.Identity
{
   public class UserRegisterViewModel
    {
            public int Id { get; set; }
            public string UserName { get; set; }
            [EmailAddress]
            public string Email { get; set; }
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "Password and Confirmation password Do no match.")]
            public string ConfirmPassword { get; set; }
        }
    }
