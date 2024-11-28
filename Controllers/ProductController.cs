using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Lab3_301064831.Models;

namespace Lab3_301064831.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99M },
            new Product { Id = 2, Name = "Mouse", Price = 19.99M },
            new Product { Id = 3, Name = "Keyboard", Price = 49.99M }
        };

        [HttpGet]
        [Route("Product")]
        public IActionResult Index(string searchQuery)
        {
            var products = string.IsNullOrEmpty(searchQuery)
                ? _products
                : _products.Where(p => p.Name.Contains(searchQuery, System.StringComparison.OrdinalIgnoreCase)).ToList();

            ViewData["SearchQuery"] = searchQuery;

            return View(products);
        }

        [HttpGet]
        [Route("Product/Details/{id}")]
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        [Route("Product/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Product/Create")]
        public IActionResult Create(Product product)
        {
            _products.Add(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Product/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [Route("Product/DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}
