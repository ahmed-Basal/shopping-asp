using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Data.Configration
{
    public class OrderItemsConfigration : IEntityTypeConfiguration<orderitem>
    {
        public void Configure(EntityTypeBuilder<orderitem> builder)
        {
            builder.Property(x=>x.Price).HasColumnType("decimal(18,2)");
        }
    }
}
