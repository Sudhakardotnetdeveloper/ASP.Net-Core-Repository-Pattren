using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.EF.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(c => c.Code).IsRequired().HasColumnType("varchar(10)");
            builder.Property(c => c.Name).IsRequired().HasColumnType("varchar(255)");

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
