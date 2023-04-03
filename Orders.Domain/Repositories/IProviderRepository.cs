using Orders.Domain.Models;

namespace Orders.Domain.Repositories
{
    public interface IProviderRepository
    {
        IQueryable<Provider> GetAll();
        Task<Provider> Get(int id);
    }
}
