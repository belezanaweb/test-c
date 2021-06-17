using BoticarioAPI.Domain.Entities;
using System.Collections.Generic;

namespace BoticarioAPI.Domain.Interfaces.Application
{
    public interface IWarehouseApp
    {
        bool AddRange(List<Warehouse> warehouses);
        bool Updaterange(List<Warehouse> warehouses);
        List<Warehouse> GetAll(int sku);
        bool Delete(int sku);
    }
}
