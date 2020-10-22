using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Services
{
    interface ISaveInventoryService
    {
        Task Execute(int sku, IList<IInventory> inventories);
    }
}
