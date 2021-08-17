using NUnit.Framework;
using System;
using System.Collections.Generic;
using TesteVagaBoticario.Negocio;

namespace TesteVagaBoticario.Teste
{
    public class Tests
    {
        [Test]
        public void TestaIsMarketable()
        {
            var product = ObtenhaProduto();

            Assert.AreEqual(true, product.IsMarketable);
        }

        [Test]
        public void TestCalculatedQuantityInvetary()
        {
            var product = ObtenhaProduto();

            Assert.AreEqual(15, product.Inventory.Quantity);
        }

        private Product ObtenhaProduto()
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Sku = 43265,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    Id = Guid.NewGuid(),
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse() { Id =Guid.NewGuid(), Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                        new Warehouse() { Id =Guid.NewGuid(), Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }
                    }
                }
            };
        }
    }
}