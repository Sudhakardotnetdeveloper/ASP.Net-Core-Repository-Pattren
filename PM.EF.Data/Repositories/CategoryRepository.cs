using PM.Domain;
using PM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.EF.Data.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(PMContext context)
            :base(context)
        {

        }
    }
}
