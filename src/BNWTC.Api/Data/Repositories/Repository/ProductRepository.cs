using BNWTC.Api.Data.Repositories.Interface;
using BNWTC.Api.Models.Entities;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace BNWTC.Api.Data.Repositories.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> FindBySku(int sku)
        {
            var product = await _context.Products
                .Include(x => x.Inventory)
                .Include(x => x.Inventory.Warehouses)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Sku == sku);

            return product;
        }

        public async Task<Product> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Remove(Product product)
        {
            if (product == null)
                return false;

            _context.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
