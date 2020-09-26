using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Domain.Entities.Impl;
using BelezaNaWeb.Framework.Data.Contexts;

namespace BelezaNaWeb.Framework.Data.Repositories.Impl
{
    public sealed class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        #region Constructors

        public ProductRepository(ILogger<ProductRepository> logger, ApiContext dbContext)
            : base(logger, dbContext)
        { }

        #endregion

        #region Overriden Methods

        public override async Task Update(object id, Product entity)
        {
            var existing = await _dbContext.Set<Product>()
                .Where(x => x.Sku.Equals(id))
                .Include(x => x.Warehouses)
                .FirstOrDefaultAsync();

            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(entity);

                foreach (var warehouse in existing.Warehouses.ToList())
                {
                    if (!entity.Warehouses.Any(x => x.Equals(warehouse)))                    
                        _dbContext.Set<Warehouse>().Remove(warehouse);                    
                }

                foreach (var item in entity.Warehouses)
                {
                    var current = existing.Warehouses
                        .Where(x => x.Equals(item))
                        .SingleOrDefault();

                    if (current == null)
                        existing.Warehouses.Add(item);
                    else
                        _dbContext.Entry(current).CurrentValues.SetValues(item);
                }
            }            
        }

        #endregion
    }
}
