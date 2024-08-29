using FashionWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FashionWeb.Components
{
    [ViewComponent(Name = "Category")]
    public class Category : ViewComponent
    {
        private DataContext _context;
        public Category(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofcategory = (from m in _context.Categories
                                  where (m.IsActive == true)
                                  select m).Take(12).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofcategory));
        }
    }
}
