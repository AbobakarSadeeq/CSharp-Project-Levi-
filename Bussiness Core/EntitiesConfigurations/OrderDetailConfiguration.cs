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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(a => a.OrderDetailId);

            // Relationship
            builder.HasOne(a => a.Order).WithMany().HasForeignKey(a => a.Order_Id);
            builder.HasOne(a => a.Mobile).WithMany().HasForeignKey(a => a.Mobile_Id);

        }

    }
    }
