using BWEBTestBack.Business.Models;
using System;
using System.Threading.Tasks;

namespace BWEBTestBack.Business.Interfaces
{
    public interface IInventoryRepository
    {
        Task Add(Inventory inventory);
        Task<Inventory> GetByProductId(Guid productId);
        Task Update(Inventory inventory);
        Task DeleteByProductId(Guid productId);
    }
}
