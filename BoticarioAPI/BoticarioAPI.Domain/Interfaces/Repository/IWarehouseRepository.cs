using BoticarioAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.Interfaces.Repository
{
    public interface IWarehouseRepository : IBaseRepository<Warehouse>
    {
        List<Warehouse> GetAllBySku(int sku);
    }
}
