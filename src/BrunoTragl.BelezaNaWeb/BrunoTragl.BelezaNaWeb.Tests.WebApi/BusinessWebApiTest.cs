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
    public class BusinessWebApiTest : WebApiBase
    {
        protected override string ApiAddressProduct => "/api/product/";

        [TestMethod]
        public void IsMarketableProductTest()
        {
            var withQuantityProduct = ProductFactory.Create(StateProduct.WithQuantity);

            PostProductTest(withQuantityProduct);

            TokenModel tokenModel = GetToken();
            
            
            var getRequestBuilder = CreateRequestBuilder(Method.GET,
                                                      tokenModel.Token,
                                                      null,
                                                      withQuantityProduct.Sku.ToString());
            var getResponse = getRequestBuilder.GetAsync().Result;
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

            var objString = getResponse.Content.ReadAsStringAsync().Result;
            var productReturn = JsonConvert.DeserializeObject<ResponseProductModel>(objString);

            Assert.IsTrue(productReturn.Data.IsMarketable == true);
        }

        [TestMethod]
        public void IsNotMarketableProductTest()
        {
            var withoutQuantityProduct = ProductFactory.Create(StateProduct.WithoutQuantity);

            PostProductTest(withoutQuantityProduct);

            TokenModel tokenModel = GetToken();
            

            var getRequestBuilder = CreateRequestBuilder(Method.GET,
                                                      tokenModel.Token,
                                                      null,
                                                      withoutQuantityProduct.Sku.ToString());
            var getResponse = getRequestBuilder.GetAsync().Result;
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

            var objString = getResponse.Content.ReadAsStringAsync().Result;
            var productReturn = JsonConvert.DeserializeObject<ResponseProductModel>(objString);

            Assert.IsTrue(productReturn.Data.IsMarketable == false);
        }

        [TestMethod]
        public void HowManyProductsInWarehousesTest()
        {
            var withoutQuantityProduct = ProductFactory.Create(StateProduct.WithoutQuantity);
            uint quantityAllProductsOfWarehouses = 0;
            foreach (var item in withoutQuantityProduct.Inventory.Warehouses)
                quantityAllProductsOfWarehouses += item.Quantity;

            PostProductTest(withoutQuantityProduct);

            TokenModel tokenModel = GetToken();


            var getRequestBuilder = CreateRequestBuilder(Method.GET,
                                                      tokenModel.Token,
                                                      null,
                                                      withoutQuantityProduct.Sku.ToString());
            var getResponse = getRequestBuilder.GetAsync().Result;
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

            var objString = getResponse.Content.ReadAsStringAsync().Result;
            var productReturn = JsonConvert.DeserializeObject<ResponseProductModel>(objString);

            Assert.IsTrue(productReturn.Data.Inventory.Quantity == quantityAllProductsOfWarehouses);
        }

        [TestMethod]
        public void PostProductTest(ProductModel productModel)
        {
            TokenModel tokenModel = GetToken();

            var postRequestBuilder = CreateRequestBuilder(Method.POST,
                                                      tokenModel.Token,
                                                      CreateContent(productModel));

            var postResponse = postRequestBuilder.PostAsync().Result;
            postResponse.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.Created, postResponse.StatusCode);
        }
    }
}
