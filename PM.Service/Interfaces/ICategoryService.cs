using PM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Service.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAllWithIncludes();
    }
}
