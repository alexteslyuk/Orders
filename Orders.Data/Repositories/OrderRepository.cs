using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;
using Orders.Domain.Repositories;

namespace Orders.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Order> GetAll() => _context.Orders.AsNoTracking();

        public async Task<Order> Get(int id) => await _context.Orders.SingleOrDefaultAsync(i => i.Id == id);

        public async Task<Order> Add(Order order)
        {
            return (await _context.Orders.AddAsync(order)).Entity;
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
