using BrunoTragl.BelezaNaWeb.Tests.WebApi.Base;
using BrunoTragl.BelezaNaWeb.Tests.WebApi.Enumerable;
using BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState.Enumerable;
using BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState.Factory;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi
{
    [TestClass]
    public class NotFoundWebApiTest : WebApiBase
    {
        protected override string ApiAddressProduct => "/api/product/";

        [TestMethod]
        public void GetProductTest()
        {
            TokenModel tokenModel = GetToken();

            var requestBuilder = CreateRequestBuilder(Method.POST,
                                                      tokenModel.Token,
                                                      null,
                                                      "0");

            var response = requestBuilder.GetAsync().Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void PutProductTest()
        {
            TokenModel tokenModel = GetToken();

            var product = ProductFactory.Create(StateProduct.WithQuantity);
            var requestBuilder = CreateRequestBuilder(Method.PUT,
                                                      tokenModel.Token,
                                                      CreateContent(product),
                                                      product.Sku.ToString());

            var response = requestBuilder.SendAsync(Method.PUT.ToString()).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            TokenModel tokenModel = GetToken();

            var product = ProductFactory.Create(StateProduct.WithQuantity);
            var requestBuilder = CreateRequestBuilder(Method.DELETE,
                                                      tokenModel.Token,
                                                      CreateContent(product),
                                                      product.Sku.ToString());

            var response = requestBuilder.SendAsync(Method.DELETE.ToString()).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
