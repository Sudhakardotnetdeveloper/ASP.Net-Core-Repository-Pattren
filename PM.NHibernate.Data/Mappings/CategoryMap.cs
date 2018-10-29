using FluentNHibernate.Mapping;
using PM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.NHibernate.Data.Mappings
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(c => c.Id);
            Map(c => c.Code).Length(10).CustomType("AnsiString");
            Map(c => c.Name).Length(255).CustomType("AnsiString");
            HasMany(c => c.Products)
                .AsSet()
                .Inverse()
                .KeyColumn("CategoryId")
                .Cascade.All();
               
        }
    }
}
