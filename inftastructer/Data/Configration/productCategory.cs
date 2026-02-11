using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Data.Configration
{
    public class productCategory : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<core.Entities.product>
    {
        public void Configure(EntityTypeBuilder<product> builder)
        {
            builder.Property(x => x.name).IsRequired();
            builder.Property(x => x.description).IsRequired();
          
           
            builder.HasData(
                new product { Id = 1, name = "test", description = "test", CategoryId = 1, NewPrice = 20.5m });
        }
    }
}
