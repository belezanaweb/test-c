using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.domain.Entities;
using webapi.domain.Gateways;

namespace webapi.unittests.Mock
{
    public class ProductRepositoryMock : IProductGateway
    {
        private IMemoryCache _memoryCache { get; set; }

        public ProductRepositoryMock(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task Delete(int key)
        {
            _memoryCache.Remove(key);
            return Task.CompletedTask;
        }

        public Task<Product> Get(int key)
        {
            return Task.FromResult(_memoryCache.Get<Product>(key));
        }


        public Task Insert(Product entity)
        {
            _memoryCache.Set(entity.sku, entity);
            return Task.CompletedTask;
        }

        public Task Update(Product entity)
        {

            _memoryCache.Set(entity.sku, entity);
            return Task.CompletedTask;
        }
    }
}
