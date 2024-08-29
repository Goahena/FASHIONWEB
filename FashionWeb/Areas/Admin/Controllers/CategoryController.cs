using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FashionWeb.Models;
using FashionWeb.Utilities;
using Microsoft.Extensions.Hosting;

namespace FashionWeb.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ct = _context.Categories.Find(id);
            if (ct == null)
            {
                return NotFound();
            }
            
            return View(ct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(prod);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prod);
        }
        public IActionResult Index()
        {
            var mnList = _context.Categories.OrderBy(m => m.CategoryID).ToList();
            return View(mnList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Products.Find(id);

            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleMenu = _context.Categories.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

