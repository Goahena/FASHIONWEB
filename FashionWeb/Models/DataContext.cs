using FashionWeb.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace FashionWeb.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders => Set<Order>();
    }
}
