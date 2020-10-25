using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Inventory.Services;
using Boticario.Backend.Modules.Products.Dto;
using Boticario.Backend.Modules.Products.Factories;
using Boticario.Backend.Modules.Products.Models;
using Boticario.Backend.Modules.Products.Repositories;
using Boticario.Backend.Modules.Products.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Implementation.Services
{
    public class DefaultProductServices : IProductServices
    {
        private readonly IProductRepository productRepository;
        private readonly IInventoryServices inventoryServices;
        private readonly IProductFactory productFactory;

        public DefaultProductServices(IProductRepository productRepository, IInventoryServices inventoryServices, IProductFactory productFactory)
        {
            this.productRepository = productRepository;
            this.inventoryServices = inventoryServices;
            this.productFactory = productFactory;
        }

        public async Task<IProductDetails> Get(int sku)
        {
            IProductEntity productEntity = await this.productRepository.Get(sku);

            if (productEntity == null)
            {
                return null;
            }

            IList<IInventoryEntity> inventories = await this.inventoryServices.GetAll(sku);

            return this.productFactory.CreateProductDetails(productEntity, inventories);
        }

        public Task Create(ProductOperationDto product)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductOperationDto product)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int sku)
        {
            throw new NotImplementedException();
        }
    }
}
