using BelezaNaWeb.Domain.Entities;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<int> SaveChangesAsync();
    }
}
