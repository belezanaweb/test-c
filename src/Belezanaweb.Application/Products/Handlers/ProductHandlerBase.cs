using Belezanaweb.Core.Exceptions;
using Belezanaweb.Domain.Products.Entity;
using Belezanaweb.Domain.Products.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belezanaweb.Application.Products.Handlers
{
    public abstract class ProductHandlerBase
    {
        protected readonly IProductRepository productRepository;

        public ProductHandlerBase(IProductRepository productRepository) 
        {
            this.productRepository = productRepository;
        }

        protected Product GetProductBySku(long sku)
        {
            Product existingProduct = productRepository.Get(sku);
            if (existingProduct == null)
                throw new BusinessException($"Produto com SKU {sku} não existe na base.");
            
            return existingProduct;
        }

        protected void CheckIfProductExists(long sku)
        {
            Product existingProduct = productRepository.Get(sku);
            if (existingProduct != null)
                throw new BusinessException($"Produto já existe para o Sku {sku}.");
        }


    }
}
