using Boticario.Backend.Modules.Products.Models;
using Boticario.Backend.Modules.Products.Repositories;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Tests.Mocks
{
    internal class ProductRepositoryMock : IProductRepository
    {
        public IProductEntity Database { get; set; }

        public async Task<IProductEntity> Get(int sku)
        {
            return await Task.Run(() =>
            {
                return this.Database;
            });
        }

        public async Task Insert(IProductEntity product)
        {
            await Task.Run(() =>
            {
                this.Database = product;
            });            
        }

        public async Task Update(IProductEntity product)
        {
            await Task.Run(() =>
            {
                this.Database = product;
            });
        }

        public async Task Delete(int sku)
        {
            await Task.Run(() =>
            {
                this.Database = null;
            });
        }
    }
}
