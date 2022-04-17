using System.Collections.Generic;
using System.Linq;
using BelezaNaWeb.Domain.Constants;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Repository;
using Xunit;

namespace BelezaNaWeb.Tests.UnitTests.Product
{
    public class ProductTest
    {
        private readonly ProductRepository _productRepository;
        private Domain.Entities.Product _product;

        public ProductTest()
        {
            _productRepository = new ProductRepository();
            
            var warehouse1 = new Warehouse { Locality = "SP", Quantity = 10, Type = WareHouseTypeConstants.ECOMMERCE };
            var warehouse2 = new Warehouse { Locality = "RJ", Quantity = 12, Type = WareHouseTypeConstants.PHYSICAL_STORE };
            _product = _productRepository.Create(new Domain.Entities.Product(new Inventory(new List<Warehouse> { warehouse1, warehouse2 })) { Name = "L'Oréal Professionnel Exp...", Sku = 43264 });
        }

        [Fact]
        public void Get_Product_By_Valid_Sku()
        {
            Assert.True(_productRepository.GetBySku(43264) is not null);
        }

        [Fact]
        public void Get_Product_By_Invalid_Sku()
        {
            Assert.False(_productRepository.GetBySku(33) is not null);
        }

        [Fact]
        public void Delete_Product_By_Valid_Sku_And_Verify_Deleted_Product()
        {
            _productRepository.DeleteBySku(43264);
            var product = _productRepository.GetBySku(43264);

            Assert.True(product is null);
        }

        [Fact]
        public void Verify_Inventory_Quantity_Is_Calculated_Correctly()
        {
            var product = _productRepository.GetBySku(43264);
            var inventoryQuantity = product.Inventory.Quantity;
            var wareHousesQuantity = product.Inventory.Warehouses.Sum(inventoryWarehouse => inventoryWarehouse.Quantity);

            Assert.Equal(inventoryQuantity, wareHousesQuantity);
        }
    }
}
