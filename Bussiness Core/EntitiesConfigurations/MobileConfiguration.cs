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
    public class MobileConfiguration : IEntityTypeConfiguration<Mobile>
    {
        public void Configure(EntityTypeBuilder<Mobile> builder)
        {
            builder.HasKey(a => a.Mobile_Id);
            builder.HasOne(a => a.Brand).WithMany().HasForeignKey(a => a.BrandId);
            builder.HasOne(a => a.Color).WithMany().HasForeignKey(a => a.ColorId);
            builder.HasOne(a => a.OperatingSystemVersion).WithMany().HasForeignKey(a => a.OSVersionId);

        }
    }
}