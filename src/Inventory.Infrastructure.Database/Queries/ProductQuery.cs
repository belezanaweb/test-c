using Inventory.Core;
using Inventory.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Database.Data.Queries
{
    public class ProductQuery
    {
        private readonly IQueryable<Product> products;
        private readonly ApplicationContext applicationContext;

        public ProductQuery(IQueryable<Product> products, ApplicationContext applicationContext)
        {
            this.products = products;
            this.applicationContext = applicationContext;
        }

        public async Task<Product> GetAsync(long sku)
        {
            var product = await this.products.Include(x => x.Inventory).ThenInclude(x => x.Warehouses).FirstOrDefaultAsync(w => w.Sku == sku);
            product?.CalculateInventory();
            return product;
        }

        public async Task<Product> GetAsReadOnly(long sku)
        {
            var product = await applicationContext.Set<Product>().AsNoTracking().Include(x => x.Inventory).ThenInclude(x => x.Warehouses).FirstOrDefaultAsync(w => w.Sku == sku);
            applicationContext.Entry(product).State = EntityState.Detached;
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var query = this.products
                .Include(x => x.Inventory)
                .ThenInclude(x => x.Warehouses)
                .ToList()
                .Select(s =>
                {
                    s.CalculateInventory();
                    return s;
                });
            return query;
        }
    }
}