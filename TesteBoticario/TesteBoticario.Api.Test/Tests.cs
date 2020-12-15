using NUnit.Framework;
using System.Collections.Generic;
using TesteBoticario.Api.Controllers;
using TesteBoticario.Application;
using TesteBoticario.Domain.Dto;
using TesteBoticario.Repository.Memory;

namespace TesteBoticario.Api.Test
{
    public class Tests
    {
        public Product Product { get; set; }

        [SetUp]
        public void Setup()
        {
            Product = new Product() { Name = "L'Oréal Professionnel Expert AbsolutRepairCortexLipidium - Máscara de Reconstrução 500g", Sku = 43264, Inventory = new Inventory() };
        }

        [Test]
        public void VerifyProductWithStockIsMarketable()
        {
            Product.Inventory.Warehouses = new List<Warehouse>
                                            {
                                                new Warehouse() { Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                new Warehouse() { Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }
                                            };

            Assert.IsTrue(Product.IsMarketable);
        }
    }
}