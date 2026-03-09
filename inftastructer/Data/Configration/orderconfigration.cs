using core.Entities;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackExchange.Redis;
using Stripe.Climate;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Data.Configration
{
    public class orderconfigration : IEntityTypeConfiguration<core.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<core.Entities.Order> builder)
        {
            builder.OwnsOne(x => x.Address, a =>
            {
                a.WithOwner();
            });


            builder.HasMany(x => x.OrderItems)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Status)
          .HasConversion(
              o => o.ToString(),
              o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
          );
            builder.Property(x => x.Subtotal).HasColumnType("decimal(18,2)");
        }
    }
}
