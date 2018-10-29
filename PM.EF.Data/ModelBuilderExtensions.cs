using Microsoft.EntityFrameworkCore;
using PM.EF.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.EF.Data
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyConfigurations(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}
