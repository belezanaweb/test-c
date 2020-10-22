using belezanaweb.Domain.Entities;
using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Infra.Data.Context;

namespace belezanaweb.Infra.Data.Repositories
{
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(BelezanawebContext context)
            : base(context)
        {

        }
    }
}
