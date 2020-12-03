using BrunoTragl.BelezaNaWeb.Tests.WebApi.Base;
using BrunoTragl.BelezaNaWeb.Tests.WebApi.Enumerable;
using BrunoTragl.BelezaNaWeb.Tests.WebApi.Models;
using BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState.Enumerable;
using BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState.Factory;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi
{
    [TestClass]
    public class SuccessWebApiTest : WebApiBase
    {
        protected override string ApiAddressProduct => "/api/product/";

        [TestMethod]
        public void GetProductTest()
        {
            PostProductTest();

            TokenModel tokenModel = GetToken();
            var withQuantityProduct = ProductFactory.Create(StateProduct.WithQuantity);
            
            var getRequestBuilder = CreateRequestBuilder(Method.GET,
                                                      tokenModel.Token,
                                                      null,
                                                      withQuantityProduct.Sku.ToString());
            var getResponse = getRequestBuilder.GetAsync().Result;
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
        }

        [TestMethod]
        public void PostProductTest()
        {
            TokenModel tokenModel = GetToken();

            var withQuantityProduct = ProductFactory.Create(StateProduct.WithQuantity);
            var postRequestBuilder = CreateRequestBuilder(Method.POST,
                                                      tokenModel.Token,
                                                      CreateContent(withQuantityProduct));

            var postResponse = postRequestBuilder.PostAsync().Result;
            postResponse.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.Created, postResponse.StatusCode);
        }

        [TestMethod]
        public void PutProductTest()
        {
            PostProductTest();

            TokenModel tokenModel = GetToken();
            uint quantityModified = 0;
            uint quantityPerWarehouses = 50;
            var withQuantityProduct = ProductFactory.Create(StateProduct.WithQuantity);
            foreach (var item in withQuantityProduct.Inventory.Warehouses)
            {
                item.Quantity = quantityPerWarehouses;
                quantityModified += quantityPerWarehouses;
            } 

            var putRequestBuilder = CreateRequestBuilder(Method.PUT,
                                                      tokenModel.Token,
                                                      CreateContent(withQuantityProduct),
                                                      withQuantityProduct.Sku.ToString());
            var putResponse = putRequestBuilder.SendAsync(Method.PUT.ToString()).Result;
            putResponse.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.NoContent, putResponse.StatusCode);


            var getRequestBuilder = CreateRequestBuilder(Method.GET,
                                                      tokenModel.Token,
                                                      null,
                                                      withQuantityProduct.Sku.ToString());
            var getResponse = getRequestBuilder.GetAsync().Result;
            getResponse.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

            string objString = getResponse.Content.ReadAsStringAsync().Result;
            var productModified = JsonConvert.DeserializeObject<ResponseProductModel>(objString);
            uint quantityReturn = 0;
            foreach (var item in productModified.Data.Inventory.Warehouses)
                quantityReturn += item.Quantity;

            Assert.IsTrue(quantityModified == quantityReturn);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            PostProductTest();

            TokenModel tokenModel = GetToken();
            var withQuantityProduct = ProductFactory.Create(StateProduct.WithQuantity);
            var putRequestBuilder = CreateRequestBuilder(Method.DELETE,
                                                      tokenModel.Token,
                                                      null,
                                                      withQuantityProduct.Sku.ToString());
            var putResponse = putRequestBuilder.SendAsync(Method.DELETE.ToString()).Result;
            putResponse.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.NoContent, putResponse.StatusCode);


            var getRequestBuilder = CreateRequestBuilder(Method.GET,
                                                      tokenModel.Token,
                                                      null,
                                                      withQuantityProduct.Sku.ToString());
            var getResponse = getRequestBuilder.GetAsync().Result;
            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
        }
    }
}
