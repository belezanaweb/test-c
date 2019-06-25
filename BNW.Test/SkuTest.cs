using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BNW.Test
{
    [TestClass]
    public class SkuTest
    {
        Product product1 = new Product
        {
            sku = 1,
            name = "Produto 1",
            inventory = new Inventory
            {
                warehouses = new List<Warehouse> {
                            new Warehouse { locality = "SP", quantity = 12, type = "ECOMMERCE" },
                            new Warehouse { locality = "MOEMA", quantity = 3, type = "PHYSICAL_STORE" }
                        }
            }
        };

        Product product2 = new Product
        {
            sku = 1,
            name = "Produto sdf1",
            inventory = new Inventory
            {
                warehouses = new List<Warehouse> {
                            new Warehouse { locality = "SP", quantity = 12, type = "ECOMMERCE" },
                            new Warehouse { locality = "MOEMA", quantity = 3, type = "PHYSICAL_STORE" }
                        }
            }
        };

        [TestMethod]
        public void RetornarErroQuandoInserirSkuDuplicado()
        {
        }
    }
}
