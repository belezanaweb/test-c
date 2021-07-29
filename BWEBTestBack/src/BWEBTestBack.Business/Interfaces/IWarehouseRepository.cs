using BWEBTestBack.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BWEBTestBack.Business.Interfaces
{
    public interface IWarehouseRepository
    {
        Task Add(Warehouse warehouse);
        Task<List<Warehouse>> GetByInventoryId(Guid inventoryId);
        Task Update(Warehouse warehouse);
        Task DeleteInventoryId(Guid inventoryId);
    }
}
