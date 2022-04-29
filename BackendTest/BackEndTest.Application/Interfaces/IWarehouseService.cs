using BackEndTest.Application.DTOs;

namespace BackEndTest.Application.Interfaces
{
    public interface IWarehouseService
    {
        Task<bool> CreateWarehouses(List<WarehouseDTO> warehouses, int productSku);
        Task<List<WarehouseDTO>> GetWarehousesByProductSku(int productSku);
        Task<bool> RemoveWarehousesByProductSku(int productSku);
        Task<bool> UpdateWarehousesBySku(List<WarehouseDTO> warehouses);
    }
}
