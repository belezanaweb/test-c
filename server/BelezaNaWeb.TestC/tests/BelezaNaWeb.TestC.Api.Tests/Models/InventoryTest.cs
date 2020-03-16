using BelezaNaWeb.TestC.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BelezaNaWeb.TestC.Api.Tests.Models
{
    public class InventoryTest
    {
        [Fact]
        public void Quantity_Success()
        {
            // Arrange
            var inventory = new Inventory
            {
                Warehouses = new List<Warehouse>
                {
                    new Warehouse { Quantity = 3 },
                    new Warehouse { Quantity = 7 },
                    new Warehouse { Quantity = 11 },
                }
            };

            // Assert
            Assert.Equal(21, inventory.Quantity);
        }
    }
}
