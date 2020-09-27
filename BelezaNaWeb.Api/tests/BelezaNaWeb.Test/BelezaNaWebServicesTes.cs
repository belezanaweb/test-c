using System.Linq;
using BelezaNaWeb.Core.Model;
using BelezaNaWeb.Core.Repositories;
using BelezaNaWeb.Services.Services;
using GenFu;
using Moq;
using Shouldly;
using Xunit;
using static GenFu.GenFu;

namespace BelezaNaWeb.Test
{
    public class BelezaNaWebServicesTes
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly ProductService _productServices;

        public BelezaNaWebServicesTes()
        {
            _productServices = new ProductService(_productRepositoryMock.Object);
        }



        [Fact]
        public void Add_CreateProduct_ExpectCreateProduct()
        {
           // Arrange
            var warehouses = A.ListOf<Warehouse>(3);
            var inventory = New<Inventory>();
            inventory.Warehouses = warehouses;
            var product = new Product {Inventory = inventory};
            _productRepositoryMock.Setup(p => p.Add(It.IsAny<Product>())).Returns(product);

            //Act
            var result = _productServices.Add(product);

            //Assert
            result.ShouldBeOfType<Product>();
            result.Inventory.Quantity.ShouldBeGreaterThan(0);
            result.IsMarketable.ShouldBe(true);

        }
    }
}

