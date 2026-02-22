using core.Entities;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Data.Configration
{
    public class orderconfigration : IEntityTypeConfiguration<orders>
    {
        public void Configure(EntityTypeBuilder<orders> builder)
        {
            builder.OwnsOne(x => x.address, a =>
            {
                a.WithOwner();
            });


            builder.HasMany(x => x.orderItems)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.statues)
          .HasConversion(
              o => o.ToString(),
              o => (statues)Enum.Parse(typeof(statues), o)
          );
            builder.Property(x => x.subtotal).HasColumnType("decimal(18,2)");
        }
    }
}
