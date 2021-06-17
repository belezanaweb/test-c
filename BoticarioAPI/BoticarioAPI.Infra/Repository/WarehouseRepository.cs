using BoticarioAPI.Domain.Entities;
using BoticarioAPI.Domain.Interfaces.Repository;
using BoticarioAPI.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace BoticarioAPI.Infra.Repository
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        private readonly BoticarioContext _context;
        public WarehouseRepository(BoticarioContext context) : base(context)
        {
            _context = context;
        }

        public List<Warehouse> GetAllBySku(int sku)
        {
           return _context.Warehouses.Where(warehouse => warehouse.Sku == sku).ToList();
        }
    }
}
