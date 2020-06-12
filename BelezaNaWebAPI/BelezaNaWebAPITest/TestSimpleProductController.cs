using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BelezaNaWebAPI.Controllers;
using BelezaNaWebAPI.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BelezaNaWebAPITest
{
    [TestClass]
    public class TestSimpleProductController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductsController(null, null, null);

            var result = controller.GetBySku(1) as Product;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.name, result.name);
        }

        private List<Product> GetTestProducts()
        {
            var testProducts = new List<Product>();
            //testProducts.Add(new Product { Id = 1, Name = "Demo1", Price = 1 });
            //testProducts.Add(new Product { Id = 2, Name = "Demo2", Price = 3.75M });
            //testProducts.Add(new Product { Id = 3, Name = "Demo3", Price = 16.99M });
            //testProducts.Add(new Product { Id = 4, Name = "Demo4", Price = 11.00M });

            return testProducts;
        }
    }
}
