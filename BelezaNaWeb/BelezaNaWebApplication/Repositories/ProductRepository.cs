using BelezaNaWebApplication.Persistence.Contexts;
using BelezaNaWebDomain;
using BelezaNaWebDomain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWebApplication.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(MemoryDbContext context) : base(context)
        {
        }

        public async Task AddAync(Product product)
        {
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
        }

        public async Task<Product> FindByIdAsync(long sku)
        {
            var objResult = await _context.Products.FirstOrDefaultAsync(x => x.SKU == sku);
            return objResult;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}