using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Domain.Models;
using BelezaNaWeb.Infrastructure.Data.Context;
using System.Linq;

namespace BelezaNaWeb.Infrastructure.Data.Repository
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(BelezaNaWebContext belezaNaWebContext) : base(belezaNaWebContext)
        {
        }

        public Warehouse Get(string locality, string type)
        {
            return DbSet.FirstOrDefault(w => w.Locality == locality && w.Type == type);
        }
    }
}
