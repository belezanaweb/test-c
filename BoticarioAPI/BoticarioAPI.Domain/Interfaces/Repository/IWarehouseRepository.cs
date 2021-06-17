using BoticarioAPI.Domain.Entities;
using System.Collections.Generic;

namespace BoticarioAPI.Domain.Interfaces.Repository
{
    public interface IWarehouseRepository : IBaseRepository<Warehouse>
    {
        List<Warehouse> GetAllBySku(int sku);
    }
}
