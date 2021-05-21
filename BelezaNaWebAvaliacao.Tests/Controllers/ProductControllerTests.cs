using BelezaNaWebAvaliacao.DataAccess;
using BelezaNaWebAvaliacao.Product.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using models = BelezaNaWebAvaliacao.Models;

namespace BelezaNaWebAvaliacao.Tests.Controllers
{
    public class ProductControllerTests
    {

        public DbContextOptions<DataContext> dbConnOptions =
                new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

        private ProductController productController;

        [Fact]
        private async Task PostProduct_Ok()
        {

            using (DataContext context = new DataContext(dbConnOptions))
            {
                productController = new ProductController(context);
                //Add a new product
                var product = makeNewProcuctTest(43264);

                var result = await productController.Post(context, product);
                var okResult = Assert.IsType<OkObjectResult>(result);
                var retResult = Assert.IsType<string>(okResult.Value);
                Assert.Equal("Ação realizada com sucesso!", retResult);
            }

        }

        [Fact]
        private async Task PostProduct_BadRequest_ProductAlreadyExisting()
        {

            using (DataContext context = new DataContext(dbConnOptions))
            {
                productController = new ProductController(context);
                //Load a product model
                var product = makeNewProcuctTest(43264);

                await productController.Post(context, product);

                var result = await productController.Post(context, product);
                var badResult = Assert.IsType<BadRequestObjectResult>(result);
                var retResult = Assert.IsType<string>(badResult.Value);
                Assert.Equal("Já existe produto com o sku informado!", retResult);
            }

        }

        [Fact]
        private async Task GetProduct_Ok()
        {

            using (DataContext context = new DataContext(dbConnOptions))
            {

                var skuAdd = await AddProduct(context);

                productController = new ProductController(context);

                //Consulta o produto adicionado
                var result = await productController.Get(context, skuAdd);
                var okResult = Assert.IsType<OkObjectResult>(result);
                var producResult = Assert.IsType<models.Product>(okResult.Value);
                Assert.Equal(skuAdd, producResult.Sku);

            }

        }

        [Fact]
        private async Task GetProduct_Verify_Inventory_Quantity()
        {

            using (DataContext context = new DataContext(dbConnOptions))
            {


                productController = new ProductController(context);

                var product = makeNewProcuctTest(43264);

                await productController.Post(context, product);

                //Consulta o produto adicionado
                var result = await productController.Get(context, product.Sku);
                var okResult = Assert.IsType<OkObjectResult>(result);
                var producResult = Assert.IsType<models.Product>(okResult.Value);

                var sumQuantity = 0;
                foreach (var item in producResult.Inventory.Warehouses)
                {
                    sumQuantity += item.quantity;
                }

                Assert.Equal(sumQuantity, producResult.Inventory.Quantity);

            }

        }

        [Fact]
        private async Task GetProduct_Verify_isMarketable()
        {

            using (DataContext context = new DataContext(dbConnOptions))
            {

                productController = new ProductController(context);

                var product = makeNewProcuctTest(43264);

                await productController.Post(context, product);

                //Consulta o produto adicionado
                var result = await productController.Get(context, product.Sku);
                var okResult = Assert.IsType<OkObjectResult>(result);
                var producResult = Assert.IsType<models.Product>(okResult.Value);

                Assert.Equal(producResult.Inventory.Quantity > 0, producResult.isMarketable);

            }

        }

        [Fact]
        private async Task GetProduct_BadRequest()
        {

            using (DataContext context = new DataContext(dbConnOptions))
            {

                var skuAdd = await AddProduct(context);

                productController = new ProductController(context);

                //Consulta o produto adicionado por um código diferente do cadastrado sku + 1
                var result = await productController.Get(context, skuAdd + 1);
                var badResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Null(badResult.Value);

            }

        }


        private async Task<int> AddProduct(DataContext context)
        {
            Random numRand = new Random();
            var skuRandom = numRand.Next(1, 99999);

            productController = new ProductController(context);
            //Add a new product
            var product = makeNewProcuctTest(43265);

            product.Sku = skuRandom;

            await productController.Post(context, product);

            return skuRandom;

        }

        private models.Product makeNewProcuctTest(int sku)
        {

            var product = new models.Product()
            {
                Sku = sku,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new models.Inventory()
                {
                }
            };

            var listWarehouses = new List<models.Warehouse>();

            listWarehouses.Add(
                new models.Warehouse()
                {
                    locality = "MOOCA",
                    quantity = 12,
                    type = "ECOMMERCE"
                }
            );

            listWarehouses.Add(
                new models.Warehouse()
                {
                    locality = "MOOCA",
                    quantity = 12,
                    type = "ECOMMERCE"
                }

            );

            product.Inventory.Warehouses = listWarehouses;

            return product;

        }
    }
}
