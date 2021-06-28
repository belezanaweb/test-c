using GrupoBoticario.DataAccess.Repositories.Generic;
using GrupoBoticario.Domain.Entity.Product;
using GrupoBoticario.Domain.IRepositories;

namespace GrupoBoticario.DataAccess.Repositories
{
    public class InventoryRepository : RepositoryBase<InventoryEntity>, IInventoryRepository
    {
        public InventoryRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
