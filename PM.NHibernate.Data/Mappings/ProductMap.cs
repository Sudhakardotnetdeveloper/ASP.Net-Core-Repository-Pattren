using FluentNHibernate.Mapping;
using PM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.NHibernate.Data.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Id(c => c.Id);
            Map(c => c.Name).CustomType("AnsiString").Length(255);
            Map(c => c.Code).CustomType("AnsiString").Length(10);
            References(c => c.Category)
                .Column("CategoryId")
                       .Cascade.All();
            
        }
    }
}
