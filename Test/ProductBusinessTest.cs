using Business;
using Business.Entity;
using Business.ViewModel;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductTests
{
    public class ProductTests
    {
        private ApiContext _context;
        private ProductBusiness _productBusiness;
        private readonly string productNotFound = "Produto Não Encontrado";
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "boticatiotest")
                .Options;

            _context = new ApiContext(options);
            _productBusiness = new ProductBusiness(_context);
        }

        [Test]
        public async Task AddProduct_CorrectEntry_WillAdd()
        {
            var result = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 123,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            });


            Assert.IsNotNull(result);
        }


        [Test]
        public async Task AddProduct_DuplicateEntry_WillNotAdd()
        {
            var firstProduct = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 1234,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            });

            ArgumentException result = Assert.ThrowsAsync<ArgumentException>(async () => await _productBusiness.Add(new ProductViewModel
            {
                SKU = 1234,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            }));

            Assert.AreEqual(result.Message, "Dois produtos são considerados iguais se os seus skus forem iguais");

        }

        [Test]
        public async Task GetProduct_CheckQuantity()
        {
            var product1 = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 12345,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse> {
                        new Warehouse { Locality = "PE", Quantity = 5, Type = "ECOMMERCE" } ,
                        new Warehouse { Locality = "SP", Quantity = 3, Type = "WEBLOJA" } ,
                    }
                }
            });

            var result = await _productBusiness.GetBySKU(12345);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Inventory.Quantity, 8);
        }

        [Test]
        public async Task GetProduct_CheckIsMarketable_True()
        {
            var product1 = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 123456,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse> {
                        new Warehouse { Locality = "PE", Quantity = 5, Type = "ECOMMERCE" } ,
                        new Warehouse { Locality = "SP", Quantity = 3, Type = "WEBLOJA" } ,
                    }
                }
            });

            var result = await _productBusiness.GetBySKU(123456);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.isMarketable, true);
        }

        [Test]
        public async Task GetProduct_CheckIsMarketable_False()
        {
            var product1 = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 1234567,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse> {
                        new Warehouse { Locality = "PE", Quantity = 0, Type = "ECOMMERCE" } ,
                        new Warehouse { Locality = "SP", Quantity = 0, Type = "WEBLOJA" } ,
                    }
                }
            });

            var result = await _productBusiness.GetBySKU(1234567);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.isMarketable, false);
        }

        [Test]
        public async Task UpdateProduct_WillUpdate()
        {
            var product1 = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 3219,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            });

            var result = await _productBusiness.Update(new ProductViewModel
            {
                SKU = 3219,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse> {
                        new Warehouse { Locality = "PE", Quantity = 5, Type = "ECOMMERCE" } ,
                        new Warehouse { Locality = "SP", Quantity = 3, Type = "WEBLOJA" } ,
                    }
                }
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Inventory.Warehouses.Count, 2);
        }

        [Test]
        public async Task UpdateProduct_ProductNotFound()
        {
            var product1 = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 321,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            });

            ArgumentException result = Assert.ThrowsAsync<ArgumentException>(async () => await _productBusiness.Update(new ProductViewModel
            {
                SKU = 3021,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            }));

            Assert.AreEqual(result.Message, productNotFound);
        }


        [Test]
        public async Task GetProduct_ProductFound()
        {
            var product1 = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 9,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            });

            var result = await _productBusiness.GetBySKU(9);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, product1.Name);
        }

        [Test]
        public async Task RemoveProduct()
        {
            var product1 = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 98,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            });

            await _productBusiness.Remove(9);

            ArgumentException result = Assert.ThrowsAsync<ArgumentException>(async () => await _productBusiness.GetBySKU(9));

            Assert.AreEqual(result.Message, productNotFound);
        }

        [Test]
        public void RemoveProduct_NotFound()
        {

            ArgumentException result = Assert.ThrowsAsync<ArgumentException>(async () => await _productBusiness.GetBySKU(99));

            Assert.AreEqual(result.Message, productNotFound);
        }

        [Test]
        public async Task GetProduct_ProductNotFound()
        {
            var product1 = await _productBusiness.Add(new ProductViewModel
            {
                SKU = 900,
                Name = "Teste",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>()
                }
            });

            ArgumentException result = Assert.ThrowsAsync<ArgumentException>(async () => await _productBusiness.GetBySKU(9999));

            Assert.AreEqual(result.Message, productNotFound);
        }
    }
}