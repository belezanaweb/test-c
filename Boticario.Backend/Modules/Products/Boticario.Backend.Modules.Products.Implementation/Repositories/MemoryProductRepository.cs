using Boticario.Backend.Modules.Products.Implementation.Exceptions;
using Boticario.Backend.Modules.Products.Models;
using Boticario.Backend.Modules.Products.Repositories;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Implementation.Repositories
{
    public class MemoryProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<int, IProductEntity> database;

        public MemoryProductRepository()
        {
            this.database = new ConcurrentDictionary<int, IProductEntity>();
        }

        public async Task<IProductEntity> Get(int sku)
        {
            return await Task.Run(() =>
            {
                if (this.database.TryGetValue(sku, out IProductEntity product))
                {
                    return product;
                }
                else
                {
                    return null;
                }
            });
        }

        public async Task Insert(IProductEntity product)
        {
            await Task.Run(() =>
            {
                if (!this.database.TryAdd(product.Sku, product))
                {
                    throw new ProductAlreadyExistsException();
                }
            });
        }

        public async Task Update(IProductEntity product)
        {
            await Task.Run(() =>
            {
                if (this.database.TryGetValue(product.Sku, out IProductEntity actualProduct))
                {
                    if (!this.database.TryUpdate(product.Sku, product, actualProduct))
                    {
                        throw new InvalidOperationException("Product not updated!");
                    }
                }
                else
                {
                    throw new ProductNotFoundException();
                }
            });
        }

        public async Task Delete(int sku)
        {
            await Task.Run(() =>
            {
                if (!this.database.TryRemove(sku, out _))
                {
                    throw new ProductNotFoundException();
                }
            });
        }
    }
}
