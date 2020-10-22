using System.Collections.Generic;
using System.Threading.Tasks;

namespace belezanaweb.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(int id);
    }
}
