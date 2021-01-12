using GrupoBoticarioTeste.Business.Interfaces.Repositories;
using GrupoBoticarioTeste.Business.Models;
using GrupoBoticarioTeste.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace GrupoBoticarioTeste.Infrastructure.Repository
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(DataContext dbContext) : base(dbContext)
        { }

        public void AddWarehouse(IEnumerable<Warehouse> warehouse)
        {   
            _dbContext.AddRange(warehouse);
            _dbContext.SaveChanges();
        }

        public void ChangeWarehouse(int id, Warehouse warehouse)
        {
            var warehouses = _dbContext.Set<Warehouse>()
                                 .Where(x => x.ProductId == id)
                                 .ToList();

            _dbContext.RemoveRange(warehouses);
            _dbContext.AddRange(warehouse);
            _dbContext.SaveChanges();

        }
    }
}
