using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BW.Application.Repository.Product;
using BW.Domain;

namespace BW.Application.UseCases.Product
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepositoryReadOnlyRepository _productReadOnlyRepository;
        private readonly IProductRepositoryrWriteOnlyRepository _productWriteOnlyRepository;

        public ProductUseCase(
            IProductRepositoryReadOnlyRepository productReadOnlyRepository,
            IProductRepositoryrWriteOnlyRepository productWriteOnlyRepository
            )
        {
            _productReadOnlyRepository = productReadOnlyRepository;
            _productWriteOnlyRepository = productWriteOnlyRepository;
        }

        public async Task Add(ProductDomain product)
        {
            CheckIfProductExists(product.Sku);


            await _productWriteOnlyRepository.Add(product);

        }

        public async Task Delete(int sku)
        {
            CheckIfProductNotExists(sku);
            await _productWriteOnlyRepository.Delete(sku);
        }

        public async Task<ProductDomain> Get(int sku)
        {
            ProductDomain product = await _productReadOnlyRepository.Get(sku);

            if (product == null)
            {
                throw new DomainException("Sku não foi encontrado.");
            }           
            
            if (product.Inventory!=null)
            {
                if (product.Inventory.Warehouses.Any()) {
                    product.Inventory.Quantity = product.Inventory.Warehouses.Sum(x => x.Quantity);
                    if (product.Inventory.Quantity > 0)
                    {
                        product.IsMarketable = true;
                    }
                    else
                    {
                        product.IsMarketable = false;
                    }
                }                
            }
            

            return product;
        }

        public async Task Update(ProductDomain product)
        {
            await Get(product.Sku);

            await _productWriteOnlyRepository.Update(product);
        }

        private void CheckIfProductExists(int sku)
        {
            var productExists = _productReadOnlyRepository.Get(sku).Result;
            if (productExists != null)
            {
                throw new DomainException($"SKU {sku} existe no sistema cadastrado.");
            }
        }
        private void CheckIfProductNotExists(int sku)
        {
            var productExists = _productReadOnlyRepository.Get(sku).Result;
            if (productExists == null)
            {
                throw new DomainException($"SKU {sku} nao existe no sistema cadastrado.");
            }
        }

    }
}
