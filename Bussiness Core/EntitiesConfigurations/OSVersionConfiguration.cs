using Bussiness_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.EntitiesConfigurations
{
   public class OSVersionConfiguration :  IEntityTypeConfiguration<OperatingSystemVersion>
    {
        public void Configure(EntityTypeBuilder<OperatingSystemVersion> builder)
        {
            builder.HasKey(a => a.OSV_Id);
            builder.HasOne(a => a.OperatingSystemss).WithMany().HasForeignKey(a => a.OperatingSystemId);





        }
    }
}
