using DataAccess.DatabaseContext;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Tests.Builder;
using Xunit;

namespace WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for controller ProductsController
    /// </summary>
    public class ProductsControllerTests : TestBase
    {
        #region Default Tests

        /// <summary>
        /// Test a get a products
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Get_Products()
        {
            using (var context = new BelezaWebContext(DatabaseOptions))
            {
                //arrange         
                var product = BuilderProduct.BuildProduct(context, out int idItem);
                var product2 = BuilderProduct.BuildProduct(context, out int idItem2);
                var mockRepo = new ProductService(context);
                var controller = new ProductsController(mockRepo);

                // Act
                var result = await controller.Get();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnSession = Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(okResult.Value);
                Assert.True(returnSession.Count() == 2);

                //Clean database
                context.Database.EnsureDeleted();
            }
        }

        /// <summary>
        /// Test a get a product
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Get_Product()
        {
            using (var context = new BelezaWebContext(DatabaseOptions))
            {
                //arrange         
                var product = BuilderProduct.BuildProduct(context, out int idItem);
                var mockRepo = new ProductService(context);
                var controller = new ProductsController(mockRepo);

                // Act
                var result = await controller.Get(product.Sku);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnSession = Assert.IsAssignableFrom<ProductDTO>(okResult.Value);
                Assert.True(returnSession.Sku == product.Sku);

                //Clean database
                context.Database.EnsureDeleted();
            }
        }

        /// <summary>
        /// Test a post a product
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Post_Product()
        {
            using (var context = new BelezaWebContext(DatabaseOptions))
            {
                //arrange         
                var product = BuilderProduct.BuildProductDTO(context, out int idItem, false);
                var mockRepo = new ProductService(context);
                var controller = new ProductsController(mockRepo);

                // Act
                var result = await controller.Post(product);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnSession = Assert.IsAssignableFrom<ProductDTO>(okResult.Value);
                Assert.True(returnSession != null);

                //Clean database
                context.Database.EnsureDeleted();
            }
        }

        #endregion
    }
}
