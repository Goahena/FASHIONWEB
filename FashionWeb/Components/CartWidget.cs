using FashionWeb.Models;
using FashionWeb.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FashionWeb.Components
{
    [ViewComponent(Name = "CartWidget")]
    public class CartWidget : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View(HttpContext.Session.GetJson<Cart>("cart")));
        }
    }
}
