using NHibernate;
using PM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;


namespace PM.NHibernate.Data.Repositories
{
    public abstract class Repository<T>:IRepository<T> where T:class
    {
        protected readonly ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public void AddEntity(T entity)
        {
            session.Save(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return session.Query<T>().ToList();
        }

        public IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = session.Query<T>();
            foreach(var include in includes)
            {
                query = query.Fetch(include);
            }
            return query.AsEnumerable();
        }
    }
}
