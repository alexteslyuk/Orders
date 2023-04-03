using Orders.Domain.Models;

namespace Orders.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
    }
}
