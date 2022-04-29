using BackEndTest.Application.DTOs;

namespace BackEndTest.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<bool> CreateInventory(InventoryDTO inventory, int productSku);
        Task<InventoryDTO> GetInventoryByProductSku(int productSku);
        Task<bool> RemoveInventoryByProductSku(int productSku);
        Task<bool> UpdateInventoryByProductSku(InventoryDTO inventory);
    }
}
