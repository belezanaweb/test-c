using AutoFixture;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace UnitTests.Core
{
    public class ProductServiceGetData : ProductServiceTextFixture
    {

        [Fact]
        public void GetProductByExistingSku()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();
            product = service.InsertProduct(product);

            var savedProduct = service.GetProduct(product.Sku);

            Assert.Equal(product, savedProduct);

        }

        [Fact]
        public void GetProductNonExistingSku()
        {
            var fixture = new Fixture();
            var service = GetProductService();
            var sku = fixture.Create<int>();

            Assert.Null(service.GetProduct(sku));
        }


        [Fact]
        public void GetProductNotMarketable()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();

            product.Inventory = null;

            product = service.InsertProduct(product);
            var savedProduct = service.GetProduct(product.Sku);

            Assert.False(product.isMarketable);
            Assert.False(savedProduct.isMarketable);
        }

        [Fact]
        public void GetProductNotMarketableWithWarehouses()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();

            product.Inventory = new Inventory();

            var warehouses = fixture.CreateMany<Warehouse>(20);
            foreach (var warehouse in warehouses)
            {
                warehouse.Quantity = 0;
                product.Inventory.Warehouses.Add(warehouse);
            }

            product = service.InsertProduct(product);
            var savedProduct = service.GetProduct(product.Sku);

            Assert.False(product.isMarketable);
            Assert.False(savedProduct.isMarketable);
        }

        [Fact]
        public void GetProductIsMarketableTrue()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();


            var warehouses = fixture.CreateMany<Warehouse>(20);

            var random = new Random();

            foreach (var warehouse in warehouses)
            {
                warehouse.Quantity = random.Next(1, 10);
                product.Inventory.Warehouses.Add(warehouse);
            }


            product = service.InsertProduct(product);

            var savedProduct = service.GetProduct(product.Sku);

            Assert.True(product.isMarketable);
            Assert.True(savedProduct.isMarketable);
        }

        [Fact]
        public void GetProductInventoryQuantityZero()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();

            product.Inventory = new Inventory();

            var warehouses = fixture.CreateMany<Warehouse>(20);

            foreach (var warehouse in warehouses)
            {
                warehouse.Quantity = 0;
                product.Inventory.Warehouses.Add(warehouse);
            }

            product = service.InsertProduct(product);

            var savedProduct = service.GetProduct(product.Sku);


            Assert.True(product.Inventory.Quantity == 0);
            Assert.True(savedProduct.Inventory.Quantity == 0);
        }

        [Fact]
        public void GetProductInventoryQuantityNotZero()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();
            product.Inventory.Warehouses = new List<Warehouse>();

            var service = GetProductService();


            

            var warehouses = fixture.CreateMany<Warehouse>(20);


            var random = new Random();
            int sumQuantity = 0;
            foreach (var warehouse in warehouses)
            {
                warehouse.Quantity = random.Next(1, 10);
                sumQuantity += warehouse.Quantity;
                product.Inventory.Warehouses.Add(warehouse);
            }

            product = service.InsertProduct(product);

            var savedProduct = service.GetProduct(product.Sku);

            Assert.True(product.Inventory.Quantity > 0);
            Assert.True(savedProduct.Inventory.Quantity > 0);

            Assert.Equal(savedProduct.Inventory.Quantity, sumQuantity);
        }
    }
}
