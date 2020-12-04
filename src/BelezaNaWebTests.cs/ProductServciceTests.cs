using BelezaNaWeb.Data.Models;
using BelezaNaWeb.Data.Repositories.Interfaces;
using BelezaNaWeb.Services.Interfaces;
using BelezaNaWeb.Services.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BelezaNaWebTests.cs
{
    public class ProductServciceTests
    {
        Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();

        IProductService _service;

        public ProductServciceTests()
        {
            _service = new ProductService(_productRepository.Object);
        }

        [Fact]
        public void InsertProduct_Sucess()
        {
            var products = GetProducts();
            _productRepository.Setup(x => x.Select(It.IsAny<int>())).Returns((int sku) => products.SingleOrDefault(o => o.Sku == sku));
            _productRepository.Setup(x => x.Insert(It.IsAny<Product>()));

            var product = new Product()
            {
                Sku = 43265,
                Name = "Produto 2",
                Inventory = new Inventory()
                {
                    WareHouses = new List<WareHouse>() {
                                                             new WareHouse() { Id =1, InventoryId = 1, Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouse() { Id =2, InventoryId = 1, Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                }
            };

            _service.Insert(product);

            _productRepository.Verify(x => x.Insert(product), Times.Once);
        }

        [Fact]
        public void InsertProduct_Fail()
        {
            var products = GetProducts();
            _productRepository.Setup(x => x.Select(It.IsAny<int>())).Returns((int sku) => products.SingleOrDefault(o => o.Sku == sku));
            _productRepository.Setup(x => x.Insert(It.IsAny<Product>()));

            var product = new Product()
            {
                Sku = 43264,
                Name = "Produto 2",
                Inventory = new Inventory()
                {
                    WareHouses = new List<WareHouse>() {
                                                             new WareHouse() { Id =1, InventoryId = 1, Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouse() { Id =2, InventoryId = 1, Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                }
            };

            Action action = () => { _service.Insert(product); };

            action.Should().Throw<Exception>().WithMessage($"O produto de SKU {product.Sku} já existe na base.");    
            _productRepository.Verify(x => x.Insert(product), Times.Never);
        }

        [Fact]
        public void UpdateProduct_Sucess()
        {
            var products = GetProducts();
            _productRepository.Setup(x => x.Select(It.IsAny<int>())).Returns((int sku) => products.SingleOrDefault(o => o.Sku == sku));
            _productRepository.Setup(x => x.Update(It.IsAny<Product>()));

            var product = new Product()
            {
                Sku = 43264,
                Name = "Produto 2",
                Inventory = new Inventory()
                {
                    WareHouses = new List<WareHouse>() {
                                                             new WareHouse() { Id =1, InventoryId = 1, Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouse() { Id =2, InventoryId = 1, Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                }
            };

            _service.Update(product.Sku, product);
            _productRepository.Verify(x => x.Update(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void UpdateProduct_Fail()
        {
            var products = GetProducts();
            _productRepository.Setup(x => x.Select(It.IsAny<int>())).Returns((int sku) => products.SingleOrDefault(o => o.Sku == sku));
            _productRepository.Setup(x => x.Update(It.IsAny<Product>()));

            var product = new Product()
            {
                Sku = 43265,
                Name = "Produto 2",
                Inventory = new Inventory()
                {
                    WareHouses = new List<WareHouse>() {
                                                             new WareHouse() { Id =1, InventoryId = 1, Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouse() { Id =2, InventoryId = 1, Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                }
            };

            Action action = () => { _service.Update(product.Sku, product); };

            action.Should().Throw<Exception>().WithMessage($"O produto de SKU {product.Sku} não foi encontrado.");
            _productRepository.Verify(x => x.Update(product), Times.Never);
        }

        [Fact]
        public void DeleteProduct_Sucess()
        {
            var sku = 43264;
            var products = GetProducts();
            _productRepository.Setup(x => x.Select(It.IsAny<int>())).Returns((int sku) => products.SingleOrDefault(o => o.Sku == sku));
            _productRepository.Setup(x => x.Delete(It.IsAny<int>()));      

            _service.Delete(sku);
            _productRepository.Verify(x => x.Delete(sku), Times.Once);
        }

        [Fact]
        public void DeleteProduct_Fail()
        {
            var sku = 43265;
            var products = GetProducts();
            _productRepository.Setup(x => x.Select(It.IsAny<int>())).Returns((int sku) => products.SingleOrDefault(o => o.Sku == sku));
            _productRepository.Setup(x => x.Delete(It.IsAny<int>()));


            Action action = () => { _service.Delete(sku); };

            action.Should().Throw<Exception>().WithMessage($"O produto de SKU {sku} não foi encontrado.");
            _productRepository.Verify(x => x.Delete(sku), Times.Never);
        }

        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Sku = 43264,
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Inventory = new Inventory()
                    {
                        Id = 1,
                        ProductId = 1,
                        WareHouses = new List<WareHouse>() { 
                                                             new WareHouse() { Id =1, InventoryId = 1, Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouse() { Id =2, InventoryId = 1, Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                    }
                }
            };
        }
    }
}
