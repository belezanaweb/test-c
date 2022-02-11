using System.Threading.Tasks;
using System.Collections.Generic;

namespace BelezaWeb.Domain.Interfaces
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int sku);
        Task<T> Create(T item);
        Task<T> Edit(T item);
        Task Delete(int sku);
    }
}
