using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PM.Domain;
using PM.Service.Interfaces;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;

        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(string code,string name)
        {
            Category category = new Category()
            {
                Code = code,
                Name = name
                
            };


            var products = new List<Product>() {
                new Product(){ Code="P001",Name="Product1",Category=category},
                new Product(){ Code="P001",Name="Product1",Category=category},
                new Product(){Code="P001",Name="Product1",Category=category}

            };
            category.Products = products;
            categoryService.AddCategory(category);
            TempData["Information"] = "Category added";
            return RedirectToAction(nameof(AddCategory));
        }

        public IActionResult CategoryList()
        {
            IEnumerable<Category> categories = categoryService.GetAllWithIncludes();
            return View(categories);
        }
    }
}
