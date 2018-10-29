# ASP.Net-Core-Repository-Pattren
Repository Pattern in ASP. Net Core  with ORM Ignorance(Entity Framework/NHibernate).You can change ORM with minimal effects on project






You can Inject ORM's in Startup.cs (I have written only for EF and NHibernate)

In case of NHibernate change the code as below in AppSessionFactory to generate database tables from domain entities
.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))

