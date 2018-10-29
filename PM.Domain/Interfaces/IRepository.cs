using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PM.Domain.Interfaces
{
    public interface IRepository<T> where T:class
    {
        void AddEntity(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithIncludes(params Expression<Func<T,object>>[] includes);



    }
}
