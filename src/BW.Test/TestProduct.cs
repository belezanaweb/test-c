using BW.API.Controllers;
using BW.AplicationCore.Services;
using BW.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc;
using BW.AplicationCore.Entities;
using Newtonsoft.Json;
using System.Net;

namespace BW.Test
{
    [TestClass]
    public class TestProduct
    {
        private readonly ProductController _controller;
        private readonly string _payLoadPostjson;

        public TestProduct()
        {
             _controller = new ProductController(new ProductService(new ProductRepository()));

            _payLoadPostjson = @"{
                        'sku': 43264,
                        'name': 'L\'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g',
                        'inventory': {

                                    'warehouses': [
                                        {
                                    'locality': 'SP',
                                            'quantity': 12,
                                            'type': 'ECOMMERCE'
                                },
                                {
                                    'locality': 'MOEMA',
                                    'quantity': 3,
                                    'type': 'PHYSICAL_STORE'
                                }
                            ]
                        }
                    }";
        }
        [TestMethod]
        public void TestGet()
        {
           var result =  _controller.Get(43263).Result;

            var value = (result as OkObjectResult).Value;
            var sku = (value as Product).Sku;

            Assert.AreEqual(sku, 43263);
        }

        [TestMethod]
        public void TestPost()
        {

            var products = JsonConvert.DeserializeObject<Product>(_payLoadPostjson);

            var result = _controller.Post(products).Result;

            var statusCode = (result as Microsoft.AspNetCore.Mvc.StatusCodeResult).StatusCode;

            Assert.AreEqual(statusCode, HttpStatusCode.NoContent.GetHashCode());
        }

        [TestMethod]
        public void TestPostDuplicated()
        {

            var products = JsonConvert.DeserializeObject<Product>(_payLoadPostjson);

            var resultPost1 = _controller.Post(products).Result;

            var resultPost2 = _controller.Post(products).Result;

            Assert.IsInstanceOfType(resultPost2, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void TestPut()
        {

            var json = @"{
                        'sku': 43263,
                        'name': 'Mudanca de Nome',
                        'inventory': {

                                    'warehouses': [
                                        {
                                    'locality': 'SP',
                                            'quantity': 12,
                                            'type': 'ECOMMERCE'
                                },
                                {
                                    'locality': 'MOEMA',
                                    'quantity': 3,
                                    'type': 'PHYSICAL_STORE'
                                }
                            ]
                        }
                    }";

            var products = JsonConvert.DeserializeObject<Product>(json);

            var result = _controller.Put(products).Result;

            var statusCode = (result as Microsoft.AspNetCore.Mvc.StatusCodeResult).StatusCode;

            Assert.AreEqual(statusCode, HttpStatusCode.NoContent.GetHashCode());
        }

        [TestMethod]
        public void TestDelete()
        {
            var result = _controller.Delete(43263).Result;

            var statusCode = (result as Microsoft.AspNetCore.Mvc.StatusCodeResult).StatusCode;

            Assert.AreEqual(statusCode, HttpStatusCode.NoContent.GetHashCode());
        }
    }
}
