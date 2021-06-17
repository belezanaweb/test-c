using BoticarioAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
