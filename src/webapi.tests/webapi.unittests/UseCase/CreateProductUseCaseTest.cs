using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.application.Models;
using webapi.application.Models.Comum;
using webapi.application.UseCases;
using webapi.domain.Entities;
using webapi.infrastructure;
using webapi.infrastructure.DataProviders.Repositories;
using webapi.unittests.Mock;
using Xunit;

namespace webapi.unittests.UseCase
{
    public class CreateProductUseCaseTest
    {
        private static IMapper _mapper;
        public CreateProductUseCaseTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductRequest>();
                    cfg.CreateMap<ProductRequest, Product>();

                    cfg.CreateMap<Product, ProductResponse>();
                    cfg.CreateMap<ProductResponse, Product>();


                    cfg.CreateMap<Inventory, InventoryRequest>();
                    cfg.CreateMap<InventoryRequest, Inventory>();

                    cfg.CreateMap<Inventory, InventoryResponse>();
                    cfg.CreateMap<InventoryResponse, Inventory>();

                    cfg.CreateMap<Warehouse, WarehouseModel>();
                    cfg.CreateMap<WarehouseModel, Warehouse>();


                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void CreateProductInexistente()
        {

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var _productRepository = new ProductRepositoryMock(memoryCache);
            var _UseCaseCreateProduct = new CreateProductUseCase(_productRepository, _mapper);

            var CreateProductResponse = new CreateProductRequest()
            {
                sku = 1234,
                name = "TESTE NOME 1",
                inventory = new InventoryResponse()
                {
                    warehouses = new List<WarehouseModel>
                    {
                        new WarehouseModel() {
                            locality = "TESTE", quantity = 2, type = "TESTE"
                        }
                    }
                }
            };
            var response = _UseCaseCreateProduct.Execute(CreateProductResponse).Result;

            Assert.True(response.IsValid);
        }


        [Fact]
        public void CreateProductExistente()
        {

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var _productRepository = new ProductRepositoryMock(memoryCache);
            var _UseCaseCreateProduct = new CreateProductUseCase(_productRepository, _mapper);

            var CreateProductResponse = new CreateProductRequest()
            {
                sku = 1234,
                name = "TESTE NOME 1",
                inventory = new InventoryResponse()
                {
                    warehouses = new List<WarehouseModel>
                    {
                        new WarehouseModel() {
                            locality = "TESTE", quantity = 2, type = "TESTE"
                        }
                    }
                }
            };
            _UseCaseCreateProduct.Execute(CreateProductResponse);
            var response = _UseCaseCreateProduct.Execute(CreateProductResponse).Result;
            string msgErroProdutoExistente = "Dois produtos são considerados iguais se os seus skus forem iguais";
            Assert.Equal(msgErroProdutoExistente, response.ErrorMessage);
        }


        [Fact]
        public void CreateProductFalha()
        {

            MemoryCache memoryCache = null;
            var _productRepository = new ProductRepositoryMock(memoryCache);
            var _UseCaseCreateProduct = new CreateProductUseCase(_productRepository, _mapper);

            var CreateProductResponse = new CreateProductRequest()
            {
                sku = 1234,
                name = "TESTE NOME 1",
                inventory = new InventoryResponse()
                {
                    warehouses = new List<WarehouseModel>
                    {
                        new WarehouseModel() {
                            locality = "TESTE", quantity = 2, type = "TESTE"
                        }
                    }
                }
            };
            _UseCaseCreateProduct.Execute(CreateProductResponse);
            var response = _UseCaseCreateProduct.Execute(CreateProductResponse).Result;         
            Assert.False(response.IsValid);
        }



    }
}
