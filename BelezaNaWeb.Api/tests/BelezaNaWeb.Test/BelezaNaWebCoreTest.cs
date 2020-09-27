using System.Collections.Generic;
using BelezaNaWeb.Core.Model;
using Shouldly;
using Xunit;

namespace BelezaNaWeb.Test
{
    public class BelezaNaWebCoreTest
    {
        [Fact]
        public void IsMarketable_GiveTwoProduct_ByQuantityZero_ExepctedSumquantity_EqualZero()
        {
            var product = new Product
            {
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>
                    {
                        new Warehouse
                        {
                            Quantity = 0
                        },
                        new Warehouse
                        {
                            Quantity = 0
                        }
                    }
                }
            };


            product.Inventory.Quantity.ShouldBe(0);
            product.IsMarketable.ShouldBe(false);
        }

        [Fact]
        public void IsMarketable_GiveTwoProduct_ByWithValues_ExepctedSumquantity_Positive()
        {
            var product = new Product
            {
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>
                    {
                        new Warehouse
                        {
                            Quantity = 15
                        },
                        new Warehouse
                        {
                            Quantity = 20
                        }
                    }
                }
            };

            product.Inventory.Quantity.ShouldBe(35);
            product.IsMarketable.ShouldBe(true);
        }

        [Fact]
        public void SumQuantity_GiveTwoProduct_ExepctedSumquantity()
        {
            var warehouses = new List<Warehouse>
            {
                new Warehouse {Quantity = 10}, new Warehouse {Quantity = 20}
            };

            var inventory = new Inventory {Warehouses = warehouses};
            inventory.Quantity.ShouldBe(30);
        }
    }
}