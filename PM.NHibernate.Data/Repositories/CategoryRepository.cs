using NHibernate;
using PM.Domain;
using PM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.NHibernate.Data.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(ISession session)
            :base(session)
        {

        }
    }
}
