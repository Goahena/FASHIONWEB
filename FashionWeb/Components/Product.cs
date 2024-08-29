using FashionWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FashionWeb.Components
{
    [ViewComponent(Name = "Product")]
    public class Product : ViewComponent
    {
        private DataContext _context;
        public Product(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofmenu = (from m in _context.Products
                              where m.IsActive == true
                              select m).Take(8).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofmenu));
        }
    }
}
