using BackEndTest.Domain.Entities;

namespace BackEndTest.Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task<bool> CreateInventoryAsync(Inventory inventory, int productSku);
        Task<Inventory> GetInventoryByProductSkuAsync(int productSku);
        Task<bool> RemoveInventoryByProductSkuAsync(int productSku);
        Task<bool> UpdateInventoryByProductSkuAsync(Inventory inventory);
    }
}
