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
            IProductEntity productEntity = null;
            IList<IInventoryEntity> inventories = null;

            Task[] tasks = new Task[]
            {
                Task.Run(async() =>
                {
                    productEntity = await this.productRepository.Get(sku);
                }),
                Task.Run(async() =>
                {
                    inventories = await this.inventoryServices.GetAll(sku);
                }),
            };

            await Task.WhenAll(tasks);

            if (productEntity == null)
            {
                return null;
            }            

            return this.productFactory.CreateProductDetails(productEntity, inventories);
        }

        public async Task Create(ProductOperationDto product)
        {
            if (product == null)
            {
                throw new NullReferenceException("Product is Null!");
            }

            Task[] tasks = new Task[]
            {
                Task.Run(async() =>
                {
                    IProductEntity productEntity = this.productFactory.CreateEntity(product.Sku, product.Name);
                    await this.productRepository.Insert(productEntity);
                }),
                Task.Run(async() =>
                {
                    await this.inventoryServices.SaveAll(product.Sku, product.Inventory);
                }),
            };

            await Task.WhenAll(tasks);
        }

        public async Task Update(ProductOperationDto product)
        {
            if (product == null)
            {
                throw new NullReferenceException("Product is Null!");
            }

            Task[] tasks = new Task[]
            {
                Task.Run(async() =>
                {
                    IProductEntity productEntity = this.productFactory.CreateEntity(product.Sku, product.Name);
                    await this.productRepository.Update(productEntity);
                }),
                Task.Run(async() =>
                {
                    await this.inventoryServices.SaveAll(product.Sku, product.Inventory);
                }),
            };

            await Task.WhenAll(tasks);
        }

        public Task Delete(int sku)
        {
            throw new NotImplementedException();
        }
    }
}
