using System;
using System.Collections.Generic;
using System.Text;
using web_beauty.Models;
using Xunit;

namespace web_beauty_tests.Models
{
    public class ProductTest
    {
        private Product _productDummy;
        public void InitTest()
        {
            _productDummy = new Product()
            {
                Id = "5ee15aa59fb71e3d5c1f50a6",
                Sku = 123456,
                Name = "Product Dummy",
                Inventory = new Inventory()
                {
                    Quantity = null,
                    Warehouses = new List<Warehouse>()
                        {   new Warehouse() { Locality = "Local A" , Quantity = 10, Type = "ECOMMERCE"},
                            new Warehouse() { Locality = "Local A" , Quantity = 10, Type = "ECOMMERCE"}
                    }
                },
                IsMarketable = null
            };
        }

        [Fact]
        public void CalculateQuantityShouldBeTheSumOfWarehousesQuantity() {
            InitTest();

            _productDummy.CalculateQuantity();

            var expected = 0L;

            foreach (var item in _productDummy.Inventory.Warehouses)
            {
                expected += item.Quantity;
            }

            Assert.Equal(expected, _productDummy.Inventory.Quantity);
        }

        [Fact]
        public void SetIsMarketableIsMarketable()
        {
            InitTest();

            _productDummy.CalculateQuantity();
            _productDummy.SetIsMarketable();

            var expected = _productDummy.Inventory.Quantity > 0;

            Assert.Equal(expected, _productDummy.IsMarketable);
        }
    }
}
