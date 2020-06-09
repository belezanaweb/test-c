using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_beauty.Data;
using web_beauty.Models;

namespace web_beauty.Repositories
{
    public class ProductRepository
    {
        private readonly IContext _context;
        public ProductRepository(IContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {

            await _context.Products.InsertOneAsync(product);

        }

        public async Task<Product> GetBySku(long sku)
        {
            return await _context.Products.Find(p => p.Sku == sku).FirstOrDefaultAsync();
        }

        public async Task Update(Product product)
        {
            await _context.Products.ReplaceOneAsync(p => p.Sku == product.Sku, product);
        }

        public async Task Delete(long sku)
        {
            await _context.Products.DeleteOneAsync(p => p.Sku == sku);
        }
    }
}
