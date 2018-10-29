using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using PM.NHibernate.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.NHibernate.Data.Helpers
{
    public class AppSessionFactory
    {
        public Configuration Configuration { get; }
        public ISessionFactory SessionFactory { get; }

        public AppSessionFactory(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default");
            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, false, false))
                .BuildConfiguration()
                .BuildSessionFactory();

            //var mapper = new ModelMapper();
            //mapper.AddMapping<CategoryMap>();
            //var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            //Configuration = new Configuration();
            //Configuration.DataBaseIntegration(db =>
            //{
            //    db.ConnectionString = connectionString;
            //    db.Dialect<MsSql2012Dialect>();
            //    db.Driver<Sql2008ClientDriver>();
            //})
            //    .AddMapping(domainMapping);
            //Configuration.SessionFactory().GenerateStatistics();
            //SessionFactory = Configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
