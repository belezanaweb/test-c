using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Produto.Domain.Models;
using Produto.Domain.Repositories;
using Produto.Infra.Contexts;
using Produto.Infra.Repository;

namespace TestingData
{
    [TestClass]
    public class RepositoryTests
    {
        private DbContextOptions<ProductDBContext> contextOptions;
        private ProductDBContext dbContext;
        private IProdutoRepository produtoRepository;

        private void InitializeDBContext()
        {
            if (dbContext == null)
            {
                contextOptions = new DbContextOptionsBuilder<ProductDBContext>()
                            .UseInMemoryDatabase(databaseName: "Products Test")
                            .Options;

                dbContext = new ProductDBContext(contextOptions);
            }
        }

        private void ClearDatabaseMemory()
        {
            dbContext.Database.EnsureDeleted();
        }

        private bool InsertProduct()
        {
            InitializeDBContext();
            var product = new ProductBuilder().WithSku("123456")
                                              .WithName("Base Eudora")
                                              .Build();
       
            produtoRepository = new ProductRepository(dbContext);
            try
            {
                produtoRepository.AddAsync(product);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
         

            return true;
        }

        private Product GetProduct()
        {
            InitializeDBContext();
            produtoRepository = new ProductRepository(dbContext);

            var sku = "123456";
            var product = produtoRepository.FindBy(sku);

            return product;
        }

        private bool DeleteProduct()
        {
            InitializeDBContext();
            produtoRepository = new ProductRepository(dbContext);

            var sku = "123456";
            var product = produtoRepository.FindBy(sku);
            bool ok = produtoRepository.Remove(product);

            return ok;
        }


        [TestMethod]
        public void InsertProductOk()
        {  

            Assert.IsTrue(InsertProduct());

        }

        [TestMethod]
        public void GetProductEncontrado123456()
        {
            InsertProduct();
            var product = GetProduct();
            Assert.IsTrue(product.Sku.Contains("123456"));

        }

        [TestMethod]
        public void GetProductNaoEncontrado123456()
        {
            ClearDatabaseMemory();     
            var product = GetProduct();
            Assert.IsNull(product);

        }


        [TestMethod]
        public void DeleteProduct123456()
        {
            var product = GetProduct();
            Assert.IsNull(product);

        }



        [TestMethod]
        public void DeleteProduto123456()
        {
            var product = GetProduct();
            Assert.IsNull(product);

        }

        [TestMethod]
        public void InsertProdutoComMesmoSku()
        {
 
            Assert.IsTrue(DeleteProduct());

        }
    }
}
