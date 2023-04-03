using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;
using Orders.Domain.Repositories;

namespace Orders.Data.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly DataContext _context;
        public ProviderRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Provider> GetAll() => _context.Providers.AsNoTracking();

        public async Task<Provider> Get(int id) => await _context.Providers.SingleOrDefaultAsync(i => i.Id == id);
    }
}