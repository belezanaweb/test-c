using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Services
{
    public interface IGetInventoryService
    {
        Task<IList<IInventory>> Delete(int sku);
    }
}
