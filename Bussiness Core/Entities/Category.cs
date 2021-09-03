using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime? Created_At { get; set; } = DateTime.Now;


    }
}