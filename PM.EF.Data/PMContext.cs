using Microsoft.EntityFrameworkCore;
using PM.Domain;
using PM.EF.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.EF.Data
{
    public class PMContext:DbContext
    {
        public PMContext(DbContextOptions<PMContext> contextOptions)
            :base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=ProductManager;User=sa;Password=sa123", options =>
            {
                options.UseRowNumberForPaging();
                options.CommandTimeout(100);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurations();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
