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
    public class BadWebApiTest : WebApiBase
    {
        protected override string ApiAddressProduct => "/api/product/";

        [TestMethod]
        public void PostProductTest()
        {
            TokenModel tokenModel = GetToken();

            var badProduct = ProductFactory.Create(StateProduct.Bad);
            var requestBuilder = CreateRequestBuilder(Method.POST,
                                                      tokenModel.Token,
                                                      CreateContent(badProduct));

            var response = requestBuilder.PostAsync().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PutProductTest()
        {
            TokenModel tokenModel = GetToken();

            var badProduct = ProductFactory.Create(StateProduct.Bad);
            var requestBuilder = CreateRequestBuilder(Method.PUT,
                                                      tokenModel.Token,
                                                      CreateContent(badProduct),
                                                      "0");

            var response = requestBuilder.SendAsync(Method.PUT.ToString()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
