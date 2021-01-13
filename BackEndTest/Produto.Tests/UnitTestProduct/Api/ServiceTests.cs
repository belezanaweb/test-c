using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Produto.Domain.Models;
using Produto.Domain.Notifications;
using Produto.Domain.Repositories;
using Produto.Domain.Services;
using Produto.Infra.Contexts;
using Produto.Infra.Repository;
using Produto.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingServices
{
    [TestClass]
    public class ServiceTests
    {
        private DbContextOptions<ProductDBContext> contextOptions;
        private ProductDBContext dbContext;
        private IProductService productService;
        private IProdutoRepository productRepository;
        private NotificationContext notificationContext;

        private void InitializeServices()
        {
            if (productService == null)
            {

                notificationContext = new NotificationContext();
                contextOptions = new DbContextOptionsBuilder<ProductDBContext>()
                            .UseInMemoryDatabase(databaseName: "Products Test")
                            .Options;

                dbContext = new ProductDBContext(contextOptions);
                productRepository = new ProductRepository(dbContext);
                productService = new ProductService(productRepository, notificationContext);
            }
        }


        private Product InsertProductWithInvenctory(string sku)
        {
            InitializeServices();

            var wareHouses = new List<WareHouse>();
            wareHouses.Add(new WareHouse() { Locality = "SP", Quantitiy = 10 });
            wareHouses.Add(new WareHouse() { Locality = "Jundiai", Quantitiy = 3 });
            Invenctory invenctory = new InvenctoryBuilder().WithWareHouses(wareHouses).Build();

            var product = new ProductBuilder().WithSku(sku)
                                         .WithName("Base Eudora")
                                         .WithInvenctory(invenctory)
                                         .Build();

            var returned = productService.AddAsync(product);

            return returned;
        }

        private Product GetProduct(String sku)
        {
            InitializeServices();

            var product = productService.FindBy(sku);

            return product;
        }

        private bool DeleteProduct(String sku)
        {
            InitializeServices();

            bool ok = productService.Remove(sku);

            return ok;
        }

        private Product UpdateProduct(String sku)
        {
            InitializeServices();

            var wareHouses = new List<WareHouse>();
            wareHouses.Add(new WareHouse() { Locality = "Belo Horizonte", Quantitiy = 10 });
            wareHouses.Add(new WareHouse() { Locality = "Jundiai", Quantitiy = 3 });
            Invenctory invenctory = new InvenctoryBuilder().WithWareHouses(wareHouses).Build();

            var product = new ProductBuilder().WithSku(sku)
                                         .WithName("Base Eudora")
                                         .WithInvenctory(invenctory)
                                         .Build();
            int id = 1;
            return productService.Update(id,product);
        }

        [TestMethod]
        public void InsertProductOk()
        {
            Assert.IsNotNull(InsertProductWithInvenctory("123456"));

        }

        [TestMethod]
        public void InsertProductComMesmoSKU()
        {
            InsertProductWithInvenctory("12345");
            Assert.IsNull(InsertProductWithInvenctory("12345"));

        }

        [TestMethod]
        public void GetProductNaoEncontrado()
        {
            InsertProductWithInvenctory("123456");

            var product = GetProduct("12345");

            Assert.IsTrue(this.notificationContext.Notifications.Where(p => p.Message == "Produto nao encontrado").Count() > 0);

        }

        [TestMethod]
        public void ValidateQuantityTrezeInvenctory()
        {
            InsertProductWithInvenctory("123456");

            var product = GetProduct("123456");

            Assert.IsTrue(product.Invenctory.Quantity == 13);

        }

        [TestMethod]
        public void ValidateProductSkuNull()
        {
            var product = InsertProductWithInvenctory(null);

            Assert.IsNull(product);

        }

        [TestMethod]
        public void ValidateProductSkuEmpty()
        {
            var product = InsertProductWithInvenctory(string.Empty);

            Assert.IsNull(product);


        }

        [TestMethod]
        public void ValidateProductRemoved()
        {
            InsertProductWithInvenctory("123456");

            var ok = DeleteProduct("123456");

            Assert.IsTrue(ok);
        }

        

        [TestMethod]
        public void ValidateProductUpdated()
        {
            InsertProductWithInvenctory("123456");

            var product = UpdateProduct("1234599");

            Assert.IsTrue(product.Sku.Contains("1234599"));


        }


    }
}
