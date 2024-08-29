using FashionWeb.Models;
using FashionWeb.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FashionWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.Contacts.OrderByDescending(m => m.ContactID).ToList();
            return View(mnList);
        }
        [Route("/contact-{slug}-{id:int}.html", Name = "ContactDetails")]
        public IActionResult ContactDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = _context.Contacts
                .FirstOrDefault(m => (m.ContactID == id));
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
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
            var deleMenu = _context.Contacts.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
