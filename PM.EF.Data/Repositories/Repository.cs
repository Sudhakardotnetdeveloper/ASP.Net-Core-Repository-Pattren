using Microsoft.EntityFrameworkCore;
using PM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PM.EF.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PMContext context;

        public Repository(PMContext context)
        {
            this.context = context;
        }
        public void AddEntity(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();
            foreach(var include in includes)
            {
                query=query.Include(include);
            }
            return query.AsEnumerable();
        }
    }
}
