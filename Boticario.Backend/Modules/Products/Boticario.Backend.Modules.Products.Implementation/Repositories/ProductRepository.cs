using Boticario.Backend.Data.DatabaseContext;
using Boticario.Backend.Modules.Products.Implementation.Exceptions;
using Boticario.Backend.Modules.Products.Models;
using Boticario.Backend.Modules.Products.Repositories;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabaseContext databaseContext;

        public ProductRepository(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IProductEntity> Get(int sku)
        {
            return await this.databaseContext.ExecuteReader(async (connection) =>
            {
                return await Task.Run(() =>
                {
                    if (connection.Database.Products.TryGetValue(sku, out IProductEntity product))
                    {
                        return product;
                    }
                    else
                    {
                        return null;
                    }
                });
            });
        }

        public async Task Insert(IProductEntity product)
        {
            await this.databaseContext.ExecuteWriter(async (connection) =>
            {
                await Task.Run(() =>
                {
                    if (!connection.Database.Products.TryAdd(product.Sku, product))
                    {
                        throw new ProductAlreadyExistsException();
                    }
                });
            });
        }

        public async Task Update(IProductEntity product)
        {
            await this.databaseContext.ExecuteWriter(async (connection) =>
            {
                await Task.Run(() =>
                {
                    if (connection.Database.Products.TryGetValue(product.Sku, out IProductEntity actualProduct))
                    {
                        if (!connection.Database.Products.TryUpdate(product.Sku, product, actualProduct))
                        {
                            throw new InvalidOperationException("Product not updated!");
                        }
                    }
                    else
                    {
                        throw new ProductNotFoundException();
                    }
                });
            });
        }

        public async Task Delete(int sku)
        {
            await this.databaseContext.ExecuteWriter(async (connection) =>
            {
                await Task.Run(() =>
                {
                    if (!connection.Database.Products.TryRemove(sku, out _))
                    {
                        throw new ProductNotFoundException();
                    }
                });
            });
        }
    }
}
