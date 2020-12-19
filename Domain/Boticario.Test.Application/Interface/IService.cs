using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Test.Application.Interface
{
    public interface IService<T>
    {
        Task<T> add(T entity);
        Task update(T entity);
        Task remove(int id);
        Task<IEnumerable<T>> getAll();
        Task<T> getBySku(int sku);
    }
}