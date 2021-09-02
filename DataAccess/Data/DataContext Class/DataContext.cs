using Bussiness_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.DataContext_Class
{
   public class DataContext : DbContext
   {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Registration of Entity Classes in Database

        public DbSet<Category> Categories { get; set; }
   }
}
