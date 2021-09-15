using Projeto.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Domain.Repositories
{
    public interface IWarehouseRepository
    {
        Task<int> Add(Warehouse entity);

        Task<bool> Delete(int sku);

        Task<IEnumerable<Warehouse>> Get(int sku);
    }
}
