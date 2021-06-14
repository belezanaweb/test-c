using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBoticario.Domain.Entities;
using TesteBoticario.Storage.Interfaces;

namespace TesteBoticario.Storage
{
    public class ProductCache : IProductCache
    {
        private readonly IMemoryCache _cache;

        public ProductCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Product Get(int sku)
        {
            var result = _cache.Get<Product>(sku);

            return result;
        }

        public Product Insert(Product product)
        {
            if (product == null)
                throw new NullReferenceException();

            var result = _cache.Set(product.Sku, product);

            return result;
        }

        public Product Delete(int sku)
        {
            var result = Get(sku);
             _cache.Remove(sku);

            return result;
        }
    }
}
