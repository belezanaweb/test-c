using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrupoBoticario.API.Services.Services;
using GrupoBoticario.API.Models;
using System.Collections.Generic;
using GrupoBoticario.API.Data.Repositories.Repository;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using GrupoBoticario.API.Data;

namespace GrupoBoticario.Testes
{
    [TestClass]
    public class UnitTest1
    {               

        [TestMethod]
        [TestCategory("Produtos")]
        public void IsMarketableTrue()
        {
            var produto = new Produtos
            {
                Id = 1,
                Sku = 43264,
                Nome = "Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    Sku = 43264,
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse() { Id =1, Sku = 43265, Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                        new Warehouse() { Id =2, Sku = 43265, Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }
                    }
                }
            };

            Assert.AreEqual(true, produto.IsMarketable);
        }

        [TestMethod]
        [TestCategory("Produtos")]
        public void IsMarketableFalse()
        {
            var product = new Produtos
            {
                Id = 1,
                Sku = 43264,
                Nome = "Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    Sku = 43264,
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse() { Id =1, Sku = 43265, Locality = "SP", Quantity = 0, Type = "ECOMMERCE" },
                        new Warehouse() { Id =2, Sku = 43265, Locality = "MOEMA", Quantity = 0, Type = "PHYSICAL_STORE" }
                    }
                }
            };

            Assert.AreEqual(false, product.IsMarketable);
        }

        [TestMethod]
        [TestCategory("Produtos")]
        public void CalcularQuantityInvetary()
        {
            var product = new Produtos
            {
                Id = 1,
                Sku = 43264,
                Nome = "Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    Sku = 43264,
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse() { Id =1, Sku = 43265, Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                        new Warehouse() { Id =2, Sku = 43265, Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }
                    }
                }
            };

            Assert.AreEqual(15, product.Inventory.Quantity);
        }

    }
}
