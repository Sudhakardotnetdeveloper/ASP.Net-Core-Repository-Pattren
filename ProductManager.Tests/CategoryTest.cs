using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Domain;
using PM.Domain.Interfaces;
using PM.NHibernate.Data.Helpers;
using PM.NHibernate.Data.Repositories;
using PM.Service;
using PM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Tests
{
    [TestClass]
    public class CategoryTest
    {
        public ICategoryService _categoryService;
        public ICategoryRepository _categoryRepository;
        public IConfiguration configuration;
        [TestInitialize]
        public void InitializeCategoryTest()
        {

            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _categoryRepository = new CategoryRepository(new AppSessionFactory(configuration).OpenSession());
            _categoryService = new CategoryService(_categoryRepository);

        }
        [TestMethod]
        public void AddCategory()
        {
            Category category = new Category()
            {
                Code = "C10001",
                Name = "Category one"
            };
                

            var products = new List<Product>() {
                new Product(){ Code="P001",Name="Product1",Category=category},
                new Product(){ Code="P001",Name="Product1",Category=category},
                new Product(){Code="P001",Name="Product1",Category=category}

            };

            category.Products = products;
            _categoryService.AddCategory(category);

        }
    }
}
