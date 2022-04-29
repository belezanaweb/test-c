using BackEndTest.Domain.Entities;

namespace BackEndTest.Domain.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<bool> CreateWarehousesAsync(List<Warehouse> warehouses, int productSku);
        Task<List<Warehouse>> GetWarehousesByProductSkuAsync(int productSku);
        Task<bool> RemoveWarehousesByProductSkuAsync(int productSku);
        Task<bool> UpdateWarehousesBySkuAsync(List<Warehouse> warehouses);
    }
}
