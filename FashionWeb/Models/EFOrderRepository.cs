using FashionWeb.Models;
using Microsoft.EntityFrameworkCore;
namespace FashionWeb.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private DataContext _context;
        public EFOrderRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Order> Orders => _context.Orders
        .Include(o => o.Lines)
       .ThenInclude(l => l.Product);
        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}