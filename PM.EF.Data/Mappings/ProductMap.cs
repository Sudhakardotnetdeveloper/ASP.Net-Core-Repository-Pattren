using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Design;
using PM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.EF.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(p => p.Code).IsRequired().HasColumnType("varchar(10)");
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(255)");
        }
    }
}
