using Boticario.Backend.Modules.Products.Exceptions;
using Boticario.Backend.Modules.Products.Models;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<int, IProduct> database;

        public ProductRepository()
        {
            this.database = new ConcurrentDictionary<int, IProduct>();
        }

        public async Task<bool> Exists(int sku)
        {
            return await Task.Run(() =>
            {
                return this.database.ContainsKey(sku);
            });
        }

        public async Task<IProduct> Get(int sku)
        {
            return await Task.Run(() =>
            {
                if (this.database.TryGetValue(sku, out IProduct product))
                {
                    return product;
                }
                else
                {
                    return null;
                }
            });
        }

        public async Task Save(IProduct product)
        {
            await Task.Run(() =>
            {
                if (!this.database.TryAdd(product.Sku, product))
                {
                    throw new ProductAlreadyExistsException();
                }
            });
        }

        public async Task Delete(int sku)
        {
            await Task.Run(() =>
            {
                if (this.database.TryRemove(sku, out _))
                {
                    throw new ProductNotFoundException();
                }
            });
        }
    }
}
