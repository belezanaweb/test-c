using BelezaNaWeb.Api.Controllers;
using BelezaNaWeb.Api.Model;
using BelezaNaWeb.Application;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Infra.Data.Repository;
using BelezaNaWeb.Test.Builders;
using Bogus;
using ExpectedObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace BelezaNaWeb.Test.Services
{
    public class ProductTest : IDisposable
    {
        Faker faker;

        private readonly ProductController _productController;
        private readonly ITestOutputHelper _output;

        private readonly int _sku;
        private readonly string _name;
        private readonly InventoryModel _inventory;
        private readonly InventoryModel _inventoryWithQuantityInvalid;
        private readonly bool _isMarketable;

        public ProductTest(ITestOutputHelper output)
        {
            faker = new Faker();

            _output = output;
            _output.WriteLine("Executing constructor!");

            _sku = 77;
            _name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";
                
            _inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                    new WarehouseModel
                    {
                        Locality = "MOEMA",
                        Quantity= 3,
                        Type = "PHYSICAL_STORE"
                    },
                    
                }
            };

            _inventoryWithQuantityInvalid = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 0,
                        Type = "ECOMMERCE"
                    },
                    new WarehouseModel
                    {
                        Locality = "MOEMA",
                        Quantity= 0,
                        Type = "PHYSICAL_STORE"
                    },

                }
            };

            var productRepository = new ProductRepository();
            var productApplication = new ProductApp(productRepository);
            _productController = new ProductController(productApplication);

            _output.WriteLine($"Product fake data: {faker.Company.CompanyName()}");
        }

        public void Dispose()
        {
            _output.WriteLine("Executing Dispose!");
        }

        [Fact]
        public void MustGetAllProducts()
        {
            var actual = (_productController.GetAllProducts().Result as OkObjectResult).StatusCode;
            var expected = new OkResult().StatusCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MustCreateProduct()
        {
            //Arrange
            var product = ProductServiceBuilder.newProduct()
                .WithSku(001)
                .WithName(_name)
                .Marketable(_inventory)
                .Build();
            
            //Act
            var act = (_productController.Post(product) as OkObjectResult).StatusCode;
            var exp = new OkResult().StatusCode;

            //Assert
            Assert.Equal(exp, act);
        }

        [Fact]
        public void MustGetProductBySkuNumber()
        {
            //Arrange
            var product = ProductServiceBuilder.newProduct()
                .WithSku(_sku)
                .WithName(_name)
                .Marketable(_inventory)
                .Build();
            _productController.Post(product);

            //Act
            var act = (_productController.Get(_sku).Result as OkObjectResult).Value as Product;
            
            //Assert
            product.ToExpectedObject().Matches(act);
            Assert.Equal(15, act.Inventory.Quantity);
            Assert.True(act.IsMarketable);
        }

        [Fact]
        public void MustUpdateProduct()
        {
            //Arrange
            var product = ProductServiceBuilder.newProduct()
                .WithSku(_sku)
                .WithName(_name)
                .Marketable(_inventory)
                .Build();
            _productController.Post(product);
            
            product.Name = faker.Random.Word();

            var act = (_productController.Update(product) as OkObjectResult).StatusCode;
            var exp = new OkResult().StatusCode;

            Assert.Equal(exp, act);
        }

        [Fact]
        public void MustDeleteProduct()
        {
            //Arrange
            var product = ProductServiceBuilder.newProduct()
                .WithSku(_sku)
                .WithName(_name)
                .Marketable(_inventory)
                .Build();
            _productController.Post(product);

            var act = (_productController.Delete(_sku) as OkObjectResult).StatusCode;
            var exp = new OkResult().StatusCode;

            Assert.Equal(exp, act);
        }

        [Fact]
        public void GetProductBySku_UsingInventoryWithoutQuantity()
        {
            var product = ProductServiceBuilder.newProduct()
                .WithSku(100)
                .WithName(_name)
                .WithInventoryWithoutQuantity(_inventoryWithQuantityInvalid)
                .Build();
            _productController.Post(product);

            var act = (_productController.Get(product.Sku).Result as OkObjectResult).Value as Product;

            Assert.Equal(0, act.Inventory.Quantity);
            Assert.False(act.IsMarketable);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MustNotGetProduct_UsinginvalidSku(int sku)
        {
            var act = (_productController.Get(sku).Result as BadRequestObjectResult).StatusCode;
            var exp = new BadRequestResult().StatusCode;

            Assert.Equal(exp, act);
        }

        [Fact]
        public void CreateProductWithTheSameSku()
        {
            var product = ProductServiceBuilder.newProduct()
                .WithSku(_sku)
                .WithName(_name)
                .Marketable(_inventory)
                .Build();
            _productController.Post(product);

            var act = (_productController.Post(product) as BadRequestObjectResult).StatusCode;
            var exp = new BadRequestResult().StatusCode;
            
            Assert.Equal(exp, act);
        }

        [Fact]
        public void MustNotCreateProduct_WithoutSku()
        {
            var product = ProductServiceBuilder.newProduct()
                .WithName(_name)
                .WithInventoryWithoutQuantity(_inventoryWithQuantityInvalid)
                .Build();
            _productController.Post(product);

            var act = (_productController.Post(product) as BadRequestObjectResult).StatusCode;
            var exp = new BadRequestResult().StatusCode;

            Assert.Equal(exp, act);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MustNotUpdateProduct_UsingInvalidSku(int invalidSku)
        {
            var product = ProductServiceBuilder.newProduct()
                .WithSku(invalidSku)
                .WithName(_name)
                .Marketable(_inventory)
                .Build();
            _productController.Post(product);

            var act = (_productController.Update(product) as BadRequestObjectResult).StatusCode;
            var exp = new BadRequestResult().StatusCode;

            Assert.Equal(exp, act);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MustNotDeleteProduct_UsingInvalidSku(int invalidSku)
        {
            var act = (_productController.Delete(invalidSku) as BadRequestObjectResult).StatusCode;
            var exp = new BadRequestResult().StatusCode;

            Assert.Equal(exp, act);
        }

        
    }
}
