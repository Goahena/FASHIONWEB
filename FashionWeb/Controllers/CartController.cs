using FashionWeb.Infrastructure;
using FashionWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FashionWeb.Controllers
{
    public class CartController : Controller
    {
        public Cart? Cart { get; set; }
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("Cart", HttpContext.Session.GetJson<Cart>("cart"));
        }
        public IActionResult AddToCart(int productID)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
        public IActionResult UpdateCart(int productID)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, -1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
        public IActionResult RemoveFromCart(int productID)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart");
                Cart.RemoveLine(product);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
