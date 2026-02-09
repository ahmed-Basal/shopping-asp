using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Data.Configration
{
    public  class ProductConfigration: Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<core.Entities.product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<core.Entities.product> builder)
        {
            builder.Property(x => x.name).IsRequired();
            builder.Property(x => x.description).IsRequired();
            builder.Property(x => x.price).HasColumnType("decimal(18,2)");
        }
    }
}
