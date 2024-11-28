using Microsoft.AspNetCore.Mvc;
using Lab3_301064831.Models;
using System.Collections.Generic;

namespace Lab3_301064831.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Mouse", Price = 19.99m },
            new Product { Id = 3, Name = "Keyboard", Price = 49.99m }
        };

        // GET: /Product/
        public IActionResult Index()
        {
            return View(_products); 
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            return View(); 
        }

        // POST: /Product/Create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _products.Add(product); 
            return RedirectToAction("Index");
        }
    }
}
