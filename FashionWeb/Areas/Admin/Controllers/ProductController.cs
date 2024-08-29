using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FashionWeb.Models;
using FashionWeb.Utilities;
using Microsoft.Extensions.Hosting;

namespace FashionWeb.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var mnList = (from m in _context.Categories
                          select new SelectListItem()
                          {
                              Text = m.CategoryName,
                              Value = m.CategoryID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            var color = (from m in _context.Colors
                         select new SelectListItem()
                         {
                             Text = m.ColorName,
                             Value = m.ColorID.ToString()
                         }).ToList();
            color.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            var size = (from m in _context.Sizes
                        select new SelectListItem()
                        {
                            Text = m.SizeName,
                            Value = m.SizeID.ToString()
                        }).ToList();
            size.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.size = size;
            ViewBag.color = color;
            ViewBag.CategoryList = mnList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
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
            var ct = _context.Products.Find(id);
            if (ct == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Categories
                          select new SelectListItem()
                          {
                              Text = m.CategoryName,
                              Value = m.CategoryID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            var color = (from m in _context.Colors
                         select new SelectListItem()
                         {
                             Text = m.ColorName,
                             Value = m.ColorID.ToString()
                         }).ToList();
            color.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            var size = (from m in _context.Sizes
                        select new SelectListItem()
                        {
                            Text = m.SizeName,
                            Value = m.SizeID.ToString()
                        }).ToList();
            size.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.size = size;
            ViewBag.color = color;
            ViewBag.prodList = mnList;
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
            var mnList = _context.Products.OrderBy(m => m.ProductID).ToList();
            return View(mnList);
        }
        public IActionResult Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _context.Products.Find(id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
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
            var deleMenu = _context.Products.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Products.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

