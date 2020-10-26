using Boticario.Backend.Data.UnitOfWork;
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
        private readonly IUnitOfWork unitOfWork;

        public DefaultProductServices(IProductRepository productRepository, IInventoryServices inventoryServices, IProductFactory productFactory, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.inventoryServices = inventoryServices;
            this.productFactory = productFactory;
            this.unitOfWork = unitOfWork;
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

        public async Task Create(ProductOperationDto product)
        {
            if (product == null)
            {
                throw new NullReferenceException("Product is Null!");
            }

            await this.unitOfWork.Execute(async () =>
            {
                IProductEntity productEntity = this.productFactory.CreateEntity(product.Sku, product.Name);
                await this.productRepository.Insert(productEntity);

                await this.inventoryServices.SaveAll(product.Sku, product.Inventory);
            });
        }

        public async Task Update(ProductOperationDto product)
        {
            if (product == null)
            {
                throw new NullReferenceException("Product is Null!");
            }

            await this.unitOfWork.Execute(async () =>
            {
                IProductEntity productEntity = this.productFactory.CreateEntity(product.Sku, product.Name);
                await this.productRepository.Update(productEntity);

                await this.inventoryServices.SaveAll(product.Sku, product.Inventory);
            });
        }

        public async Task Delete(int sku)
        {
            await this.unitOfWork.Execute(async () =>
            {
                await this.productRepository.Delete(sku);

                await this.inventoryServices.DeleteAll(sku);
            });
        }
    }
}
