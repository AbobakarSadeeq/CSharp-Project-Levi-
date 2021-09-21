using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class CustomIdentity : IdentityUser
    {
        public ICollection<UserImage> UserImages { get; set; }
        public CustomIdentity()
        {
            UserImages = new HashSet<UserImage>();
        }
    }
}
