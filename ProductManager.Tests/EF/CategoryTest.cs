using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Domain;
using PM.Domain.Interfaces;
using PM.EF.Data;
using PM.EF.Data.Repositories;
using PM.Service;
using PM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Tests.EF
{
    [TestClass]
    public class CategoryTest
    {
        ICategoryService _categoryService;
        ICategoryRepository _categoryRepository;
        PMContext _context;
        IConfiguration _configuration;
        [TestInitialize]
        public void InitializeCategoryTest()
        {
            _configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();
            var options = new DbContextOptionsBuilder<PMContext>()
            .UseSqlServer(_configuration.GetConnectionString("Default"))
             .Options;
            _context = new PMContext(options);
            _categoryRepository = new CategoryRepository(_context);
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
                new Product(){ Code="P001",Name="Product1",CategoryId=category.Id},
                new Product(){ Code="P001",Name="Product1",CategoryId=category.Id},
                new Product(){Code="P001",Name="Product1",CategoryId=category.Id}

            };

            category.Products = products;
            _categoryService.AddCategory(category);
        }
    }
}
