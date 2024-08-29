using FashionWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FashionWeb.Components
{
    [ViewComponent(Name = "SimilarProduct")]
    public class SimilarProduct : ViewComponent
    {
        private DataContext _context;
        public SimilarProduct(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Sprod = (from m in _context.Products
                              where m.IsActive == true
                              select m).Take(5).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", Sprod));
        }
    }
}
