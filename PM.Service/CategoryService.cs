using PM.Domain;
using PM.Domain.Interfaces;
using PM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void AddCategory(Category category)
        {
            categoryRepository.AddEntity(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAllWithIncludes()
        {
            return categoryRepository.GetAllWithIncludes(c => c.Products);
        }
    }
}
