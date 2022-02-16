using BelezaNaWeb.Domain.Entities.Products;
using BelezaNaWeb.Domain.Interfaces.Products;
using BelezaNaWeb.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BelezaNaWeb.Infrastructure.Repositories.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<Product> GetProductBySkuAsync(long sku)
            => await Query
                .Include(p => p.Inventory)
                    .ThenInclude(c => c.Warehouses)
                .FirstOrDefaultAsync(d => d.Sku == sku);
    }
}
