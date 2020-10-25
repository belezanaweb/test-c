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

        public Task Update(IProductEntity product)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int sku)
        {
            throw new System.NotImplementedException();
        }
    }
}
