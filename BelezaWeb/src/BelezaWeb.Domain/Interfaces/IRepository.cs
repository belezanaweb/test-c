using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaWeb.Domain.Interfaces
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int sku);
        Task<T> Add(T item);
        Task<T> Edit(T item);
        Task Delete(int sku);
    }
}
