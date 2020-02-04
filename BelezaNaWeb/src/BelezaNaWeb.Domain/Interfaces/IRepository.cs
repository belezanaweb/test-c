using System;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> GetById(long id);
        Task<TEntity> Update(TEntity entity);
        Task Remove(long id);
    }
}
