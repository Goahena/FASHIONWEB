using FashionWeb.Components;
using FashionWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ct = _context.Products.ToList();
            if (ct == null)
            {
                return NotFound();
            }
            return View(ct);
        }
        public IActionResult CategorySearch(int? CategoryID)
        {
            if (CategoryID == null || CategoryID == 0)
            {
                return NotFound();
            }
            var ct = _context.Products
                .Where(m => m.CategoryID == CategoryID).ToList();
            if (ct == null)
            {
                return NotFound();
            }
            return View(ct);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products
                .FirstOrDefault(m => (m.ProductID == id));
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Search(string ProductName)
        {
            if (ProductName == null || ProductName == "")
            {
                return View("Index");
            }
            var product = _context.Products.Where(m => m.ProductName == ProductName).ToList();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
