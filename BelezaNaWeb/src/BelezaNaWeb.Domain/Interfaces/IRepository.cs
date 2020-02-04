using System;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(long id);
        void  Update(TEntity entity);
        Task Deletar(long id);
        Task CommitAsync();
    }
}
