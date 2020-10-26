using Boticario.Backend.Modules.Inventory.Dto;
using Boticario.Backend.Modules.Inventory.Models;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Services
{
    public interface IInventoryServices
    {
        Task<IInventoryDetails> GetAll(int sku);
        Task SaveAll(int sku, InventoryOperationDto inventory);
        Task DeleteAll(int sku);
    }
}
