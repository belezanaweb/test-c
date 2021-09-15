using Projeto.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Domain.Interfaces
{
    public interface IWarehouseService
    {
        Task<bool> Create(Warehouse warehouse);

        Task<bool> Delete(int sku);

        Task<IEnumerable<Warehouse>> Get(int sku);
    }
}
