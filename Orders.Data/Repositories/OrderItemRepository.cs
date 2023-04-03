using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;
using Orders.Domain.Repositories;

namespace Orders.Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DataContext _context;

        public OrderItemRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<OrderItem> GetAll() => _context.OrderItems.AsNoTracking();

        public async Task<OrderItem> Get(int id) => await _context.OrderItems.SingleOrDefaultAsync(i => i.Id == id);

        public async Task<OrderItem> Add(OrderItem orderItem)
        {
            return (await _context.OrderItems.AddAsync(orderItem)).Entity;
        }

        public void Remove(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
