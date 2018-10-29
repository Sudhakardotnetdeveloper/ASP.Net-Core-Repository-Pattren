using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PM.Domain.Interfaces;
using PM.EF.Data;
using PM.NHibernate.Data.Helpers;
using PM.NHibernate.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.Extensions
{
    public static class ORMServiceExtensions
    {
        public static IServiceCollection InjectEF(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<PMContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("Default"));

            });
            services.AddScoped<ICategoryRepository, PM.EF.Data.Repositories.CategoryRepository>();
            return services;
        }

        public static IServiceCollection InjectNHibernate(this IServiceCollection services)
        {
            services.AddSingleton<AppSessionFactory>();
            services.AddScoped(x => x.GetService<AppSessionFactory>().OpenSession());
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
