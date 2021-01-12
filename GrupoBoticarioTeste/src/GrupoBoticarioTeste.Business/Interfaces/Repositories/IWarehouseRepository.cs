using GrupoBoticarioTeste.Business.Models;
using System.Collections.Generic;

namespace GrupoBoticarioTeste.Business.Interfaces.Repositories
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        void AddWarehouse(IEnumerable<Warehouse> warehouse);
        void ChangeWarehouse(int id, Warehouse warehouse);
    }
}
