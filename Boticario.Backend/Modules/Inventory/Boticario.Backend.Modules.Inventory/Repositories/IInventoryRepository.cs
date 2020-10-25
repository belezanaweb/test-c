using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Repositories
{
    public interface IInventoryRepository
    {
        Task<IList<IInventoryEntity>> GetAll(int sku);
        Task DeleteAll(int sku);
        Task SaveAll(int sku, IList<IInventoryEntity> inventories);
    }
}
