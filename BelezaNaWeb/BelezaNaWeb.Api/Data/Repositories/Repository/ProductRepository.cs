using System.Collections.Generic;
using System.Threading.Tasks;
using BelezaNaWeb.Api.Data.Repositories.Contract;
using BelezaNaWeb.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWeb.Api.Data.Repositories.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Index()
        {
            var products = await _context.Products
                .Include(x => x.Inventory)
                .Include(x => x.Inventory.Warehouses)
                .ToListAsync();
            return products;
        }
        public async Task<Product> Store(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Show(int sku)
        {
            var product = await _context.Products
                .Include(x => x.Inventory)
                .Include(x => x.Inventory.Warehouses)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Sku == sku);

            return product;
        }
        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Destroy(Product product)
        {
            if (product == null)
                return false;

            _context.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
