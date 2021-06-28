using GrupoBoticario.DataAccess.Repositories.Generic;
using GrupoBoticario.Domain.Entity.Product;
using GrupoBoticario.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoBoticario.DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        private DbSet<ProductEntity> _dbSet;
        public ProductRepository(Context dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<ProductEntity>();
        }

        public async Task<ProductEntity> ObterPorId(long sku)
        {
            return await _dbSet
                .Include(x => x.Inventory)
                .Include(x => x.Inventory.WareHouses)
                .FirstOrDefaultAsync(x => x.Sku == sku);  
        }

        public async Task<IEnumerable<ProductEntity>> ObterTodos()
        {
            return await _dbSet
                 .Include(x => x.Inventory)
                 .Include(x => x.Inventory.WareHouses)
                 .ToListAsync();
        }
    }
}
