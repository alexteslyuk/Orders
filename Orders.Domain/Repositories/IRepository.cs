using Orders.Domain.Models;

namespace Orders.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);        
        void Remove(TEntity entity);
        Task<int> SaveChanges();
    }
}
